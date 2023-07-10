using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserProfile.Pages;

public class Files : PageModel
{
    public string dirContent { get; set; }

    public void OnGet([FromQuery] string directory)
    {
        // Get directory contents
        /*System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        if (Regex.IsMatch(directory, @"^[a-zA-Z]+$"))
        {
            startInfo.Arguments = $"/C dir {directory}";
        }
        else
        {
            startInfo.Arguments = $"/C dir C:\\";
        }

        startInfo.RedirectStandardOutput = true;
        process.StartInfo = startInfo;
        Console.WriteLine(process.StartInfo.Arguments);
        process.Start();
        dirContent = process.StandardOutput.ReadToEnd();
        process.WaitForExitAsync();*/
    }

    public void OnPost([FromBody] string filename)
    {
        // Add image to archive and rename it
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = $"/C rename {filename}.jpg + Archive.rar Image2.jpg";
        process.StartInfo = startInfo;
        process.Start();
    }
}