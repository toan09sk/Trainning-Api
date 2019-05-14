using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.DTO;

namespace WebAPIDemo.Interfaces
{
    public interface ITournamentService
    {
        IEnumerable<Tournament> GetTournament();
        IEnumerable<Tournament> InsertTournament(Tournament tournament);
        Tournament FindTournamentById(int id);

        void DeleteTournament(int id);

        void UpdateTournament(int id, Tournament tournament);
    }
}
