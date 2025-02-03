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
        int PurchasePrice { get; }
    }
}
