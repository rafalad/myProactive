﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

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
			//
			i++;
			j++;
			if (ws.Cells[i, j].Value2 != null)
				return ws.Cells[i, j].Value2;
			else
				return "";
		}

		public void WriteToCell(int i, int j, string s)
		{
			//ws.Cells[1, 1].Column.
			//ws.Cells.Borders.
			//ws.Cells.EntireColumn.AutoFit(); // dostosowanie kalumny szerokoc
			//ws.Columns.AutoFitContents();
			//ws.Cells.EntireRow.BorderAround2();
			//ws.Cells[1, 1].EntireRow.Font.Bold = true;
			//.Style.EntireColumn.AutoFit();
			i++;
			j++;
			ws.Cells[i, j].Value2 = s;
			//ws.Cells.FormulaHidden = false;
		}

		public void CopyCell(int i, int j)
		{
			_Excel.Range sourceRange = ws.Cells[2, 10];
			_Excel.Range destinationRange = ws.Cells[i, j];

			sourceRange.Copy(Type.Missing);
			destinationRange.PasteSpecial(XlPasteType.xlPasteFormulas, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
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
