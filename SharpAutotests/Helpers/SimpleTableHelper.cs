using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Helpers
{
    class SimpleTableHelper
    {
        List<TableData> _table = new List<TableData>();

        public void ReadTable(IWebElement table)
        {
            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));

            int rowIndex = 0;
            foreach(var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _table.Add(new TableData
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text,
                        ColumnValue = colValue.Text
                    });
                    colIndex++;
                }
                rowIndex++;

            }
        }

        public string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _table
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;
        }
    }
}
