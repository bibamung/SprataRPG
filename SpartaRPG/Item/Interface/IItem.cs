using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Item.Interface
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        int IncreaseUnit { get; set; }
        int PurchasePrice { get; }
        int Quantity { get; set; }
        bool isEquip { get; set; }
    }
}
