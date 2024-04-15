using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Utility
{
    public class Constants
    {
        public enum MenuType
        {
            LogIn,
            Main,
            FavoriteSubject,
            CourseRegistration,
            Search,
            InputSearch
        }

        public enum DigitType
        {
            Id,
            Password,
            CourseTitle,
            ProfessorName,
            Grade
        }

        public enum LogInMenu
        {
            Quit = -1,
            Id = 0,
            Password = 1
        }

        public enum MainMenu
        {
            GoBack = -1,
            LectureScheduleSearch,
            FavoriteSubjectsPut,
            CourseRegistration,
            CourseRegistrationHistoryCheck
        }
    }
}
