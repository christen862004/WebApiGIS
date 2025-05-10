using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGIS.DTO;
using WebApiGIS.Models;

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ITIContext context = new ITIContext();
        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            Employee? emp= context.Employees
                .Include(e=>e.Department).FirstOrDefault(e=>e.Id== id);
            //declare DTO
            EmpDeptDTO empDTO = new EmpDeptDTO();
            //Mapping
            empDTO.EmpID = emp.Id;
            empDTO.EmpName = emp.Name;
            empDTO.DeptName = emp.Department.Name;//without include in query the line will thorw null ref exxception
            //return
            
            return Ok(empDTO);
        }
    }
}
