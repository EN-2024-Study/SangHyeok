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
            Search,
            Major,
            CreditClassification,
            Grade
        }

        public enum DigitType
        {
            Id,
            Password,
            SubjectTitle,
            ProfessorName,
            SubjectId
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
            SubjectTitle,
            ProfessorName,
            Grade,
            Enter
        }

        public enum MajorMenu
        {
            All,
            Computer,
            Software,
            Inteligent,
            space
        }

        public enum CreditClassificationMenu
        {
            All,
            Culture,
            Essential,
            Selected
        }

        public enum LectureTimeSheetType
        {
            FavoriteSubjectHistory,
            FavoriteSubjectApply,
            FavoriteSubjectDelete,
            AppliedCourseHistory,
            CourseApply,
            CourseSearch,
            CourseDelete
        }
    }
}
