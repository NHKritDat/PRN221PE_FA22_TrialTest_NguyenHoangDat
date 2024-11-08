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
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;
        private readonly IJobPostingRepo _jobPostingRepo;

        public DetailsModel(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
            _jobPostingRepo = jobPostingRepo;
        }

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
    }
}
