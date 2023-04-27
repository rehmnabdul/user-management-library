using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserManagementLibrary.Models;

[Table(name: "um_countries")]
[Index(nameof(Title), IsUnique = true)]
public class Country: ParentTable
{
    public string Title { get; set; }
}