using System;

namespace AwsElastiCache
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new JsonUser
            {
                Id = 1,
                Name = "user 1",
                Dob = DateTime.Now,
            };

            var cache = CacheManager.Instance;

            cache.Add(user.Id.ToString(), user);
            var cachedUser = cache.Get<JsonUser>(user.Id.ToString());

            Console.WriteLine($"{cachedUser.Id} - {cachedUser.Name} - {cachedUser.Dob}");
        }
    }
}
