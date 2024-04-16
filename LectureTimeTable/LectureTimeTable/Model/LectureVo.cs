using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class LectureVo
    {
        private Double id;
        private string major, number, group, subjectName, 
            creditClassification, grade, score, day, room, 
            professorName, language;

        public LectureVo(Double id, string major, string number,
            string group, string subjectName,
            string creditClassification, string grade, string score,
            string day, string room, string professorName, string language)
        {
            this.id = id;
            this.major = major;
            this.number = number;
            this.group = group;
            this.subjectName = subjectName;
            this.creditClassification = creditClassification;
            this.grade = grade;
            this.score = score;
            this.day = day;
            this.room = room;
            this.professorName = professorName;
            this.language = language;
        }

        public Double Id
        { get { return id; } }
         public string Major
        { get { return major; } }
        public string Number
        { get { return number; } }
        public string Group
        { get { return group; } }
        public string SubjectName
        { get { return subjectName; } }
        public string CreditClassification
        { get { return creditClassification; } }
        public string Grade
        { get { return grade; } }
        public string Score
        { get { return score; } }
        public string Day
        { get { return day; } }
        public string Room
        { get { return room; } }
        public string ProfessorName
        { get { return professorName; } }
        public string Language
        { get { return language; } }
    }
}
