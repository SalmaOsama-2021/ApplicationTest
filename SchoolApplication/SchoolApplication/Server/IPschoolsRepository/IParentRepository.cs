using SchoolApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Server.IPschoolsRepository
{
    public interface IParentRepository
    {
        Task<int> UpdateParent(Parent request);
        Task<int> AddParent(Parent request);
        Task<int> deleteParent(int ParentId);
        Task<Parent> geParentById(int ParentId);
        Task<List<Parent>> getParentDatatable();
    }
}
