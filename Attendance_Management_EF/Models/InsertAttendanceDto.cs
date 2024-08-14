namespace Attendance_Management_EF.Models
{
    public class InsertAttendanceDto
    {
        public int EmpId { get; set; }
        public DateTime? CheckIn { get; set; }
    }
}
