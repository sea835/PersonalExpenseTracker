using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalExpenseTracker.Models;

[Table("ExpenseCategory")]
public class Category
{
    [Key]
    [Column("ID")]
    public required int id { get; set; }
    
    [Column("Name")]
    public required string name { get; set; }
}