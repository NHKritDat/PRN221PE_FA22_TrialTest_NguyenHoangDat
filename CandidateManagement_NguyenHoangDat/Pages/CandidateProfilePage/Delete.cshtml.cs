using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BOs.Models;
using Candidate_Repositories;

namespace CandidateManagement_NguyenHoangDat.Pages.CandidateProfilePage
{
    public class DeleteModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;
        private readonly IJobPostingRepo _jobPostingRepo;

        public DeleteModel(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
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
            else
            {
                candidateprofile.Posting = _jobPostingRepo.GetJobPosting(candidateprofile.PostingId);
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateProfileRepo.GetCandidateProfile(id);
            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _candidateProfileRepo.DeleteCandidateProfile(CandidateProfile.CandidateId);
            }

            return RedirectToPage("./Index");
        }
    }
}
