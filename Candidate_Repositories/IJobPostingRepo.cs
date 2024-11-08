using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IJobPostingRepo
    {
        public JobPosting? GetJobPosting(string id);
        public List<JobPosting> GetJobPostings();
        public void AddJobPosting(JobPosting jobPosting);
        public void UpdateJobPosting(JobPosting jobPosting);
        public void DeleteJobPosting(string id);
    }
}
