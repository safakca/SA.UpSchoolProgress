namespace PersonalBlog.Persistence.Entities;
public class Contact : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Mail { get; set; }
    public string? Message { get; set; }

}
