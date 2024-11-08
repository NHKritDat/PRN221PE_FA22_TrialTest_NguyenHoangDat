using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface ICandidateProfileRepo
    {
        public CandidateProfile? GetCandidateProfile(string id);
        public void AddCandidateProfile(CandidateProfile candidateProfile);
        public void UpdateCandidateProfile(CandidateProfile candidateProfile);
        public void DeleteCandidateProfile(string id);
        public List<CandidateProfile> GetCandidateProfiles();
    }
}
