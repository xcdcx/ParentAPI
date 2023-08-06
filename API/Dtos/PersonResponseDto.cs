using Engine.Entities;
using Shared.Entities;

namespace API.Dtos
{
    public class PersonResponseDto
    {
        public PersonResponseDto() { }
        public PersonResponseDto(Node node)
        {
            this.Id = node.id;
            this.Name = node.value;
            this.Childs = node.childs.Select(n => new PersonResponseDto(n)).ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonResponseDto> Childs { get; set; }
    }
}
