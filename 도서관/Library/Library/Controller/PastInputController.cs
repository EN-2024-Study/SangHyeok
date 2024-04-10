//using Library.Model;
//using Library.Utility;
//using Library.View;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices.ComTypes;
//using System.Text;
//using System.Threading.Tasks;

//namespace Library.Controller
//{
//    public class PastInputController
//    {
//        private PastExceptionController exceptionController;
//        private PastAccountInfo accountInfo;

//        public PastInputController()
//        {
//            exceptionController = new PastExceptionController();
//            accountInfo = new PastAccountInfo();
//        }

//        public string InputLogIn(int coordinateX, int coordinateY, int length, bool isPassword)
//        {
//            Console.CursorVisible = true;
//            Console.SetCursorPosition(coordinateX, coordinateY);
//            string str = null;
//            char[] inputString = new char[length];
//            bool isBreak = false;

//            for (int i = 0; i < length + 1; i++)
//            {
//                ConsoleKeyInfo keyInfo = Console.ReadKey();
//                switch (keyInfo.Key)
//                {
//                    case ConsoleKey.Enter:
//                        isBreak = true;
//                        break;
//                    case ConsoleKey.Backspace:
//                        Console.SetCursorPosition(15, coordinateY - i - 1);
//                        Console.Write(" ");
//                        Console.SetCursorPosition(15, coordinateY - i);
//                        break;
//                    case ConsoleKey.Escape:
//                        return null;
//                }

//                if (isBreak)
//                    break;
//                else if (isPassword)
//                {
//                    Console.SetCursorPosition(coordinateX, 25);
//                    Console.Write("*");
//                    coordinateX++;
//                }
//                inputString[i] = keyInfo.KeyChar;
//            }

//            if (!isBreak)
//            {
//                ConsoleKeyInfo keyInfo = Console.ReadKey();
//                exceptionController.HandleInputException((int)Constants.Error.Length);
//                return InputLogIn(coordinateX, coordinateY, length, isPassword);
//            }

//            for (int i = 0; i < length; i++)
//                str += inputString[i];

//            Console.CursorVisible = false;
//            return str;
//        }


//        public string InputSignUp(int coordinateX, int coordinateY, int infoNumber)
//        {
//            string str = null;
//            int lengthLimit = 0;
//            bool isBreak = false;

//            switch (infoNumber)
//            {
//                case (int)Constants.User.Id:
//                    lengthLimit = 15;
//                    break;
//                case (int)Constants.User.Password:
//                case (int)Constants.User.Name:
//                    lengthLimit = 4;
//                    break;
//                case (int)Constants.User.Age:
//                    lengthLimit = 200;
//                    break;
//                case (int)Constants.User.PhoneNumber:
//                    lengthLimit = 13;
//                    break;
//                case (int)Constants.User.Address:
//                    lengthLimit = 20;
//                    break;
//            }

//            char[] inputString = new char[lengthLimit];
//            for(int i = 0; i < lengthLimit - 1; i++)
//            {
//                Console.SetCursorPosition(coordinateX + i + 1, coordinateY);
//                ConsoleKeyInfo keyInfo = Console.ReadKey();
//                if (keyInfo.Key == ConsoleKey.Enter)
//                {
//                    isBreak = true;
//                    break;
//                }
//            }

//            if (!isBreak)
//            {
//                ConsoleKeyInfo keyInfo = Console.ReadKey();
//                Console.SetCursorPosition(coordinateX, coordinateY);
//                Console.Write("                  ");
//                exceptionController.HandleInputException((int)Constants.Error.Length);
//                return InputSignUp(coordinateX, coordinateY, infoNumber);
//            }

//            for (int i = 0; i < lengthLimit - 1; i++)
//                str += inputString[i];
//            return str;
//        }
//    }
//}
