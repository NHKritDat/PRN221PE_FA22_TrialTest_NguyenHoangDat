using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BOs.Models;
using Candidate_Repositories;

namespace CandidateManagement_NguyenHoangDat.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;
        private readonly IJobPostingRepo _jobPostingRepo;

        public CreateModel(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
            _jobPostingRepo = jobPostingRepo;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(_jobPostingRepo.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("CandidateProfile.Posting");
            if (!ModelState.IsValid)
            {
                ViewData["PostingId"] = new SelectList(_jobPostingRepo.GetJobPostings(), "PostingId", "JobPostingTitle");
                return Page();
            }

            _candidateProfileRepo.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
