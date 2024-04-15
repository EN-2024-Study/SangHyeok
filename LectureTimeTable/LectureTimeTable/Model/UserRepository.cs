using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class UserRepository // singleton
    {
        private static UserRepository instance;
        private UserDto user;
        private UserRepository()
        {
            user = new UserDto("21013314", "1234");
        }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        public string GetUserId()
        { return user.Id; }

        public string GetUserPassword()
        { return user.Password; }
    }
}
