using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolApplication.Server.Data;
using SchoolApplication.Server.IPschoolsRepository;
using SchoolApplication.Server.PschoolsRepository;
using SchoolApplication.Server.ResponseBuilders;
using SchoolApplication.Shared;
using System.Net;

namespace SchoolApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ApplicationDbContext context;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository=studentRepository;   
        }
        [HttpGet("getAllStudent")]
        public async Task<ActionResult<List<Parent>>> getAllStudent()
        {
          
            try
            {

                var resultdata = await _studentRepository.getStudentDatatable();
            

                return Ok(resultdata);
            }
            catch (Exception ex)
            {
               
                return null;


            }

        }
        [HttpGet("getAllStudentSearch/{parentId}")]
        public async Task<ActionResult<List<Parent>>> getAllStudentSearch(int parentId)
        {

            try
            {

                var resultdata = await _studentRepository.getStudentSearchDatatable(parentId);


                return Ok(resultdata);
            }
            catch (Exception ex)
            {

                return null;


            }

        }
        [HttpPost]
        [Route("AddStudents")]
       
        public async Task<ActionResult<Student>> AddStudents(Student request)
        {

            try
            {

                if (request.Id != 0)
                {

                    var isUpdated = _studentRepository.UpdateStudent(request);
                    if (isUpdated != null)
                    {
                        return Ok(isUpdated);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var isAdded = _studentRepository.AddStudent(request);
                    if (isAdded.Id > 0)
                    {
                        return Ok(isAdded);
                    }
                    else
                    {
                        return NotFound();
                    }
                }


            }
            catch (Exception ex)
            {

                return null;


            }

        }
        [HttpGet("{id}")]

        public async Task<Student> getByStudentId(int id)
        {

            try
            {

                var studentData = await _studentRepository.getStudentById(id);



                return studentData;
            }
            catch (Exception ex)
            {

                return null;


            }

        }
   
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> deleteStudent(int id)
        {

            try
            {


                var isDeleted = await _studentRepository.deleteStudent(id);

                if (isDeleted > 0)
                {
                    return Ok("Success");

                }
                else
                {
                    return NotFound("Faild");
                }

            }
            catch (Exception ex)
            {

                return null;


            }

        }
    }
}
