using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacaySystem.Models
{
    public class VacayApplication
    {
        public int VacayApplicationId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        
        [Required]
        public LeaveType Type { get; set; }

        [ForeignKey("Employee")]
        public int FkEmployeeId { get; set; }
        public Employee? Employee { get; set; }

    }
    public enum LeaveType
    {
        Holiday,
        SickLeave,
        PaternityLeave,
        MaternityLeave,
        UnpaidLeave,
        CompHours
    }
}
