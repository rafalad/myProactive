using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace myProactive
{
	public class Excel
	{
		string path = "";
		_Application excel = new _Excel.Application();
		Workbook wb;
		Worksheet ws;

		public Excel(string path, int sheet)
		{
			this.path = path;
			wb = excel.Workbooks.Open(path);
			ws = wb.Worksheets[sheet];
		}

		public string ReadCell(int i, int j)
		{
			i++;
			j++;
			if (ws.Cells[i, j].Value2 != null)
				return ws.Cells[i, j].Value2;
			else
				return "";
		}

		public void WriteToCell(int i, int j, string s)
		{
			i++;
			j++;
			ws.Cells[i, j].Value2 = s;
		}
		public void Save()
		{
			wb.Save();
		}
		public void SaveAs(string path)
		{
			wb.SaveAs(path);
		}
		public void Close()
		{
			wb.Close();
		}

		public void Quit()
		{
			wb.Close();
			excel.Quit();
		}

		public void KillSpecificExcelFileProcess(string excelFileName)
		{
			var processes = from p in Process.GetProcessesByName("EXCEL.EXE")
							select p;

			foreach (var process in processes)
			{
				if (process.MainWindowTitle == excelFileName)
					process.Kill();
			}
		}
	}
}
