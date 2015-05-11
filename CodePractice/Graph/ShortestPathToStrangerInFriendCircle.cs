using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Graph
{
    class ShortestPathToStrangerInFriendCircle
    {
        class User
        {
            public string UserName { get; set; }
        }

        public static void Implementation()
        {
            string user1 = "Jabez", user2 = "Arun";
            //Jabez to Arun
            //      Jabez - Sathish - Lenin - Naveen - Arun
            //      Jabez - Joshua - Arun

            FindShortestPath(user1, user2);
        }

        //Graph representation
        private static Dictionary<string, string> graphPath = new Dictionary<string, string>();

        static void FindShortestPath(string user1, string user2)
        {
            var queue = new Queue<string>();

            queue.Enqueue(user1);

            while (queue.Count > 0)
            {
                var currentUser = queue.Dequeue();
                var friends = GetFBFriends(currentUser);

                foreach (var friend in friends)
                {
                    if (!graphPath.ContainsKey(friend.UserName))
                    {
                        graphPath.Add(friend.UserName, currentUser);
                    }

                    if (friend.UserName == user2)
                    {
                        queue.Clear();
                        break;
                    }



                    queue.Enqueue(friend.UserName);
                }
            }

            List<string> path = new List<string>();
            if (graphPath.ContainsKey(user2))
            {
                //Indicates there was indeed a connection between user1 and user2

                var currenUser = user2;
                while (currenUser != user1)
                {
                    path.Add(currenUser);
                    currenUser = graphPath[currenUser];
                }
                path.Add(currenUser);
            }

            path.Reverse();

            foreach (var node in path)
            {
                Console.WriteLine(node);
            }
        }


        static List<User> GetFBFriends(string userName)
        {
            List<User> result = null;

            // Also have added a loop to imitate real life API:  Jabez - Sathish - Jabez 

            switch (userName)
            {
                case "Jabez":
                    {
                        result = new List<User>()
                        {
                            new User(){UserName = "Sathish"},
                            new User(){UserName = "Joshua"}
                        };
                        break;
                    }
                case "Sathish":
                    {
                        result = new List<User>()
                        {
                            new User(){UserName = "Bharath"},
                            new User(){UserName = "Lenin"},
                            new User(){UserName = "Jabez"}
                        };
                        break;
                    }
                case "Lenin":
                    {
                        result = new List<User>()
                        {
                            new User(){UserName = "Clement"},
                            new User(){UserName = "Naveen"}
                        };
                        break;
                    }
                case "Naveen":
                    {
                        result = new List<User>()
                        {
                            new User(){UserName = "Joshua"},
                            new User(){UserName = "Arun"}
                        };
                        break;
                    }
                case "Joshua":
                    {
                        result = new List<User>()
                        {
                            new User(){UserName = "Sathish"},
                            new User(){UserName = "Arun"},
                        };
                        break;
                    }
                case "Bharath":
                    {
                        result = new List<User>()
                        {
                            new User(){UserName = "Joshua"}
                        };
                        break;
                    }

            }
            return result;
        }

    }
}
