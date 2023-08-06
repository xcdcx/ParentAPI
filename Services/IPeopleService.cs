using Services.Models;

namespace Services
{
    public interface IPeopleService
    {
        int Create(IEnumerable<Person> persons);
    }
}
