using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalExpenseTracker.Models;

[Table("Expense")]
public class Expense
{
    [Key]
    [Column("ID")]
    public required int id { get; set; }
    
    [Column("Amount")]
    public required float amount { get; set; }
    
    [Column("Date")]
    public required DateTime date { get; set; }
    
    [Column("Description")]
    public required string description { get; set; }
    
    [Column("CategoryId")]
    public required int categoryId { get; set; }
    
    public Category Category { get; set; }
    
    public override string ToString()
    {
        return $"Id: {id}, Amount: {amount}, Date: {date}, Description: {description}, CategoryId: {categoryId}, Category: {Category?.name}";
    }

}