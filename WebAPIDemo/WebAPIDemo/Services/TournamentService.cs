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
        private readonly IDynamicRepository dynamicRepository;
        public TournamentService(IDynamicRepository dynamicRepo)
        {
            dynamicRepository = dynamicRepo;
        }
        public void DeleteTournament(int id)
        {
            var command = new DeleteTournamentByIdCriteria()
            {
                Id = id
            };

            dynamicRepository.Execute(command);
        }

        public IEnumerable<Tournament> GetTournament()
        {
            var criteria = new GetAllTournamentCriteria();
            var tournament = dynamicRepository.Fetch<Tournament>(criteria);
            return tournament;
        }

        public Tournament FindTournamentById(int id)
        {
            var criteria = new QueryTournamentByIdCriteria
            {
                Id = id
            };

            var tournament = dynamicRepository.Get<Tournament>(criteria);
            return tournament;
        }

        public IEnumerable<Tournament> InsertTournament(Tournament tournament)
        {
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

            var touranments = dynamicRepository.Fetch<Tournament>(criteria);
            return touranments;
        }

        public void UpdateTournament(int id,[FromBody] Tournament tournament)
        {
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

            dynamicRepository.Execute(command);

        }
    }
}