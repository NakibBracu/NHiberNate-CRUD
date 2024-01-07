using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHiberNate_CRUD.Application;
using NHiberNate_CRUD.Domain.Entities;
using NHiberNate_CRUD.Domain.UnitOfWork;

namespace NHiberNate_CRUD.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(IApplicationDbContext dbContext) : base((DbContext)dbContext)
        {
        }
    }
}
