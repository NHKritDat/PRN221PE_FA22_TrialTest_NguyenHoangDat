using Candidate_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_NguyenHoangDat.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHraccountRepo _hraccountRepo;
        public LoginModel(IHraccountRepo hraccountRepo)
        {
            _hraccountRepo = hraccountRepo;
        }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var email = Request.Form["txtEmail"];
            var password = Request.Form["txtPassword"];
            var account = _hraccountRepo.GetHraccount(email, password);
            if (account == null || account.MemberRole == 3)
                ErrorMessage = "You are not allowed to do this function!";
            else
            {
                HttpContext.Session.SetString("RoleID", account.MemberRole.ToString());
                Response.Redirect("/CandidateProfilePage");
            }
        }
    }
}
