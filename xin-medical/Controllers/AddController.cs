using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xin_medical.DAL;
using xin_medical.Models;

namespace xin_medical.Controllers
{
    public class AddController : Controller
    {
        private readonly DBHandler dbHandler = new DBHandler();
        // GET: Add
        public ActionResult Index()
        {
            return View();
        }

        // GET: Add/MedicalHistoryEntry/5
        public ActionResult MedicalHistoryEntry(int id)
        {
            Patient temp = dbHandler.GetPatient(id);
            return View(temp);
        }

        // POST: Add/MedicalHistoryEntry/5
        [HttpPost]
        public ActionResult MedicalHistoryEntry(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
