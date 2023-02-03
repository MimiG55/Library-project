using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum UserRights
    {
        Regular,
        Admin
    }
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserRights Rights { get; private set; }

        public User(string username, string password, UserRights rights)
        {
            Username = username;
            Password = password;
            Rights = rights;
        }
    }
    public class UserManager
    {
        public List<User> newUser = new List<User>();
        public void AddUser(string username, string password, UserRights rights)
        {
            User user = new User(username, password, rights);           
            newUser.Add(user);
        }
        public bool VerifyUser(string username, string password)
        {
            bool isUserExist = false;
            for (int i = 0; i < newUser.Count; i++)
            {
                if (newUser[i].Username == username && newUser[i].Password == password)
                {
                    isUserExist = true;
                    break;
                }
            }
            return isUserExist;
        }
        public User GetUser(string username)
        {
            User user = null;
            for (int i = 0; i < newUser.Count; i++)
            {
                if (newUser[i].Username == username)
                {
                    user = newUser[i];
                    break;
                }

            }

            return user;

        }

        public void RemoveUser(string userToRemove)
        {
            int index = 0;
            for (int i = 0; i < newUser.Count; i++)
            {
                if (newUser[i].Username.Equals(userToRemove))
                {
                    index = i;
                    break;
                }
            }
            newUser.RemoveAt(index);
        }
    }
}
