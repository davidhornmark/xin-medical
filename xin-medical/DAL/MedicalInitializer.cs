using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using xin_medical.Models;

namespace xin_medical.DAL
{
    public class MedicalInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MedicalContext>
    {
        protected override void Seed(MedicalContext context)
        {
            var Patients = new List<Patient>
            {
            new Patient{Firstname="Gary",Lastname="Alexander",Birthdate=DateTime.Parse("2005-09-01"),Gender=Gender.Male},
            new Patient{Firstname="Meredith",Lastname="Alonso",Birthdate=DateTime.Parse("2002-09-01"),Gender=Gender.Female},
            new Patient{Firstname="Jake",Lastname="Anand",Birthdate=DateTime.Parse("2003-09-01"),Gender=Gender.Male},
            new Patient{Firstname="Hayley",Lastname="Barzdukas",Birthdate=DateTime.Parse("2002-09-01"),Gender=Gender.Female},
            new Patient{Firstname="Peggy",Lastname="Justice",Birthdate=DateTime.Parse("2001-09-01"),Gender=Gender.Female},
            new Patient{Firstname="Laura",Lastname="Norman",Birthdate=DateTime.Parse("2003-09-01"),Gender=Gender.Female},
            new Patient{Firstname="Chandler",Lastname="Olivetto",Birthdate=DateTime.Parse("2005-09-01"),Gender=Gender.Male}
            };

            Patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();
    
            var MedicalHistory = new List<MedicalHistoryEntry>
            {
            new MedicalHistoryEntry{MedicalHistoryEntryID=1, PatientID=1, Date=DateTime.Parse("1995-10-23"), Category="Allergy", Description="Needed antihestamine." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=2, PatientID=1, Date=DateTime.Parse("1996-01-12"), Category="Blood Disorder", Description="Acquired Hepatitis C" },
                new MedicalHistoryEntry{MedicalHistoryEntryID=3, PatientID=1, Date=DateTime.Parse("1997-02-28"), Category="Headache", Description="Cronic pain in head." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=4, PatientID=2, Date=DateTime.Parse("1945-06-23"), Category="Numbness", Description="Couldn't feel feet." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=5, PatientID=2, Date=DateTime.Parse("1951-07-11"), Category="Broken bone", Description="Wrist broke during accident." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=6, PatientID=2, Date=DateTime.Parse("1955-11-12"), Category="Cancer", Description="Cancer in the stomach was detected." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=7, PatientID=3, Date=DateTime.Parse("1977-03-22"), Category="Allergy", Description="Allergy against fur-animals was detected." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=8, PatientID=3, Date=DateTime.Parse("1988-04-01"), Category="Soreness", Description="Soreness in neckmuscles." },
                new MedicalHistoryEntry{MedicalHistoryEntryID=9, PatientID=3, Date=DateTime.Parse("1999-01-02"), Category="Blackout", Description="Spontainious blackout occured." },            };
            MedicalHistory.ForEach(s => context.MedicalHistoryEntries.Add(s));
            context.SaveChanges();
        }
    }
}