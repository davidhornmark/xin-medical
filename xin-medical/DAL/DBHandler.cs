using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using xin_medical.Models;

namespace xin_medical.DAL
{
    public class DBHandler
    {
        #region Functionality for Patients

        public List<Patient> GetPatients()
        {
            using (var db = new MedicalContext())
            {
               return db.Patients.ToList();
            }
        }

        public Patient GetPatient(int id)
        {
            using (var db = new MedicalContext())
            {
                Patient temp = db.Patients.Find(id);
                List<MedicalHistoryEntry> ltemp = db.MedicalHistoryEntries.Where(p => p.PatientID == id).ToList();
                temp.MedicalHistoryEntries = ltemp;
                return temp;
            }
        }

        public List<MedicalHistoryEntry> GetRecords(int PatientID)
        {
            using (var db = new MedicalContext())
            {
                List<MedicalHistoryEntry> temp = db.MedicalHistoryEntries.Where(p => p.PatientID == PatientID).ToList();
                return temp;
            }
        }

        public bool AddNewPatient(FormCollection collection)
        {
            if (collection.Get("Firstname") == null || 
                collection.Get("Lastname") == null || 
                DateTime.Parse(collection.Get("Birthdate")) == null)
            {
                return false;
            }
            using (var db = new MedicalContext())
            {
                Patient temp = new Models.Patient
                {
                    Firstname = collection.Get("Firstname"),
                    Lastname = collection.Get("Lastname"),
                    Birthdate = DateTime.Parse(collection.Get("Birthdate")),
                    Phonenumber = collection.Get("Phonenumber"),
                    Address = collection.Get("Address"),
                    WeChat = collection.Get("WeChat"),
                };
               
                if (collection.Get("Gender") == "1")
                {
                    temp.Gender = Gender.Female;
                }
                else
                {
                    temp.Gender = Gender.Male;
                }
                db.Patients.Add(temp);
                db.SaveChanges();
                return true;
            }
        }
       
        public bool EditPatient(int id, FormCollection collection)
        {
            using (var db = new MedicalContext())
            {
                try
                {
                    Patient patient = db.Patients.Find(id);
                    patient.Firstname   =   collection.Get("Firstname");
                    patient.Lastname    =   collection.Get("Lastname");
                    patient.Birthdate   =   DateTime.Parse(collection.Get("Birthdate"));
                    if (collection.Get("Gender") == "1")
                    {
                        patient.Gender = Gender.Female;
                    }
                    else
                    {
                        patient.Gender = Gender.Male;
                    }
                    patient.Phonenumber =   collection.Get("Phonenumber");
                    patient.Address     =   collection.Get("Address");
                    patient.WeChat      =   collection.Get("WeChat");
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion
    }
}