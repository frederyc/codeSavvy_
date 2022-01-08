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
using Microsoft.EntityFrameworkCore;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly DatabaseContext _db;

        public FavoriteRepository(DatabaseContext db)
            => _db = db;

        public async Task<Favorite> CreateFavoriteRecord(Favorite favorite)
        {
            _ = favorite ?? throw new FavoriteNullArgumentException();
            await _db.Favorites.AddAsync(favorite);
            await _db.SaveChangesAsync();
            return favorite;
        }

        public async Task<Favorite> DeleteFavoriteRecord(int favoriteId)
        {
            var favorite = await GetFavoriteRecord(favoriteId);
            _db.Favorites.Remove(favorite);
            await _db.SaveChangesAsync();
            return favorite;
        }

        public async Task<Favorite> GetFavoriteRecord(int favoriteId)
        {
            var favorite = await _db.Favorites.Include(x => x.Employee)
                               .Include(x => x.Job)
                               .Include(x => x.Job.Employer)
                               .SingleAsync(x => x.Id == favoriteId) ?? 
                           throw new FavoriteNotFoundException($"Favorite with Id: {favoriteId} could not be found");
            return favorite;
        }

        public async Task<Favorite> UpdateFavoriteRecord(int favoriteId, Favorite favorite)
        {
            _ = GetFavoriteRecord(favoriteId);
            _ = favorite ?? throw new FavoriteNullArgumentException();

            favorite.Id = favoriteId;
            _db.Favorites.Update(favorite);
            await _db.SaveChangesAsync();
            return favorite;
        }

        public async Task<List<Favorite>> GetFavoritesForEmployee(int employeeId)
        {
            return await _db.Favorites.Where(x => x.Employee.Id == employeeId)
                .Include(x => x.Employee)
                .Include(x => x.Job)
                .Include(x => x.Job.Employer)
                .ToListAsync();
        }
    }
}
