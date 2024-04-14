﻿using System;
using System.Collections.Generic;
using Library.Model;
using Library.Utility;

namespace Library.View
{
    public class InformationScreen
    {
        public void PrintBookInfo(List<BookDto> bookList)
        {
            Console.SetCursorPosition(0, 8);
            for(int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("책 아이디  : " + (i + 1));
                Console.WriteLine("책 제목    : " + bookList[i].Title);
                Console.WriteLine("작가       : " + bookList[i].Writer);
                Console.WriteLine("출판사     : " + bookList[i].Publisher);
                Console.WriteLine("수량       : " + bookList[i].Count);
                Console.WriteLine("가격       : " + bookList[i].Price);
                Console.WriteLine("출시일     : " + bookList[i].ReleaseDate);
                Console.WriteLine("ISBN       : " + bookList[i].ISBN);
                Console.WriteLine("책 정보    : " + bookList[i].Info);
            }
        }

        public void PrintIdSearch(string str)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(str);
            Console.WriteLine("ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("입력 : ");
        }

        public void AccountScreen(List<AccountDto> accountList)
        {
            Console.SetCursorPosition(0, 8);
            foreach (AccountDto accout in accountList)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("USER ID            : " + accout.Id);
                Console.WriteLine("USER NAME          : " + accout.Name);
                Console.WriteLine("USER AGE           : " + accout.Age);
                Console.WriteLine("USER PHONENUMBER   : " + accout.PhoneNumber);
                Console.WriteLine("USER ADDRESS       : " + accout.Address);
            }
        }

        public void PrintAccountInfomation(AccountDto account)
        {
            Console.SetCursorPosition(40, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("개 인 정 보 바 꾸 끼");
            Console.ResetColor();

            Console.SetCursorPosition(0, 6);
            Console.WriteLine("========================================================================");
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("USER ID          : " + account.Id);
            Console.WriteLine("USER NAME        : " + account.Name);
            Console.WriteLine("USER AGE         : " + account.Age);
            Console.WriteLine("USER PHONENUMBER : " + account.PhoneNumber);
            Console.WriteLine("USER ADDRESS     : " + account.Address);
        }
    }
}
