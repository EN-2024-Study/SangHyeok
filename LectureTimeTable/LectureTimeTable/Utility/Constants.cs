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
            Id,
            Password
        }

        public enum MainMenu
        {
            LectureScheduleSearch,
            FavoriteSubjectsPut,
            CourseRegistration,
            CourseRegistrationHistoryCheck
        }

        public enum RegistrationMenu
        {
            Registration,
            Statement,
            Schedule,
            Delete
        }

        
        
    }
}
