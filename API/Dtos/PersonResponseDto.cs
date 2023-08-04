using Engine.Entities;

namespace API.Dtos
{
    public class PersonResponseDto
    {
        public PersonResponseDto() { }
        public PersonResponseDto(PersonNode node)
        {
            this.Id = node.Id;
            this.Name = node.Name;
            this.Childs = node.Childs.Select(n => new PersonResponseDto(n)).ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonResponseDto> Childs { get; set; }
    }
}
