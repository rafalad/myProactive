using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace myProactive
{
	class OutlookInfo
	{
        public string Outlook()
        {
            string info = string.Empty;
            Outlook.Application Application = new Outlook.Application();
            Outlook.Accounts accounts = Application.Session.Accounts;
            foreach (Outlook.Account account in accounts)
            {
                info = account.DisplayName;
                //Console.WriteLine(account.DisplayName);
            }
            return info;
        }
    }
}
