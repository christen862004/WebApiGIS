using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebApiGIS.DTO
{
    public class DeptEmpCountDTO
    {
        public int Id { get; set; }
        public string   DeptName { get; set; }
        public int EmpCount { get; set; }
        //public List<string> EmpNAme { get; set; }
    }
}
