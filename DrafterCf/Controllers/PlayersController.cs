﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrafterCf.Models;

namespace DrafterCf.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Players/
        public async Task<ActionResult> Index()
        {
            var players = db.Players.Include(p => p.Family).Include(p => p.League);
            return View(await players.ToListAsync());
        }

        // GET: /Players/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: /Players/Create
        public ActionResult Create()
        {
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name");
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name");
            return View();
        }

        // POST: /Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,PlayerId,LastName,FirstName,Age,DraftScore,LeagueId,FamilyId")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name", player.FamilyId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", player.LeagueId);
            return View(player);
        }

        // GET: /Players/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name", player.FamilyId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", player.LeagueId);
            return View(player);
        }

        // POST: /Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,PlayerId,LastName,FirstName,Age,DraftScore,LeagueId,FamilyId")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name", player.FamilyId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", player.LeagueId);
            return View(player);
        }

        // GET: /Players/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: /Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Player player = await db.Players.FindAsync(id);
            db.Players.Remove(player);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
