using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    //Ientity arayüzü oluşturduk bunu diğer entity classlarına implemente edeceğiz
    public interface IEntity
    {
        //Id propunu zorunlu hale getirdik
        public int Id { get; set; }
    }
}
