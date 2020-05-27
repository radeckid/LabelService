using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelService.Interfaces
{
    public interface IFeatures
    {
        string DeliveryIns { get; set; }

        string Price { get; set; }

        string Currency { get; set; }

        string Weight { get; set; }
    }
}
