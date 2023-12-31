﻿using Lab1_SinhVien.Data;
using Lab1_SinhVien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab1_SinhVien.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;
        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            //
            return View(learners);
        }

        //thêm 2 action create
        public IActionResult Create()
        {
            //dùng 1 trong 2 cách để tạo SelectList gửi về View qua ViewBag để
            //hiển thị danh sách chuyên ngành (Majors)
            var majors = new List<SelectListItem>(); //cách 1
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                });

            }
            ViewBag.MajorID = majors;
            //ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName"); //cách 2
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")]
Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //lại dùng 1 trong 2 cách tạo SelectList gửi về View để hiển thị danh sách Majors
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            Learner learner = db.Learners.Find(ID);
            if (learner != null)
            {
                ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName"); //cách 2               
                return View(learner);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Update(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //lại dùng 1 trong 2 cách tạo SelectList gửi về View để hiển thị danh sách Majors
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }



        public IActionResult Delete(int? ID)
        {
            Learner learner = db.Learners.Find(ID);
            if(learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }      
    }
}
