using Company.G02.DAL.Models;

public class Employee : BaseEntity
{
    public int Id { get; set; } // Add this!
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime HiringTime { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }
}
