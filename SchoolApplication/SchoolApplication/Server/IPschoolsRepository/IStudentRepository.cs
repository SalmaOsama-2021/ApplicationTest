using SchoolApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Server.IPschoolsRepository
{
    public interface IStudentRepository
    {
        Task<int> UpdateStudent(Student request);
        Task<int> AddStudent(Student request);
        Task<int> deleteStudent(int StudentId);
        Task<Student> getStudentById(int StudentId);
        Task<List<Student>> getStudentDatatable();
        Task<List<Student>> getStudentSearchDatatable(int parentId);
    }
}
