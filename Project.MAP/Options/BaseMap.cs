using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    //Ayarlamaları yapmakla görevli olan sınıfınız aslında EntityTypeConfiguration isimli generic sınıftır...Bu sınıf cagrıldıgı zaman (dikkat ederseniz asagıda miras almak icin cagırıyoruz) generic tipinin belirlenmesini veya belirlenemiyorsa devam ettirilmesini saglamanız lazım...Dikkat ederseniz asagıda EntityTypeConfiguration class'ını miras almak icin cagırdıgımız zaman generic tipini belirlemiyoruz...Cünkü eger belirlersek tüm veritabanı ayarlama işlemlerimiz sadece o belirledigimiz sınıf üzerinden yapılır...Bizim asıl istegimiz EntityTypeCOnfiguration sınıfının cagrıldıgı yerde genericligini devam ettirmesi...Ancak generic bir sınıf cagrılırsa genericligini elinizde bir generic yapı olmadan devam ettiremez...Dolayısıyla biz önce BaseMap'te belirledigimiz generic yapıyı (T'yi) EntityTypeConfiguration'a veriyoruz ve böylece EntityTypeConfiguration generic tipini belirlememiş ve hala devam ettiriyor bir şekilde cagırıyor...Yalnız EntityTypeConfiguration isimli sınıfın generic tipinde istedigi bir şart vardır o da ilgili tipin sadece class olabilmesi ....
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Yaratılma Tarihi");
            Property(x => x.DeletedDate).HasColumnName("Silme Tarihi");
            Property(x => x.ModifiedDate).HasColumnName("Guncelleme Tarihi");
            Property(x => x.Status).HasColumnName("Veri Durumu");
        }
    }

    //BaseMap<Category>
    //BaseMap<Product>
    //BaseMap<Order>
}
