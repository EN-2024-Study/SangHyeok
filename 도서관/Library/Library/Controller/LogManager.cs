using Library.Constants;
using Library.Model.Dao;
using Library.Model.DtoVo;
using Library.View;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Controller
{
    public class LogManager
    {
        private LogDao logDao;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private Screen screen;

        public LogManager(MenuSelector menuSelector) 
        {
            this.logDao = new LogDao();
            this.screen = new Screen();
            this.inputManager = new InputManager();
            this.menuSelector = menuSelector;
        }

        public void ControllHistoryScreen()
        {
            ShowHistory();
            AddLog(LogStrings.MANAGER, LogStrings.LOG_HISTORY, LogStrings.BLANK);
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
                AddLog(LogStrings.MANAGER, LogStrings.LOG_DELETE, inputNumber);
                ExplainingScreen.ExplainSuccessScreen();
                menuSelector.WaitForEscKey();
            }
        }

        public void DeleteAllLog()
        {
            List<LogDto> logList = logDao.GetLogList();
            foreach (LogDto log in logList)
                logDao.DeleteLog(log.Number);

            AddLog(LogStrings.MANAGER, LogStrings.LOG_ALL_DELETE, LogStrings.BLANK);
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void SaveFile()
        {
            List<LogDto> logList = logDao.GetLogList();
            string filePath = EnvironmentSetUp.LOG_PATH;

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

            AddLog(LogStrings.MANAGER, LogStrings.LOG_SAVE_FILE, LogStrings.BLANK);
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void DeleteFile()
        {
            string filePath = EnvironmentSetUp.LOG_PATH;

            File.Delete(filePath);
            AddLog(LogStrings.MANAGER, LogStrings.LOG_FILE_DELETE, LogStrings.BLANK);
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void AddLog(string user, string info, string play)
        {
            LogDto log = new LogDto(LogStrings.NULL, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), user, info, play);
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
