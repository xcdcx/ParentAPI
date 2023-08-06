using Engine.Algorithms;
using Engine.Entities;
using Shared.Entities;

namespace Engine
{
    internal static class Mapper
    {
        internal static Dictionary<int, DataMember> ToDataMembersDic(this IEnumerable<Entities.Person> personse)
        {
            Dictionary<int, DataMember> result = new Dictionary<int, DataMember>
            {
                { 0, new DataMember(-1, null) }
            };
            foreach (Entities.Person person in personse)
            {
                if (result.ContainsKey(person.Id))
                {
                    throw new ArgumentException("Duplicated Id");
                }
                else
                {
                    result.Add(person.Id, new DataMember(person.ParentId, person.Name));
                }
            }
            return result;
        }
        internal static DataMember[] ToDataMembers(this IEnumerable<Entities.Person> persons)
        {
            DataMember[] arr = new DataMember[persons.Count() + 1];
            arr[0] = new DataMember(-1, null); //root init
            foreach (Entities.Person person in persons)
            {
                if (arr[person.Id] != null)
                {
                    throw new ArgumentException("Duplicated Id");
                }
                else
                {
                    arr[person.Id] = new DataMember(person.ParentId, person.Name);
                }
            }
            return arr;
        }

        internal static IEnumerable<Services.Models.Person> ToModel(this Node node)
        {
            List<Services.Models.Person> result = new();
            if (node.value == null) //tree root node
            {
                foreach (Node person in node.childs)
                {
                    result.Add(new Services.Models.Person(person));
                }
            }
            return result;
        }

        internal static Service.Models.UserLogin ToModel(this UserLogin login)
        {
            return new Service.Models.UserLogin
            {
                Username = login.Username,
                Password = login.Password
            };
        }

        internal static User ToEntity(this Service.Models.User user)
        {
            return new User
            {
                UserName = user.UserName,
                Password = user.Password,
                EmailAddress = user.EmailAddress,
                GivenName = user.GivenName,
                Surname = user.Surname,
                Role = user.Role
            };
        }
    }
}
