using Aeroport.Models;
using System.Collections.Generic;

namespace Aeroport.Repository
{
    public interface IVolRepository : IRepository<Vol>
    {
        IEnumerable<Vol> ObtenirVolsAvecDetails();
    }
}
