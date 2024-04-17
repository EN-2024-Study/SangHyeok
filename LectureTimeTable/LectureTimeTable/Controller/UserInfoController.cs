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
        private LectureTimeScreen screen;
        private LectureInfoController lectureInfoController;

        public UserInfoController()
        {
            this.user = UserRepository.Instance;    // singleton 생성
            this.inputManager = new InputManager();
            this.screen = new LectureTimeScreen();
            this.lectureInfoController = new LectureInfoController();
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

        public void ManageLectureList(int menuValue)
        {
            List<LectureVo> courseList = null;
            switch(menuValue)
            {
                case (int)Constants.CourseMenu.Favorite:
                    courseList = user.FavoriteSubjectList;
                    break;
                case (int)Constants.CourseMenu.Class:
                    courseList = user.AppliedCourseList;
                    break;
            }
            //screen.DrawLectureTimeSheetScreen(courseList);
            lectureInfoController.ManageLectureTimeSheet(courseList);
        }
    }
}
