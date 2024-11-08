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
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;
        private readonly IJobPostingRepo _jobPostingRepo;

        public IndexModel(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
            _jobPostingRepo = jobPostingRepo;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; } = default!;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPages { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public string FullName { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public DateTime? Birthday { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            PageNumber = pageNumber;

            var candidateProfiles = _candidateProfileRepo.GetCandidateProfiles();
            if (!string.IsNullOrEmpty(FullName))
                candidateProfiles = candidateProfiles.Where(c => c.Fullname.ToLower().Contains(FullName.ToLower())).ToList();
            if(Birthday.HasValue)
                candidateProfiles = candidateProfiles.Where(c => c.Birthday == Birthday).ToList();

            var totalItems = candidateProfiles.Count;
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            candidateProfiles = candidateProfiles.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

            candidateProfiles.ForEach(candidateProfile =>
            {
                candidateProfile.Posting = _jobPostingRepo.GetJobPosting(candidateProfile.PostingId);
            });
            CandidateProfile = candidateProfiles;
        }
    }
}
