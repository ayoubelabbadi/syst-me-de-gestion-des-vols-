using Aeroport.Models;
using System;
using System.Collections.Generic;

namespace Aeroport.Repository
{
    public interface IPiloteRepository : IRepository<Pilote>
    {
    }

    public interface IPassagerRepository : IRepository<Passager>
    {
    }

    public class PiloteRepository : Repository<Pilote>, IPiloteRepository
    {
        public PiloteRepository(Data.AeroportDbContext context) : base(context)
        {
        }
    }

    public class PassagerRepository : Repository<Passager>, IPassagerRepository
    {
        public PassagerRepository(Data.AeroportDbContext context) : base(context)
        {
        }
    }
}