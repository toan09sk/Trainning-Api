using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fanex.Data.Repository;

namespace WebAPIDemo.Criterias
{
    public class InsertTournamentCriteria : CriteriaBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public string Federation { get; set; }
        public string Director { get; set; }
        public string ChiefArbiter { get; set; }
        public string Location { get; set; }
        public string RatingCalculation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rating { get; set; }
        public int Category { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsFinished { get; set; }
        public int NumberOfRounds { get; set; }

        public override string GetSettingKey()
        {
            return "InsertTournament";
        }

        public override bool IsValid()
        {
            return Id > 0;
        }
    }
}