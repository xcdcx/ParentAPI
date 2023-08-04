using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PersonDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int? Parent { get; set; }
    }
}
