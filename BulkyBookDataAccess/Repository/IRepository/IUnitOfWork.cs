using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get;    }
        ICompanyRepository Company { get; }


        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        IApplicationUserRepository ApplicationUser { get; }


        ISP_Call SP_Call { get; }
        void Save();
    }
}
