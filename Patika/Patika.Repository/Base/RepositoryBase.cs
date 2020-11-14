using Patika.DataContext;
using Patika.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patika.Repository.Base
{
    public class RepositoryBase : IRepositoryBase, IDisposable
    {
        private WebContext _webdbContext;
        public RepositoryBase(WebContext webdbContext)
        {
            _webdbContext = webdbContext;
        }
        public WebContext WebDbContext => _webdbContext;
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
