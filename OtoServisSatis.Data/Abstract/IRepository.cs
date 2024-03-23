using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        //Senkron repository interfaceleri
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);   //tüm verileri verilen parametreye göre getirecek
        T Get(Expression<Func<T,bool>>expression);      //bulduğun tekli veriyi lambda parametresine göre getir
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete (T entity);
        int Save();

        //Asenkron repository interfaceleri
        // Bir işlem yapılırken başka bir işlemi yapmaya olanak tanır(uzun sürecek işlemler için makuldür)

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);        //lambda express
        Task AddAsync(T entity);                                                //girilen data
        Task<T> FindAsync(int id); 
        Task<T> GetAsync(Expression<Func<T, bool>>expression);
        Task<int> SaveAsync();

    }
}
