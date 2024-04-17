using LectureTimeTable.Utility;
using LectureTimeTable.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class UserInfoController
    {
        private UserRepository user;
        private InputManager inputManager;

        public UserInfoController()
        {
            this.user = UserRepository.Instance;    // singleton 생성
            this.inputManager = new InputManager();
        }

        public bool IsUserLogInValid(int digitValue)
        {
            while (true)
            {
                string  inputId = "", inputPassword = "";
                switch (digitValue)
                {
                    case (int)Constants.DigitType.Id:
                        inputId = inputManager.LimitInputLength((int)Constants.DigitType.Id, 9, false);
                        break;
                    case (int)Constants.DigitType.Password:
                        inputPassword = inputManager.LimitInputLength((int)Constants.DigitType.Password, 5, true);
                        break;
                }

                if (inputId == null || inputPassword == null)
                    return false;
                else if (user.GetUserId().Equals(inputId) || user.GetUserPassword().Equals(inputPassword))
                    return true;
            }
        }


        public List<LectureVo> GetFavoriteSubjectList()
        {
            return user.FavoriteSubjectList;
        }

        public List<LectureVo> GetAppliedCourseList()
        {
            return user.AppliedCourseList;
        }

        public bool IsCourseSetValid(int typeValue, LectureVo addCourse)
        {
            List<LectureVo> lectureList = null;
            bool isDuplication = false;
            switch (typeValue)
            {
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectApply:
                    lectureList = user.FavoriteSubjectList;
                    break;
                case (int)Constants.LectureTimeSheetType.CourseApply:
                    lectureList = user.AppliedCourseList;
                    break;
            }

            foreach (LectureVo lecture in lectureList)
            {
                if (addCourse.Id.Equals(lecture.Id))
                {
                    isDuplication = true;
                    break;
                }
            }

            if (isDuplication)
                return false;

            switch (typeValue)
            {
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectApply:
                    user.SetFavoriteSubject(addCourse);
                    break;
                case (int)Constants.LectureTimeSheetType.CourseApply:
                    user.SetAppliedCourse(addCourse);
                    break;
            }
            return true;
        }
    }
}
