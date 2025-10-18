using Aeroport.Data;
using Aeroport.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Aeroport.Repository
{
    public class VolRepository : Repository<Vol>, IVolRepository
    {
        public VolRepository(AeroportDbContext context) : base(context)
        {
        }

        public IEnumerable<Vol> ObtenirVolsAvecDetails()
        {
            return DbSet
                .Include(v => v.Avion)
                .Include(v => v.Pilote)
                .ToList();
        }
    }
}
