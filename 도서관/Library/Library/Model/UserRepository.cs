using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class UserRepository     // singleton
    {
        private static UserRepository instance;
        private List<UserDto> userDtoList;
        private int userIndex;

        private UserRepository()
        {
            this.userDtoList = new List<UserDto> { new UserDto("1234567", "1234")};
            this.userIndex = -1;
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

        public List<UserDto> GetUserList()
        {
            return userDtoList;
        }

        public int UserIndex
        {
            get { return userIndex; }
            set { userIndex = value; }
        }

        public void SetUserPassword(int index, string password)
        {
            userDtoList[index].Password = password; 
        }
    }
}
