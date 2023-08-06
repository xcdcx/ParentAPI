using Services.Models;

namespace Service.Services
{
    public interface IPeopleService
    {
        void Create(IEnumerable<Person> persons);
    }
}
