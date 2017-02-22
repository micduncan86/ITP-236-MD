using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LinqSalesProjectGraderAnswer;
using LinqSalesStudent;
using MS.Internal.Xml.XPath;

namespace LinqSalesProjectGrader2
{
    public class ProjectData
    {
        public string ProjectName;
        public List<LinqSalesStudent.Part> Parts ;
        public List<LinqSalesStudent.Customer> Customers ;
        public List<LinqSalesStudent.Vendor> Vendors ;
        public List<LinqSalesStudent.Receipt> Receipts = new List<LinqSalesStudent.Receipt>();
        public List<LinqSalesStudent.Spoilage> Spoilages = new List<LinqSalesStudent.Spoilage>();
        public List<LinqSalesStudent.ShipmentPart> ShipmentParts = new List<LinqSalesStudent.ShipmentPart>();
        public List<LinqSalesStudent.SalesReturn> SalesReturns = new List<LinqSalesStudent.SalesReturn>();
        public List<LinqSalesStudent.SalesOrder> SalesOrders = new List<LinqSalesStudent.SalesOrder>();
        public List<LinqSalesStudent.SalesOrderPart> SalesOrderParts = new List<LinqSalesStudent.SalesOrderPart>();
        public List<LinqSalesStudent.Shipment> Shipments = new List<LinqSalesStudent.Shipment>();
        public List<LinqSalesStudent.PurchaseOrder> PurchaseOrders = new List<LinqSalesStudent.PurchaseOrder>();
        public List<LinqSalesStudent.PurchaseOrderPart> PurchaseOrderParts = new List<LinqSalesStudent.PurchaseOrderPart>();
        public ProjectData(Grader.Project projectType)
        {
            switch (projectType)
            {
                case Grader.Project.Linq:
                    LoadDataFromXml();
                    break;
                case Grader.Project.EntityFramework:
                    LoadDataFromDb();
                    break;
            }
        }
        private void LoadDataFromDb()
        {
            
        }
        private void LoadDataFromXml()
        {
            var projectData = XDocument.Load("XML/LinqProjectData.xml");
            ProjectName = projectData.Descendants("Name").First().Value;
            Parts = LoadParts(projectData);
            Customers = LoadCustomers(projectData);
            Vendors = LoadVendors(projectData);
        }
        private List<LinqSalesStudent.Part> LoadParts(XDocument ProjectData)
        {
            var parts = (from part in ProjectData.Descendants("Part")
                         select new LinqSalesStudent.Part()
                         {
                             PartId = Convert.ToInt32(part.Attribute("PartId").Value),
                             Name = part.Attribute("Name").Value,
                             Price = Convert.ToDecimal(part.Attribute("Price").Value),
                             Spoilages = (from spoilage in part.Descendants("Spoilage")
                                          where spoilage.Attribute("PartId").Value == part.Attribute("PartId").Value
                                          select new LinqSalesStudent.Spoilage()
                                          {
                                              SpoilageId = Convert.ToInt32(spoilage.Attribute("SpoilageId").Value),
                                              SpoilageDate = Convert.ToDateTime(spoilage.Attribute("SpoilageDate").Value),
                                              Quantity = Convert.ToInt32(spoilage.Attribute("Quantity").Value),
                                              UnitCost = Convert.ToDecimal(spoilage.Attribute("UnitCost").Value)
                                          }).ToList(),
                         }).ToList();
            foreach (var part in parts)
            {
                var spoilages = part.Spoilages;
                foreach (var spoilage in spoilages)
                {
                    spoilage.Part = part;
                    Spoilages.Add(spoilage);
                }
            }
            return parts;
        }
        private List<LinqSalesStudent.Customer> LoadCustomers(XDocument ProjectData)
        {
            var customers = (from customer in ProjectData.Descendants("Customer")
                             select new LinqSalesStudent.Customer()
                             {
                                 CustomerId = Convert.ToInt32(customer.Attribute("CustomerId").Value),
                                 FirstName = customer.Attribute("FirstName").Value,
                                 LastName = customer.Attribute("LastName").Value,
                                 City = customer.Attribute("City").Value,
                                 State = customer.Attribute("State").Value,
                                 SalesOrders = (from salesOrder in customer.Descendants("SalesOrder")
                                                select new LinqSalesStudent.SalesOrder()
                                                {
                                                    SalesOrderNumber = Convert.ToInt32(salesOrder.Attribute("SalesOrderNumber").Value),
                                                    CustomerId = Convert.ToInt32(customer.Attribute("CustomerId").Value),
                                                    OrderDate = Convert.ToDateTime(salesOrder.Attribute("OrderDate").Value),
                                                    SalesOrderParts =
                                                        (from sop in salesOrder.Descendants("SalesOrderPart")
                                                         select new LinqSalesStudent.SalesOrderPart()
                                                         {
                                                             SalesOrderPartId = Convert.ToInt32(sop.Attribute("SalesOrderPartId").Value),
                                                             SalesOrderNumber = Convert.ToInt32(salesOrder.Attribute("SalesOrderNumber").Value),
                                                             PartId = Convert.ToInt32(sop.Attribute("PartId").Value),
                                                             Quantity = Convert.ToInt32(sop.Attribute("Quantity").Value),
                                                             UnitCost = Convert.ToDecimal(sop.Attribute("UnitCost").Value),
                                                             UnitPrice = Convert.ToDecimal(sop.Attribute("UnitPrice").Value)
                                                         }).ToList(),
                                                    Shipments =
                                                      (from ship in salesOrder.Descendants("Shipment")
                                                       select new LinqSalesStudent.Shipment()
                                                       {
                                                           ShipmentId = Convert.ToInt32(ship.Attribute("ShipmentId").Value),
                                                           ShipmentDate = Convert.ToDateTime(ship.Attribute("ShipmentDate").Value),
                                                           ShipmentParts =
                                                             (from sp in ship.Descendants("ShipmentPart")
                                                              select new LinqSalesStudent.ShipmentPart()
                                                              {
                                                                  ShipmentPartId = Convert.ToInt32(sp.Attribute("ShipmentPartId").Value),
                                                                  Quantity = Convert.ToInt32(sp.Attribute("Quantity").Value),
                                                                  SalesOrderPartId = Convert.ToInt32(sp.Attribute("SalesOrderPartId").Value),
                                                                  //UnitCost = Convert.ToDecimal(sp.Attribute("UnitCost").Value),
                                                                  SalesReturns =
                                                                    (from sr in sp.Descendants("SalesReturn")
                                                                     select new LinqSalesStudent.SalesReturn()
                                                                     {
                                                                         SalesReturnId = Convert.ToInt32(sr.Attribute("SalesReturnId").Value),
                                                                         Reason = sr.Attribute("Reason").Value,
                                                                         ReturnDate = Convert.ToDateTime(sr.Attribute("ReturnDate").Value),
                                                                         Quantity = Convert.ToInt32(sp.Attribute("Quantity").Value)
                                                                     }).ToList()
                                                              }).ToList()
                                                       }).ToList()
                                                }).ToList()
                             }).ToList();

            foreach (var customer in customers)
            {
                foreach (var so in customer.SalesOrders)
                {
                    so.Customer = customer;
                    SalesOrders.Add(so);
                    foreach (var sop in so.SalesOrderParts)
                    {
                        sop.SalesOrder = so;
                        sop.Part = Parts.First(p => p.PartId.Equals(sop.PartId));
                        sop.Part.SalesOrderParts.Add(sop);
                        SalesOrderParts.Add(sop);
                        sop.Part.SalesOrderParts.Add(sop);
                    }
                    foreach (var shipment in so.Shipments)
                    {
                        shipment.SalesOrder = so;
                        Shipments.Add(shipment);
                        foreach (var sp in shipment.ShipmentParts)
                        {
                            sp.Shipment = shipment;
                            sp.SalesOrderPart =
                                SalesOrderParts.Find(sop => sop.SalesOrderPartId.Equals(sp.SalesOrderPartId));
                            sp.SalesOrderPart.ShipmentParts.Add(sp);
                            sp.UnitCost = sp.SalesOrderPart.UnitCost;
                            var part = sp.SalesOrderPart.Part;
                            part.ShipmentParts.Add(sp);
                            ShipmentParts.Add(sp);
                            foreach (var sr in sp.SalesReturns)
                            {
                                sr.ShipmentPart = sp;
                                SalesReturns.Add(sr);

                            }
                        }
                    }
                }
            }
            return customers;
        }
        private List<LinqSalesStudent.Vendor> LoadVendors(XDocument ProjectData)
        {
            var vendors = (from vendor in ProjectData.Descendants("Vendor")
                           select new LinqSalesStudent.Vendor()
                           {
                               VendorId = Convert.ToInt32( vendor.Attribute("VendorId").Value),
                               Name = vendor.Attribute("Name").Value,
                               PurchaseOrders = (from purchaseOrder in vendor.Descendants("PurchaseOrder")
                                                 select new LinqSalesStudent.PurchaseOrder()
                                                 {
                                                     PurchaseOrderNumber = Convert.ToInt32(purchaseOrder.Attribute("PurchaseOrderNumber").Value),
                                                     VendorId = Convert.ToInt32(vendor.Attribute("VendorId").Value),
                                                     OrderDate = Convert.ToDateTime(purchaseOrder.Attribute("PoDate").Value),
                                                     PurchaseOrderParts =
                                                     (from sop in purchaseOrder.Descendants("PurchaseOrderPart")
                                                      select new LinqSalesStudent.PurchaseOrderPart()
                                                      {
                                                          PurchaseOrderPartId = Convert.ToInt32(sop.Attribute("PoPartId").Value),
                                                          PartId = Convert.ToInt32(sop.Attribute("PartId").Value),
                                                          Quantity = Convert.ToInt32(sop.Attribute("Quantity").Value),
                                                          UnitCost = Convert.ToDecimal(sop.Attribute("UnitCost").Value),
                                                          Receipts = (from recvd in sop.Descendants("Receipt")
                                                                      select new LinqSalesStudent.Receipt()
                                                                      {
                                                                          ReceiptId = Convert.ToInt32(recvd.Attribute("ReceiptId").Value),
                                                                          Quantity = Convert.ToInt32(recvd.Attribute("Quantity").Value),
                                                                          ReceiptDate = Convert.ToDateTime(recvd.Attribute("ReceiptDate").Value),
                                                                          TotalCost = Convert.ToDecimal(recvd.Attribute("TotalCost").Value),
                                                                          ShippingAndHandling = Convert.ToDecimal(recvd.Attribute("ShippingAndHandling").Value)
                                                                      }).ToList()
                                                      }).ToList()
                                                 }).ToList()
                           }).ToList();

            foreach (var vendor in vendors)
            {
                foreach (var po in vendor.PurchaseOrders)
                {
                    po.Vendor = vendor;
                    PurchaseOrders.Add(po);
                    foreach (var pop in po.PurchaseOrderParts)
                    {
                        pop.PurchaseOrder = po;
                        pop.Part = Parts.First(p => p.PartId.Equals(pop.PartId));
                        pop.Part.PurchaseOrderParts.Add(pop);
                        PurchaseOrderParts.Add(pop);
                        foreach (var receipt in pop.Receipts)
                        {
                            receipt.PurchaseOrderPart = pop;
                            receipt.Part = pop.Part;
                            Receipts.Add(receipt);
                            pop.Part.Receipts.Add(receipt);
                        }
                    }
                }
            }
            return vendors;
        }
    }
}
