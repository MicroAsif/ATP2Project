﻿using DoctorConsult.Core.Entity.Model;
using DoctorConsult.Core.Service.Interfaces.Base;

namespace DoctorConsult.Core.Service.Interfaces
{
    public interface IPatientProfileService : IBaseService<PatientProfileModel>
    {
        PatientProfileModel FindByAuth(string email, string password);
    }
}
