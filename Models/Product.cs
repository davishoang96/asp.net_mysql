using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace asp.net_mysql_crud.Models
{
  [Table("Product")]
  public class Product
  {
    public string Id {get;set;}
    public string Name {get;set;}
    public double Price {get;set;}
    public int Quantity {get;set;}
    public bool Status {get;set;}
  }
}