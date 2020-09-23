using DoctorConsult.Core.Entity.Model.AuthenticationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Core.Service.Interfaces
{
    public interface IUserService
    {
        void Insert(User entity);
    }
}
