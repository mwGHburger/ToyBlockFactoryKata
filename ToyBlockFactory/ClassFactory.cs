using System.Collections.Generic;

namespace ToyBlockFactory
{
    public static class ClassFactory
    {
        public static ApplicationRouter CreateApplication()
        {
            return new ApplicationRouter(CreateApplicationController(), CreateConsoleIO());
        }

        public static IApplicationController CreateApplicationController()
        {
            return new ApplicationController(CreateOrderTaker(), CreateReportGenerator());
        }

        // TODO: Why not IConsoleIO
        public static IConsoleIO CreateConsoleIO()
        {
            return new ConsoleIO();
        }

        public static IOrderTaker CreateOrderTaker()
        {
            return new OrderTaker(CreateCustomerInformationCollector(), CreateOrderListGenerator(), CreateOrderNumberTracker());
        }

        public static ICustomerInformationCollector CreateCustomerInformationCollector()
        {
            return new CustomerInformationCollector(CreateConsoleIO());
        }
        public static IOrderListGenerator CreateOrderListGenerator()
        {
            return new BlockOrderListGenerator(CreateConsoleIO(), CreateShapes(), CreateColours());
        }

        public static List<IShape> CreateShapes()
        {
            return new List<IShape>()
            {
                new Square(),
                new Triangle(),
                new Circle()
            };
        }
        public static List<IColour> CreateColours()
        {
            return new List<IColour>()
            {
                new Red(),
                new Blue(),
                new Yellow()
            };
        }

        public static IOrderNumberTracker CreateOrderNumberTracker()
        {
            return new OrderNumberTracker();
        }

        public static IReportGenerator CreateReportGenerator()
        {
            return new ReportsGenerator(CreateReportTypes());
        }

        public static List<IReport> CreateReportTypes()
        {
            return new List<IReport>()
            {
                new InvoiceReport(CreateConsoleIO(), CreateColours(), CreateShapes(), CreateStandardReportMessages(), CreateInvoiceReportTable()),
                // TODO: Fix parameter order
                new CuttingListReport(CreateConsoleIO(), CreateStandardReportMessages(), CreateCuttingListReportTable()),
                new PaintingReport(CreateConsoleIO(), CreateInvoiceReportTable(), CreateStandardReportMessages())
            };
        }

        public static IStandardReportMessages CreateStandardReportMessages()
        {
            return new StandardReportMessages();
        }

        public static IReportTable CreateInvoiceReportTable()
        {
            return new ReportTable(CreateColumns(), CreateRows(), CreateInvoiceFieldData());
        }

        public static IReportTable CreateCuttingListReportTable()
        {
            return new ReportTable(CreateColumns(), CreateRows(), CreateCuttingListFieldData());
        }

        // TODO: Fix this implementation
        public static List<string> CreateColumns()
        {
            return new List<string>()
            {
                "Red",
                "Blue",
                "Yellow"
            };
        }

        public static List<string> CreateRows()
        {
            return new List<string>()
            {
                "Square",
                "Triangle",
                "Circle"
            };
        }

        public static IFieldData CreateInvoiceFieldData()
        {
            return new InvoiceFieldData();
        }
        
        public static IFieldData CreateCuttingListFieldData()
        {
            return new CuttingListFieldData();
        }
    }
}