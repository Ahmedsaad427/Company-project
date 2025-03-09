using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.G02.PL.Dtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Deletion status is required")]
        public bool IsDelete { get; set; }

        [DisplayName("Hiring Date")]
        public DateTime HiringTime { get; set; }

        [DisplayName("Date of Creation")]
        public DateTime CreateAt { get; set; }
    }
}
