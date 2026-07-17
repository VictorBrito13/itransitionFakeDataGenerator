using Bogus;
using ErrorsType;
using Bogus.DataSets;

namespace Services.GenerateFakeData
{
    class FakeData
    {
        public List<UserModel> Generate(int seed, string region, int limit, int errors, int page)
        {
            Errors.SetSeed(seed + page);

            Randomizer.Seed = new Random(seed + page);
            var userGenerator = new Faker<UserModel>(region);
            string charSet = new Lorem(region).Sentence(22).Replace(",", " ");

            userGenerator.CustomInstantiator(f => new UserModel());
            userGenerator.RuleFor(u => u.gender, (f, u) => f.PickRandom<Gender>().ToString())
            .RuleFor(u => u.ID, (f, u) => Guid.NewGuid().ToString())
            .RuleFor(u => u.name, (f, u) => Errors.Modifier(f.Name.FullName(), errors / 3, charSet))
            .RuleFor(u => u.address, (f, u) => Errors.Modifier(f.Address.FullAddress(), errors / 3, charSet))
            .RuleFor(u => u.phone, (f, u) => Errors.Modifier(f.Phone.PhoneNumber(), errors / 3, charSet));

            var users = userGenerator.Generate(limit);
            return users;
        }
    }
}