namespace Day34_Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FriendsNetwork network = new();

            User billu = new() { Id = 1, Name = "Billu" };
            User chintu = new() { Id = 1, Name = "Chintu" };
            User dillu = new() { Id = 1, Name = "Dillu" };

            network.AddFriends(billu, chintu);
            network.AddFriends(billu, dillu);

            network.ShowNetwork();
        }
    }

    class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    class FriendsNetwork
    {
        public Dictionary<User, HashSet<User>> Network { get; private set; }
        public FriendsNetwork() { Network = []; }

        public void AddFriends(User x, User y)
        {
            if (Network.TryGetValue(x, out HashSet<User>? xValue))
                xValue.Add(y);

            if (Network.TryGetValue(y, out HashSet<User>? yValue))
                yValue.Add(x);

            if (xValue == null)
                Network.Add(x, [y]);

            if (yValue == null)
                Network.Add(y, [x]);
        }

        public void ShowNetwork()
        {
            foreach (var user in Network)
            {
                Console.WriteLine($"{user.Key.Name} -> {string.Join(", ", user.Value.Select(x => x.Name))}");
            }
        }
    }
}