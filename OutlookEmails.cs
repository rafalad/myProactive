using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.Runtime;
using System.Text.RegularExpressions;
//using LanguageExt;
using System.Diagnostics;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
//using LanguageExt.ClassInstances;
using System.Data;

namespace myProactive
{
	public class OutlookEmails
	{
        //public static int total = 0;
        public string ReadMailItems()
        {
            Application outlookApplication = null;
            NameSpace outlookNamespace = null;
            MAPIFolder inboxFolder = null;
            Items mailItems = null;

            Excel excel = new Excel(@"C:\TEST_eksela\Test.xlsx", 1); //obiek + numer zakladki

            int i = 0;

            int k1 = 1;
            int k2 = 1;
            int k3 = 1;
            int k4 = 1;
            int k5 = 1;
            int k6 = 1;

            string content = string.Empty;
            string content2 = string.Empty;


            excel.WriteToCell(0, 0, "Item");
            excel.WriteToCell(0, 1, "DATE");
            excel.WriteToCell(0, 2, "WFID");
            excel.WriteToCell(0, 3, "BP");
            excel.WriteToCell(0, 4, "SourceID");
            excel.WriteToCell(0, 5, "DestinationID");

            try
            {
                outlookApplication = new Application();
                outlookNamespace = outlookApplication.GetNamespace("MAPI");
                //inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                inboxFolder = outlookNamespace.Folders.Session.PickFolder();
                //testFolder = outlookNamespace.CurrentProfileName;
                //inboxFolder2 = folder.FolderPath.Contains("Test");
                mailItems = inboxFolder.Items;

                foreach (MailItem item in mailItems)
                {
                    i = i + 1;
                    if (i <= 10) //ograniczam wybor tylko dla pierwszych 10 maili
                    {

                        var stringBuilder = new StringBuilder();

                        string CreationTime = item.CreationTime.ToString();
                        stringBuilder.AppendLine("Subject: " + item.Subject);
                        stringBuilder.AppendLine("Body: " + item.Body);

                        string body = item.Body.ToString();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(item);
                        //string source_wfid = string.Empty;

                        string sPattern = "LOCK";

                        if (Regex.IsMatch(body, sPattern, RegexOptions.IgnoreCase))
                        {
                            Console.WriteLine("Item: " + i + " || " + "Skipping, found: Error description 'LOCK: Lock exists'");
                        }
                        else
                        {
                            //////////// extract WFID
                            content = stringBuilder.ToString();
                            int first = content.IndexOf(" = ") + " : ".Length;

                            int last = content.LastIndexOf(" : ");
                            string str2 = content.Substring(first, last - first);

                            Regex wyrazenie_wfid = new Regex(@"\d+");

                            Match wfid = wyrazenie_wfid.Match(str2);
                            if (wfid.Success)
                            {
                                //int wfid_count = wfid.Value.Count();
                                //string source_wfid = wfid.Value.Substring(0, wfid_count);
                            }
                            else
                            {
                                Console.WriteLine("You didn't enter a string containing a number!");
                            }

                            //wfid.Value.Substring(0, wfi
                            //source_wfid;


                            //source_wfid = wfid.Value.Substring(0, wfid_count);

                            //////////// extract BP
                            ///

                            string content_BP = stringBuilder.ToString();
                            int first_bp = content_BP.IndexOf(" : ") + ": ".Length;
                            int last_bp = content_BP.LastIndexOf("Body");

                            string bp_part1 = content_BP.Substring(first_bp, last_bp - first_bp);
                            int first_bp1 = bp_part1.IndexOf(" ");
                            int last_bp1 = bp_part1.LastIndexOf(" :");

                            string bp = bp_part1.Substring(first_bp1, last_bp1 - first_bp1);


                            //////////// extract SOURCE ID
                            string content_sourceID = stringBuilder.ToString();

                            int first2 = content_sourceID.IndexOf("(Name)"); //+ " : ".Length;
                            int last2 = content_sourceID.LastIndexOf("(Name)");
                            string source_id = content_sourceID.Substring(first2 + 7, last2 - 26 - first2);

                            string sourceIDpattern = "()";

                            if (source_id.Length > 100)
                            {
                                source_id = "()";
                            }
                            else // jezeli wystpuje w stringu () to utnij spacje
                            {
                                if (Regex.IsMatch(source_id, sourceIDpattern, RegexOptions.IgnoreCase))
                                {
                                    source_id = source_id.Trim();
                                }
                            }

                            //////////// extract DESTINATION ID

                            string content_destID = stringBuilder.ToString();

                            int first_destID = content_destID.IndexOf("Destination"); //+ " : ".Length;
                            int last_destID = content_destID.LastIndexOf("Type");
                            string source_destID = content_destID.Substring(first_destID + 22, last_destID - 35 - first_destID);

                            string destIDpattern = "()";

                            if (source_destID.Length > 100)
                            {
                                source_destID = "()";
                            }
                            else //jezeli wystepuje w stringu () to utnij spacje
                            {
                                if (Regex.IsMatch(source_destID, destIDpattern, RegexOptions.IgnoreCase))
                                {
                                    source_destID = source_destID.Trim();
                                }
                            }



                            //////////// extract ERROR

                            string content_error = stringBuilder.ToString();
                            int first_error = content_error.IndexOf(" : ") + " : ".Length;
                            int last_error = content_error.LastIndexOf("Body:");

                            string error_part1 = content_error.Substring(first_error, last_error - first_error);
                            int error_first1 = error_part1.IndexOf(": ") + " ".Length + 1;
                            int error_last1 = error_part1.LastIndexOf("");

                            string source_error = error_part1.Substring(error_first1, error_last1 - error_first1);

                            excel.WriteToCell(k1++, 0, i.ToString());
                            excel.WriteToCell(k2++, 1, CreationTime + Environment.NewLine);
                            excel.WriteToCell(k3++, 2, wfid.Value + Environment.NewLine);
                            excel.WriteToCell(k4++, 3, bp + Environment.NewLine);
                            excel.WriteToCell(k5++, 4, source_id + Environment.NewLine);
                            excel.WriteToCell(k6++, 5, source_destID + Environment.NewLine);

                            Console.WriteLine("Item: " + i + " || " + "Date: " + CreationTime + " || " + "WFID: " + wfid.Value + " || " +
                                "BP: " + bp + " || " + "SourceID: " + source_id + " || " + "DestinationID: " + source_destID + " || " + source_error);

                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Item no. : " + i);
                Console.WriteLine("Content : " + content2);

            }
            finally
            {
                ReleaseComObject(mailItems);
                ReleaseComObject(inboxFolder);
                ReleaseComObject(outlookNamespace);
                ReleaseComObject(outlookApplication);
            }


            excel.Save();
            excel.Close();

            return "";
        }

        public static void ReleaseComObject(object obj)
        {
            if (obj != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }
    }
}
