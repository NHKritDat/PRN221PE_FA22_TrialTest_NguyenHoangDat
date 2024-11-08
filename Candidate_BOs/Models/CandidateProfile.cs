using Candidate_BOs.Validates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candidate_BOs.Models;

public partial class CandidateProfile
{
    [Required]
    public string CandidateId { get; set; } = null!;
    [Required]
    [MinLength(13, ErrorMessage = "FullName is greater than 12 characters.")]
    [CapitalizeEachWord]
    public string Fullname { get; set; } = null!;
    [Required]
    public DateTime? Birthday { get; set; }
    [Required]
    [MinLength(12, ErrorMessage = "ProfileDescription from 12 – 200 characters.")]
    [MaxLength(200, ErrorMessage = "ProfileDescription from 12 – 200 characters.")]
    public string? ProfileShortDescription { get; set; }
    [Required]
    public string? ProfileUrl { get; set; }
    [Required]
    public string? PostingId { get; set; }

    public virtual JobPosting? Posting { get; set; }
}
