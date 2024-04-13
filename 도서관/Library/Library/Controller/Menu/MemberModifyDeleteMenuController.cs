using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class MemberModifyDeleteMenuController : MenuController
    {
        private InformationController informationController;
        private InformationScreen bookScreen;
        private UserModifyMenuController userModifyMenuController;
        public MemberModifyDeleteMenuController() : base()
        {
            this.informationController = new InformationController();
            this.bookScreen = new InformationScreen();
            this.userModifyMenuController = new UserModifyMenuController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.ManagerInfo);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isBack = false;
            bool isMenuSelect = true;
        
            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)  
            {
                case (int)Constants.InfoMenu.GoBack:
                    return true;
                case (int)Constants.InfoMenu.Modify:  // 유저 정보 수정
                    isBack = Modify();
                    break;
                case (int)Constants.InfoMenu.Delete:   // 유저 계정 삭제
                    isBack = Delete();
                    break;
            }

            if (isBack)
                return true;
            return false;
        }

        private bool Modify()
        {
            AccountDto account = SearchId();
            if (account != null)
            {
                return userModifyMenuController.Run();
                //Console.Clear();
                //ExplainingScreen.PrintComplete("계정을 수정하는데 성공!");
                //ExplainingScreen.PrintEnterCheck();
                //Console.ReadLine();
            }
            return false;
        }

        private bool Delete()
        {
            AccountDto account = SearchId();
            if (account != null)
            {
                informationController.DeleteAccount(account);
                Console.Clear();
                ExplainingScreen.PrintComplete("계정을 삭제하는데 성공!");
                ExplainingScreen.PrintEnterCheck();
                Console.ReadLine();
                return true;
            }
            return false;
        }

        private AccountDto SearchId()
        {
            List<AccountDto> accounts = informationController.GetAccoutList();
            Console.Clear();
            bookScreen.AccountScreen(accounts);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("수정 할 유저 ID");    // 얘도 겹침
            Console.WriteLine("ID 값을 정확히 입력해 주세요.");
            Console.WriteLine("입력 : ");

            Console.SetCursorPosition(8, 2);    // BookSearchMenuController에서 SearchId()와 겹침
            Console.CursorVisible = true;
            string id = Console.ReadLine();
            Console.CursorVisible = false;

            foreach (AccountDto account in accounts)
                if (account.Id.Equals(id))
                    return account;
            return null;
        }
    }

}
