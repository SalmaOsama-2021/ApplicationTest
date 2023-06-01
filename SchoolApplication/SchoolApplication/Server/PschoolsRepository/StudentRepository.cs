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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        //private readonly IStudentRepository _studentRepository;  

        public StudentRepository(ApplicationDbContext db)
        {
            this.context = db;
            //_studentRepository = studentRepository; 
        }

        public async Task<int> AddStudent(Student request)
        {
            try
            {
                var allStudent = new Student
                {
                    isEnabled = true,
                    isDeleted = false,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                     parentId =request.parentId,    
                };
                await context.student.AddAsync(allStudent);
                context.SaveChanges();

                return request.Id;

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> deleteStudent(int StudentId)
        {
            try
            {
                var Students = await context.student.FindAsync(StudentId);
                Students.isDeleted = true;
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<Student> getStudentById(int StudentId)
        {
            var Students = await context.student.Where(x => x.Id == StudentId
           && !x.isDeleted.Value).FirstOrDefaultAsync();

            return Students;
        }

        public async Task<List<Student>> getStudentDatatable()
        {
            var students = await context.student.Include(m=>m.Parent)
                .Where(x => x.isDeleted != true).OrderByDescending(x => x.Id)
                .ToListAsync();

            return students;
        }
        
        public async Task<List<Student>> getStudentSearchDatatable(int parentId)
        {
            var students = await context.student.Include(m => m.Parent)
                .Where(x => x.isDeleted != true && x.parentId==parentId).OrderByDescending(x => x.Id)
                .ToListAsync();

            return students;
        }
        public async Task<int> UpdateStudent(Student request)
        {
            try
            {
                var AllStudent = new Student();
                AllStudent = context.student.FirstOrDefault(x => x.Id == request.Id);

                AllStudent.FirstName = request.FirstName;
                AllStudent.LastName = request.LastName;
                AllStudent.UserName = request.UserName;
                AllStudent.parentId = request.parentId;
         
                
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
