namespace NetCoreProject.Services.Contact.Model.Exchange.Contact.GetById;

public class GetContactByIdResponseModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName => Name + "-" + Surname;
    public int Age { get; set; }
}
