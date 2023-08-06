namespace Services.Models
{
    public interface IPersonStoreDatabaseSettings
    {
        public string PersonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
