using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Asset 
{
    public int Id { get; set; }
    public string Ptype { get; set; }
    public string PBrand { get; set; }
    public string PModel { get; set; }
    public string POffices { get; set; }
    public DateTime PPurcdate { get; set; }
    public double PPrice { get; set; }
    public string PCurrency { get; set; }
    public float locPrice { get; set; }
  

}

public class Computer : Asset
{
    public Computer()
    {
    }
}
public class Mobile : Asset
{
    public Mobile()
    {
    }
}
