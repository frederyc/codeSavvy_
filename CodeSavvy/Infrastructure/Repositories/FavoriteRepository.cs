using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly DatabaseContext _db;

        public FavoriteRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Task<Favorite> CreateFavoriteRecord(Favorite favorite)
        {
            _db.Favorites.Add(favorite);
            _db.SaveChanges();
            return Task.FromResult(favorite);
        }

        public Task<Favorite> DeleteFavoriteRecord(int favoriteId)
        {
            var favorite = GetFavoriteRecord(favoriteId).Result;
            _db.Favorites.Remove(favorite);
            return Task.FromResult(favorite);
        }

        public Task<Favorite> GetFavoriteRecord(int favoriteId)
        {
            var favorite = _db.Favorites.Find(favoriteId);
            return Task.FromResult(favorite);
        }

        public Task<Favorite> UpdateFavoriteRecord(int favoriteId, Favorite favorite)
        {
            favorite.Id = favoriteId;
            _db.Favorites.Update(favorite);
            _db.SaveChanges();
            return Task.FromResult(favorite);
        }

        public Task<List<Favorite>> GetFavoritesForEmployee(Employee employee)
        {
            return Task.FromResult(
                _db.Favorites.Where(f => f.Employee == employee).ToList()
            );
        }
    }
}
