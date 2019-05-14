using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thousand.Models;

namespace thousand.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp

            public ActionResult HomePage()
        {
            return View();
        }


        public ActionResult Table()
        {
            DataTable dataTable = Details();



            List<Sale> purchaseList = new List<Sale>();
            foreach (DataRow row in dataTable.Rows)
            {
                Sale purchase1 = new Sale()
                {
                    Region = Convert.ToString(row["Region"]),
                    Country = Convert.ToString(row["Country"]),
                    ItemType = Convert.ToString(row["Item Type"]),
                    SalesChannel = Convert.ToString(row["Sales Channel"]),
                    OrderPriority = Convert.ToString(row["Order Priority"]),
                    OrderDate = Convert.ToDateTime(row["Order Date"]),
                    OrderId = Convert.ToInt32(row["Order Id"]),
                    UnitsSold = Convert.ToInt32(row["Units Sold"]),
                    Shipdate = Convert.ToDateTime(row["Ship date"]),
                    UnitPrice = Convert.ToInt32(row["Unit Price"]),
                    UnitCost = Convert.ToInt32(row["Unit Cost"]),
                    TotalRevenue = Convert.ToInt32(row["Total Revenue"]),
                    TotalCost = Convert.ToInt32(row["Total Cost"]),
                    TotalProfit = Convert.ToInt32(row["Total Profit"])

                };
                purchaseList.Add(purchase1);
            }


            return View(purchaseList);



        }
       public DataTable Details()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-2UL7R6Q;Initial Catalog=GridView;Integrated Security=SSPI");
            SqlCommand sqlCommand = new SqlCommand("select * from SaleRecord", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Massive data reads
            //while (sqlDataReader.Read())
            //{
            //    int categoryId = Convert.ToInt32(sqlDataReader.GetValue(0)); // CategoryId
            //}

            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);

            sqlConnection.Close();

            return dt;
        }
        //RN-added for sorting
        [HttpPost]
        public JsonResult EditView(string Region)
        {
            List<Sale> purchaseList = new List<Sale>();
            //foreach (DataRow row in Details.dataTable.Row Where(x => x.Region.Contains(Region)).ToList());

            purchaseList.ForEach
                (x =>

                {
                    Sale purchase1 = new Sale();
                    purchase1.Region = x.Region;
                    purchase1.Country = x.Country;
                    purchase1.ItemType = x.ItemType;
                    purchase1.SalesChannel = x.SalesChannel;
                    purchase1.OrderPriority = x.OrderPriority;
                    purchase1.OrderDate = x.OrderDate;
                    purchase1.OrderId = x.OrderId;
                    purchase1.UnitsSold = x.UnitsSold;
                    purchase1.Shipdate = x.Shipdate;
                    purchase1.UnitPrice = x.UnitPrice;
                    purchase1.UnitCost = x.UnitCost;
                    purchase1.TotalRevenue = x.TotalRevenue;
                    purchase1.TotalCost = x.TotalCost;
                    purchase1.TotalProfit = x.TotalProfit;
                    purchaseList.Add(purchase1);
                }
                );
        
            if (purchaseList.Count > 0)
            {
                return Json(purchaseList);
            }
            else
            {
                return Json("No Record Found");
            }
           
        }
        public ActionResult Datatable()
        {
            DataTable dataTable = Details();



            List<Sale> purchaseList = new List<Sale>();
            foreach (DataRow row in dataTable.Rows)
            {
                Sale purchase1 = new Sale()
                {
                    Region = Convert.ToString(row["Region"]),
                    Country = Convert.ToString(row["Country"]),
                    ItemType = Convert.ToString(row["Item Type"]),
                    SalesChannel = Convert.ToString(row["Sales Channel"]),
                    OrderPriority = Convert.ToString(row["Order Priority"]),
                    OrderDate = Convert.ToDateTime(row["Order Date"]),
                    OrderId = Convert.ToInt32(row["Order Id"]),
                    UnitsSold = Convert.ToInt32(row["Units Sold"]),
                    Shipdate = Convert.ToDateTime(row["Ship date"]),
                    UnitPrice = Convert.ToInt32(row["Unit Price"]),
                    UnitCost = Convert.ToInt32(row["Unit Cost"]),
                    TotalRevenue = Convert.ToInt32(row["Total Revenue"]),
                    TotalCost = Convert.ToInt32(row["Total Cost"]),
                    TotalProfit = Convert.ToInt32(row["Total Profit"])

                };
                purchaseList.Add(purchase1);
            }


            return View(purchaseList);
        }
        
    }








    ////
    //        {
    //            Sale purchase1 = new Sale();
    //purchase1.Region = Region;
    //            purchase1.Country = x.country;
    //            purchase1.ItemType = ,
    //                purchase1.SalesChannel = 
    //                purchase1.OrderPriority = 
    //                purchase1.OrderDate = 
    //               purchase1.OrderId = 
    //               purchase1.UnitsSold = 
    //               purchase1.Shipdate = 
    //               purchase1.UnitPrice = 
    //                purchase1.UnitCost = 
    //                purchase1.TotalRevenue = 
    //               purchase1.TotalCost = 
    //               purchase1.TotalProfit = 


            }