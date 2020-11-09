using System.Collections.Generic;

namespace ToyBlockFactory
{
    public static class ClassFactory
    {
        public static ApplicationRouter CreateApplication()
        {
            return new ApplicationRouter(CreateApplicationController(), CreateConsoleIO(), CreateStandardApplicationMessages());
        }

        public static IApplicationController CreateApplicationController()
        {
            return new ApplicationController(CreateOrderTaker(), CreateReportGenerator());
        }

        public static IConsoleIO CreateConsoleIO()
        {
            return new ConsoleIO();
        }

        public static IStandardApplicationMessages CreateStandardApplicationMessages()
        {
            return new StandardApplicationMessages();
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
                new InvoiceReport(
                    CreateConsoleIO(), 
                    CreateColours(), 
                    CreateShapes(), 
                    CreateStandardReportMessages(), 
                    CreateInvoiceReportTable()),
                new CuttingListReport(
                    CreateConsoleIO(), 
                    CreateStandardReportMessages(), 
                    CreateCuttingListReportTable()),
                new PaintingReport(
                    CreateConsoleIO(), 
                    CreateStandardReportMessages(), 
                    CreateInvoiceReportTable())
            };
        }

        public static IStandardReportMessages CreateStandardReportMessages()
        {
            return new StandardReportMessages();
        }

        public static IReportTable CreateInvoiceReportTable()
        {
            return new ReportTable(
                CreateInvoiceReportColumns(), 
                CreateRows(), 
                CreateInvoiceFieldData());
        }

        public static IReportTable CreateCuttingListReportTable()
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

        // TODO: Fix this implementation
        public static List<string> CreateInvoiceReportColumns()
        {
            var columns = CreateColours();
            var newColumns = new List<string>();
            foreach(IColour colour in columns)
            {
                newColumns.Add(colour.Name);
            }
            return newColumns;
        }

        public static List<string> CreateRows()
        {
            var columns = CreateShapes();
            var newColumns = new List<string>();
            foreach(IShape colour in columns)
            {
                newColumns.Add(colour.Name);
            }
            return newColumns;
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