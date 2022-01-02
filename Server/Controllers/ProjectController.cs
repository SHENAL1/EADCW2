using CW2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        static List<Project> projects = new List<Project>
        {
            new Project { ProjectId= 1, ProjectName="Project 1", ProjectDescription = "E Commerce Site", StartDate ="01/11/2021", EndDate = "01/12/2021", ProjectStatus = "Completed"},
            new Project { ProjectId= 2, ProjectName="Project 2", ProjectDescription = "3 sites with Buying and Selling", StartDate ="02/12/2021", EndDate = "01/02/2022", ProjectStatus = "Inprogress"}
        };

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleProject(int id)
        {
            var project = projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound("The Project is not in the system");
            }
            else
            {
                return Ok(project);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            //This is to increase the Project id of the newly added Project
            project.ProjectId = projects.Max(p => p.ProjectId + 1);
            projects.Add(project);

            return Ok(projects);
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Project project, int id)
        {
            var dbProject = projects.FirstOrDefault(p => p.ProjectId == id);
            if (dbProject == null)
            {
                return NotFound("The Project is not in the system");
            }
            var indexProject = projects.IndexOf(dbProject);
            projects[indexProject] = project;
           
            return Ok(projects);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var dbProject = projects.FirstOrDefault(p => p.ProjectId == id);
            if (dbProject == null)
            {
                return NotFound("The Project is not in the system");
            }
            projects.Remove(dbProject);

            return Ok(projects);


        }
    }
}
