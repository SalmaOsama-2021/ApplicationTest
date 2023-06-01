using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SchoolApplication.Server.Data;
using SchoolApplication.Server.IPschoolsRepository;
using SchoolApplication.Server.ResponseBuilders;
using SchoolApplication.Shared;
using System.Net;

namespace SchoolApplication.Server.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;
        private readonly ApplicationDbContext context;
        public ParentController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }
        [HttpGet("getAllParent")]
        public async Task<ActionResult<List<Parent>>> getAllParent()
        {
            ResponseBuilder Response = ResponseBuilder.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {

                var resultdata = await _parentRepository.getParentDatatable();
                Response = ResponseBuilder.Create(HttpStatusCode.OK, resultdata, "Success");

                return Ok(resultdata);
            }
            catch (Exception ex)
            {
                Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                return NotFound();


            }

        }

        [HttpPost("AddParents")]
        public async Task<ActionResult<Parent>> AddParents(Parent request)
        {
           
            try
            {

                if (request.Id != 0)
                {

                    var isUpdated = _parentRepository.UpdateParent(request);
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
                    var isAdded = _parentRepository.AddParent(request);
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
        public async Task<Parent> getByParentId(int id)
        {
           
            try
            {
            
                var ParentData = await _parentRepository.geParentById(id);


               
                return ParentData;
            }
            catch (Exception ex)
            {
               
                return null;


            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Parent>>> deleteParent(int id)
        {
           
            try
            {
              

                var isDeleted = await _parentRepository.deleteParent(id);

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
   
