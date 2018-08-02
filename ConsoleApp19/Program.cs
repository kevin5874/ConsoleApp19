using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
//So the biggest downside to this style of program that I can forsee is that it's only going to work if the data is formated in excell
//correctly.
namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(@"C:\Users\kevin\Downloads\TestBook.xlsx");//place the path to an excel doc here
            Excel.Worksheet sheet = wb.Sheets[1];
            Excel.Range range = sheet.UsedRange;
            List<Employee> emps = new List<Employee>();
            for(int i = 2; i <= range.Rows.Count; i++)
            {
                int j = 1;

                string s = sheet.Cells[i, 1].Value;
                string a = sheet.Cells[i, j + 1].Value;
                string b = sheet.Cells[i, j + 2].Value.ToString();
                string c = sheet.Cells[i, j + 3].Value;
                string d = sheet.Cells[i, j + 4].Value;
                string e =sheet.Cells[i, j + 5].Value.ToString();
                DateTime f =sheet.Cells[i, j + 6].Value;

                    emps.Add(new Employee(s,a,b,c,d,e,f));
               
                
            }
            foreach(Employee emp in emps)//loops through any employees in the list
            {
                emp.ToDB();//calls a method to add them to the DB
            }

        }
    }
}
