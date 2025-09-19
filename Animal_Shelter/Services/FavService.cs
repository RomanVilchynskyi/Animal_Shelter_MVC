using Animal_Shelter.Data;
using Animal_Shelter.Data.Entities;
using Animal_Shelter.Extensions;
using Animal_Shelter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Animal_Shelter.Services
{
    public class FavService : IFavService
    {
        private readonly HttpContext httpContext;
        private readonly ShelterDbContext ctx;

        public FavService(ShelterDbContext ctx, IHttpContextAccessor contextAccessor)
        {
            this.ctx = ctx;

            this.httpContext = contextAccessor.HttpContext
                ?? throw new Exception("No HttpContext found.");
        }

        public void Add(int id)
        {
            var existingIds = httpContext.Session.Get<List<int>>("FavItems");
            List<int> ids = existingIds ?? new();

            ids.Add(id);

            httpContext.Session.Set("FavItems", ids);
        }
        public void Remove(int id)
        {
            var existingIds = httpContext.Session.Get<List<int>>("FavItems");
            List<int> ids = existingIds ?? new();

            ids.Remove(id);

            httpContext.Session.Set("FavItems", ids);
        }

        public void Clear()
        {
            httpContext.Session.Remove("FavItems");
        }
        public int GetFavSize()
        {
            var ids = httpContext.Session.Get<List<int>>("FavItems");
            return ids?.Count ?? 0;
        }

        public List<int> GetItemIds()
        {
            return httpContext.Session.Get<List<int>>("FavItems") ?? new List<int>();
        }

        public List<AnimalQuestionnaire> GetAnimals()
        {
            var existingIds = GetItemIds();

            return ctx.AnimalQuestionnaires
                .Include(a => a.Species)
                .Include(a => a.Breed)
                .Include(a => a.Gender)
                .Where(x => existingIds.Contains(x.Id))
                .ToList();
        }

    }
}
