using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cloud_firestore_with_net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                title = "Cloud Firestore and .NET, is this possible?",
                description = "Implementing Firebase Cloud Firestore in an API in .NET 🤩",
                speaker = "Christian Sánchez",
                bio = "I am Software Engineer, Auth0 Ambassador and Postman Supernova",
                codeExample = "https://github.com/christiansc96/cloud-firestore-with-net",
                communities = new List<object>
                {
                    new
                    {
                        DevTeam504 = "Co-Founder & Organizer",
                        FlutterHonduras = "Co-Founder y Co-Organizer",
                        googleDSCUNAHVS = "Google DSC Lead"
                    }
                },
                socialMedia = new
                {
                    twitter = new
                    {
                        user = "@christian_sc96",
                        profile = "https://twitter.com/christian_sc96"
                    },
                    github = new
                    {
                        user = "@christiansc96",
                        profile = "https://github.com/christiansc96"
                    },
                    instagram = new
                    {
                        user = "@christian_sc96",
                        profile = "https://www.instagram.com/christian_sc96/"
                    },
                    linkedin = new
                    {
                        user = "Christian Sánchez",
                        profile = "https://www.linkedin.com/in/christiandavidsanchez/"
                    }
                }
            };
            return Ok(data);
        }
    }
}