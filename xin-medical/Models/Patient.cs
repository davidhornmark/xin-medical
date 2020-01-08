using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xin_medical.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Patient
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }

        [Display(Name = "WeChat")]
        public string WeChat { get; set; }

        [Display(Name = "Medical History")]
        public ICollection<MedicalHistoryEntry> MedicalHistoryEntries { get; set; }
    }
}