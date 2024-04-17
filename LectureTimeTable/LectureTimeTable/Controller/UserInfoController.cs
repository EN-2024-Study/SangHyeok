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

        public bool IsCourseSetValid(int typeValue, LectureVo course)
        {
            if (!IsCheckDuplication(typeValue, course))
                return false;

            switch (typeValue)
            {
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectApply:
                    user.AddFavoriteSubject(course);
                    break;
                case (int)Constants.LectureTimeSheetType.ApplyAfterSearch:
                case (int)Constants.LectureTimeSheetType.ApplyForFavoriteSubject:
                    user.AddAppliedCourse(course);
                    break;
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectDelete:
                    user.RemoveFavoriteSubject(course);
                    break;
                case (int)Constants.LectureTimeSheetType.CourseDelete:
                    user.RemoveAppliedCourse(course);
                    break;
            }
            return true;
        }

        private bool IsCheckDuplication(int typeValue, LectureVo addCourse)
        {
            List<LectureVo> lectureList = null;

            switch (typeValue)
            {
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectApply:
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectDelete:
                case (int)Constants.LectureTimeSheetType.ApplyForFavoriteSubject:
                    lectureList = user.FavoriteSubjectList;
                    break;
                case (int)Constants.LectureTimeSheetType.ApplyAfterSearch:
                case (int)Constants.LectureTimeSheetType.CourseDelete:
                    lectureList = user.AppliedCourseList;
                    break;
            }

            if (typeValue == (int)Constants.LectureTimeSheetType.ApplyAfterSearch || 
                typeValue == (int)Constants.LectureTimeSheetType.FavoriteSubjectApply)
            {
                foreach (LectureVo lecture in lectureList)  // 추가할 과목이 이미 존재하면 false
                    if (addCourse.Id.Equals(lecture.Id))
                        return false;
                return true;
            }
            else
            {
                foreach (LectureVo lecture in lectureList)  // 삭제할 과목이 없다면 false
                    if (addCourse.Id.Equals(lecture.Id))
                        return true;
                return false;
            }
        }
    }
}
