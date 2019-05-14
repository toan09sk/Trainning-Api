using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.BasicAuthentication
{
    public class TournamentSecurity
    {
        public static bool Login(string username,string password)
        {
            return username == "ross" && password == "Batoan01326754";
        }
    }
}