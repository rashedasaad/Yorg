using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Image { get; set; }
    
    public decimal Price { get; set; }
    
    public int Stock { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public Category Category { get; set; }
    
    
    
}