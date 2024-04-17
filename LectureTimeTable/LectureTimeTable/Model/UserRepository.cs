using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class UserRepository // singleton
    {
        private static UserRepository instance;
        private UserDto userDto;
        private List<LectureVo> favoriteSubjectList;
        private List<LectureVo> appliedCourseList;
        private int favoriteSubjectScore;
        private int appliedCourseScore;

        private UserRepository()
        {
            this.userDto = new UserDto("21013314", "1234");
            this.favoriteSubjectList = new List<LectureVo>();
            this.appliedCourseList = new List<LectureVo>();
            this.favoriteSubjectScore = 0;
            this.appliedCourseScore = 0;
        }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        public string GetUserId()
        { return userDto.Id; }

        public string GetUserPassword()
        { return userDto.Password; }

        public List<LectureVo> FavoriteSubjectList
        {
            get { return favoriteSubjectList; }
        }

        public void AddFavoriteSubject(LectureVo lecture)
        {
            favoriteSubjectList.Add(lecture);
            favoriteSubjectScore += int.Parse(lecture.Score);
        }
        public void RemoveFavoriteSubject(LectureVo lecture)
        {
            favoriteSubjectList.Remove(lecture);
            favoriteSubjectScore -= int.Parse(lecture.Score);
        }

        public List<LectureVo> AppliedCourseList
        {
            get { return appliedCourseList; }
        }

        public void AddAppliedCourse(LectureVo lecture)
        {
            appliedCourseList.Add(lecture);
            appliedCourseScore += int.Parse(lecture.Score);
        }

        public void RemoveAppliedCourse(LectureVo lecture)
        {
            appliedCourseList.Remove(lecture);
            appliedCourseScore -= int.Parse(lecture.Score);
        }

        public int FavoriteSubjectScore
        { get { return favoriteSubjectScore; } }

        public int AppliedCourseScore
        { get { return appliedCourseScore; } }
    }
}
