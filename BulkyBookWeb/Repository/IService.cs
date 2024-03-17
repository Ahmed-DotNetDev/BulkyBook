using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository
{
    public interface IService
    {
        Category Finder(int id);
    }
}
