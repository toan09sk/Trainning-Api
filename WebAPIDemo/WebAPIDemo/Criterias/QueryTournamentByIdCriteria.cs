using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.Data.Repository;

namespace WebAPIDemo.Criterias
{
    public class QueryTournamentByIdCriteria : CriteriaBase
    {
        public int Id { get; set; }
        public override string GetSettingKey()
        {
            return "QueryTournamentById";
        }

        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}