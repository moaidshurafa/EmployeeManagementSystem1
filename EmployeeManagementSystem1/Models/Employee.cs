using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string? FullName { get; set; }
        public string? Position { get; set; }
        public string? Office { get; set; }
        [Range(18, 64, ErrorMessage = "Age must be between 18 and 64")]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }
    }
}
