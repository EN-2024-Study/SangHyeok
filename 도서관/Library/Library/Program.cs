﻿using Library.Controller;
using Library.Utility;
using System;

namespace Library
{
    public class Program
    {

        public static void Main(string[] args)
        {
            MenuController menuController = new MenuController();
            menuController.Run();
        }
    }
}
