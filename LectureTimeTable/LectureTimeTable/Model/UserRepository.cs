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
        private List<LectureVo> favoriteSubjectList;
        private List<LectureVo> appliedCourseList;

        private UserRepository()
        {
            this.user = new UserDto("21013314", "1234");
            this.favoriteSubjectList = new List<LectureVo>();
            this.appliedCourseList = new List<LectureVo>();
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

        public List<LectureVo> FavoriteSubjectList
        {
            get { return favoriteSubjectList; }
            set { favoriteSubjectList = value; }
        }

        public List<LectureVo> AppliedCourseList
        {
            get { return appliedCourseList; }
            set { appliedCourseList = value; }
        }
    }
}
