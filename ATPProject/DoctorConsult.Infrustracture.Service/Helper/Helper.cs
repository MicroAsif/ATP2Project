using Dapper;
using DoctorConsult.Core.Entity.Model.AuthenticationModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsult.Infrustracture.Service.Helper
{
    public class Helper
    {
        public int GetRoleIdByRoleName(string rolename)
        {
            List<string> list = new List<string>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                try
                {
                    string sqlQuery = @"select RoleId from Roles where RoleName = '"+rolename+"'";
                    int roleId = conn.Query<int>(sqlQuery).Single();
                    conn.Close();
                    return roleId;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
        public int CreateUser(User user)
        {
            List<string> list = new List<string>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                try
                {
                    string sqlQuery = @"INSERT INTO [dbo].[Users]([Username],[Email],[Password],[ActivationCode],[IsActive])
                    OUTPUT INSERTED.UserId
                    VALUES (@Username,@Email,@Password,@ActivationCode,@IsActive)";
                    int id = conn.QuerySingle<int>(sqlQuery,
                        new
                        {
                            user.Username,
                            user.Email,
                            user.Password,
                            user.ActivationCode,
                            user.IsActive
                        });

                    conn.Close();
                    return id;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
        public bool CreateRole(int userid,int roleid)
        {
            List<string> list = new List<string>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                try
                {
                    string sqlQuery = "INSERT INTO [dbo].[UserRoles]([User_UserId],[Role_RoleId]) VALUES (@User_UserId,@Role_RoleId)";
                    conn.Execute(sqlQuery,
                        new
                        {
                            User_UserId = userid,
                            Role_RoleId = roleid
                        });

                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
        public List<string> GetRolesByUsername(string uname)
        {
            List<string> list = new List<string>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                var sql = "EXEC SPGetRolesFromUsername @username";
                var values = new { username = uname };
                var results = conn.Query(sql, values).ToList();
                results.ForEach(r => list.Add($"{r.RoleName}"));
                return list;
            }

        }

        public User GetUser(string username)
        {
            var getUserQuery = @"select u.*,r.* from Users u
                                    inner join UserRoles ur on ur.User_UserId = u.UserId
                                    inner join Roles r on ur.Role_RoleId = r.RoleId
                                    where Username = '" + username + "'; ";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                return conn.Query<User, Role, User>(getUserQuery, (user, role) =>
                {
                    user.Roles = user.Roles ?? new List<Role>();
                    user.Roles.Add(role);
                    return user;
                },
                //new { Status = status },
                splitOn: "RoleId")
                .GroupBy(o => o.UserId)
                .Select(group =>
                {
                    var combinedOwner = group.First();
                    combinedOwner.Roles = group.Select(owner => owner.Roles.Single()).ToList();
                    return combinedOwner;
                }).First();
            }
        }

        public string GetUserNameByEmail(string email)
        {
            var getUserQuery = "select * from users where email = '" + email + "'";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                User user = conn.Query<User>(getUserQuery).FirstOrDefault();
                if (user != null)
                    return user.Username;
                else
                    return null;
            }
        }

        public bool IsAuthenticUser(string username, string password)
        {
            User user = null;
            var getUserQuery = "select * from users where username = '" + username + "' and password = '" + password + "' and IsActive = 1";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorConsultContext"].ConnectionString.ToString()))
            {
                user = conn.Query<User>(getUserQuery).FirstOrDefault();
            }
            return (user != null) ? true : false;
        }
    }
}
