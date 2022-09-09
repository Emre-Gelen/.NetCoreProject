namespace NetCoreProject.Services.Contact.Model.Exchange.Contact.Add;

public class AddContactResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName => Name + "-" + Surname;
    public int Age { get; set; }
}
