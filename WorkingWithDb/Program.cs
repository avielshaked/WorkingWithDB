﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                List<Product> products = context.Products.Where(p => p.UnitPrice > 80).ToList();
                products.ForEach(p => Console.WriteLine(p.ProductName));

                Console.WriteLine("-----------------------");

                List<string> products2 = context.Products.Where(p => p.UnitPrice > 80).Select(p => p.ProductName).ToList();
                products2.ForEach(p => Console.WriteLine(p));

                Console.WriteLine("-----------------------");

                var product3 = context.Products.Where(p => p.UnitPrice > 80).FirstOrDefault();
                Console.WriteLine(product3.ProductName);

                Console.WriteLine("-----------------------");

                List<string> products4 = context.Products.Where(p => p.UnitPrice > 80).OrderByDescending(p => p.ProductName).Select(p => p.ProductName).ToList();



                var query = from p in context.Products
                            where p.UnitPrice > 80
                            group p by p.CategoryID into f

                            select new
                            {
                                categoryid = f.Key,
                                productname = f.Count()
                            };

                foreach (var item in query)
                {
                    Console.WriteLine("{0},{1}", item.categoryid, item.productname);
                }

                var listP = from p in context.Products
                            join c in context.Categories
                            on p.CategoryID equals c.CategoryID
                            where p.CategoryID == 1
                            select new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.CategoryID,
                                c.CategoryName,
                                c.Description
                            };

                var cat = from p in context.Products
                          where p.ProductName.Equals("Chang")
                          select new
                          {
                              p.CategoryID
                          };
                int? cat2 = cat.Select(c => c.CategoryID).SingleOrDefault();

                string catName = context.Categories.Where(c => c.CategoryID == cat2).Select(c => c.CategoryName).FirstOrDefault();

                string catname2 = (from c in context.Categories
                                   where c.CategoryID == cat2
                                   select c.CategoryName).FirstOrDefault();

                var units = from p in context.Products
                            where new[] { 1, 2 }.Any(s => s == p.CategoryID)
                            group p by p.CategoryID into gruped
                            select new
                            {
                                categoryid = gruped.Key,
                                unitsinorderPerCat = gruped.Sum(p => p.UnitsOnOrder)
                            };

            };

            Console.WriteLine(SimpleReturn());
            Console.WriteLine(SimpleReturn());
            Console.WriteLine(SimpleReturn());
            Console.WriteLine(SimpleReturn());

            foreach (int item in YieldReturn())
            {
                Console.WriteLine(item);
            }

            string asasa = ExtractTextFromPDF(@"C:\Users\shake\Downloads\ionic_mifrat.pdf");

            string rst = ReverseString(asasa);

            string text = "מרכזי המכירה של יונדאי";
            if (rst.Contains(text))
                Console.Write("ok");

            string text2 = "hybrid";
            if (rst.Contains(text2))
                Console.Write("Ok");



        }




        static int SimpleReturn()
        {
            return 1;
            return 2;
            return 3;
        }

        static IEnumerable<int> YieldReturn()
        {
            yield return 55;
            yield return 44;
            yield return 33;
        }

        static Func<int, int, int> sum = (num1, num2) => num1 + num2;
    }
    }
}
