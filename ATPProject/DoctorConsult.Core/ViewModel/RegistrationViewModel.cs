using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.ViewModel
{
    public class RegistrationViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDay { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Area { get; set; }
        public string District { get; set; }
        public string Division { get; set; }
    }
}
