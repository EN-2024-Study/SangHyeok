using Library.Constants;
using Library.Model.Dao;
using Library.Model.DtoVo;
using Library.View;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Library.Controller
{
    public class LogController
    {
        private LogDao logDao;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private Screen screen;
        private string filePath;

        public LogController(MenuSelector menuSelector) 
        {
            this.logDao = new LogDao();
            this.screen = new Screen();
            this.inputManager = new InputManager();
            this.menuSelector = menuSelector;
            this.filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "로그.txt");
        }

        public void ControllHistoryScreen()
        {
            ShowHistory();
            AddLog(new LogDto("", "", "Manager", "21013314", "로그 내역 조회"));
            ExplainingScreen.ExplainEcsKey(0);
            menuSelector.WaitForEscKey();
        }

        public void ControllDeleteScreen()
        {
            ShowHistory();
            ExplainingScreen.ExplainInputId("로그");
            string inputNumber = inputManager.LimitInputLength((int)Enums.InputType.LogId, false);
            if (inputNumber == null)
                return;
            else if (IsDeleteValid(inputNumber))
            {
                logDao.DeleteLog(inputNumber);
                AddLog(new LogDto("", "", "Manager", "21013314", "로그 내역 삭제"));
                ExplainingScreen.ExplainSuccessScreen();
                menuSelector.WaitForEscKey();
            }
        }

        public void DeleteAllLog()
        {
            List<LogDto> logList = logDao.GetLogList();
            foreach (LogDto log in logList)
                logDao.DeleteLog(log.Number);

            AddLog(new LogDto("", "", "Manager", "21013314", "로그 내역 삭제"));
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void SaveFile()
        {
            List<LogDto> logList = logDao.GetLogList();
            File.WriteAllText(filePath, " ");
            foreach (LogDto log in logList)
            {
                File.AppendAllText(filePath, "============================\n");
                File.AppendAllText(filePath, (log.Number + "\n"));
                File.AppendAllText(filePath, (log.Time + "\n"));
                File.AppendAllText(filePath, (log.User + "\n"));
                File.AppendAllText(filePath, log.Info);
                File.AppendAllText(filePath, (log.Play + "\n"));
            }

            AddLog(new LogDto("", "", "Manager", "21013314", "로그 내역 파일에 저장"));
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void DeleteFile()
        {
            File.Delete(filePath);
            AddLog(new LogDto("", "", "Manager", "21013314", "로그 내역 파일 삭제"));
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void AddLog(LogDto log)
        {
            log.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            logDao.AddLog(log);
        }

        private bool IsDeleteValid(string inputNumber)
        {
            List<LogDto> logList = logDao.GetLogList();
            foreach(LogDto log in logList)
            {
                if (log.Number.Equals(inputNumber))
                    return true;
            }

            ExplainingScreen.ExplainFailScreen();
            menuSelector.WaitForEscKey();
            return false;
        }

        private void ShowHistory()
        {
            Console.Clear();
            Console.SetWindowSize(70, 40);
            screen.DrawLogs(logDao.GetLogList());
        }
    }
}
