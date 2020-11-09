using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class InvoiceReport : IReport
    {
        public string ReportType { get; } = "Invoice Report";
        private IConsoleIO _consoleIO;
        private List<IColour> _colours;
        private List<IShape> _shapes;
        private IStandardReportMessages _standardReportMessages;
        private int _longestRowLength;

        public InvoiceReport(IConsoleIO consoleIO, List<IColour> colours, List<IShape> shapes, IStandardReportMessages standardReportMessages)
        {
            _consoleIO = consoleIO;
            _colours = colours;
            _shapes = shapes;
            _standardReportMessages = standardReportMessages;
            _longestRowLength = FindLongestRowLength();
        }
        public void GenerateReport(IOrder order)
        {
            var rows = CreateTableRows();
            var columns = CreateTableColumns();
            var tableHeader = CreateTableHeader(columns);
            var breaker = CreateTableBreaker(columns);
            var tableBody = CreateTableBody(order, rows, columns);
            var costInformation = CreateCostInformation(order);
            _consoleIO.Write(
                _standardReportMessages.GenerateReportConfirmation(ReportType) +
                _standardReportMessages.DisplayCustomerDetails(order) +
                tableHeader +
                breaker +
                tableBody +
                costInformation
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
                    var tableFieldData = DetermineTableFieldData(order, row, column);
                    body += $" {tableFieldData.PadRight(column.Length)} |";
                }
                body = AddLineBreak(body);
            }
            return body;
        }

        private string CreateCostInformation(IOrder order)
        {
            var costInformation = "";
            var additionalPadding = 14;
            foreach(IShape shape in _shapes)
            {
                var blocks = order.Blocks.FindAll(x => x.Shape.Equals(shape.Name));
                var quantity = 0;
                foreach(IBlockOrderItem block in blocks)
                {
                    quantity += block.OrderQuantity;
                }
                var totalCost = shape.Cost * quantity;
                costInformation += AddLineBreak($"{shape.Name.PadRight(additionalPadding)} {quantity} @ ${shape.Cost} ppi = ${totalCost}");
            }
            costInformation += CreateSurcharge("Red", order.Blocks);
            return costInformation;
        }

        private string CreateSurcharge(string colourName, List<IBlockOrderItem> blocks)
        {
            var colouredBlocks = blocks.FindAll(x => x.Colour.Equals(colourName));
            var colour = _colours.Find(x => x.Name.Equals(colourName));
            var quantity = 0;
            foreach(IBlockOrderItem block in colouredBlocks)
            {
                quantity += block.OrderQuantity;
            }
            var totalCharge = colour.Surcharge * quantity;
            return AddLineBreak($"{colourName} color surcharge    {quantity} @ ${colour.Surcharge} ppi = ${totalCharge}");
        }

        private string DetermineTableFieldData(IOrder order, string row, string column)
        {
            var fieldData = order.Blocks.Find(block => 
                block.Colour.Equals(column) && 
                block.Shape.Equals(row)
            ).OrderQuantity;
            
            var stringifiedQuantity = fieldData.Equals(0) ? "-" : $"{fieldData}";
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
            var columns = new List<string>();
            _colours.ForEach(colour => columns.Add(colour.Name));
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