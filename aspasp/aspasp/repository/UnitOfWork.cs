using Aeroport.Data;
using Aeroport.Models;
using aspasp.Repository;

namespace Aeroport.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AeroportDbContext _context;

        public UnitOfWork(AeroportDbContext context)
        {
            _context = context;
            Pilotes = new PiloteRepository(_context);
            Passagers = new PassagerRepository(_context);
            Avions = new AvionRepository(_context);
            Vols = new VolRepository(_context); 


        }

        public IPiloteRepository Pilotes { get; private set; }
        public IPassagerRepository Passagers { get; private set; }
        public IAvionRepository Avions { get; private set; }

        public IVolRepository Vols { get; private set; } 





        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}