using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace LinqSalesStudent
{
    public partial class Customer
    {
        /// <summary>
        /// TotalSales is the sum of the SalesOrders' OrderTotal
        /// </summary>
        public decimal TotalSales => SalesOrders.Sum(x => x.OrderTotal);
        /// <summary>
        /// TotalCost is the sum of the SalesOrders' OrderCost
        /// </summary>
        public decimal TotalCost => SalesOrders.Sum(x => x.OrderCost);
        /// <summary>
        /// GrossProfit is the difference between TotalSales and TotalCost
        /// </summary>
        public decimal GrossProfit => TotalSales - TotalCost;

        /// <summary>
        /// ItemsSold is the sum of the SalesOrders' SalesOrderParts Quantities
        /// </summary>
        public int ItemsSold => SalesOrders.Sum(x => x.SalesOrderParts.Sum(y => y.Quantity));

        /// <summary>
        /// LargestSale is the largest sale for the Customer based on OrderTotal
        /// </summary>
        public SalesOrder LargestSale => new SalesOrder();
        /// <summary>
        /// Returns a collection (List) of the items that a Customer has purchased, with the total quantities
        /// Group the SalesOrderParts from the SalesOrders. Group by the Part's PartId and Name
        /// For each group, 
        ///     create a new CustomerItem object summing the 
        ///     Quantites, ExtendedPrices, UnitsShipped and 
        ///     the differences between Quantities and UnitsShipped for the Backorder
        /// </summary>
        public List<CustomerItem> CustomerItems
        {
            get
            {
                var st = (from so in SalesOrders
                          from sop in so.SalesOrderParts
                          group sop by sop.PartId into g
                          select new CustomerItem(g.Select(x => x.SalesOrder.CustomerId).First()
                          ,g.Key
                          ,g.Select(x => x.Part.Name).First()
                          ,g.Sum(x => x.Quantity)
                          ,g.Sum(x => x.ExtendedPrice)
                          ,g.Sum(x => x.UnitsShipped)
                          ,g.Sum(x => x.Quantity - x.UnitsShipped)
                          )).ToList();
                       
                        return new List<CustomerItem>(st);
            }
        }
    }
    public partial class Part
    {
        public const string StudentName = "Michael Duncan";

        #region Quantities
        /// <summary>
        /// QuantityOnHand = Units Received - Units Spoiled - Units Shipped
        /// </summary>
        public int QuantityOnHand => UnitsReceived - UnitsSpoiled - UnitsShipped;

        /// <summary>
        /// UnitsReceived is the sum of the Receipt Quantities for the Part
        /// </summary>
        public int UnitsReceived => Receipts.Sum(x => x.Quantity);
        /// <summary>
        /// UnitsSold is the sum of the sales for the Part. Use SalesOrderParts.
        /// </summary>
        public int UnitsSold => SalesOrderParts.Sum(x => x.Quantity);

        /// <summary>
        /// UnitsShipped is the sum of the quantities shipped for the Part. Use ShipmentParts.
        /// </summary>
        public int UnitsShipped => ShipmentParts.Sum(x => x.Quantity);

        /// <summary>
        /// UnitsSpoiled is the sum of the quantities for the Part. Use Spoilages.
        /// </summary>
        public int UnitsSpoiled => Spoilages.Sum(x => x.Quantity);
        #endregion
        #region Amounts
        /// <summary>
        /// CurrentValue = Amount Received - Amount Spoiled - Amount Shipped
        /// </summary>
        public decimal CurrentValue => AmountReceived - AmountSpoiled - AmountShipped;
        /// <summary>
        /// Amount Sold is the sum of the extended prices for the SalesOrderParts.
        /// </summary>
        public decimal AmountSold => SalesOrderParts.Sum(x => x.ExtendedPrice);
        /// <summary>
        /// AmountReceived is the sum of the Receipts' total cost + shipping and handling.
        /// </summary>
        public decimal AmountReceived => Receipts.Sum(x => (x.TotalCost + x.ShippingAndHandling));
        /// <summary>
        /// AmountShipped is the sum of the Extended Costs for the Shipment Parts.
        /// </summary>
        public decimal AmountShipped => ShipmentParts.Sum(x => x.ExtendedCost);

        /// <summary>
        /// AmountSpoiled is the sum of the Extended Costs for the Spoilages.
        /// </summary>
        public decimal AmountSpoiled => Spoilages.Sum(x => x.ExtendedCost);
        #endregion
        /// <summary>
        /// Vendors is the list of Vendors that we have purchased this part from.
        /// Start with Purchase Order Parts, find the Purchase Order for each one
        /// Then get the Vendors for the Purchase Orders.
        /// We only want one distinct object for each vendor.
        /// Create a List of the Vendors.
        /// </summary>
        public List<Vendor> Vendors => PurchaseOrderParts.Select(x => x.PurchaseOrder).Select(y => y.Vendor).Distinct().ToList();
    }
    public partial class SalesOrder
    {
        #region Quantities
        /// <summary>
        /// ItemsSold is the sum of the quantities for SalesOrderParts
        /// </summary>
        public int ItemsSold => SalesOrderParts.Sum(x => x.Quantity);

        /// <summary>
        /// ItemsShipped is the sum of the Shipments' ShipmentParts' Quantities
        /// </summary>
        public int ItemsShipped => Shipments.Sum(x => x.ShipmentParts.Sum(y => y.Quantity));
        /// <summary>
        /// BackOrdered is the difference between the Items Sold and the Items Shipped
        /// </summary>
        public int BackOrdered => ItemsSold - ItemsShipped;
        #endregion
        #region Amounts
        /// <summary>
        /// OrderTotal is the sum of the SalesOrderParts' Extended Prices
        /// </summary>
        public decimal OrderTotal => SalesOrderParts.Sum(x => x.ExtendedPrice);
        /// <summary>
        /// OrderCost is the sum of the SalesOrderPart's Extended Costs
        /// </summary>
        public decimal OrderCost => SalesOrderParts.Sum(sop => sop.ExtendedCost);
        /// <summary>
        /// GrossProfit is the difference between the Order Total and the Order Cost
        /// </summary>
        public decimal GrossProfit => OrderTotal - OrderCost;
        #endregion
    }
    public partial class SalesOrderPart
    {
        /// <summary>
        /// ExtendedPrice is the Quantity * the Unit Price
        /// </summary>
        public decimal ExtendedPrice => Quantity * UnitPrice;
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity * UnitCost;
        /// <summary>
        /// GrossProfit is the difference between the extended price and the extended cost
        /// </summary>
        public decimal GrossProfit => (ExtendedPrice - ExtendedCost);
        /// <summary>
        /// UnitsShipped is the sum of the quantities of the Shipment Parts
        /// </summary>
        public int UnitsShipped => ShipmentParts.Sum(sp => sp.Quantity);
    }
    public partial class PurchaseOrder
    {
        /// <summary>
        /// OrderTotal is the sum of the Extended Costs for the Purchase Order Parts
        /// </summary>
        public decimal OrderTotal => PurchaseOrderParts.Sum(p => p.ExtendedCost);
    }
    public partial class PurchaseOrderPart
    {
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity * UnitCost;
    }
    public partial class Receipt
    {
        /// <summary>
        /// UnitCost is the (total cost + shipping and handling) / Quantity
        /// If the Quantity is 0, the Unit Cost is 0
        /// (Remember the C# ternary operator?)
        /// </summary>
        public decimal UnitCost => Equals(Quantity,0) ? 0 : ((TotalCost + ShippingAndHandling) / Quantity) ;
    }
    public partial class Spoilage
    {
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity * UnitCost;
    }
    public partial class Shipment
    {
        /// <summary>
        /// SalesOrderNumber is the SalesOrder's Sales Order Number
        /// </summary>
        public int SalesOrderNumber => SalesOrder.SalesOrderNumber;
        /// <summary>
        /// ShipmentAmount is the sum of the Extended Costs for the Shipment Parts
        /// </summary>
        public decimal ShipmentAmount => ShipmentParts.Sum(s => s.ExtendedCost);
    }
    public partial class ShipmentPart
    {
        /// <summary>
        /// ShipmentId is the Shipment's ShipmentId
        /// </summary>
        public int ShipmentId => Shipment.ShipmentId;
        /// <summary>
        /// ExtendedCost is the Quantity * the Unit Cost
        /// </summary>
        public decimal ExtendedCost => Quantity * UnitCost;
    }
    public partial class Vendor
    {
        /// <summary>
        /// TotalPurchases is the sum of the Purchase Orders order total
        /// </summary>
        public decimal TotalPurchases => PurchaseOrders.Sum(x => x.OrderTotal);

        public int ItemsSold => PurchaseOrders.Sum(po => po.PurchaseOrderParts.Sum(pop => pop.Quantity));
    }
}