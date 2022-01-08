using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Domain.Interfaces
{
    public interface ICredentialsRepository
    {
        Task<Credentials> CreateCredentials(Credentials credentials);
        Task<Credentials> GetCredentials(int credentialsId);
        Task<Credentials> GetCredentials(string email);
        Task<Credentials> DeleteCredentials(int credentialsId);
        Task<Credentials> UpdateCredentials(int credentialsId, Credentials credentials);
    }
}
