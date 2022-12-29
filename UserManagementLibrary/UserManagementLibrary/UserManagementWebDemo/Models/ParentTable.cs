using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementWebDemo.Models;

public class ParentTable
{
    [Key]
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateTime { get; set; }
    
    public bool IsDisabled { get; set; }
    public DateTime? DisabledDateTime { get; set; }
    
    
    public DateTime DateUpdated { get; set; }
    public DateTime DateCreated { get; set; }
}