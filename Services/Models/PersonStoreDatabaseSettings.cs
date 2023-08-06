namespace Services.Models
{
    public class PersonStoreDatabaseSettings : IPersonStoreDatabaseSettings
    {
        public string PersonCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
