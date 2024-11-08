using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BOs.Models;
using Candidate_Repositories;

namespace CandidateManagement_NguyenHoangDat.Pages.JobPostingPage
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingRepo _jobPostingRepo;

        public CreateModel(IJobPostingRepo jobPostingRepo)
        {
            _jobPostingRepo = jobPostingRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _jobPostingRepo.AddJobPosting(JobPosting);

            return RedirectToPage("./Index");
        }
    }
}
