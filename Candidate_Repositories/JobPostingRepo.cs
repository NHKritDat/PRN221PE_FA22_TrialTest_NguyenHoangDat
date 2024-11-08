using Candidate_BOs.Models;
using Candidate_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public void AddJobPosting(JobPosting jobPosting)=>JobPostingDao.Instance.AddJobPosting(jobPosting);

        public void DeleteJobPosting(string id) => JobPostingDao.Instance.DeleteJobPosting(id);

        public JobPosting? GetJobPosting(string id) => JobPostingDao.Instance.GetJobPosting(id);

        public List<JobPosting> GetJobPostings()=> JobPostingDao.Instance.GetJobPostings();

        public void UpdateJobPosting(JobPosting jobPosting) => JobPostingDao.Instance.UpdateJobPosting(jobPosting);
    }
}
