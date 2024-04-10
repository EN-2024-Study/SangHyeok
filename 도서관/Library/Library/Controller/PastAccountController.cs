//using Library.View;
//using Library.Model;
//using System;
//using Library.Utility;
//using System.Collections.Generic;

//namespace Library.Controller
//{
//    public class AccountController
//    {
//        private PastInputController inputController;
//        private AccountScreen accountScreen;
//        private PastExceptionController exceptionController;
//        private PastAccountsDto accountsDto;

//        public AccountController()
//        {
//            this.inputController = new PastInputController();
//            this.accountScreen = new AccountScreen();
//            this.exceptionController = new PastExceptionController();
//            this.accountsDto = new PastAccountsDto();
//        }

//        public void LogIn()
//        {
//            accountScreen.PrintLogInWindow();

//            string id = inputController.InputLogIn(15, 23, 15, false);
//            if (id == null)
//                return;
//            string password = inputController.InputLogIn(15, 25, 4, true);
//            if (password == null)
//                return;

//            PastAccountInfo loginInfo = new PastAccountInfo(id, password);
//            List<AccountInfo> accounts = accountsDto.Accounts;

//            foreach (AccountInfo value in accounts)
//            {
//                if (value.Id == loginInfo.Id && value.Password == loginInfo.Password)
//                {
//                    // userModeMenu
//                }
//            }
//            exceptionController.HandleInputException((int)Constants.Error.Correspond);
//            LogIn();
//        }

//        public void SignUp(int modeValue)
//        {
//            if (modeValue == (int)Constants.ModeMenu.ManagerMode)
//            {
//                exceptionController.HandleSignUpException();
//                return;
//            }

//            Console.CursorVisible = true;
//            bool isInput = true;
//            int menuValue = 0;
//            while (isInput)
//            {
//                string info = null;
//                int coordinateX = 40;
//                int coordinateY = 21 + menuValue;
//                accountScreen.PrintSignUpWindow(menuValue);
//                Console.SetCursorPosition(coordinateX, coordinateY);
//                ConsoleKeyInfo keyInfo = Console.ReadKey();
//                switch (keyInfo.Key)
//                {
//                    case ConsoleKey.UpArrow:
//                        menuValue--;
//                        if (menuValue < 0)
//                            menuValue = 0;
//                        break;
//                    case ConsoleKey.DownArrow:
//                        menuValue++;
//                        break;
//                    case ConsoleKey.Enter:
//                        if (menuValue == 6)
//                        {
//                            // enter일 때
//                        }
//                        break;
//                    default:
//                        info = inputController.InputSignUp(coordinateX, coordinateY, menuValue % 7);
//                        break;
//                }
//                if (menuValue > 6)
//                    menuValue = 6;

//                if (info != null)
//                {
//                    List<PastAccountInfo> account = accountsDto.Accounts;
//                    foreach (PastAccountInfo value in account)
//                    {

//                    }
//                }
//            }
//            Console.CursorVisible = false;
//        }


//    }
//}
