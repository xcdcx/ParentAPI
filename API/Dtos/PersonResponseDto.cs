namespace API.Dtos
{
    public class PersonResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonResponseDto> Childs { get; set; }
    }
}
