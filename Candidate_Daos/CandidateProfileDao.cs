using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Daos
{
    public class CandidateProfileDao
    {
        private static CandidateProfileDao instance;
        public static CandidateProfileDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new CandidateProfileDao();
                return instance;
            }
        }
        private CandidateManagementContext _context;
        public CandidateProfileDao()
        {
            _context = new CandidateManagementContext();
        }
        public CandidateProfile GetCandidateProfile(string id) => _context.CandidateProfiles.FirstOrDefault(x => x.CandidateId == id);
        public List<CandidateProfile> GetCandidateProfiles() => _context.CandidateProfiles.ToList();
        public void AddCandidateProfile(CandidateProfile candidateProfile)
        {
            _context.CandidateProfiles.Add(candidateProfile);
            _context.SaveChanges();
            _context.Entry(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
        public void UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            CandidateProfile old = GetCandidateProfile(candidateProfile.CandidateId);
            if (old != null)
            {
                _context.CandidateProfiles.Update(candidateProfile);
                _context.SaveChanges();
                _context.Entry(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
        public void DeleteCandidateProfile(string id)
        {
            CandidateProfile candidateProfile = GetCandidateProfile(id);
            if (candidateProfile != null)
            {
                _context.CandidateProfiles.Remove(candidateProfile);
                _context.SaveChanges();
                _context.Entry(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
