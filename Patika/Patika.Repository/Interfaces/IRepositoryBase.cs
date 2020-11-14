using Patika.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patika.Repository.Interfaces
{
    public interface IRepositoryBase
    {
        WebContext WebDbContext { get; }
    }
}
