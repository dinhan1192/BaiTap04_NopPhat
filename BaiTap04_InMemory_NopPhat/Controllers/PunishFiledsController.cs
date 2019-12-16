using BaiTap04_InMemory_NopPhat.Models;
using BaiTap04_InMemory_NopPhat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap04_InMemory_NopPhat.Controllers
{
    public class PunishFiledsController : Controller
    {
        IPunishFiledService punishFiledService;
        //private static string _rollNumber;
        public PunishFiledsController()
        {
            punishFiledService = new InMemoryPunishFiledService();
        }
        // GET: PunishFileds
        public ActionResult Index()
        {
            //ViewData["ListStudent"] = studentService.GetList();
            var listPunishFiled = punishFiledService.GetList();
            var totalMoney = punishFiledService.GetTotalMoneyPunished();
            var totalPush = punishFiledService.GetTotalPushPunished();
            ViewBag.totalMoney = totalMoney;
            ViewBag.totalPush = totalPush;
            return View(listPunishFiled);
        }

        //[HttpPost]
        //public ActionResult GetList()
        //{
        //    return RedirectToAction("Create");
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PunishFiled punishFiledInput)
        {
            punishFiledService.Store(punishFiledInput);
            return RedirectToAction("Index");
        }
    }
}