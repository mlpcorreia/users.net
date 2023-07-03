using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using RazorLight;

namespace UserProfile.Pages;

public class CustomTemplates : PageModel
{
    public string usertag { get; set; }
    
    public void OnGet()
    {
        string methodCode = @"
        string helloString =  $@""Hello """ + (String)Request.Query["name"] +
                            @"System.Console.WriteLine(""Test script"");
";

        var opt = ScriptOptions.Default;
        opt.AddImports("System");
        var state = CSharpScript.RunAsync(methodCode, opt).Result;
        Console.WriteLine("Code execution state: " + state);
    }

    public async void OnPost()
    {
        var engine = new RazorLightEngineBuilder()
            .UseMemoryCachingProvider()
            .Build();

        string username = Request.Query["username"];
        // Email template (for example)
        string template = @"<div>
<p>" + username + @"</p>
</div>";
        /*string template = @"<div>
<p>@Model.tmp</p>
</div>";*/
        usertag = await engine.CompileRenderStringAsync("templateKey", template, new {});
    }
    
}