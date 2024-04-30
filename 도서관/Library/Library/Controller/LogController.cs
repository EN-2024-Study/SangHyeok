using Library.Constants;
using Library.Model.Dao;
using Library.Model.DtoVo;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class LogController
    {
        private LogDao logDao;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private Screen screen;

        public LogController(MenuSelector menuSelector) 
        {
            this.logDao = new LogDao();
            this.screen = new Screen();
            this.inputManager = new InputManager();
            this.menuSelector = menuSelector;
        }

        public void ControllHistoryScreen()
        {
            ShowHistory();
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
                ExplainingScreen.ExplainSuccessScreen();
                menuSelector.WaitForEscKey();
            }
        }

        public void DeleteAllLog()
        {
            List<LogDto> logList = logDao.GetLogList();
            foreach (LogDto log in logList)
                logDao.DeleteLog(log.Number);

            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
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
            Console.SetWindowSize(50, 40);
            screen.DrawLogs(logDao.GetLogList());
        }
    }
}
