using Dapper;
using DoctorConsult.Core.Entity.Model.AuthenticationModels;
using DoctorConsult.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Infrustracture.Service
{
    public class UserService : IUserService
    {
        public List<string> GetRolesByUsername(string uname)
        {
            List<string> list = new List<string>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                var sql = "EXEC GetRolesFromUsername @username";
                var values = new { username = uname };
                var results = conn.Query(sql, values).ToList();
                results.ForEach(r => list.Add($"{r.RoleName}"));
                return list;
            }

        }

        public User GetUser(string username)
        {
            var getUserQuery = "select * from users where username = '" + username + "'";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                return conn.Query<User>(getUserQuery).FirstOrDefault();
            }
        }

        public string GetUserNameByEmail(string email)
        {
            var getUserQuery = "select * from users where email = '" + email + "'";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                return conn.Query<User>(getUserQuery).FirstOrDefault().Username;
            }
        }

        public bool IsAuthenticUser(string username, string password)
        {
            User user = null;
            var getUserQuery = "select * from users where username = '" + username + "' and password = '" + password + "'and IsActive = 1";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                user = conn.QueryAsync<User>(getUserQuery).Result.FirstOrDefault();
            }
            return (user != null) ? true : false;
        }
    }
}
