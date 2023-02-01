using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEFExample.Data;
using WebApiEFExample.Models;

namespace WebApiEFExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IApplicationContext _applicationContext;
        public StudentController(IApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student )
        {
           if(!ModelState.IsValid) return BadRequest(ModelState);

           _applicationContext.Students.Add(student);

            await _applicationContext.SaveChnages();

            return Ok(student.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

          var students = await _applicationContext.Students.ToListAsync();
            if(students==null) return NotFound();
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if(Id <= 0) return BadRequest(ModelState);

            var student  = await _applicationContext.Students.Where(x=> x.Id== Id).FirstOrDefaultAsync();   
            if(student==null) return NotFound();
            return Ok(student);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            //if(Id<=0) return BadRequest(ModelState);
            var student = await _applicationContext.Students.
                Where(s => s.Id == Id).FirstOrDefaultAsync();
            
            if (student==null) return NotFound();

            _applicationContext.Students.Remove(student);
            await _applicationContext.SaveChnages();

            return Ok(student.Id);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, Student studentUpdate)
        {
            if(Id<=0) return BadRequest(ModelState);

            var student = await _applicationContext.Students.
                Where(D=>D.Id==Id).FirstOrDefaultAsync();

            if(student==null) return BadRequest(ModelState);
            else
            {
                student.Name = studentUpdate.Name;
                student.Roll = studentUpdate.Roll;
                student.Class = studentUpdate.Class;
                student.Section = student.Section;
                student.Age = studentUpdate.Age;

                await _applicationContext.SaveChnages();
                return Ok(student.Id);
            }


        }


    }
}
