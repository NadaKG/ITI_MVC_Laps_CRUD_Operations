using Day8Task2.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Day8Task2.ViewModels
{
    public class Product_Cust_ViewModel
    {
      
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
    }
}
