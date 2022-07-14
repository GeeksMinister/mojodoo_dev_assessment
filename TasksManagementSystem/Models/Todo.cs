using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TasksManagementSystem.Models;

public class Todo
{
    public int Id { get; set; }

    [Required]
    [DisplayName("Name")]
    [StringLength(100, ErrorMessage = "Name is too big. 100 charactera max!")]
    public string TaskName { get; set; } = string.Empty;
    [StringLength(1250, ErrorMessage = "1250 charactera max!")]
    public string? Description { get; set; }
    [Range(1, 5)]
    [DisplayName("Set Priority")]
    public int? Priority { get; set; } = null;
    public string Status { get; set; } = "Not Started";
    public string? Tag { get; set; }

    public Todo()
    {

    }

}

