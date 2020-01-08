using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xin_medical.DAL;
using xin_medical.Models;

namespace xin_medical.Controllers
{
    public class ManagePatientsController : Controller
    {
        private readonly DBHandler dbHandler = new DBHandler();
        // GET: ManagePatients
        public ActionResult Index()
        {
            List<Patient> temp = dbHandler.GetPatients();
            return View(temp);
        }

        // GET: ManagePatients/Records/5
        public ActionResult Records(int id)
        { 
            Patient temp = dbHandler.GetPatient(id);
            /*
            List<MedicalHistoryEntry> ltemp = dbHandler.GetRecords(id);
            temp.MedicalHistoryEntries = ltemp;
             */
            return View(temp);
        }

        // GET: ManagePatients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagePatients/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                dbHandler.AddNewPatient(collection);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return View();
            }
        }

        // GET: ManagePatients/EditInfo/5
        public ActionResult EditInfo(int id)
        {
            Patient temp = dbHandler.GetPatient(id);
            return View(temp);
        }

        // POST: ManagePatients/EditInfo/5
        [HttpPost]
        public ActionResult EditInfo(int id, FormCollection collection)
        {
            if (dbHandler.EditPatient(id, collection))
            {
                return RedirectToAction("Index");
            }
            Patient temp = dbHandler.GetPatient(id);
            return View(temp);
        }

        // GET: ManagePatients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagePatients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
