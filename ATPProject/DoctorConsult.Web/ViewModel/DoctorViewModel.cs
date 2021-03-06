﻿using System;

namespace DoctorConsult.Core.Entity.ViewModel
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Bithdate { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Specialist { get; set; }
        public string Location { get; set; }
        public string ContactNumber { get; set; }
        public string Image { get; set; }
    }
}
