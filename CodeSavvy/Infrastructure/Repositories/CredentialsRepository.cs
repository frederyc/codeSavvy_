using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.DataAccess;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly DatabaseContext _db;

        public CredentialsRepository(DatabaseContext db)
            => _db = db;

        public Task<Credentials> CreateCredentials(Credentials credentials)
        {
            _db.Credentials.Update(credentials);
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
            var credentials = _db.Credentials.Find(credentialsId);
            return Task.FromResult(credentials);
        }

        public Task<Credentials> UpdateCredentials(
            int credentialsId,
            Credentials credentials)
        {
            credentials.Id = credentialsId;
            _db.Credentials.Update(credentials);
            _db.SaveChanges();
            return Task.FromResult(credentials);
        }
    }
}
