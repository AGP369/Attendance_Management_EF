namespace Attendance_Management_EF.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Designation { get; set; }
    }

    
}
