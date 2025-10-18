using aspasp.Repository;
using System;

namespace Aeroport.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPiloteRepository Pilotes { get; }
        IPassagerRepository Passagers { get; }
        IAvionRepository Avions { get; }
        IVolRepository Vols { get; }



        int Complete();
    }
}