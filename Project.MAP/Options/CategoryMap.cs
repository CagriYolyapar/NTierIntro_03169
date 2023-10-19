using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Kategoriler");
            Property(x => x.CategoryName).HasColumnName("Kategori Adi").IsRequired().HasMaxLength(40); //IsRequired() metodu bir sütunun SQL'de null gecilememesini saglar...
            Property(x => x.Description).HasColumnName("Aciklama");
            
        }
    }
}
