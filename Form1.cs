﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OutlookApp = Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace myProactive
{
	public partial class MyProactive : Form
	{
		private delegate void EnableDelegate(bool enable);

		public string excelPath;
		public string noexcelPath = "blank";

        //pole tekstowe wybor ilosci maili do przetworzenia
        public string selectedItems;

        //zmienna wykorzystywana do definiowania zakresu maili (ich daty modyfikacji)
        public string filter;

        //wybor ilosci maili do przetworzenia
        public int number;

        //wątek roboczy
        private Thread workerThread;

        public MyProactive()
		{
			InitializeComponent();

            LoginDSV login = new LoginDSV();
            Resources resource = new Resources();

            groupBox1.Paint += GroupBox_Paint;
            groupBox2.Paint += GroupBox_Paint;

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            ListBox("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Logged as: " + userName + " " + "(" + login.Login() + ")");
            ListBox("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "App is ready to use.");

            ver.Text = "v" + Application.ProductVersion;

            Task.Delay(3000).ContinueWith(t => resource.LogToFTP()); //zapisz log na serwerze z opoźnieniem

            latest_ver.Text = resource.CheckVersion(); //kontrola wersji programu

            textBox1.Enabled = false;
        }

        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.MidnightBlue, Color.DarkGray);
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                g.Clear(this.BackColor);

                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
            MessageBox.Show("myProactive " + ver.Text + Environment.NewLine + "" + Environment.NewLine +
                "Developed by: " + Environment.NewLine + "" + Environment.NewLine +
                "rafal.adamczyk@dsv.com" + Environment.NewLine + Environment.NewLine +
                "EDI Support Team®", "myProactive", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string SetFilter()
        {
            // Filtr używany w metodzie ReadMailItems 
            string filter_today = "@SQL=" + "%today(" + "\"" + "DAV:getlastmodified" + "\"" + ")%";
            string filter_yesterday = "@SQL=" + "%yesterday(" + "\"" + "DAV:getlastmodified" + "\"" + ")%";
            string filter_thisweek = "@SQL=" + "%thisweek(" + "\"" + "DAV:getlastmodified" + "\"" + ")%";
            string filter_thismonth = "@SQL=" + "%thismonth(" + "\"" + "DAV:getlastmodified" + "\"" + ")%";
            string filter_lastmonth = "@SQL=" + "%lastmonth(" + "\"" + "DAV:getlastmodified" + "\"" + ")%";

            string selected = comboBoxTimeRange.GetItemText(comboBoxTimeRange.SelectedItem);

            if (selected == "Today")
            {
                filter = filter_today;
            }
            else if (selected == "Yesterday")
            {
                filter = filter_yesterday;
            }
            else if (selected == "This week")
            {
                filter = filter_thisweek;
            }
            else if (selected == "This month")
            {
                filter = filter_thismonth;
            }
            else if (selected == "Last month")
            {
                filter = filter_lastmonth;
            }
            return filter;
        }

        private int SetQuantity()
        {
            if (textBox1.Enabled == true)
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Please enter the quantity of items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //ilosc maili
                    selectedItems = textBox1.Text;
                    //konwertuje do integera cyfry z pola tekstowego
                    int selectedItemsInt = Convert.ToInt32(selectedItems);

                    number = selectedItemsInt;
                }
            }
            else
            {
                number = 1000;
            }

            return number;
        }

        //Funkcja która wydobywa plik excel i nadaje mu nazwę, po czym wrzuca ją do zmiennej publicznej excelname.
        private string ExcelFile()
        {
            LoginDSV login = new LoginDSV();
            ExtractResource resource = new ExtractResource();
            DateTime thisDay = DateTime.Today;

            DateTimeOffset theTime = new DateTimeOffset(2008, 3, 1, 14, 15, 00, DateTimeOffset.Now.Offset);
            
            string time = thisDay.ToString("ddMMyyyy") + "_" + theTime.Hour + theTime.Minute + theTime.Second;
            
            string excelname = "LW_ErrorAnalyze_" + login.Login() + "_" + time + ".xlsx";

            //Wydobywam plik
            resource.Extract("myProactive", @"C:\EDI", "Resources", "LW_ErrorAnalyze.xlsx");

            //Zmieniam nazwę pliku
            if (File.Exists(@"C:\EDI\LW_ErrorAnalyze.xlsx"))
            {
                File.Copy(@"C:\EDI\LW_ErrorAnalyze.xlsx", @"C:\EDI\" + excelname, true);
                File.Delete(@"C:\EDI\LW_ErrorAnalyze.xlsx");
            }

            //przypisuje nowo utworzony jako plik docelowy
            excelPath = @"C:\EDI\" + excelname;
            richTextBox_savepath.Text = excelPath;

            return excelname;
        }

        private void Button_go_Click(object sender, EventArgs e)
        {
            // pobierz ilość zadeklarowanych maili
            SetQuantity();
            
            // przypisz do zmiennej publicznej filter wybrany filtr z comboboxa
            SetFilter();

            // ustaw nazwe pliku
            ExcelFile();

            // Sprawdź czy backgroundWorker jest już zajęty wykonywaniem operacji asynchronicznej 
            if (!backgroundWorker1.IsBusy)
            {
                // Ta metoda uruchomi wykonanie asynchronicznie w tle 
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void CustomizeVerticalScroll()
        {
            // Upewniam się, że żadne elementy nie są wyświetlane częściowo. 
            listBox1.IntegralHeight = true;

            // Wyświetl poziomy pasek przewijania. 
            listBox1.HorizontalScrollbar = true;

            // Utwórz obiekt Graphics do użycia podczas określania rozmiaru największego elementu w ListBox. 
            Graphics g = listBox1.CreateGraphics();

            // Określ rozmiar dla HorizontalExtent przy użyciu metody MeasureString przy użyciu ostatniego elementu na liście. 
            int hzSize = (int)g.MeasureString(listBox1.Items[listBox1.Items.Count - 1].ToString(), listBox1.Font).Width;

            // Ustaw właściwość HorizontalExtent. 
            listBox1.HorizontalExtent = hzSize;
        }

		private void EnableTextBox(bool enable)
		{
            // Jeśli to zwróci true, oznacza to, że zostało wywołane z zewnętrznego wątku. 
            if (InvokeRequired)
			{
                // Utwórz delegata tej metody i pozwól formularzowi go uruchomić. 
                Invoke(new EnableDelegate(EnableTextBox), new object[] { enable });
				return;
			}
		}

        public static void ReleaseComObject(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
            if (Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        public void ReadMailItems(object sender, DoWorkEventArgs e)
        {
            OutlookApp.Application outlookApplication = null;
            OutlookApp.NameSpace outlookNamespace = null;
            OutlookApp.MAPIFolder inboxFolder = null;
            OutlookApp.Items mailItems = null;

            workerThread = Thread.CurrentThread;

            // Obiek + numer zakladki
            Excel excel = new Excel(excelPath, 1);

            // Wykorzystam to do nazwy kategorii w outlooku
            LoginDSV login = new LoginDSV();

            // Licznik maili (wszystkie)
            int i = 0;

            // Licznik maili zapisanych (uwzglednionych)
            int l = 0;

            int k1 = 1;
            int k2 = 1;
            int k3 = 1;
            int k4 = 1;
            int k5 = 1;
            int k6 = 1;
            int k7 = 1;
            int k8 = 1;
            int k9 = 1;

            string content = string.Empty;
            string content2 = string.Empty;
            string inc = "waiting to be created";
            string mailCategory = "[myProactive] handled by " + login.Login();

            excel.WriteToCell(2, 0, "");
            excel.WriteToCell(2, 1, "DATE");
            excel.WriteToCell(2, 2, "WFID");
            excel.WriteToCell(2, 3, "BP");
            excel.WriteToCell(2, 4, "SourceID");
            excel.WriteToCell(2, 5, "DestinationID");
            excel.WriteToCell(2, 6, "Error Description");
            excel.WriteToCell(2, 7, "Taken action");
            excel.WriteToCell(2, 8, "INC");

            excel.ReadCell(0, 0);

            try
            {
                outlookApplication = new OutlookApp.Application();
                outlookNamespace = outlookApplication.GetNamespace("MAPI");
                inboxFolder = outlookNamespace.Folders.Session.PickFolder();
                mailItems = inboxFolder.Items;

				OutlookApp.Items restrictedItems = mailItems.Restrict(filter);

                for (int j = 0; j <= restrictedItems.Count; j++)
                {
                    foreach (OutlookApp.MailItem item in mailItems)
                    {
                        // Licznik maili, zwiększam o 1 za każdym razem gdy obliczam kolejną pozycję mailową
                        i += 1;

                        // Licznik maili uwzblędnionych, zwiększam o 1 za każdym razem gdy pochodzę do kolejnego rekordu
                        l += 1;

                        //Start date
                        string startDate = item.CreationTime.ToString();

                        if ((i <= number)) //wczytaj tyle maili, ile zostalo wybranych w klasie Form1.cs
                        {
                            Invoke( //odpowiedź na: Nieprawidłowa operacja między wątkami.
                               new Action(() =>
                               {
                                   // Wywołanie metody ReportProgress() wywołuje zdarzenie ProgressChanged
                                   // Do tej metody należy przekazać procent przetwarzania, które zostało zakończone 
                                   backgroundWorker1.ReportProgress(i);

                                   // Przypisuje kategorie do obsłużonego maila
                                   if (checkBoxTagYes.Checked)
                                   {
                                       string existingCategories = item.Categories;

                                       if (string.IsNullOrEmpty(existingCategories))
                                       {
                                           item.Categories = mailCategory;
                                       }
                                       else
                                       {
                                           if (item.Categories.Contains(mailCategory) == false)
                                           {
                                               item.Categories = mailCategory;
                                           }
                                       }
                                       // Zapisuje maila po dodaniu kategorii
                                       item.Save();
                                   }
                                   var stringBuilder = new StringBuilder();

                                   string CreationTime = item.CreationTime.ToString();
                                   stringBuilder.AppendLine("Subject: " + item.Subject);
                                   stringBuilder.AppendLine("Body: " + item.Body);

                                   string body = item.Body.ToString();
                                   Marshal.ReleaseComObject(item);

                                   string sPattern = "LOCK";

                                   if (Regex.IsMatch(body, sPattern, RegexOptions.IgnoreCase))
                                   {
                                       listBox1.Items.Add("Item: " + i + " || " + "Skipping, found: Error description 'LOCK: Lock exists'");

                                       // Odejmuje z licznika pozycje z LOCK w opisie bledu, w dalszej czesci nie zapisuje i przechodze dalej.
                                       l -= 1;
                                   }
                                   else
                                   {
                                       //////////// extract WFID
                                       content = stringBuilder.ToString();
                                       int first = content.IndexOf(" = ") + " : ".Length;

                                       int last = content.LastIndexOf(" : ");
                                       string str2 = content.Substring(first, last - first);

                                       string wfid = string.Empty;

                                       Regex wyrazenie_wfid = new Regex(@"\d+");

                                       Match wfidTry = wyrazenie_wfid.Match(str2);

                                       if (wfidTry.Success)
                                       {
                                           wfid = wfidTry.Value;
                                       }
                                       else
                                       {
                                           wfid = "myProactive_error";
                                       }

                                       //////////// extract BP
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

                                       excel.ReadCell(1, 1);

                                       excel.WriteToCell(k1++, 0, l.ToString());
                                       excel.WriteToCell(k2++, 1, CreationTime);
                                       excel.WriteToCell(k3++, 2, wfid);
                                       excel.WriteToCell(k4++, 3, bp);
                                       excel.WriteToCell(k5++, 4, source_id);
                                       excel.WriteToCell(k6++, 5, source_destID);
                                       excel.WriteToCell(k7++, 6, source_error);
                                       excel.WriteToCell(k8++, 7, "no");
                                       excel.WriteToCell(k9++, 8, inc);

                                       ListBox("Item: " + i + " || " + "Date: " + CreationTime + " || " + "WFID: " + wfid + " || " +
                                       "BP: " + bp + " || " + "SourceID: " + source_id + " || " + "DestinationID: " + source_destID + " || " + source_error);

                                       // AktualizujProgres(i, number);
                                       CustomizeVerticalScroll();

                                       // Przewijam wraz z dodana pozycja
                                       listBox1.TopIndex = listBox1.Items.Count - 1;

                                       // Sprawdź, czy zażądano anulowania 
                                       if (backgroundWorker1.CancellationPending)
                                       {
                                           // Ustaw właściwość Cancel obiektu DoWorkEventArgs na true 
                                           e.Cancel = true;

                                           // Zresetuj procent postępu do ZERA 
                                           backgroundWorker1.ReportProgress(0);

                                           return;
                                       }
                                   }
                               }));
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //excel.Close();
                label5.Text = "Completed.";
                //Zapobiega propagacji ThreadAbortException
                //Thread.ResetAbort();
            }
            finally
            {
                ReleaseComObject(mailItems);
                ReleaseComObject(inboxFolder);
                ReleaseComObject(outlookNamespace);
                ReleaseComObject(outlookApplication);
            }

            if (workerThread != null)
            {
                e.Result = i;
                excel.Save();
                excel.Close();
                excel.KillSpecificExcelFileProcess("EXCEL.EXE");
            }

            return;
        }

        public void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy)
                {
                    // Anuluj operację asynchroniczną jeśli nadal trwa 
                    backgroundWorker1.CancelAsync();

                    if (workerThread != null)
                    {
                        workerThread.Abort();
                        workerThread = null;
                    }

                    backgroundWorker1.Dispose();
                    backgroundWorker1.ReportProgress(0);

                    // Czyszcze listbox po anulowaniu procesu
                    listBox1.Items.Clear();
                    label5.Text = "Processing cancelled.";

                    ListBox("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Processing cancelled.");

                    btnCancel.Enabled = false;
                }
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
        }

        public void AktualizujProgres(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Maximum = number;
            progressBar.Value = e.ProgressPercentage;
            label5.Text = "running, please wait";

            // Uaktywnij przycisk "Anuluj"
            btnCancel.Enabled = true;
        }
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label5.Text = "Processing cancelled";   
            }
            else if (e.Error != null)
            {
                ListBox("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + e.Error.Message);
            }
            else
            {
                label5.Text = "Completed.";

                // Dezaktywuj przycisk "anuluj" kiedy zakończy sie praca.
                btnCancel.Enabled = false;

                if (MessageBox.Show("Completed successfully. \n Would you like to open it?", "myProactive", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start(excelPath);
                }
            }
        }
        /*
		private void ButtonExtract_Click(object sender, EventArgs e)
		{
            ExtractResource click = new ExtractResource();
            //Wydobywam plik
            click.Extract("myProactive", @"C:\EDI", "Resources", "LW_ErrorAnalyze.xlsx");
        }
        */
		private void Ver_Click(object sender, EventArgs e)
		{

		}

		private void CleanEventViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
            listBox1.Items.Clear();
            ListBox("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "App is ready to use.");
        }

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void CheckBoxYes_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxYes.Checked)
            {
                checkBoxNo.Checked = false;
                textBox1.Enabled = true;
            }
            else
            {
                checkBoxNo.Checked = true;
                textBox1.Enabled = false;
            }
        }

		private void CheckBoxNo_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxNo.Checked)
            {
                checkBoxYes.Checked = false;
                textBox1.Enabled = false;
            }
            else
            {
                checkBoxYes.Checked = true;
                textBox1.Enabled = true;
            }
        }

		private void CheckBoxTagYes_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxTagYes.Checked)
            {
                checkBoxTagNo.Checked = false;
            }
            else
            {
                checkBoxTagNo.Checked = true;
            }
        }

		private void CheckBoxTagNo_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxTagNo.Checked)
            {
                checkBoxTagYes.Checked = false;
            }
            else
            {
                checkBoxTagYes.Checked = true;
            }
        }

        private void ListBox(string value)
        {
			_ = listBox1.Items.Add(value);
        }
	}
}
