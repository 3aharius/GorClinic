using GorClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace GorClinic.auth
{
    public class Auth
    {

        public static void login(string userName, string password, HttpSessionState session)
        {
            /*UserDbService userDbService = new UserDbService();
            User user = userDbService.findUserByUserName(userName);
            if (user == null || user.Password != password)
            {
                throw new Exception();
            }
            session["user"] = user;*/
        }

        public static bool checkPermissions()
        {
            return false;
        }

    }
}