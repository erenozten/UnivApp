using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivApp.Repositories.Abstract
{
    public interface IRepository<TEntityHere> where TEntityHere: class
    {
        TEntityHere GetById(int? id);
        //Yukarıdaki GetById metodu içine bir id değeri alıyor ama ne dönderecek? Bir student mi, bir Instructor mu? Bunu bilmiyoruz kodumuz şu haldeyken:
        //GetById(int id);
        //Bilmediğimiz için, bu IRepository interface'imizi Generic hale getirmeliyiz.
        //Bunu belirtelim ve kodun eski yeni hali aşağıda yorum şeklinde gösteriliyor.
        // public interface IRepository
        // public interface IRepository<TEntityHere> (örnekte TEntity denmiş, ben de TEntityHere yazdım ki bunun bir keyword olmadığı anlaşılsın.
        //Şimdi ise, bu TEntityHere entity'sinin bir class olduğunu (olacağını) belirtelim. Son halimiz şu:
        //public interface IRepository<TEntityHere> where TEntityHere: class
        //Şimdi property'mize hangi entity'den data gelecekse onu return edeceğini belirtme zamanı:
        //eski hal: GetById(int id);
        //yeni hal: TEntityHere GetById(int id);
        IEnumerable<TEntityHere> GetAll();
        //Ve yukarıda bir metodumuz daha var "GetAll();" şeklinde. Peki bu ne dönderecek? Şu anki haliyle ne döneceği belirsiz.
        //Ne dönecek? TEntityHere'nin listesini dönecek değil mi? O halde yeni halimiz şu:
        // IEnumerable<TEntityHere> GetAll();
        void Add(TEntityHere tEntityHere);
        //Gelelim diğer metodumuza. Add(); metodu. Bu metod herhangi bir değer dönecek mi? Hayır. Hiçbir şey dönmeyecek.
        //Peki içine parametre olarak ne alması gerekir? Tabi ki bir TEntityHere almalı ki onu db'ye kaydedebilelim değil mi? O sırasıyla bunları belirtme vakti.
        //Şimdi, geriye bir değer dönmeyeceğimizi, yani return etmeyeceğimizi biliyoruz. O halde bunu belirtelim bi:
        //eski hal: Add();
        //yeni hal: void Add();
        //İşlem tamam. Şimdi de içine bir TEntityHere alacak olduğunu belirtelim:
        //eski hal void Add();
        //yeni hal: void Add(TEntityHere tEntityHere);
        void AddRange(IEnumerable<TEntityHere> tEntityHereList);
        //AddRange metodu, toplu halde entity'nin db'ye eklenme işlemini gerçekleştirecek. O halde:
        //Ne döndürecek? Hiçbir şey döndürmeyecek. İçine ne alacak? İçine db'ye kaydedeceği bu entity'leri alacak. Yani:
        //eski hal: AddRange();
        //yeni hal: void AddRange(IEnumerable<TEntityHere> tEntityHereList);
        void Remove(int id);
        //Remove metodu, dışarıdan bir ID alacak ve geriye bir şey dönmeyecek. ID alacak çünkü bu değere göre db'den bir veri silecek.
        //eski hal: Remove();
        //yeni hal: void Remove(int id);
        void RemoveRange(IEnumerable<TEntityHere> tEntityHereList);
        //RemoveRange ise toplu silme işlemi yapacak. O halde:
        //eski hal: RemoveRange();
        //yeni hal: void RemoveRange(IEnumerable<TEntityHere> tEntityHereList);

        void Edit(TEntityHere entityHere);
       
    }
}
