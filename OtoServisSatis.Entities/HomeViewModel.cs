using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class HomeViewModel
    {
        public virtual List<Slider> Sliders { get; set; }
        public virtual List<Arac> Aracs { get; set; }
    }
}
