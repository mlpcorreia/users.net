using Microsoft.AspNetCore.Mvc;

namespace UserProfile.Pages;

public class UserParam
{
    [BindProperty] public string uname { get; set; }
    [BindProperty] public string profile { get; set; }
    [BindProperty] public string role { get; set; }
}