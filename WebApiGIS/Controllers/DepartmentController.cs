﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGIS.DTO;
using WebApiGIS.Models;

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]//api/Department
    [ApiController]//att controller (Validation during binding - Binding)
    //Binding action parameter (primitive bind route value | Querystring)
    //                         (Complex object Bind REquest body)
    public class DepartmentController : ControllerBase
    {
        ITIContext context;
        public DepartmentController()
        {
            context=new ITIContext();
        }
        
        //api/Department Get
        [HttpGet]
        public IActionResult GetAll()
        {
            List<DeptEmpCountDTO> depts = context.Department
                .Include(d=>d.Emps)
                .Select(d=>new DeptEmpCountDTO() {
                    Id= d.Id,
                    DeptName = d.Name,
                    EmpCount=d.Emps.Count()
                }).ToList();
            return Ok(depts);
        }
        
        //api/Department/1 Get
        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> Details(int id)
        {
            Department? dept=context.Department.FirstOrDefault(d=>d.Id==id);
            if (dept != null)
                return new GeneralResponse() {IsPass=true,Data=dept };
               // return Ok(dept);
            return new GeneralResponse() { IsPass = false, Data = "Invalid Id" };
        }

        [HttpGet("{name:alpha}")]//api/department/sd get
        public IActionResult FindByName(string name) {
            Department? dept = context.Department.FirstOrDefault(d => d.Name.Contains(name));
            return Ok(dept);
        }

        //api/Department Post
        [HttpPost]
        public IActionResult AddDepartemnt(Department depFromRequest)
        {
            if(ModelState.IsValid)
            {
                context.Department.Add(depFromRequest);
                context.SaveChanges();
                // return Created($"http://localhost:9086/api/department/{depFromRequest.Id}",depFromRequest);
                return CreatedAtAction("Details", new { id = depFromRequest.Id }, depFromRequest);
            }
            return BadRequest(ModelState);
        }

        //api/Department/1 Put(object)
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Department deptReqBody)
        {
            if (ModelState.IsValid)
            {
                Department dept= context.Department.FirstOrDefault(d => d.Id == id);
                dept.Name = deptReqBody.Name;
                dept.ManagerName = deptReqBody.ManagerName;
                context.SaveChanges();
                // return Ok("Edit Success");
                return NoContent();
            }
            return BadRequest(ModelState);
        }
      
        
        //api/Department/1 Delete
        //[HttpDelete("{id:int}")]
        //public IActionResult Remove(int id)
        //{
        //    try
        //    {
        //        Department dept = context.Department.FirstOrDefault(d => d.Id == id);
        //        context.Department.Remove(dept);
        //        context.SaveChanges();
        //        // return Ok("Delete Success");
        //        return NoContent();
        //    }catch (Exception ex)
        //    {
        //        return BadRequest(ex.InnerException.Message);
        //    }

        //}
    }
}
