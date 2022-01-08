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
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly DatabaseContext _db;

        public CredentialsRepository(DatabaseContext db)
            => _db = db;

        public async Task<Credentials> CreateCredentials(Credentials credentials)
        {
            _ = credentials ?? throw new CredentialsNullArgumentException();
            await _db.Credentials.AddAsync(credentials);
            await _db.SaveChangesAsync();
            return credentials;
        }

        public async Task<Credentials> DeleteCredentials(int credentialsId)
        {
            var credentials = await GetCredentials(credentialsId);
            _db.Credentials.Remove(credentials);
            await _db.SaveChangesAsync();
            return credentials;
        }

        public async Task<Credentials> GetCredentials(int credentialsId)
        {
            var credentials = await _db.Credentials
                                  .FindAsync(credentialsId) ??
                              throw new CredentialsNotFoundException($"Credentials with Id: {credentialsId} could not be found");
            return credentials;
        }

        public async Task<Credentials> GetCredentials(string email)
        {
            var credentials = await _db.Credentials.Where(c => c.Email == email).FirstAsync();
            return credentials;
        }

        public async Task<Credentials> UpdateCredentials(int credentialsId, Credentials credentials)
        {
            _ = credentials ?? throw new CredentialsNullArgumentException();            // Check if credentials argument is null
            var credentialsEntity = await GetCredentials(credentialsId);                // Get credentials entity from db
            credentialsEntity.Email = credentials.Email;                                // Set email and password of entity with user input
            credentialsEntity.Password = credentials.Password;          
            await _db.SaveChangesAsync();                                   
            return credentials;
        }
    }
}
