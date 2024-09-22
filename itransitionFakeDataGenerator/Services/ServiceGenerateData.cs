using Bogus;
using ErrorsType;
using Bogus.DataSets;
using System.Collections;

namespace Services.GenerateFakeData
{
    public class UserComparer : IEqualityComparer<UserModel>
    {
        public bool Equals(UserModel? x, UserModel? y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.name == y.name && x.phone == y.phone;
        }

        public int GetHashCode(UserModel user)
        {
            if (Object.ReferenceEquals(user, null)) return 0;

            int hashUserName = user.name == null ? 0 : user.name.GetHashCode();

            int hashUserPhone = user.phone.GetHashCode();

            return hashUserName ^ hashUserPhone;
        }
    }
    class FakeData {
        private List<UserModel> _users = [];
        public List<UserModel> Generate(int seed, string region, int limit, int errors, int page) {
            //Generate the data
            Randomizer.Seed = new Random(seed);
            var userGenerator = new Faker<UserModel>(region);
            string charSet = new Lorem(region).Sentence(22);

            Console.WriteLine(page);

            userGenerator.CustomInstantiator(f => new UserModel());
            userGenerator.RuleFor(u => u.gender, (f, u) => f.PickRandom<Gender>().ToString())
            .RuleFor(u => u.ID, (f, u) => Guid.NewGuid().ToString())
            .RuleFor(u => u.name, (f,u) => Errors.Modifier(f.Name.FullName(), errors / 3, charSet))
            .RuleFor(u => u.address, (f,u) => Errors.Modifier(f.Address.FullAddress(), errors / 3, charSet))
            .RuleFor(u => u.phone, (f, u) => Errors.Modifier(f.Phone.PhoneNumber(), errors / 3, charSet));

            
            var users = userGenerator.GenerateLazy(limit * page);
            var HashSet = new HashSet<UserModel>(users).ToList();

            _users = HashSet;
            return _users;
        }
    }
}