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

        public enum LectureType
        {
            FavoriteSubjectHistory,
            AppliedCourseHistory,
            CourseSearch,
            FavoriteSubjectApply,
            FavoriteSubjectDelete,
            ApplyAfterSearch,
            ApplyForFavoriteSubject,
            CourseDelete
        }


        public static readonly string SCHEDULE = @"
 ============================================================= 시간표 ===========================================================
====================월=====================화====================수====================목====================금=================== 

08:30 ~ 09:00

09:00 ~ 09:30

09:30 ~ 10:00

10:00 ~ 10:30

10:30 ~ 11:00

11:00 ~ 11:30

11:30 ~ 12:00

12:00 ~ 12:30

12:30 ~ 13:00

13:00 ~ 13:30

13:30 ~ 14:00

14:00 ~ 14:30

14:30 ~ 15:00

15:00 ~ 15:30

15:30 ~ 16:00

16:00 ~ 16:30

16:30 ~ 17:00

17:00 ~ 17:30

17:30 ~ 18:00

18:00 ~ 18:30

18:30 ~ 19:00

19:00 ~ 19:30

19:30 ~ 20:00

20:00 ~ 20:30

20:30 ~ 21:00
====================월=====================화====================수====================목====================금=================== 
";

        public static readonly string[] TIMES = new string[] {"08:30", "09:00", "09:30", "10:00", "10:30" ,
                "11:00", "11:30" , "12:00", "12:30" , "13:00", "13:30" ,
                "14:00", "14:30" , "15:00", "15:30" , "16:00", "16:30" ,
                "17:00", "17:30" , "18:00", "18:30" , "19:00", "19:30" ,
                "20:00", "20:30" , "21:00", "21:30" };
    }
}
