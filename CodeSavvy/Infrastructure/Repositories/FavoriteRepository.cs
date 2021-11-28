using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Application.Exceptions.NotFoundException;
using CodeSavvy.Application.Exceptions.NullArgumentException;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly DatabaseContext _db;

        public FavoriteRepository(DatabaseContext db)
            => _db = db;

        public Task<Favorite> CreateFavoriteRecord(Favorite favorite)
        {
            _ = favorite ?? throw new FavoriteNullArgumentException();
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
            var favorite = _db.Favorites.Find(favoriteId) ?? 
                           throw new FavoriteNotFoundException($"Favorite with Id: {favoriteId} could not be found");
            return Task.FromResult(favorite);
        }

        public Task<Favorite> UpdateFavoriteRecord(int favoriteId, Favorite favorite)
        {
            _ = GetFavoriteRecord(favoriteId);
            _ = favorite ?? throw new FavoriteNullArgumentException();

            favorite.Id = favoriteId;
            _db.Favorites.Update(favorite);
            _db.SaveChanges();
            return Task.FromResult(favorite);
        }

        public Task<List<Favorite>> GetFavoritesForEmployee(Employee employee)
        {
            _ = employee ?? throw new EmployeeNullArgumentException();
            return Task.FromResult(
                _db.Favorites.Where(f => f.Employee == employee).ToList()
            );
        }
    }
}
