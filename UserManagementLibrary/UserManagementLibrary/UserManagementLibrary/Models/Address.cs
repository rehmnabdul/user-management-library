using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementLibrary.Models;

[Table(name: "um_addresses")]
public class Address: ParentTable
{
    [Key]
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    public string? CompleteAddress { get; set; }
    public string? Street { get; set; }
    public string? HouseNo { get; set; }
    public string? NearBy { get; set; }

    public City? City { get; set; }
}