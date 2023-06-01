using SchoolApplication.Shared;

namespace SchoolApplication.Client.Services.serviceAllParent
{
    public interface IServiceStudent
    {
        List<Student> students { get; set; }
        Task Getstudents();
        Task GetStudentsSearch(int parentId);
        Task createAndUpdatestudents(Student student);
        Task deletestudent(int id);
        Task<Student> GetSingleStudent(int id);
    }
}
