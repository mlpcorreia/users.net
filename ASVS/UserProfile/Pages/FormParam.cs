using Microsoft.AspNetCore.Mvc;

namespace UserProfile.Pages;

public class FormParam
{
    [BindProperty] public string uname { get; set; }
    [BindProperty] public string profile { get; set; }
}