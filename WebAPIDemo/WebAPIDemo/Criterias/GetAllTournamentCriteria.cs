using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.Data.Repository;

namespace WebAPIDemo.Criterias
{
    public class GetAllTournamentCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "AllTournament";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}