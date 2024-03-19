using Application.Common;
using Application.DTOs.StudentDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService studentService)

        : ControllerBase
    {
        private readonly IStudentService _studentService = studentService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _studentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _studentService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddStudentDto dto)
        {
            try
            {
                await _studentService.CreateAsync(dto);
                return Ok();
            }
            catch (StudentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(StudentDto dto)
        {
            try
            {
                await _studentService.UpdateAsync(dto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (StudentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
