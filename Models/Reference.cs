using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReferenceReferralApp.Models
{
    public class Reference
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Please enter reference first name.")]
        public string firstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter reference last name.")]
        public string lastName { get; set; }

        public string email { get; set; }

    }
}
