using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorConsult.Core.Entity.Model;

namespace DoctorConsult.Web.ViewModel
{
    public class InvoiceViewModel
    {
        public DoctorProfileModel Doctor { get; set; }
        public PrescriptionModel Prescribtion { get; set; }
    }
}