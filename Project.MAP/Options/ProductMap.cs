using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    //Eger bir tipin ayarlamasını özel olarak belirlemişseniz o tip bir deger tipiyse SQL'e null gecilemez gider...Referans tipiyse SQL'e null gecilebilir gider.

    //Eger bir deger tipinin SQL'e null gecilebilir olarak gitmesini istiyorsanız o tipi hibritleştirirsiniz..
    public class ProductMap:BaseMap<Product>
    {
        public ProductMap()
        {
            ToTable("Urunler");
            Property(x => x.ProductName).HasColumnName("Urun Ismi").IsRequired();
            Property(x => x.UnitPrice).HasColumnName("Fiyat").HasColumnType("money");
        }
    }
}
