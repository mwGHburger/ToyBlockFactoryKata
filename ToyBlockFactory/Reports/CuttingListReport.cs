using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class CuttingListReport :  IReport
    {
        private IConsoleIO _consoleIO;
        private List<IShape> _shapes;
        private List<IColour> _colours;
        private IStandardReportMessages _standardReportMessages;
        public string ReportType { get; } = "Cutting List";
        private int _longestRowLength;

        public CuttingListReport(IConsoleIO consoleIO, List<IShape> shapes, List<IColour> colours, IStandardReportMessages standardReportMessages)
        {
            _consoleIO = consoleIO;
            _shapes = shapes;
            _colours = colours;
            _standardReportMessages = standardReportMessages;
            _longestRowLength = FindLongestRowLength();
        }
        public void GenerateReport(IOrder order)
        {
            var rows = CreateTableRows();
            var columns = CreateTableColumns();
            _consoleIO.Write(
                _standardReportMessages.GenerateReportConfirmation(ReportType) +
                _standardReportMessages.DisplayCustomerDetails(order) +
                CreateTableHeader(columns) +
                CreateTableBreaker(columns) +
                CreateTableBody(order, rows, columns)
            );
        }

        private string CreateTableHeader(List<string> columns)
        {
            var emptySpace = " ";
            var tableHeader = $"| {emptySpace.PadRight(_longestRowLength)} |";
            columns.ForEach(column => tableHeader += $" {column} |");
            tableHeader = AddLineBreak(tableHeader);
            return tableHeader;
        }

        private string CreateTableBreaker(List<string> columns)
        {
            var line = '-';
            var extraPadding = 2;
            var breaker = $"|{line.ToString().PadRight(_longestRowLength + extraPadding, line)}|";
            columns.ForEach(column => breaker += $"{line.ToString().PadRight(column.Length + extraPadding, line)}|");
            return AddLineBreak(breaker);
        }

        private string CreateTableBody(IOrder order, List<string> rows, List<string> columns)
        {
            var body = "";
            foreach(string row in rows)
            {
                body += $"| {row.PadRight(_longestRowLength)} |";
                foreach(string column in columns)
                {
                    var tableFieldQuantity = FormatTableFieldData(row, column, order);
                    body += $" {tableFieldQuantity.PadRight(column.Length)} |";
                }
                body = AddLineBreak(body);
            }
            return body;
        }
        private string FormatTableFieldData(string row, string column, IOrder order)
        {
            var shapeQuantity = 0;
            var blocks = order.Blocks.FindAll(block => 
                block.Shape.Equals(row)
            );
            blocks.ForEach(block => shapeQuantity += block.OrderQuantity);
            var stringifiedQuantity = shapeQuantity == 0 ? "-" : $"{shapeQuantity}";
            return stringifiedQuantity;
        }

        private List<string> CreateTableRows()
        {
            var rows = new List<string>();
            _shapes.ForEach(shape => rows.Add(shape.Name));
            return rows;
        }

        private List<string> CreateTableColumns()
        {
            var columns = new List<string>()
            {
                "Qty"
            };
            return columns;
        }
        private int FindLongestRowLength()
        {
            int maxRowLength = 0;
            foreach(IShape shape in _shapes)
            {
                if(shape.Name.Length > maxRowLength)
                {
                    maxRowLength = shape.Name.Length;
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