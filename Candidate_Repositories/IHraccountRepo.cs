using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IHraccountRepo
    {
        public Hraccount? GetHraccount(string email, string password);
    }
}
