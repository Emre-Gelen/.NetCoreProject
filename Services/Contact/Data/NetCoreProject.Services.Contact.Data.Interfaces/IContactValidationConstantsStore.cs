namespace NetCoreProject.Services.Contact.Data.Interfaces
{
    public interface IContactValidationConstantsStore
    {
        public string SpecialCharacters { get; }
        public int MinAge { get; }
        public int MaxAge { get; }
    }
}
