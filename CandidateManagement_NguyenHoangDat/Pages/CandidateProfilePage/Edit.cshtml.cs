using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BOs.Models;
using Candidate_Repositories;

namespace CandidateManagement_NguyenHoangDat.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;
        private readonly IJobPostingRepo _jobPostingRepo;

        public EditModel(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
            _jobPostingRepo = jobPostingRepo;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateProfileRepo.GetCandidateProfile(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(_jobPostingRepo.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("CandidateProfile.Posting");
            if (!ModelState.IsValid)
            {
                ViewData["PostingId"] = new SelectList(_jobPostingRepo.GetJobPostings(), "PostingId", "JobPostingTitle");
                return Page();
            }

            try
            {
                _candidateProfileRepo.UpdateCandidateProfile(CandidateProfile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateProfileExists(string id)
        {
            return _candidateProfileRepo.GetCandidateProfile(id) != null;
        }
    }
}
