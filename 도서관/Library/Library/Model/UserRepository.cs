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
            this.userDtoList = new List<UserDto> 
            { new UserDto("12345678", "1234", "25", "010-3077-5666", "광진구")};
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

        public void AddUser(UserDto user)
        {
            userDtoList.Add(user);
        }

        public Dictionary<int, BookDto> GetRentalBookDict()
        {
            return userDtoList[userIndex].GetRentalBookDIct();
        }

        public void AddRentalBook(int key, BookDto book)
        {
            userDtoList[userIndex].AddRentalBook(new Tuple<int, BookDto>(key, book));
        }
    }
}
