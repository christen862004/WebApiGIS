using System.ComponentModel.DataAnnotations;

namespace WebApiGIS.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="rediued")]
        public string Name { get; set; }

        public string? ManagerName { get; set; }

        public List<Employee>? Emps { get; set; }
    }
}
