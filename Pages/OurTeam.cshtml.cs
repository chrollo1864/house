using Microsoft.AspNetCore.Mvc.RazorPages;
using HouseApp.Models;
using System.Collections.Generic;

namespace HouseApp.Pages
{
    public class OurTeamModel : PageModel
    {
        public List<TeamMember> TeamMembers { get; set; }

        public void OnGet()
        {
            TeamMembers = new List<TeamMember>
            {
                new TeamMember
                {
                    Name = "John Raven Alpiedam",
                    Position = "Full Stack Developer (Backend, Frontend)",
                    Description = "Directly impacting the software's functionality and quality.",
                    ImageUrl = "/images/Prince.jpg"
                },
                new TeamMember
                {
                    Name = "Charles Bisco",
                    Position = "Full Stack Developer(Backend, Frontend)",
                    Description = "Improving the actual source code of the project.",
                    ImageUrl = "/images/bisco.jpg"
                },
                new TeamMember
                {
                    Name = "Khatrina Khate Bravante",
                    Position = "Content Manager",
                    Description = "Writer, Modifying the Inputted Commentary, Sources the Inputted Items.",
                    ImageUrl = "/images/Khate.jpg"
                }
            };
        }
    }
}

