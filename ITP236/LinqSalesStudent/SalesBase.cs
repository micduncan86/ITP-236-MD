using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSalesStudent
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<SalesOrder> SalesOrders { get; set; }

        public Customer() : this(-1, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Customer(int customerId, string firstName, string lastName, string city, string state)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            SalesOrders = new List<SalesOrder>();
        }
    }
    public partial class Part
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        #region Collections
        public List<SalesOrderPart> SalesOrderParts { get; private set; }
        public List<Receipt> Receipts { get; private set; }
        public List<Spoilage> Spoilages { get; set; }
        public List<ShipmentPart> ShipmentParts { get; private set; }
        public List<PurchaseOrderPart> PurchaseOrderParts { get; private set; }
        #endregion
        public Part() : this(0, string.Empty, 0m) { }

        public Part(int partId, string name, decimal price)
        {
            PartId = partId;
            Name = name;
            Price = price;
            SalesOrderParts = new List<SalesOrderPart>();
            Receipts = new List<Receipt>();
            Spoilages = new List<Spoilage>();
            ShipmentParts = new List<ShipmentPart>();
            PurchaseOrderParts = new List<PurchaseOrderPart>();
        }
    }

    public partial class SalesOrder
    {
        public int SalesOrderNumber { get; set; }
        public int CustomerId { get; set; }
        public LinqSalesStudent.Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }

        #region Sales Status

        enum StatusType
        {
            Open = 1,
            Closed
        }

        public int SalesStatusId { get; set; }

        public string SalesStatus
        {
            get
            {
                var status = (StatusType)SalesStatusId;
                return status.ToString();
            }
        }

        #endregion

        public List<SalesOrderPart> SalesOrderParts { get; set; }
        public List<Shipment> Shipments { get; set; }

        public SalesOrder() : this(-1, -1, DateTime.Now)
        {

        }

        public SalesOrder(int salesOrderNumber, int customerId, DateTime orderDate)
        {
            SalesOrderNumber = salesOrderNumber;
            CustomerId = customerId;
            OrderDate = orderDate;
            SalesOrderParts = new List<SalesOrderPart>();
            Shipments = new List<Shipment>();
        }

        //public void AddSalesOrderPart(object salesOrderPart)
        //{
        //    SalesOrderParts.Add(salesOrderPart as SalesOrderPart);
        //}
    }

    public partial class SalesOrderPart
    {
        public int SalesOrderPartId { get; set; }
        public int SalesOrderNumber { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ShipmentPart> ShipmentParts { get; set; }
        public decimal UnitCost { get; set; }
        public SalesOrderPart() : this(-1, -1, -1, 0, 0m, 0m)
        {

        }
        public SalesOrderPart(int salesOrderPartId, int salesOrderNumber,
            int partId, int quantity, decimal price, decimal unitCost)
        {
            SalesOrderPartId = salesOrderPartId;
            SalesOrderNumber = salesOrderNumber;
            PartId = partId;
            Quantity = quantity;
            UnitPrice = price;
            UnitCost = unitCost;
            ShipmentParts = new List<ShipmentPart>();
        }
    }

    public partial class PurchaseOrder
    {
        public int PurchaseOrderNumber { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime OrderDate { get; set; }

        public List<PurchaseOrderPart> PurchaseOrderParts { get; set; }

        public PurchaseOrder() : this(-1, -1, DateTime.Now)
        {

        }
        public PurchaseOrder(int purchaseOrderNumber, int vendorId, DateTime orderDate)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            VendorId = vendorId;
            OrderDate = orderDate;
            PurchaseOrderParts = new List<PurchaseOrderPart>();
        }

        public void AddPurchaseOrderPart(object purchaseOrderPart)
        {
            PurchaseOrderParts.Add(purchaseOrderPart as PurchaseOrderPart);
        }
    }
    public partial class PurchaseOrderPart
    {
        public int PurchaseOrderPartId { get; set; }
        public int PurchaseOrderNumber => PurchaseOrder.PurchaseOrderNumber;
        public PurchaseOrder PurchaseOrder { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public List<Receipt> Receipts { get; set; }
        public PurchaseOrderPart() : this(-1, new PurchaseOrder(), new Part(), 0, 0m)
        { }
        public PurchaseOrderPart(int purchaseOrderPartId, PurchaseOrder purchaseOrder,
            Part part, int quantity, decimal unitCost)
        {
            PurchaseOrderPartId = purchaseOrderPartId;
            PurchaseOrder = purchaseOrder;
            Part = part;
            Quantity = quantity;
            UnitCost = unitCost;
            Receipts = new List<Receipt>();
        }
    }
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int PurchaseOrderPartId => PurchaseOrderPart.PurchaseOrderPartId;
        public PurchaseOrderPart PurchaseOrderPart { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal TotalCost { get; set; }

        public decimal ShippingAndHandling { get; set; }

        public Receipt() : this(0, new PurchaseOrderPart(), 0, DateTime.Now, 0m, 0m)
        {
        }

        public Receipt(int receiptId, PurchaseOrderPart purchaseOrderPart, int quantity, DateTime receiptDate,
            decimal totalCost, decimal shippingAndHandling)
        {
            ReceiptId = receiptId;
            PurchaseOrderPart = purchaseOrderPart;
            Quantity = quantity;
            TotalCost = totalCost;
            ReceiptDate = receiptDate;
            ShippingAndHandling = shippingAndHandling;
        }
    }

    public partial class Spoilage
    {
        public int SpoilageId { get; set; }
        public DateTime SpoilageDate { get; set; }
        public int PartId => Part.PartId;
        public Part Part { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public Spoilage() : this(0, DateTime.Now, new Part(), 0, 0) { }
        public Spoilage(int spoiledId, DateTime spoilageDate, Part part, int quantity, decimal unitCost)
        {
            SpoilageId = spoiledId;
            SpoilageDate = spoilageDate;
            Part = part;
            Quantity = quantity;
            UnitCost = unitCost;
        }
    }

    public partial class Shipment
    {
        public int ShipmentId { get; set; }

        public SalesOrder SalesOrder { get; set; }
        public DateTime ShipmentDate { get; set; }
        public List<ShipmentPart> ShipmentParts { get;  set; }

        public Shipment() : this(0, new SalesOrder(), DateTime.Today)
        {
        }

        public Shipment(int shipmentId, SalesOrder salesOrder, DateTime shipmentDate)
        {
            ShipmentId = shipmentId;
            SalesOrder = salesOrder;
            ShipmentDate = shipmentDate;
            ShipmentParts = new List<ShipmentPart>();
        }
    }

    public partial class ShipmentPart
    {
        public int ShipmentPartId { get; set; }
        public Shipment Shipment { get; set; }
        public SalesOrderPart SalesOrderPart { get; set; }
        public int SalesOrderPartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public List<SalesReturn> SalesReturns{ get; set; }

        public ShipmentPart() : this(0, new Shipment(), new SalesOrderPart(), 0, 0)
        { }

        public ShipmentPart(int shipmentPartId, Shipment shipment, SalesOrderPart salesOrderPart, int quantity,
            decimal unitCost)
        {
            ShipmentPartId = ShipmentPartId;
            Shipment = shipment;
            SalesOrderPart = salesOrderPart;
            SalesOrderPartId = salesOrderPart.SalesOrderPartId;
            Quantity = quantity;
            UnitCost = unitCost;
            SalesReturns = new List<SalesReturn>();
        }
    }

    public partial class SalesReturn
    {
        public int SalesReturnId { get; set; }
        public ShipmentPart ShipmentPart { get; set; }
        public int ShipmnetPartId => ShipmentPart.ShipmentPartId;
        public string Reason { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Quantity { get; set; }

        public SalesReturn() : this(0, new ShipmentPart(), string.Empty, DateTime.Now, 0 )
        { }

        public SalesReturn(int salesReturnId, ShipmentPart shipmentPart, string reason, DateTime returnDate,
            int quantity)
        {
            SalesReturnId = salesReturnId;
            ShipmentPart = shipmentPart;
            Reason = reason;
            ReturnDate = returnDate;
            Quantity = quantity;
        }
    }

    public partial class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }


        public Vendor() : this(-1, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Vendor(int vendorId, string firstName, string name, string city, string state)
        {
            VendorId = vendorId;
            Name = name;
            City = city;
            State = state;
            PurchaseOrders = new List<PurchaseOrder>();
        }

        public void AddPurchaseOrder(object purchaseOrder)
        {
            PurchaseOrders.Add(purchaseOrder as PurchaseOrder);
        }
    }

    public partial class CustomerItem
    {
        public int CustomerId { get; set; }
        public int PartId { get; set; }
        public string Part { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice => Quantity == 0 ? 0 : Amount / Quantity;
        public int Shipped { get; set; }
        public int BackOrdered { get; set; }

        public CustomerItem(int customerId, int partId, string part, int quantity, decimal amount, int shipped,
            int backOrdered)
        {
            CustomerId = customerId;
            PartId = partId;
            Part = part;
            Quantity = quantity;
            Amount = amount;
            Shipped = shipped;
            BackOrdered = backOrdered;
        }
    }
}
