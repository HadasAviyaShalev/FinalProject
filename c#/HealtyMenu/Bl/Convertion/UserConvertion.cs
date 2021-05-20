using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bl.Convertion
{
    public class UserConvertion
    {

        //convert one UserDto to User
        public static User convert(UserDto user)
        {
            User NewUser = new User();
            NewUser.id = user.id;
            NewUser.userId = user.userId;
            NewUser.firstName = user.firstName;
            NewUser.lastName = user.lastName;
            NewUser.email = user.email;
            NewUser.userPassword = user.userPassword;
            NewUser.bornDate = user.bornDate;
            NewUser.phone = user.phone;
            NewUser.statusCode = user.statusCode;
            NewUser.myWeight = user.myWeight;
            NewUser.height = user.height;
            NewUser.vegetarian = user.vegetarian;
            NewUser.vegan = user.vegan;
            return NewUser;
    }

        //convert one User to UserDto
        public static UserDto convert(User user)
        {
            UserDto NewUser = new UserDto();
            NewUser.id = user.id;
            NewUser.userId = user.userId;
            NewUser.firstName = user.firstName;
            NewUser.lastName = user.lastName;
            NewUser.email = user.email;
            NewUser.userPassword = user.userPassword;
            NewUser.bornDate = user.bornDate;
            NewUser.phone = user.phone;
            NewUser.statusCode = user.statusCode;
            NewUser.myWeight = user.myWeight;
            NewUser.height = user.height;
            NewUser.vegetarian = user.vegetarian;
            NewUser.vegan = user.vegan;
            return NewUser;
        }

        //convert list of UserDto to User
        public static List<User> convert(List<UserDto> user)
        {
            List<User> NewUser = new List<User>();
            user.ForEach(x => {
                NewUser.Add(convert(x));
            });
            return NewUser;

        }

        //convert list of User to UserDto
        public static List<UserDto> convert(List<User> user)
        {
            List<UserDto> NewUser = new List<UserDto>();
            user.ForEach(x => {
                NewUser.Add(convert(x));
            });
            return NewUser;

        }
    }
}
