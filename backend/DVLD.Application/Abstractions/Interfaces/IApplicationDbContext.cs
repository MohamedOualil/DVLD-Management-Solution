using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; }
        DbSet<Country> Countries { get; }
    }
}
