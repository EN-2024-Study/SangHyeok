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
        public List<LectureVo> GetFavoriteSubjectList()
        {
            return user.FavoriteSubjectList;
        }

        public List<LectureVo> GetAppliedCourseList()
        {
            return user.AppliedCourseList;
        }

        public bool IsUserIdValid()
        {
            while (true)
            {
                string inputId = inputManager.LimitInputLength((int)Constants.DigitType.Id, 9, false);

                if (inputId == null)
                    return false;
                else if (user.GetUserId().Equals(inputId))
                    return true;
            }
        }

        public bool IsUserPasswordValid()
        {    
            while (true)
            {
                string inputPassword = inputManager.LimitInputLength((int)Constants.DigitType.Password, 5, true);

                if (inputPassword == null)
                    return false;
                else if (user.GetUserPassword().Equals(inputPassword))
                    return true;
            }
        }

        public bool IsCourseSetValid(int typeValue, LectureVo course)
        {   // 입력 값 삽입과 가능한지 확인하는 함수
            if (!IsCheckDuplication(typeValue, course))
                return false;

            switch (typeValue)
            {
                case (int)Constants.LectureType.FavoriteSubjectApply:
                    user.AddFavoriteSubject(course);
                    break;
                case (int)Constants.LectureType.ApplyAfterSearch:
                case (int)Constants.LectureType.ApplyForFavoriteSubject:
                    user.AddAppliedCourse(course);
                    break;
                case (int)Constants.LectureType.FavoriteSubjectDelete:
                    user.RemoveFavoriteSubject(course);
                    break;
                case (int)Constants.LectureType.CourseDelete:
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
                case (int)Constants.LectureType.FavoriteSubjectApply:
                case (int)Constants.LectureType.FavoriteSubjectDelete:
                case (int)Constants.LectureType.ApplyForFavoriteSubject:
                    lectureList = user.FavoriteSubjectList;
                    break;
                case (int)Constants.LectureType.ApplyAfterSearch:
                case (int)Constants.LectureType.CourseDelete:
                    lectureList = user.AppliedCourseList;
                    break;
            }

            if (typeValue == (int)Constants.LectureType.ApplyAfterSearch || 
                typeValue == (int)Constants.LectureType.FavoriteSubjectApply)
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
