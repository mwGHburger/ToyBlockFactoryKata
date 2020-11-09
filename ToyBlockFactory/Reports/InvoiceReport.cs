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
        private IReportTable _reportTable;

        public InvoiceReport(IConsoleIO consoleIO, List<IColour> colours, List<IShape> shapes, IStandardReportMessages standardReportMessages, IReportTable reportTable)
        {
            _consoleIO = consoleIO;
            _colours = colours;
            _shapes = shapes;
            _standardReportMessages = standardReportMessages;
            _reportTable = reportTable;
        }
        public void GenerateReport(IOrder order)
        {
            var costInformation = CreateCostInformation(order);
            _consoleIO.Write(
                _standardReportMessages.GenerateReportConfirmation(ReportType) +
                _standardReportMessages.DisplayCustomerDetails(order) +
                _reportTable.CreateTable(order) +
                costInformation
            );
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
        private string AddLineBreak(string text)
        {
            return text += "\n";
        }
    }
}