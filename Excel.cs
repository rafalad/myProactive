using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace myProactive
{
	public class Excel
	{
		readonly string path = "";
		readonly _Application excel = new Application();
		readonly Workbook wb;
		readonly Worksheet ws;

		public Excel(string path, int sheet)
		{
			if (path == "blank")
			{

			}
			else
			{
				this.path = path;
				wb = excel.Workbooks.Open(path);
				ws = wb.Worksheets[sheet];
			}
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
		/*
		public void CopyCell(int i, int j)
		{
			Range sourceRange = ws.Cells[2, 10];
			Range destinationRange = ws.Cells[i, j];

			sourceRange.Copy(Type.Missing);
			destinationRange.PasteSpecial(XlPasteType.xlPasteFormulas, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
		}
		*/
		public void Save()
		{
			wb.Save();
		}
		/*
		public void SaveAs(string path)
		{
			wb.SaveAs(path);
		}
		*/
		public void Close()
		{
			wb.Close();
			excel.Quit();
		}

		public void KillSpecificExcelFileProcess(string excelFileName)
		{
			var processes = from p in Process.GetProcessesByName(excelFileName)
							select p;

			foreach (var process in processes)
			{
				if (process.MainWindowTitle == excelFileName)
					process.Kill();
			}
		}
	}
}
