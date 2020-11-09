using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ReportTable : IReportTable
    {
        private IFieldData _fieldData;
        private List<string> _columns;
        private List<string> _rows;
        private int _longestRowLength;

        public ReportTable(List<string> columns, List<string> rows, IFieldData fieldData)
        {
            _columns = columns;
            _rows = rows;
            _longestRowLength = FindLongestRowLength();
            _fieldData = fieldData;
        }

        public string CreateTable(IOrder order)
        {
            var tableHeader = CreateTableHeader();
            var tableBreaker = CreateTableBreaker();
            var tableBody = CreateTableBody(order);

            return tableHeader + tableBreaker + tableBody;
        }
        private string CreateTableHeader()
        {
            var emptySpace = " ";
            var tableHeader = $"| {emptySpace.PadRight(_longestRowLength)} |";
            _columns.ForEach(column => tableHeader += $" {column} |");
            tableHeader = AddLineBreak(tableHeader);
            return tableHeader;
        }

        private string CreateTableBreaker()
        {
            var line = '-';
            var extraPadding = 2;
            var breaker = $"|{line.ToString().PadRight(_longestRowLength + extraPadding, line)}|";
            _columns.ForEach(column => breaker += $"{line.ToString().PadRight(column.Length + extraPadding, line)}|");
            return AddLineBreak(breaker);
        }

        private string CreateTableBody(IOrder order)
        {
            var body = "";
            foreach(string row in _rows)
            {
                body += $"| {row.PadRight(_longestRowLength)} |";
                foreach(string column in _columns)
                {
                    var tableFieldQuantity = _fieldData.DetermineTableFieldData(order, row, column);
                    body += $" {tableFieldQuantity.PadRight(column.Length)} |";
                }
                body = AddLineBreak(body);
            }
            return body;
        }

        private int FindLongestRowLength()
        {
            int maxRowLength = 0;
            foreach(string row in _rows)
            {
                if(row.Length > maxRowLength)
                {
                    maxRowLength = row.Length;
                }
            }
            return maxRowLength;
        }

        private string AddLineBreak(string text)
        {
            return text += "\n";
        }
    }
}