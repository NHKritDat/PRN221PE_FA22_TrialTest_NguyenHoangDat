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
    public class DetailsModel : PageModel
    {
        private readonly IJobPostingRepo _jobPostingRepo;

        public DetailsModel(IJobPostingRepo jobPostingRepo)
        {
            _jobPostingRepo = jobPostingRepo;
        }

        public JobPosting JobPosting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = _jobPostingRepo.GetJobPosting(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            else
            {
                JobPosting = jobposting;
            }
            return Page();
        }
    }
}
