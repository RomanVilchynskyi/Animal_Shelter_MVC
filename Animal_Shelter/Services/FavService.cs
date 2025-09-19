using Animal_Shelter.Extensions;
using Animal_Shelter.Interfaces;

namespace Animal_Shelter.Services
{
    public class FavService : IFavService
    {
        public int GetFavSize(HttpContext httpContext)
        {
            var ids = httpContext.Session.Get<List<int>>("FavItems");
            
            return ids?.Count ?? 0;
        }
    }
}
