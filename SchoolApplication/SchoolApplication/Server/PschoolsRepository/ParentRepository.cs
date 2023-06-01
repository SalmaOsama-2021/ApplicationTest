using SchoolApplication.Server.Data;
using SchoolApplication.Server.IPschoolsRepository;
using SchoolApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolApplication.Server.PschoolsRepository
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext context;
        //private readonly IParentRepository _parentRepository;
        public ParentRepository(ApplicationDbContext db)
        {
            this.context = db;
            //_parentRepository = parentRepository;   
        }

        public async Task<int> AddParent(Parent request)
        {
            try
            {
                var allPArent = new Parent
                {
                    isEnabled = true,
                    isDeleted = false,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Phone1 = request.Phone1,
                    HomePhone = request.HomePhone,
                    WorkPhone = request.WorkPhone,
                    Sibilings = request.Sibilings,
                    Adress = request.Adress
                };
                await context.Parent.AddAsync(allPArent);
                 context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> deleteParent(int ParentId)
        {
            try
            {
                var Parents = await context.Parent.FindAsync(ParentId);
                Parents.isDeleted = true;
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<Parent> geParentById(int ParentId)
        {
            var parents = await context.Parent.Where(x => x.Id == ParentId
            && !x.isDeleted.Value).FirstOrDefaultAsync();

            return parents;
        }

        public async Task<List<Parent>> getParentDatatable()
        {
            var parents = await context.Parent
               .Where(x => x.isDeleted != true).OrderByDescending(x => x.Id)
               .ToListAsync();

            return parents;
        }

        public  async Task<int> UpdateParent(Parent request)
        {
           
            try
            {
              var  AllParent = new Parent();
                AllParent = context.Parent.FirstOrDefault(x => x.Id == request.Id);
                AllParent.FirstName = request.FirstName;
                AllParent.LastName = request.LastName;
                AllParent.UserName = request.UserName;
                AllParent.Sibilings = request.Sibilings;
                AllParent.HomePhone = request.HomePhone;
                AllParent.Phone1 = request.Phone1;
                AllParent.WorkPhone = request.WorkPhone;
                AllParent.Adress = request.Adress;
                AllParent.isDeleted = request.isDeleted;
                AllParent.isEnabled = request.isEnabled;
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
