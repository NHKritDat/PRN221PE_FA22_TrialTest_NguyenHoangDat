using System;
using System.Collections.Generic;

namespace Candidate_BOs.Models;

public partial class JobPosting
{
    public string PostingId { get; set; } = null!;

    public string JobPostingTitle { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? PostedDate { get; set; }

    public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();
}
