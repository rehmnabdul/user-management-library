using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserManagementLibrary.Models;


[Table(name: "um_users")]
[Index(nameof(Uid), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(CitizenNo), IsUnique = true)]
[Index(nameof(PassportNo), IsUnique = true)]
public class User : ParentTable
{
    public string Uid { get; set; }

    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    public string? ContactNo { get; set; }

    public string? CitizenNo { get; set; }
    public string? PassportNo { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    public Gender? Gender { get; set; }

    public string? FullName { get; set; }
    public string? FatherName { get; set; }

    public string? Picture { get; set; }

    public bool PassChangeRequired { get; set; }
    public bool EmailConfirmed { get; set; }
}