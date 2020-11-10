using System.Collections.Generic;

namespace ToyBlockFactory
{
    public static class ClassFactory
    {
        private static List<IShape> _shapes = CreateShapes();
        private static List<IColour> _colours = CreateColours();
        private static IConsoleIO _consoleIO = CreateConsoleIO();
        private static IStandardReportMessages _standardReportMessages = CreateStandardReportMessages();

        public static IApplicationRouter CreateApplication()
        {
            return new ApplicationRouter(CreateApplicationController(), _consoleIO, CreateStandardApplicationMessages());
        }

        private static IApplicationController CreateApplicationController()
        {
            return new ApplicationController(CreateOrderTaker(), CreateReportGenerator());
        }

        private static IConsoleIO CreateConsoleIO()
        {
            return new ConsoleIO();
        }

        private static IStandardApplicationMessages CreateStandardApplicationMessages()
        {
            return new StandardApplicationMessages();
        }

        private static IOrderTaker CreateOrderTaker()
        {
            return new OrderTaker(CreateCustomerInformationCollector(), CreateOrderListGenerator(), CreateOrderNumberTracker());
        }

        private static ICustomerInformationCollector CreateCustomerInformationCollector()
        {
            return new CustomerInformationCollector(_consoleIO);
        }
        private static IOrderListGenerator CreateOrderListGenerator()
        {
            return new BlockOrderListGenerator(_consoleIO, _shapes, _colours);
        }

        private static List<IShape> CreateShapes()
        {
            return new List<IShape>()
            {
                new Square(),
                new Triangle(),
                new Circle()
            };
        }
        private static List<IColour> CreateColours()
        {
            return new List<IColour>()
            {
                new Red(),
                new Blue(),
                new Yellow()
            };
        }

        private static IOrderNumberTracker CreateOrderNumberTracker()
        {
            return new OrderNumberTracker();
        }

        private static IReportGenerator CreateReportGenerator()
        {
            return new ReportGenerator(CreateReportTypes());
        }

        private static List<IReport> CreateReportTypes()
        {
            return new List<IReport>()
            {
                new InvoiceReport(
                    _consoleIO, 
                    _colours, 
                    _shapes, 
                    _standardReportMessages, 
                    CreateInvoiceReportTable()),
                new CuttingListReport(
                    _consoleIO, 
                    _standardReportMessages, 
                    CreateCuttingListReportTable()),
                new PaintingReport(
                    _consoleIO, 
                    _standardReportMessages, 
                    CreateInvoiceReportTable())
            };
        }

        private static IStandardReportMessages CreateStandardReportMessages()
        {
            return new StandardReportMessages();
        }

        private static IReportTable CreateInvoiceReportTable()
        {
            return new ReportTable(
                CreateInvoiceReportColumns(), 
                CreateRows(), 
                CreateInvoiceFieldData());
        }

        private static IReportTable CreateCuttingListReportTable()
        {
            var columns = new List<string>()
            {
                "Qty"
            };
            return new ReportTable(
                columns, 
                CreateRows(), 
                CreateCuttingListFieldData());
        }

        private static List<string> CreateInvoiceReportColumns()
        {
            var newColumns = new List<string>();
            foreach(IColour colour in _colours)
            {
                newColumns.Add(colour.Name);
            }
            return newColumns;
        }

        private static List<string> CreateRows()
        {
            var newColumns = new List<string>();
            foreach(IShape shape in _shapes)
            {
                newColumns.Add(shape.Name);
            }
            return newColumns;
        }

        private static IFieldData CreateInvoiceFieldData()
        {
            return new InvoiceFieldData();
        }
        
        private static IFieldData CreateCuttingListFieldData()
        {
            return new CuttingListFieldData();
        }
    }
}