using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnivApp.DAL;
using UnivApp.Repositories.Abstract;

namespace UnivApp.Repositories.Concrete
{
    public class Repository<TEntityHere> : IRepository<TEntityHere> where TEntityHere : class
    {
        //Dikkat! Burada database'de update yapmıyoruz! yani SaveChanges işlemi burada yapılmıyor. Yani db bağlantısını UnitOfWork class'ında yapacağız.
        protected UnivAppContext _db; //context field'ı
        private DbSet<TEntityHere> _dbSet; // sürekli set etme işlemi için dbset<TentityHere>.Set yazmamak için burada bir field oluşturduk. Constructor içinde de bu field'ı set ettik. Burada olan olayı anlamak için 3532 no'lu comment'i incele.

        //Repository class'ını kullanmak isteyen, ona bir dbcontext nesnesi vermek zorunda. Böyle bir zorunluluk var ise ortada; bu context eşitleme işlemini Constructor'da yapmak mantıklı olur:
        public Repository(UnivAppContext db)
        {
            _db = db; //dışarıdan gelen context'i (db), context field'ımıza eşitledik (_db)
            _dbSet = _db.Set<TEntityHere>(); // sürekli 
        }

        //eski hal: public class Repository{
        //yeni hal: Repository: IRepository{
        //Yaptığımız değişim belli zaten: Buradaki Repository Class'ımıza IRepository interface'ini implement ettik.

        //eski hal: Repository: IRepository{
        //yeni hal: public class Repository<TEntityHere>: IRepository<TEntityHere>
        //Buradaki Repository class'ımız da içine hangi tipin geleceğini bilmiyor. O yüzden bunu Generic olarak belirlememiz gerekiyordu. Bunu yaptık. Biraz detay aşağıda:

        //generic olarak belirttiğimiz kısım: public class Repository<TEntityHere>
        //Buraya gelecek olan generic entity'mizi, yani TEntityHere'yi şimdi de IRepository'e gönderiyoruz kodun şu kısmında:
        //  : IRepository<TEntityHere>
        //Yani şu durumda bilindiği üzere; IRepository'e gönderilecek olan değer, generic bir değer. Yani IRepository'e Student mi yolluyoruz, Instructor mu vb ne olduğu Runtime'da belli olacak.

        //eski hal: public class Repository<TEntityHere> : IRepository<TEntityHere>
        // yeni hal: public class Repository<TEntityHere> : IRepository<TEntityHere> where TEntityHere: class
        //burada ise gelen TEntityHere'nin bir class olduğunu belirttik tıpkı IRepository'de olduğu gibi.

        public void Add(TEntityHere tEntityHere)
        {
            _db.Set<TEntityHere>().Add(tEntityHere); // bu soldaki, entity framework'ün generic olan Set metodudur.
            //yani şu ifadeler aslında birbirine eşit:
            //_db.Students = _db.Set<Student>()
        }

        public void Edit(TEntityHere entityHere)
        {
            _db.Entry(entityHere).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntityHere> tEntityHereList)
        {
            //_db.Set<TEntityHere>().AddRange(tEntityHereList);

            //3532 yukarıda yazdığımız set etme işlemini _dbset field'ını kullanarak yazalım. Böylelikle daha kolay bir yazım olmuş olacak:
            //eski hal: _db.Set<TEntityHere>().AddRange(tEntityHereList);
            //yeni hal ise aşağıda:
            _dbSet.AddRange(tEntityHereList);
        }
        //3532
        public IEnumerable<TEntityHere> GetAll()
        {
            return _dbSet.ToList(); //liste geri dönderdik.
        }

        public TEntityHere GetById(int? id)
        {
            if (id == null)
            {
                //throw new Exception("ID can not be null!");
            }

            TEntityHere tEntity = _dbSet.Find(id);

            if (tEntity == null)
            {
                //throw new Exception("Data with given ID is not found!");

            }

            return tEntity;
        }

        public void Remove(int id)
        {
            _dbSet.Remove(GetById(id)); //herhangi birşey dönmedik
            //bu kodu incele. Remove içinde GetById metodu çalıştırdık. Çünkü Remove metodu bir Entity (bizim örnekte TEntityHere) bekliyor parametre olarak. Biz de GetById metodunu kullandık çünkü bu metod da ID'ye göre bir Entity dönüyor ((bizim örnekte TEntityHere).
        }

        public void RemoveRange(IEnumerable<TEntityHere> tEntityHereList)
        {
            _dbSet.RemoveRange(tEntityHereList); 
        }
    }
}