﻿using LectureTimeTable.Utility;
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
        private ExceptionManager exceptionManager;

        public UserInfoController()
        {
            this.user = UserRepository.Instance;    // singleton 생성
            this.inputManager = new InputManager();
            this.exceptionManager = new ExceptionManager();
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
                string inputId = inputManager.LimitInputLength((int)Constantss.DigitType.Id, 9, false);

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
                string inputPassword = inputManager.LimitInputLength((int)Constantss.DigitType.Password, 5, true);

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

            if (typeValue == (int)Constantss.LectureType.FavoriteSubjectApply)
            {
                if (!exceptionManager.IsOverlapCheck(user.FavoriteSubjectList, course))
                    return false;
                else if (user.FavoriteSubjectScore + int.Parse(course.Score) > 24)
                    return false;
                else
                    user.AddFavoriteSubject(course);
            }
            else if (typeValue == (int)Constantss.LectureType.ApplyAfterSearch ||
                typeValue == (int)Constantss.LectureType.ApplyForFavoriteSubject)
            {
                if (!exceptionManager.IsOverlapCheck(user.AppliedCourseList, course))
                    return false;
                else if (user.AppliedCourseScore + int.Parse(course.Score) > 21)
                    return false;
                else
                    user.AddAppliedCourse(course);
            }
            else if (typeValue == (int)Constantss.LectureType.FavoriteSubjectDelete)
                user.RemoveFavoriteSubject(course);
            else if (typeValue == (int)Constantss.LectureType.CourseDelete)
                user.RemoveAppliedCourse(course);
            return true;
        }

        private bool IsCheckDuplication(int typeValue, LectureVo addCourse)
        {   
            List<LectureVo> lectureList = null;

            switch (typeValue)
            {
                case (int)Constantss.LectureType.FavoriteSubjectApply:
                case (int)Constantss.LectureType.FavoriteSubjectDelete:
                case (int)Constantss.LectureType.ApplyForFavoriteSubject:
                    lectureList = user.FavoriteSubjectList;
                    break;
                case (int)Constantss.LectureType.ApplyAfterSearch:
                case (int)Constantss.LectureType.CourseDelete:
                    lectureList = user.AppliedCourseList;
                    break;
            }

            if (typeValue == (int)Constantss.LectureType.ApplyAfterSearch || 
                typeValue == (int)Constantss.LectureType.FavoriteSubjectApply)
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
