//using Library.Utility;
//using Library.View;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Library.Controller.Task
//{
//    public class PastUserAccountTaskController : PastAccountTaskController
//    {
//        MenuController menuController;
//        PastAccountScreen accountScreen;
//        private string[] inputString;

//        public PastUserAccountTaskController()
//        {
//            menuController = new MenuController();
//            accountScreen = new PastAccountScreen();
//            inputString = new string[7];
//        }

//        public bool SignUp()
//        {
//            bool isSignUp = true;
//            menuController.menuValue = 0;
//            Tuple<int, int> coordinate = new Tuple<int, int>(15, 20);

//            while (isSignUp)     // ID 입력과 Password 입력 중 선택
//            {
//                accountScreen.PrintScreen(menuController.menuValue, false, false, coordinate);
//                isSignUp = menuController.SelectMenu();
//                if (menuController.menuValue > 6)
//                    menuController.menuValue = 6;
//            }

//            if (menuController.menuValue == (int)Constants.Account.GoBack) // esc 입력 -> mode 선택 화면
//                return false;

//            bool isSignUp2 = SignUp2(coordinate);
//            if (!isSignUp2)
//                return false;
            
//            //Console.Write("test");
//            //Console.ReadLine();

//            return true;
//        }

//        private bool SignUp2(Tuple<int, int> coordinate)
//        {
//            bool isSignUp = true;
//            while (isSignUp)
//            {
//                bool isNull = false;
//                foreach (string s in inputString)
//                {
//                    if (s == null)
//                    {
//                        isNull = true;
//                        break;
//                    }
//                }

//                if (!isNull)
//                    isSignUp = false;

//                accountScreen.PrintScreen(menuController.menuValue, true, false, coordinate);
//                switch (menuController.menuValue)
//                {
//                    case (int)Constants.Account.Id:
//                        inputString[0] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 1);
//                        if (inputString[0] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                    case (int)Constants.Account.Password:
//                        inputString[1] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 2);
//                        if (inputString[1] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                    case (int)Constants.Account.PasswordCheck:
//                        inputString[2] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 3);
//                        if (inputString[2] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                    case (int)Constants.Account.Name:
//                        inputString[3] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 4);
//                        if (inputString[3] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                    case (int)Constants.Account.Age:
//                        inputString[4] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 5);
//                        if (inputString[4] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                    case (int)Constants.Account.PhoneNumber:
//                        inputString[5] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 6);
//                        if (inputString[5] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                    case (int)Constants.Account.Address:
//                        inputString[6] = ExceptionInput(coordinate.Item1 + 15, coordinate.Item2 + 7);
//                        if (inputString[6] == null)
//                            return false;
//                        else
//                            SignUp();
//                        break;
//                }
//            }
//            return true;
//        }

//        private string ExceptionInput(int x, int y)
//        {
//            string str = LimitInputLength(15, new Tuple<int, int>(x, y), false);
//            str = LimitInputRegex(str);

//            return str;
//        }

//        //public void ModifyPersonalAccount() 
//        //{

//        //}

//        //public void DeletePersonalAccount()
//        //{

//        //}
//    }
//}
