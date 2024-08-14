namespace Attendance_Management_EF.Models
{
    public class GetReportDto
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
