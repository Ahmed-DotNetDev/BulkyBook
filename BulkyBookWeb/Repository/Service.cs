using BulkyBookWeb.Data;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository
{
    public class Service : IService
    {
        private readonly ApplicationDbContext _db;

        public Service(ApplicationDbContext db)
        {
            this._db = db;
        }
        public Category Finder(int id)
        {

            return _db?.categories?.Find(id);
        }
    }
}
