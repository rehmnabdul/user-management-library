using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UserManagementLibrary.Models;

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


    public void MarkDeleteStatus(bool delete)
    {
        if (delete)
        {
            IsDeleted = true;
            DeletedDateTime = DateTime.Now;
        }
        else
        {
            delete = false;
            DeletedDateTime = null;
        }
    }
    
    public void MarkEnableStatus(bool enable)
    {
        if (!enable)
        {
            IsDisabled = true;
            DeletedDateTime = DateTime.Now;
        }
        else
        {
            IsDisabled = false;
            DeletedDateTime = null;
        }
    }
    
    
    /// <summary>
    /// Save the changes in the DBContext and Tracking For Later to Save In DB
    /// </summary>
    /// <param name="context">Database Context</param>
    public async Task<EntityEntry<ParentTable>> Save(DbContext context)
    {
        EntityEntry<ParentTable> entityEntry;
        if (Id == 0)
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            entityEntry = await context.AddAsync(this);
        }
        else
        {
            DateUpdated = DateTime.Now;
            entityEntry = context.Update(this);
        }

        return entityEntry;
    }

    /// <summary>
    /// Save the changes instantly into database
    /// </summary>
    /// <param name="context">Database Context</param>
    public async Task<EntityEntry<ParentTable>> SaveNow(DbContext context)
    {
        EntityEntry<ParentTable> entityEntry;
        if (Id == 0)
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            entityEntry = await context.AddAsync(this);
        }
        else
        {
            DateUpdated = DateTime.Now;
            entityEntry = context.Update(this);
        }

        await context.SaveChangesAsync();
        return entityEntry;
    }
}