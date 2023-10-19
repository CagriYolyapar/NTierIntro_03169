using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T:BaseEntity
    {
        //List Commands
        List<T> GetAll(); //bu metot ilgili T neyse o yapıdaki tüm verileri getirecek
        List<T> GetActives(); //bu metot ilgili T neyse  sadece Aktif kullanımda olan verileri getirecek...
        List<T> GetPassives(); //bu metot sadece Pasif olan verileri getirecek
        List<T> GetModifieds(); //bu metot sadece güncellenmiş olan verileri getirecek...

        //Modify Commands

        void Add(T item);
        void AddRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);
        void Delete(T item); //bu metot veriyi pasifize eder
        void DeleteRange(List<T> list);
        void Destroy(T item); //bu metot veriyi yok eder
        void DestroyRange(List<T> list);

        //Linq Expressions

        //Bir Expression ifadesi iki kısımdan olusur : x =>     x.UnitPrice  < 20

        // 1. kısım (x => ) : ifadenin argüman kısmıdır...Lambda operatoru konuldugu anda ilgili degişkeniniz Expression destekleyen metotan önce hangi yapı geliyorsa onu tekil olarak alır (TSource)   _db.Products.Where( x => )

        // x.UnitPrice < 20  :  ifadenin sorgu kısmıdır...Mevcut durumda bool olarak ifade edilmşitir...

        // x => x.UnitPrice < 20  bu iki kısım birleştigi zaman sistemi tek basına yonetebilecek bir delegate'e girerler... Delegate icerisine x'i alıp , bool ifadeye göre dısarıya bir sorgu sonucu döndürür...Bu delegate Expression tipi (class) sayesinde bir argüman olarak bilinir...
        
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);

        //Select(  x => new CategoryVM{}   )

        object Select(Expression<Func<T, object>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp); //Select<CategoryVM> (x => new CategoryVM {}) 

        //dgvResult.DataSource = _db.Categories.Select (x => new CategoryVM {Isim = x.CategoryName, Aciklama = x.Description}).ToList();
        //dgvResult.DataSource = _db.Categories.Select<CategoryVM>(x => new CategoryVM)
        // (x => x.UnitPrice < 20)    Func<T,bool>
        // (x => )    Func<T,object>

        //  Func<T,X>

        //Find
        T Find(int id);


        //Get Last Datas
        List<T> GetLastDatas(int number=1);

        //Get First Datas
        List<T> GetFirstDatas(int number=1);

        //Get Datas
        List<T> GetCountedDatas(int number=1);
       


 
        


    }
}
