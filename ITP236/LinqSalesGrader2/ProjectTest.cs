using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqSalesStudent;
using LinqSalesProjectGrader2;

namespace LinqSalesGrader2
{
    public class ProjectTest
    {
        public string StudentName { get; private set; }
        internal ProjectTest(ProjectData data, List<Topic> topics)
        {
            foreach (var topic in topics)
                GradeTopic(data, topic);
        }
        private void GradeTopic(ProjectData data, Topic topic)
        {
            foreach (var test in topic.Tests)
                GradeTest(data, test);
        }
        private void GradeTest(ProjectData data, Test test)
        {
            switch (test.Method)
            {
                #region Customer
                case "CustomerTotalSales":
                    CustomerTotalSales(data, test);
                    break;
                case "CustomerItemsSold":
                    CustomerItemsSold(data, test);
                    break;
                case "CustomerTotalCost":
                    CustomerTotalCost(data, test);
                    break;
                case "CustomerGrossProfit":
                    CustomerGrossProfit(data, test);
                    break;
                case "CustomerLargestSale":
                    CustomerLargestSale(data, test);
                    break;
                case "CustomerCustomerItems":
                    CustomerCustomerItems(data, test);
                    break;
                #endregion
                #region Part
                case "PartStudentName":
                    PartStudentName(data, test);
                    break;
                case "PartQuantityOnHand":
                    PartQuantityOnHand(data, test);
                    break;
                case "PartUnitsReceived":
                    PartUnitsReceived(data, test);
                    break;
                case "PartUnitsSold":
                    PartUnitsSold(data, test);
                    break;
                case "PartUnitsShipped":
                    PartUnitsShipped(data, test);
                    break;
                case "PartUnitsSpoiled":
                    PartUnitsSpoiled(data, test);
                    break;
                case "PartCurrentValue":
                    PartCurrentValue(data, test);
                    break;
                case "PartAmountSold":
                    PartAmountSold(data, test);
                    break;
                case "PartAmountReceived":
                    PartAmountReceived(data, test);
                    break;
                case "PartAmountShipped":
                    PartAmountShipped(data, test);
                    break;
                case "PartAmountSpoiled":
                    PartAmountSpoiled(data, test);
                    break;
                case "PartVendors":
                    PartVendors(data, test);
                    break;
                #endregion
                #region SalesOrder
                case "SalesOrderItemsSold":
                    SalesOrderItemsSold(data, test);
                    break;
                case "SalesOrderItemsShipped":
                    SalesOrderItemsShipped(data, test);
                    break;
                case "SalesOrderBackOrdered":
                    SalesOrderBackOrdered(data, test);
                    break;
                case "SalesOrderTotal":
                    SalesOrderTotal(data, test);
                    break;
                case "SalesOrderCost":
                    SalesOrderCost(data, test);
                    break;
                case "SalesOrderGrossProfit":
                    SalesOrderGrossProfit(data, test);
                    break;
                #endregion
                #region SalesOrderPart
                case "SalesOrderPartExtendedPrice":
                    SalesOrderPartExtendedPrice(data, test);
                    break;
                case "SalesOrderPartExtendedCost":
                    SalesOrderPartExtendedCost(data, test);
                    break;
                case "SalesOrderPartGrossProfit":
                    SalesOrderPartGrossProfit(data, test);
                    break;
                case "SalesOrderPartUnitsShipped":
                    SalesOrderPartUnitsShipped(data, test);
                    break;
                #endregion
                #region PurchaseOrder
                case "PurchaseOrderTotal":
                    PurchaseOrderTotal(data, test);
                    break;
                #endregion
                #region PurchaseOrderPart
                case "PurchaseOrderPartExtendedCost":
                    PurchaseOrderPartExtendedCost(data, test);
                    break;
                #endregion
                #region Receipt
                case "ReceiptUnitCost":
                    ReceiptUnitCost(data, test);
                    break;
                #endregion
                #region Spoilage
                case "SpoilageExtendedCost":
                    SpoilageExtendedCost(data, test);
                    break;
                #endregion
                #region Shipment
                case "ShipmentAmount":
                    ShipmentAmount(data, test);
                    break;
                #endregion
                #region ShipmentPart
                case "ShipmentPartExtendedCost":
                    ShipmentPartExtendedCost(data, test);
                    break;
                #endregion
                #region Vendor
                case "VendorTotalPurchases":
                    VendorTotalPurchases(data, test);
                    break;
                case "VendorItemsSold":
                    VendorItemsSold(data, test);
                    break;
                    #endregion
            }
        }
        #region Part
        private void PartStudentName(ProjectData data, Test test)
        {
            test.Grade = string.IsNullOrEmpty(Part.StudentName) ? 0 : test.Value;
            StudentName = Part.StudentName;
        }
        #region Quantities
        #region QuantityOnHand
        private void PartQuantityOnHand(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new [] {"PartId", "QoH", "= Receipts", "- Spoilages", "- Shipments", string.Empty, string.Empty, string.Empty};
            
            foreach (var part in data.Parts)
                PartQuantityOnHand(part, test);
        }
        public void PartQuantityOnHand(Part part, Test test)
        {
            var student = part.QuantityOnHand;
            var result = new LinqSalesProjectGraderAnswer.Part(part);
            int receipts = result.UnitsReceived;
            int spoilages = result.UnitsSpoiled;
            int shipmentParts = result.UnitsShipped;
            var answer = receipts - spoilages - shipmentParts;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student}",
                Value2 = $"{part.UnitsReceived}",
                Value3 = $"{part.UnitsSpoiled}",
                Value4 = $"{part.UnitsShipped}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer}",
                Value2 = $"{receipts}",
                Value3 = $"{spoilages}",
                Value4 = $"{shipmentParts}"
            });
        }
        #endregion
        #region UnitsReceived
        private void PartUnitsReceived(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Received", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };

            foreach (var part in data.Parts)
                PartUnitsReceived(part, test);
        }
        public void PartUnitsReceived(Part part, Test test)
        {
            var student = part.UnitsReceived;
            var result = new LinqSalesProjectGraderAnswer.Part(part);
            int answer = result.UnitsReceived;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #region UnitsSold
        private void PartUnitsSold(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Units Sold", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartUnitsSold(part, test);
        }
        public void PartUnitsSold(Part part, Test test)
        {
            var student = part.UnitsSold;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            int answer = result.UnitsSold;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #region UnitsShipped
        private void PartUnitsShipped(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Units Shipped", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartUnitsShipped(part, test);
        }
        public void PartUnitsShipped(Part part, Test test)
        {
            var student = part.UnitsShipped;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            int answer = result.UnitsShipped;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #region UnitsSpoiled
        private void PartUnitsSpoiled(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Spoiled", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartUnitsSpoiled(part, test);
        }
        public void PartUnitsSpoiled(Part part, Test test)
        {
            var student = part.UnitsSpoiled;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            var answer = result.UnitsSpoiled;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #endregion  
        #region Amounts
        #region CurrentValue
        private void PartCurrentValue(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Current Value", "= Receipts", "- Spoilages", "- Shipments", string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartCurrentValue(part, test);
        }
        public void PartCurrentValue(Part part, Test test)
        {
            var student = part.CurrentValue;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            //var receipts = part.Receipts.Sum(r => r.TotalCost + r.ShippingAndHandling);
            //var spoilages = part.Spoilages.Sum(s => s.ExtendedCost);
            //var shipmentParts = part.ShipmentParts.Sum(sp => sp.ExtendedCost);
            var answer = result.CurrentValue;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student:c}",
                Value2 = $"{part.AmountReceived:c}",
                Value3 = $"{part.AmountSpoiled:c}",
                Value4 = $"{part.AmountShipped:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer:c}",
                Value2 = $"{result.AmountReceived:c}",
                Value3 = $"{result.AmountSpoiled:c}",
                Value4 = $"{result.AmountShipped:c}"
            });
        }
        #endregion
        #region AmountReceived
        private void PartAmountReceived(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Amount Received", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartAmountReceived(part, test);
        }
        public void PartAmountReceived(Part part, Test test)
        {
            var student = part.AmountReceived;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            var answer = result.AmountReceived;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region AmountSold
        private void PartAmountSold(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Amount Sold", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartAmountSold(part, test);
        }
        public void PartAmountSold(Part part, Test test)
        {
            var student = part.AmountSold;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            var answer = result.AmountSold;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region AmountShipped
        private void PartAmountShipped(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Amount Shipped", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartAmountShipped(part, test);
        }
        public void PartAmountShipped(Part part, Test test)
        {
            var student = part.AmountShipped;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            var answer = result.AmountShipped;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region AmountSpoiled
        private void PartAmountSpoiled(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "Amount Spoiled", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartAmountSpoiled(part, test);
        }
        public void PartAmountSpoiled(Part part, Test test)
        {
            var student = part.AmountSpoiled;
            var result = new LinqSalesProjectGraderAnswer.Part(part);

            var answer = result.AmountSpoiled;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = part.PartId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #endregion
        #region Vendors
        private void PartVendors(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PartId", "VendorId", "Vendor Name", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var part in data.Parts)
                PartVendors(part, test);
        }
        public void PartVendors(Part part, Test test)
        {
            var student = part.Vendors;
            var result = new LinqSalesProjectGraderAnswer.Part(part);
            
            var answer = result.Vendors;
            if (student.Count != answer.Count)
                test.Grade = 0;
            for (int i = 0; i < answer.Count; i++)
            {
                test.AnswerResults.Add(new Result()
                {
                    Id = part.PartId,
                    Value1 = $"{answer[i].VendorId}",
                    Value2 = answer[i].Name
                });
                if (i < student.Count)
                {
                    test.StudentResults.Add(new Result()
                    {
                        Id = part.PartId,
                        Value1 = $"{student[i].VendorId}",
                        Value2 = student[i].Name
                    });
                    if (student[i].VendorId != answer[i].VendorId
                        || student[i].Name != answer[i].Name)
                        test.Grade = 0;
                }
            }
        }
        #endregion
        #endregion

        #region Customer
        #region TotalSales
        private void CustomerTotalSales(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "CustomerId", "Total Sales", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.Customers)
                CustomerTotalSales(cust, test);
        }
        public void CustomerTotalSales(Customer cust, Test test)
        {
            var student = cust.TotalSales;
            var result = new LinqSalesProjectGraderAnswer.Customer(cust);
            var answer = result.TotalSales;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region TotalCost
        private void CustomerTotalCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "CustomerId", "Total Cost", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.Customers)
                CustomerTotalCost(cust, test);
        }
        public void CustomerTotalCost(Customer cust, Test test)
        {
            var student = cust.TotalCost;
            var result = new LinqSalesProjectGraderAnswer.Customer(cust);

            var answer = result.TotalCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region ItemsSold
        private void CustomerItemsSold(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "CustomerId", "Items Sold", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.Customers)
                CustomerItemsSold(cust, test);
        }
        public void CustomerItemsSold(Customer cust, Test test)
        {
            var student = cust.ItemsSold;
            var result = new LinqSalesProjectGraderAnswer.Customer(cust);

            var answer = result.ItemsSold;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #region GrossProfit
        private void CustomerGrossProfit(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "CustomerId", "Gross Profit =", "Total Sales -", "Total Cost", string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.Customers)
                CustomerGrossProfit(cust, test);
        }
        public void CustomerGrossProfit(Customer cust, Test test)
        {
            var student = cust.GrossProfit;
            var result = new LinqSalesProjectGraderAnswer.Customer(cust);

            var answerSales = result.TotalSales;
            var answerCost = result.TotalCost;
            var answer = answerSales - answerCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{student:c}",
                Value2 = $"{cust.TotalSales:c}",
                Value3 = $"{cust.TotalCost:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{answer:c}",
                Value2 = $"{answerSales:c}",
                Value3 = $"{answerCost:c}"
            });
        }
        #endregion
        #region LargestSale
        private void CustomerLargestSale(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "CustomerId", "Sales Order #", "Order Total", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.Customers)
                CustomerLargestSale(cust, test);
        }
        public void CustomerLargestSale(Customer cust, Test test)
        {
            var student = cust.LargestSale;
            var result = new LinqSalesProjectGraderAnswer.Customer(cust);

            var answer = result.LargestSale;
            if (student == null && answer != null)
            {
                test.Grade = 0;
                return;
            }
            if (student == null)
                return;
            if (!student.Equals(answer))
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{student?.SalesOrderNumber}",
                Value2 = $"{student?.OrderTotal:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = cust.CustomerId,
                Value1 = $"{answer?.SalesOrderNumber}",
                Value2 = $"{answer?.OrderTotal:c}"
            });
        }
        #endregion
        #region CustomerItems
        private void CustomerCustomerItems(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "CustomerId", "PartId", "Part", "Quantity", "Amount", "Shipped", "Back Ordered", string.Empty };
            foreach (var cust in data.Customers)
                CustomerCustomerItems(cust, test);
        }
        public void CustomerCustomerItems(Customer cust, Test test)
        {
            var student = cust.CustomerItems;
            var result = new LinqSalesProjectGraderAnswer.Customer(cust);

            var answer = result.CustomerItems;
            if (student.Count != answer.Count)
                test.Grade = 0;
            for (int i = 0; i < answer.Count; i++)
            {
                test.AnswerResults.Add(new Result()
                {
                    Id = answer[i].CustomerId,
                    Value1 = $"{answer[i].PartId}",
                    Value2 = answer[i].Part,
                    Value3 = $"{answer[i].Quantity}",
                    Value4 = $"{answer[i].Amount:c}",
                    Value5 = $"{answer[i].Shipped}",
                    Value6 = $"{answer[i].BackOrdered}"
                });
                if (i < student.Count)
                {
                    test.StudentResults.Add(new Result()
                    {
                        Id = student[i].CustomerId,
                        Value1 = $"{student[i].PartId}",
                        Value2 = student[i].Part,
                        Value3 = $"{student[i].Quantity}",
                        Value4 = $"{student[i].Amount:c}",
                        Value5 = $"{student[i].Shipped}",
                        Value6 = $"{student[i].BackOrdered}"
                    });
                    if (student[i].PartId != answer[i].PartId
                        || student[i].Quantity != answer[i].Quantity
                        || student[i].Amount != answer[i].Amount
                        || student[i].Shipped != answer[i].Shipped
                        || student[i].BackOrdered != answer[i].BackOrdered)
                        test.Grade = 0;
                }
            }
        }
        #endregion
        #endregion

        #region SalesOrder
        #region Quantities
        #region ItemsSold
        private void SalesOrderItemsSold(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Sales Order #", "Items Sold", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var so in data.SalesOrders)
                SalesOrderItemsSold(so, test);
        }
        public void SalesOrderItemsSold(SalesOrder salesOrder, Test test)
        {
            var student = salesOrder.ItemsSold;
            var result = new LinqSalesProjectGraderAnswer.SalesOrder(salesOrder);

            var answer = result.ItemsSold;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #region ItemsShipped
        private void SalesOrderItemsShipped(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Sales Order #", "Items Shipped", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var so in data.SalesOrders)
                SalesOrderItemsShipped(so, test);
        }
        public void SalesOrderItemsShipped(SalesOrder salesOrder, Test test)
        {
            var student = salesOrder.ItemsShipped;
            var result = new LinqSalesProjectGraderAnswer.SalesOrder(salesOrder);

            var answer = result.ItemsShipped;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #region BackOrdered
        private void SalesOrderBackOrdered(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Sales Order #", "Back Ordered", "Quantity Sold", "Quantity Shipped", string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var so in data.SalesOrders)
                SalesOrderBackOrdered(so, test);
        }
        public void SalesOrderBackOrdered(SalesOrder salesOrder, Test test)
        {
            var student = salesOrder.BackOrdered;
            var studentOrdered = salesOrder.ItemsSold;
            var studentShipped = salesOrder.ItemsShipped;
            var result = new LinqSalesProjectGraderAnswer.SalesOrder(salesOrder);

            var answerOrdered = result.ItemsSold;
            var answerShipped = result.ItemsShipped;
            var answer = result.BackOrdered;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{student}",
                Value2 = $"{studentOrdered}",
                Value3 = $"{studentShipped}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{answer}",
                Value2 = $"{answerOrdered}",
                Value3 = $"{answerShipped}"
            });
        }
        #endregion
        #endregion
        #region Order Total
        private void SalesOrderTotal(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Sales Order #", "Order Total", "CustomerId", "Customer", string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.SalesOrders)
                SalesOrderTotal(cust, test);
        }
        public void SalesOrderTotal(SalesOrder salesOrder, Test test)
        {
            var student = salesOrder.OrderTotal;
            var result = new LinqSalesProjectGraderAnswer.SalesOrder(salesOrder);

            var answer = result.OrderTotal;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{student:c}",
                Value2 = $"{salesOrder.CustomerId}",
                Value3 = $"{salesOrder.Customer.FirstName} {salesOrder.Customer.LastName}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{answer:c}",
                Value2 = $"{salesOrder.CustomerId}",
                Value3 = $"{salesOrder.Customer.FirstName} {salesOrder.Customer.LastName}"
            });
        }
        #endregion
        #region OrderCosts
        private void SalesOrderCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Sales Order #", "Order Cost", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.SalesOrders)
                SalesOrderCost(cust, test);
        }
        public void SalesOrderCost(SalesOrder salesOrder, Test test)
        {
            var student = salesOrder.OrderCost;
            var result = new LinqSalesProjectGraderAnswer.SalesOrder(salesOrder);

            var answer = result.OrderCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region GrossProfit
        private void SalesOrderGrossProfit(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Sales Order #", "Gross Profit", "= Total Sales", "- Total Cost", string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.SalesOrders)
                SalesOrderGrossProfit(cust, test);
        }
        public void SalesOrderGrossProfit(SalesOrder salesOrder, Test test)
        {
            var student = salesOrder.GrossProfit;
            var result = new LinqSalesProjectGraderAnswer.SalesOrder(salesOrder);

            var answer = result.GrossProfit;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{student:c}",
                Value2 = $"{salesOrder.OrderTotal:c}",
                Value3 = $"{salesOrder.OrderCost:c}"

            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrder.SalesOrderNumber,
                Value1 = $"{answer:c}",
                Value2 = $"{result.OrderTotal:c}",
                Value3 = $"{result.OrderCost:c}"
            });
        }
        #endregion
        #endregion
        #region SalesOrderPart
        #region Quantities
        #region Units Shipped
        private void SalesOrderPartUnitsShipped(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "SalesOrderPartId", "Sales Order #", "Units Shipped", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var sop in data.SalesOrderParts)
                SalesOrderPartUnitsShipped(sop, test);
        }
        public void SalesOrderPartUnitsShipped(SalesOrderPart salesOrderPart, Test test)
        {
            var student = salesOrderPart.UnitsShipped;
            var result = new LinqSalesProjectGraderAnswer.SalesOrderPart(salesOrderPart);

            var answer = result.UnitsShipped;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{answer}"
            });
        }
        #endregion
        #endregion
        #region Amounts
        #region ExtendedPrice
        private void SalesOrderPartExtendedPrice(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "SalesOrderPartId", "Sales Order #", "Extended Price", "Quantity", "Unit Price", string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.SalesOrderParts)
                SalesOrderPartExtendedPrice(cust, test);
        }
        public void SalesOrderPartExtendedPrice(SalesOrderPart salesOrderPart, Test test)
        {
            var student = salesOrderPart.ExtendedPrice;
            var result = new LinqSalesProjectGraderAnswer.SalesOrderPart(salesOrderPart);

            var answer = result.ExtendedPrice;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{student:c}",
                Value3 = $"{salesOrderPart.Quantity}",
                Value4 = $"{salesOrderPart.UnitPrice:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{answer:c}",
                Value3 = $"{salesOrderPart.Quantity}",
                Value4 = $"{salesOrderPart.UnitPrice:c}"
            });
        }
        #endregion
        #region ExtendedCost
        private void SalesOrderPartExtendedCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "SalesOrderPartId", "Sales Order #", "Extended Cost", "Quantity", "Unit Cost", string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.SalesOrderParts)
                SalesOrderPartExtendedCost(cust, test);
        }
        public void SalesOrderPartExtendedCost(SalesOrderPart salesOrderPart, Test test)
        {
            var student = salesOrderPart.ExtendedCost;
            var result = new LinqSalesProjectGraderAnswer.SalesOrderPart(salesOrderPart);

            var answer = result.ExtendedCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{student:c}",
                Value3 = $"{salesOrderPart.Quantity}",
                Value4 = $"{salesOrderPart.UnitCost:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{answer:c}",
                Value3 = $"{salesOrderPart.Quantity}",
                Value4 = $"{salesOrderPart.UnitCost:c}"
            });
        }
        #endregion
        #region GrossProfit
        private void SalesOrderPartGrossProfit(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "SalesOrderPartId", "Sales Order #", "Gross Profit", "Quantity", "Unit Price", "Unit Cost", string.Empty, string.Empty };
            foreach (var cust in data.SalesOrderParts)
                SalesOrderPartGrossProfit(cust, test);
        }
        public void SalesOrderPartGrossProfit(SalesOrderPart salesOrderPart, Test test)
        {
            var student = salesOrderPart.GrossProfit;
            var result = new LinqSalesProjectGraderAnswer.SalesOrderPart(salesOrderPart);

            var answer = result.GrossProfit;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{student:c}",
                Value3 = $"{salesOrderPart.Quantity}",
                Value4 = $"{salesOrderPart.UnitPrice:c}",
                Value5 = $"{salesOrderPart.UnitCost:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = salesOrderPart.SalesOrderPartId,
                Value1 = salesOrderPart.SalesOrderNumber.ToString(),
                Value2 = $"{answer:c}",
                Value3 = $"{salesOrderPart.Quantity}",
                Value4 = $"{salesOrderPart.UnitPrice:c}",
                Value5 = $"{salesOrderPart.UnitCost:c}"
            });
        }
        #endregion
        #endregion
        #endregion

        #region PurchaseOrder
        #region TotalSales
        private void PurchaseOrderTotal(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "Purchase Order #", "OrderTotal", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var po in data.PurchaseOrders)
                PurchaseOrderTotal(po, test);
        }
        public void PurchaseOrderTotal(PurchaseOrder purchaseOrder, Test test)
        {
            var student = purchaseOrder.OrderTotal;
            var result = new LinqSalesProjectGraderAnswer.PurchaseOrder(purchaseOrder);

            var answer = result.OrderTotal;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = purchaseOrder.PurchaseOrderNumber,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = purchaseOrder.PurchaseOrderNumber,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #endregion
        #region PurchaseOrderPart
        #region Amounts
        #region ExtendedCost
        private void PurchaseOrderPartExtendedCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "PurchaseOrderPartId", "Purchase Order #", "Extended Cost", "Quantity", "Unit Cost", string.Empty, string.Empty, string.Empty };
            foreach (var cust in data.PurchaseOrderParts)
                PurchaseOrderPartExtendedCost(cust, test);
        }
        public void PurchaseOrderPartExtendedCost(PurchaseOrderPart purchaseOrderPart, Test test)
        {
            var student = purchaseOrderPart.ExtendedCost;
            var result = new LinqSalesProjectGraderAnswer.PurchaseOrderPart(purchaseOrderPart);

            var answer = result.ExtendedCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = purchaseOrderPart.PurchaseOrderPartId,
                Value1 = purchaseOrderPart.PurchaseOrderNumber.ToString(),
                Value2 = $"{student:c}",
                Value3 = $"{purchaseOrderPart.Quantity}",
                Value4 = $"{purchaseOrderPart.UnitCost:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = purchaseOrderPart.PurchaseOrderPartId,
                Value1 = purchaseOrderPart.PurchaseOrderNumber.ToString(),
                Value2 = $"{answer:c}",
                Value3 = $"{purchaseOrderPart.Quantity}",
                Value4 = $"{purchaseOrderPart.UnitCost:c}"
            });
        }
        #endregion
        #endregion
        #endregion

        #region Receipt
        #region UnitCost
        private void ReceiptUnitCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "ReceiptId", "Unit Cost", "Total Cost", "Ship & Handling", "Quantity", string.Empty, string.Empty, string.Empty };
            foreach (var receipt in data.Receipts)
                ReceiptUnitCost(receipt, test);
        }
        public void ReceiptUnitCost(Receipt receipt, Test test)
        {
            var student = receipt.UnitCost;
            var result = new LinqSalesProjectGraderAnswer.Receipt(receipt);

            var answer = result.UnitCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = receipt.ReceiptId,
                Value1 = $"{student:c}",
                Value2 = $"{receipt.TotalCost:c}",
                Value3 = $"{receipt.ShippingAndHandling:c}",
                Value4 = $"{receipt.Quantity}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = receipt.ReceiptId,
                Value1 = $"{answer:c}",
                Value2 = $"{receipt.TotalCost:c}",
                Value3 = $"{receipt.ShippingAndHandling:c}",
                Value4 = $"{receipt.Quantity}"
            });
        }
        #endregion
        #endregion
        #region Spoilage
        #region ExtendedCost
        private void SpoilageExtendedCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "SpoilageId", "Extended Cost", "Unit Cost", "Quantity",  string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var spoilage in data.Spoilages)
                SpoilageExtendedCost(spoilage, test);
        }
        public void SpoilageExtendedCost(Spoilage spoilage, Test test)
        {
            var student = spoilage.ExtendedCost;
            var result = new LinqSalesProjectGraderAnswer.Spoilage(spoilage);

            var answer = result.ExtendedCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = spoilage.SpoilageId,
                Value1 = $"{student:c}",
                Value2 = $"{spoilage.UnitCost:c}",
                Value3 = $"{spoilage.Quantity}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = spoilage.SpoilageId,
                Value1 = $"{answer:c}",
                Value2 = $"{spoilage.UnitCost:c}",
                Value3 = $"{spoilage.Quantity}"
            });
        }
        #endregion
        #endregion

        #region Shipment
        #region ShipmentAmount
        private void ShipmentAmount(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "ShipmentId", "Amount", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var shipment in data.Shipments)
                ShipmentAmount(shipment, test);
        }
        public void ShipmentAmount(Shipment shipment, Test test)
        {
            var student = shipment.ShipmentAmount;
            var result = new LinqSalesProjectGraderAnswer.Shipment(shipment);

            var answer = result.ShipmentAmount;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = shipment.ShipmentId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = shipment.ShipmentId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #endregion
        #region ShipmentPart
        #region ExtendedCost
        private void ShipmentPartExtendedCost(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "ShipmentPartId", "ShipmentId", "Extended Cost", "Unit Cost", "Quantity", string.Empty, string.Empty, string.Empty };
            foreach (var shipmentPart in data.ShipmentParts)
                ShipmentPartExtendedCost(shipmentPart, test);
        }
        public void ShipmentPartExtendedCost(ShipmentPart shipmentPart, Test test)
        {
            var student = shipmentPart.ExtendedCost;
            var result = new LinqSalesProjectGraderAnswer.ShipmentPart(shipmentPart);

            var answer = result.ExtendedCost;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = shipmentPart.ShipmentPartId,
                Value1 = $"{shipmentPart.ShipmentId}",
                Value2 = $"{student:c}",
                Value3 = $"{shipmentPart.UnitCost:c}",
                Value4 = $"{shipmentPart.Quantity}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = shipmentPart.ShipmentPartId,
                Value1 = $"{shipmentPart.ShipmentId}",
                Value2 = $"{answer:c}",
                Value3 = $"{shipmentPart.UnitCost:c}",
                Value4 = $"{shipmentPart.Quantity}"
            });
        }
        #endregion
        #endregion
        #region Vendor
        #region TotalPurchases
        private void VendorTotalPurchases(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "VendorId", "Purchases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var vendor in data.Vendors)
                VendorTotalPurchases(vendor, test);
        }
        public void VendorTotalPurchases(Vendor vendor, Test test)
        {
            var student = vendor.TotalPurchases;
            var result = new LinqSalesProjectGraderAnswer.Vendor(vendor);

            var answer = result.TotalPurchases;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = vendor.VendorId,
                Value1 = $"{student:c}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = vendor.VendorId,
                Value1 = $"{answer:c}"
            });
        }
        #endregion
        #region ItemsSold
        private void VendorItemsSold(ProjectData data, Test test)
        {
            test.Grade = test.Value;                //--< Assume it's right. Have to prove it's wrong <<<
            test.Resultnames = new[] { "VendorId", "Items Sold", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            foreach (var vendor in data.Vendors)
                VendorItemsSold(vendor, test);
        }
        public void VendorItemsSold(Vendor vendor, Test test)
        {
            var student = vendor.TotalPurchases;
            var result = new LinqSalesProjectGraderAnswer.Vendor(vendor);

            var answer = result.ItemsSold;
            if (student != answer)
                test.Grade = 0;

            test.StudentResults.Add(new Result()
            {
                Id = vendor.VendorId,
                Value1 = $"{student}"
            });
            test.AnswerResults.Add(new Result()
            {
                Id = vendor.VendorId,
                Value1 = $"{answer}"
            });
        }
        #endregion
        #endregion
    }
}
