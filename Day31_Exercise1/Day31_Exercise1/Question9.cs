using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_Exercise1
{
    
    class User { public int Id; public string Name; public string Country; }
    class Post { public int UserId; public int Likes; }


    internal class Question9
    {
        
        static void Main(String[] args)
        {
            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };
 
                var topUsers = users
                    .GroupJoin(posts,
                        user => user.Id,
                        post => post.UserId,
                        (user, userPosts) => new
                        {
                            user.Name,
                            TotalLikes = userPosts.Sum(p => p.Likes)
                        })
                    .OrderByDescending(x => x.TotalLikes);

                Console.WriteLine("Top Users by Total Likes:");
                foreach (var u in topUsers)
                {
                    Console.WriteLine($"{u.Name} - {u.TotalLikes}");
                }

          
                var groupedByCountry = users
                    .GroupBy(u => u.Country);

                Console.WriteLine("\nUsers Grouped by Country:");
                foreach (var group in groupedByCountry)
                {
                    Console.WriteLine(group.Key);
                    foreach (var user in group)
                    {
                        Console.WriteLine($"  {user.Name}");
                    }
                }

                
                var inactiveUsers = users
                    .GroupJoin(posts,
                        user => user.Id,
                        post => post.UserId,
                        (user, userPosts) => new
                        {
                            user.Name,
                            PostCount = userPosts.Count()
                        })
                    .Where(x => x.PostCount == 0);

                Console.WriteLine("\nInactive Users:");
                foreach (var u in inactiveUsers)
                {
                    Console.WriteLine(u.Name);
                }

               
                double avgLikes = posts.Any()
                    ? posts.Average(p => p.Likes)
                    : 0;

                Console.WriteLine($"\nAverage Likes Per Post: {avgLikes}");
            }
        }


    }

