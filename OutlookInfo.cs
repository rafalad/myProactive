using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace myProactive
{
	class OutlookInfo
	{
        public string Outlook()
        {
            MyProactive formularz = new MyProactive();
            string info = string.Empty;
            string info2 = string.Empty;
            Outlook.Application Application = new Outlook.Application();
            Outlook.Accounts accounts = Application.Session.Accounts;
            foreach (Outlook.Account account in accounts)
            {
                info = account.DisplayName;

                int last_info = info.LastIndexOf("@");
                info2 = info.Substring(0, last_info);

                //formularz.richTextBox_account.Text = account.DisplayName;
                //Console.WriteLine(account.DisplayName);
            }
            return info2;
        }
    }
}
