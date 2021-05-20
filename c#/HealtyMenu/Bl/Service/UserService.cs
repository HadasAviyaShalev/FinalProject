using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Service
{
    
    public class UserService
    {
        //get user by id from database
        public UserDto GetUser(string password, string str)
        {
            using(HealthyMenuEntities db= new HealthyMenuEntities())
            {
                try { 
                User user = db.Users.FirstOrDefault(x => x.userPassword == password && (x.email==str||x.phone==str|| x.userId==str));
                if (user == null)
                    return null;
                return Convertion.UserConvertion.convert(user);
                }
                catch
                {
                    return null;
                }
            }
        }

        //get all users from database
        public List<UserDto> GetUsers()
        {
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try {
                return Convertion.UserConvertion.convert(db.Users.ToList());
                }
                catch
                {
                    return null;
                }
            }
        }

        //sign up- add new user to database
        public UserDto PostUser(UserDto NewUser)
        {
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                try
                {
                    User user = db.Users.Add(Convertion.UserConvertion.convert(NewUser));
                    db.SaveChanges();
                    return Convertion.UserConvertion.convert(user);
                }
                catch (Exception e)
                {
                    return null;
                }

            } 
        }

        //remove user from database
        public UserDto RemoveUser(UserDto NewUser)
        {
            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {
                    try { 
                User user = db.Users.Remove(Convertion.UserConvertion.convert(NewUser));
                db.SaveChanges();
                return Convertion.UserConvertion.convert(user);
                }
                catch
                {
                    return null;
                }
            }
        }

        //update user in database
        public UserDto PutUser(UserDto userDto)
        {

            using (HealthyMenuEntities db = new HealthyMenuEntities())
            {

                try
                {
                    User user = db.Users.FirstOrDefault(x => x.userId == userDto.userId);
                    if (user == null)
                        return null;
                    user.firstName = userDto.firstName;
                    user.lastName = userDto.lastName;
                    user.email = userDto.email;
                    user.userPassword = userDto.userPassword;
                    user.bornDate = userDto.bornDate;
                    user.phone = userDto.phone;

                    user.vegan = userDto.vegan;
                    user.vegetarian = userDto.vegetarian;
                    db.Users.SqlQuery("UPDATE User set firstName = " + user.firstName +
                        " lastName = " + user.lastName +
                        " email = " + user.email +
                        " userPassword = " + user.userPassword +
                        " bornDate = " + user.bornDate +
                        " phone = " + user.phone +
                        " vegan = " + user.vegan +
                        " vegetarian = " + user.vegetarian +
                        " WHERE userId = " + user.userId);
                    db.SaveChanges();
                    return Convertion.UserConvertion.convert(user);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
