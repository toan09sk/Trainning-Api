using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.Data.Repository;

namespace WebAPIDemo.Criterias
{
    public class DeleteTournamentByIdCriteria : NonQueryCommand
    {
        public int Id { get; set; }
        public override string GetSettingKey()
        {
            return "DeleteTournamentById";
        }

        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}