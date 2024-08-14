using Attendance_Management_EF.Data;
using Attendance_Management_EF.Models;
using Attendance_Management_EF.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Management_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(Data.ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpPost]

        public IActionResult AddEmployee(Models.AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Designation = addEmployeeDto.Designation
            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPost]
        [Route("{empId}")]
        public IActionResult AddAttendance(int empId)
        {
            var today = DateTime.Today;
            var empAttendance = dbContext.Attendance.Any(a => a.EmpId == empId && a.CheckIn.HasValue && a.CheckIn.Value.Date == today);


            if (empAttendance == true)
            {
                return BadRequest("Already checked in today");
            }
            else
            {
                try
                {
                    var attendanceEntity = new Attendance()
                    {
                        EmpId = empId,
                        CheckIn = DateTime.Now
                    };

                    dbContext.Attendance.Add(attendanceEntity);
                    dbContext.SaveChanges();

                    return Ok("CheckIn successful");


                }
                catch (Exception)
                {
                    return BadRequest("Invalid Employee id");
                }
            }
        }
        [HttpPut]
        [Route("{empid}")]
        public IActionResult CheckOut(int empid)
        {
            var today = DateTime.Today;
            var empAttendance = dbContext.Attendance.FirstOrDefault(a => a.EmpId == empid && a.CheckIn.HasValue && a.CheckIn.Value.Date == today);

            if (empAttendance == null)
            {
                return BadRequest("No CheckIn Available");
            }

            else if (empAttendance != null && empAttendance.CheckOut == null)
            {
                empAttendance.CheckOut = DateTime.Now;
                dbContext.SaveChanges();
                return Ok("Checked Out");
            }
            return BadRequest("Already checked out today.");
        }

        [HttpGet("Daily Report")]

        public IActionResult AttendanceReport()
        {
            var today = DateTime.Today;
            var todayAttendance = from attendance in dbContext.Attendance join employee in dbContext.Employees
         on attendance.EmpId equals employee.Id where attendance.CheckIn.Value.Date == today
          select new GetReportDto
             {
                 Id = attendance.Id,
                 EmpId = attendance.EmpId,
                 Name = employee.Name,
                 CheckIn = attendance.CheckIn,
                 CheckOut = attendance.CheckOut
           };
           
            return Ok(todayAttendance.ToList());

        }
        
    }

}
