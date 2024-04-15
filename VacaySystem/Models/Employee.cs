using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacaySystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee has to have a firstname")]
        [StringLength(maximumLength:60, ErrorMessage = "The name can maxium contain 60 characters ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Employee has to have a lastname")]
        [StringLength(maximumLength: 60, ErrorMessage = "The name can maxium contain 60 characters ")]
        public string LastName { get; set; }
        public ICollection<VacayApplication>? VacayApplications { get; set; }


    }
}
