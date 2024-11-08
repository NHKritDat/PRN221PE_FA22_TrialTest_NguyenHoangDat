using Candidate_BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Daos
{
    public class JobPostingDao
    {
        private static JobPostingDao instance;
        private CandidateManagementContext _context;
        public JobPostingDao()
        {
            if (_context == null)
            {
                _context = new CandidateManagementContext();
            }
        }
        public static JobPostingDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDao();
                }
                return instance;
            }
        }

        public JobPosting? GetJobPosting(string id) => _context.JobPostings.FirstOrDefault(x => x.PostingId == id);
        public List<JobPosting> GetJobPostings() => _context.JobPostings.ToList();
        public void AddJobPosting(JobPosting jobPosting)
        {
            _context.JobPostings.Add(jobPosting);
            _context.SaveChanges();
            _context.Entry(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
        public void UpdateJobPosting(JobPosting jobPosting)
        {
            JobPosting? old = GetJobPosting(jobPosting.PostingId);
            if (old != null)
            {
                _context.JobPostings.Update(jobPosting);
                _context.SaveChanges();
                _context.Entry(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
        public void DeleteJobPosting(string id)
        {
            JobPosting? jobPosting = GetJobPosting(id);
            if (jobPosting != null)
            {
                _context.JobPostings.Remove(jobPosting);
                _context.SaveChanges();
                _context.Entry(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
