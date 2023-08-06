using Services.Models;

namespace Services
{
    public interface IPeopleService
    {
        void Create(IEnumerable<Person> persons);
    }
}
