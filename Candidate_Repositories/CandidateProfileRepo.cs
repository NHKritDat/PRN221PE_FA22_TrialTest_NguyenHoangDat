using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public void AddCandidateProfile(CandidateProfile candidateProfile) => Candidate_Daos.CandidateProfileDao.Instance.AddCandidateProfile(candidateProfile);

        public void DeleteCandidateProfile(string id) => Candidate_Daos.CandidateProfileDao.Instance.DeleteCandidateProfile(id);

        public CandidateProfile? GetCandidateProfile(string id) => Candidate_Daos.CandidateProfileDao.Instance.GetCandidateProfile(id);

        public List<CandidateProfile> GetCandidateProfiles() => Candidate_Daos.CandidateProfileDao.Instance.GetCandidateProfiles();

        public void UpdateCandidateProfile(CandidateProfile candidateProfile) => Candidate_Daos.CandidateProfileDao.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
