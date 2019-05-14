using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Fanex.Data.Repository;
using WebAPIDemo.Criterias;
using WebAPIDemo.DTO;
using WebAPIDemo.Interfaces;

namespace WebAPIDemo.Services
{
    public class TournamentService: ITournamentService
    {
        public void DeleteTournament(int id)
        {
            var repository = new DynamicRepository();
            var command = new DeleteTournamentByIdCriteria()
            {
                Id = id
            };

           repository.Execute(command);
        }

        public IEnumerable<Tournament> GetTournament()
        {
            var repository = new DynamicRepository();
            var criteria = new GetAllTournamentCriteria();
            var tournament = repository.Fetch<Tournament>(criteria);
            return tournament;
        }

        public Tournament FindTournamentById(int id)
        {
            var repository = new DynamicRepository();
            var criteria = new QueryTournamentByIdCriteria
            {
                Id = id
            };

            var tournament = repository.Get<Tournament>(criteria);
            return tournament;
        }

        public IEnumerable<Tournament> InsertTournament(Tournament tournament)
        {
            var repository = new DynamicRepository();
            var criteria = new InsertTournamentCriteria()
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Organizer = tournament.Organizer,
                Federation = tournament.Federation,
                Director = tournament.Director,
                ChiefArbiter = tournament.ChiefArbiter,
                Location = tournament.Location,
                RatingCalculation = tournament.RatingCalculation,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Rating = tournament.Rating,
                Category = tournament.Category,
                LastUpdate = tournament.LastUpdate,
                IsFinished = tournament.IsFinished,
                NumberOfRounds = tournament.NumberOfRounds
            };

            var touranments = repository.Fetch<Tournament>(criteria);
            return touranments;
        }

        public void UpdateTournament(int id,[FromBody] Tournament tournament)
        {
            var repository = new DynamicRepository();
            var command = new InsertTournamentCriteria()
            {
                Id = id,
                Name = tournament.Name,
                Organizer = tournament.Organizer,
                Federation = tournament.Federation,
                Director = tournament.Director,
                ChiefArbiter = tournament.ChiefArbiter,
                Location = tournament.Location,
                RatingCalculation = tournament.RatingCalculation,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Rating = tournament.Rating,
                Category = tournament.Category,
                LastUpdate = tournament.LastUpdate,
                IsFinished = tournament.IsFinished,
                NumberOfRounds = tournament.NumberOfRounds
            };

            repository.Execute(command);

        }
    }
}