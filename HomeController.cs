using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqToEfLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult UntypedView()
        {
            //Build db context
            NorthwindEntities ctx = new NorthwindEntities();


            #region LinqToEF MiniLab - Student Controller
            #region Example: Together Example DONE
            //Return all products with a price between $12 and $50
            //Only display the name and the price.
            //Get a Count of all of the items and display the count.

            var togetherExample = ctx.Products.Where(prod => prod.UnitPrice >= 12 && prod.UnitPrice <= 50);

            ViewBag.TogetherExample = togetherExample;
            ViewBag.Count = togetherExample.Count();

            #endregion

            //Write the query in whatever format is most comfortable for you.
            //Resolve all of the query questions. When done, come back and comment out
            //the query you have and try the other syntax.
            //(Method first, come back and do keyword)

            #region 1) Dairy Products - Name and Category Name DONE
            //return all products that are in the category of "Dairy Products"
            //only output the product name and the category name

            //method
            var dairy = ctx.Products.Where(prod => prod.Category.CategoryName.ToLower() == "dairy products");

            ViewBag.Dairy = dairy;

            //keyword
            var dairyK = from d in ctx.Products
                         where d.Category.CategoryName.ToLower() == "dairy products"
                         select d;
            ViewBag.DairyK = dairyK.ToList();


            
            #endregion

            #region 2) 10 or more products in category DONE
            //Return the category categories that have more than 10 products
            //display the category name and the number of products

            //method
            var unitsOverTen = ctx.Categories.Where(cat => cat.Products.Count > 10);
            
            ViewBag.Units = unitsOverTen;

            //keyword
            var unitsOverTenK = from u in ctx.Categories
                                where u.Products.Count > 10
                                select u;
            ViewBag.UnitsK = unitsOverTenK.ToList();




                                #endregion

                                #region 3) German Suppliers DONE
            //Return a list of suppliers (Name and their Country)
            //that reside in Germany
            var germany = ctx.Suppliers.Where(s => s.Country.ToLower() == "germany");

            ViewBag.Germany = germany;

            var germanyK = from g in ctx.Suppliers
                           where g.Country.ToLower() == "germany"
                           select g;
            ViewBag.GermanyK = germanyK;


                           #endregion

                           #region 4) Chef Products DONE
            //Return a list of products that has Chef in the name alphabetically

            var chef = ctx.Products.Where(prod => prod.ProductName.Contains("chef"));

            ViewBag.Chef = chef;

            //keyword
            var chefK = from c in ctx.Products
                        where c.ProductName.Contains("chef")
                        select c;
            ViewBag.ChefK = chefK;

                        #endregion

                        #region 5) Okra Price DONE
            //Display the Current Cost of Louisiana Hot Spiced Okra,
            //the Number in Stock, and its name
            //Retrieve Okra, then push the other values in the View.

            var okra = ctx.Products.Where(o => o.ProductName.ToLower() == "louisiana hot spiced okra");



            ViewBag.Okra = okra;

            //keyword
            var okraK = from o in ctx.Products
                        where o.ProductName.ToLower() == "louisiana hot spiced okra"
                        select o;
            ViewBag.OkraK = okraK;





                        #endregion

                        #region 6) Products with units on order DONE
            //Return all of the product names that have pending units on
            //order - Display the product name AND how many units on order
            var order = ctx.Products.Where(o => o.UnitsOnOrder > 0);

            ViewBag.Order = order;

            //keyword
            var orderK = from o in ctx.Products
                         where o.UnitsOnOrder > 0
                         select o;
            ViewBag.OrderK = orderK;


                         #endregion

                         #region 7) Active products < 10 highest price first
            //List all Active products that less than $10
            //(highest price first) - Display the Product name and price
            var activeProds = ctx.Products.Where(act => act.UnitPrice < 10 && act.UnitsInStock > 0).OrderByDescending(act => act.UnitPrice);

            ViewBag.Active = activeProds;

            //Keyword
            var activeProdsK = from a in ctx.Products
                               where a.UnitPrice < 10 && a.UnitsInStock > 0
                               orderby a.UnitPrice descending
                               select a;
            ViewBag.ActiveK = activeProdsK;


                               #endregion

                               #region 8)Discontinued Prods, How many in stock, Total Price of each 
            //List all discontinued items and how many we have in stock
            //with their total price
            var discontinued = ctx.Products.Where(prods => prods.Discontinued);
            ViewBag.Discontinued = discontinued;

            //Keyword
            var disK = from d in ctx.Products
                       where d.Discontinued
                       select d;
            ViewBag.DiscontinuedK = disK;



            #endregion
            #endregion
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}