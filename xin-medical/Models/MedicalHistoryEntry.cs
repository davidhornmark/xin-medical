using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xin_medical.Models
{
    public class MedicalHistoryEntry
    {
        public int MedicalHistoryEntryID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}