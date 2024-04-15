using LectureTimeTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Controller
{
    public class UserInfoController
    {
        private UserRepository user;

        public UserInfoController()
        {
            this.user = UserRepository.Instance;
        }

        public bool IsLogIn(string id, string password)
        {
            return user.GetUserId().Equals(id) && user.GetUserPassword().Equals(password);
        }

    }
}
