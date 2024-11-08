using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BOs.Models;
using Candidate_Repositories;

namespace CandidateManagement_NguyenHoangDat.Pages.JobPostingPage
{
    public class IndexModel : PageModel
    {
        private readonly IJobPostingRepo _jobPostingRepo;

        public IndexModel(IJobPostingRepo jobPostingRepo)
        {
            _jobPostingRepo = jobPostingRepo;
        }

        public IList<JobPosting> JobPosting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JobPosting = _jobPostingRepo.GetJobPostings();
        }
    }
}
