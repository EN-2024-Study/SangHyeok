using System;
using LectureTimeTable.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class LectureDao
    {
        private LectureRepository lecture;
        public LectureDao()
        {
            this.lecture = LectureRepository.Instance;
        }

        public List<LectureVo> ManageSchedule(int[] searchValues, string subjectName, string professorName)
        {
            string[] searchString = GetSearchStrings(searchValues);
            List<LectureVo> lectureList = lecture.LectureList;
            List<LectureVo> resultLectureList = new List<LectureVo>();

            foreach(LectureVo lecture in lectureList)
            {
                int count = 0;
                if (searchString[0] == "")
                    count++;
                else if (lecture.Major.Equals(searchString[(int)Constants.SearchMenu.Major]))
                    count++;

                if (searchString[1] == "")
                    count++;
                else if (lecture.CreditClassification.Equals(searchString[(int)Constants.SearchMenu.CreditClassification]))
                    count++;

                if (searchString[2] == "")
                    count++;
                else if (lecture.Grade.Equals(searchString[2]))
                    count++;

                if (count == 3)
                    resultLectureList.Add(lecture);
            }

            return resultLectureList;
        }

        //public void IsLecture

        private string[] GetSearchStrings(int[] searchValues)
        {
            // int [0] : Major, [1] : CreditClassification, [2] : grade
            string[] resultString = new string[3] { "", "", ""};
            switch (searchValues[0])    // 학과 
            {
                case (int)Constants.MajorMenu.Computer:
                    resultString[0] = "컴퓨터공학과";
                    break;
                case (int)Constants.MajorMenu.Software:
                    resultString[0] = "소프트웨어학과";
                    break;
                case (int)Constants.MajorMenu.Inteligent:
                    resultString[0] = "지능기전공학부";
                    break;
                case (int)Constants.MajorMenu.space:
                    resultString[0] = "기계항공우주공학부";
                    break;
            }

            switch (searchValues[1])    // 이수 구분
            {
                case (int)Constants.CreditClassificationMenu.Culture:
                    resultString[1] = "공통교양필수";
                    break;
                case (int)Constants.CreditClassificationMenu.Essential:
                    resultString[1] = "전공필수";
                    break;
                case (int)Constants.CreditClassificationMenu.Selected:
                    resultString[1] = "전공선택";
                    break;
            }

            switch (searchValues[2])    // 학년
            {
                case 1:
                    resultString[2] = "1";
                    break;
                case 2:
                    resultString[2] = "2";
                    break;
                case 3:
                    resultString[2] = "3";
                    break;
                case 4:
                    resultString[2] = "4";
                    break;
            }

            return resultString;
        }
    }
}
