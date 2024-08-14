using Attendance_Management_EF.Models.Entities;

namespace Attendance_Management_EF.Models
{
    public class AddAttendanceDto
    {
        public int EmpId { get; set; }
        public DateTime? CheckIn { get; set; }
    }
}
