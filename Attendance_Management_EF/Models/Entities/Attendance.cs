using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Attendance_Management_EF.Models.Entities
{
    public class Attendance
    {
            public int Id { get; set; }
            
            public int EmpId { get; set; }
            public DateTime? CheckIn { get; set; }
            public DateTime? CheckOut { get; set; }
        
    }
}
