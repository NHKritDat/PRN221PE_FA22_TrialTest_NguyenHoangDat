using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Daos
{
    public class HraccountDao
    {
        private static HraccountDao instance;
        private CandidateManagementContext _context;
        public HraccountDao()
        {
            if (_context == null)
            {
                _context = new CandidateManagementContext();
            }
        }
        public static HraccountDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HraccountDao();
                }
                return instance;
            }
        }

        public Hraccount? GetHraccount(string email, string password) => _context.Hraccounts.FirstOrDefault(x => x.Email == email && x.Password == password);
    }
}
