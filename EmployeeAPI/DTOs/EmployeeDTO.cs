using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTOs
{
    public class EmployeeDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;
    }
}
