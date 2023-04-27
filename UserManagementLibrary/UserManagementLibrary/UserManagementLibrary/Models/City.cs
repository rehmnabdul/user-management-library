using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementLibrary.Models;

[Table(name: "um_cities")]
public class City: ParentTable
{
    public string Title { get; set; }
    public Country Country { get; set; }
}