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
            CourseApply,
            SearchAndApply,
            Search
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
            CourseApply,
            CourseApplyHistoryCheck
        }

        public enum ApplyMenu
        {
            Apply,
            Statement,
            Schedule,
            Delete
        }

        public enum SearchAndApplyMenu
        {
            Search,
            FavoriteSubjects
        }

        public enum SearchMenu
        {
            Major,
            CreditClassification,
            subjectName,
            ProfessorName,
            Grade
        }
        
    }
}
