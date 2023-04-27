using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserManagementLibrary.Models;

[Table(name: "um_genders")]
[Index(nameof(Title), IsUnique = true)]
public class Gender: ParentTable
{
    public string Title { get; set; }
}