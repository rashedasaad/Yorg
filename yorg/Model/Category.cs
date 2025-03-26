using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public List<Product> Products { get; set; }
    
    
    
    
    
}