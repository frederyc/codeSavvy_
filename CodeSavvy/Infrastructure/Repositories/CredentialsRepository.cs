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
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly DatabaseContext _db;

        public CredentialsRepository(DatabaseContext db)
            => _db = db;

        public Task<Credentials> CreateCredentials(Credentials credentials)
        {
            _ = credentials ?? throw new CredentialsNullArgumentException();
            _db.Credentials.Add(credentials);
            _db.SaveChanges();
            return Task.FromResult(credentials);
        }

        public Task<Credentials> DeleteCredentials(int credentialsId)
        {
            var credentials = GetCredentials(credentialsId).Result;
            _db.Credentials.Remove(credentials);
            _db.SaveChanges();
            return Task.FromResult(credentials);
        }

        public Task<Credentials> GetCredentials(int credentialsId)
        {
            var credentials = _db.Credentials.Find(credentialsId) ??
                              throw new CredentialsNotFoundException($"Credentials with Id: {credentialsId} could not be found");

            return Task.FromResult(credentials);
        }

        public Task<Credentials> UpdateCredentials(int credentialsId, Credentials credentials)
        {
            _ = GetCredentials(credentialsId);              // Check if credentials exist, before updating it 
            _ = credentials ?? throw new CredentialsNullArgumentException();
            credentials.Id = credentialsId;
            _db.Credentials.Update(credentials);
            _db.SaveChanges();
            return Task.FromResult(credentials);
        }
    }
}
