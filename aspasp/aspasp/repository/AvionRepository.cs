using Aeroport.Data;
using Aeroport.Repository;
using aspasp.Models;

namespace aspasp.Repository
{
    public class AvionRepository : Repository<Models.Avion>, IAvionRepository
    {
        public AvionRepository(AeroportDbContext context) : base(context)
        {
        }
    }
}
