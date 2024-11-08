using Candidate_BOs.Models;
using Candidate_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HraccountRepo : IHraccountRepo
    {
        public Hraccount? GetHraccount(string email, string password) => HraccountDao.Instance.GetHraccount(email, password);
    }
}
