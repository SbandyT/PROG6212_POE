﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ST10298613_PROG6212_POE.Models
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HourlyRate { get; set; }
        public ICollection<Claim> Claims { get; set; }
        
    }
}
