using Microsoft.AspNetCore.Components;
using SchoolApplication.Client.Services.serviceAllParent;
using SchoolApplication.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace SchoolApplication.Client.Services.serviceAllstudent
{
    public class ServiceStudent : IServiceStudent
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ServiceStudent(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Student> students { get; set; } = new List<Student>();

        public async Task createAndUpdatestudents(Student student)
        {
            var result = await _http.PostAsJsonAsync("api/student/Addstudents", student);

            await setstudent(result);

        }
        private async Task setstudent(HttpResponseMessage result)
        {
            _navigationManager.NavigateTo("studenview");
            var response = await result.Content.ReadFromJsonAsync<List<Student>>();
            students = response;

        }
        public async Task deletestudent(int id)
        {
            var result = await _http.DeleteAsync($"api/student/{id}");
            await setstudent(result);

        }

        public async Task Getstudents()
        {
            var result = await _http.GetFromJsonAsync<List<Student>>("api/student/getAllStudent");
            if (result != null)
                students = result;

        }
        public async Task GetStudentsSearch(int parentId)
        {
            var result = await _http.GetFromJsonAsync<List<Student>>($"api/student/getAllStudentSearch/{parentId}");
         
                students = result;
            //var isbool = false;
            //if (parentId != 0)
            //{
            //     isbool = true;
            //}
            
            _navigationManager.NavigateTo($"studenview/{parentId}");


        }
        public async Task<Student> GetSingleStudent(int id)
        {
            var result = await _http.GetFromJsonAsync<Student>($"api/student/{id}");
            if (result != null)
                return result;
            throw new Exception("not found");
        }
    }

}
