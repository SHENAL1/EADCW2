using CW2.Server.Data;
using CW2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return base.Ok(await GetDbProjects());
        }

        private async Task<List<Project>> GetDbProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(c => c.ProjectId == id);

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
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Project project, int id)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (dbProject == null)
            {
                return NotFound("The Project is not in the system");
            }

            dbProject.ProjectId = project.ProjectId;
            dbProject.ProjectName = project.ProjectName;
            dbProject.ProjectDescription = project.ProjectDescription;
            dbProject.ProjectStatus = project.ProjectStatus;
            dbProject.StartDate = project.StartDate;
            dbProject.EndDate = project.EndDate;

            await _context.SaveChangesAsync();
            return Ok(await GetDbProjects());


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (dbProject == null)
            {
                return NotFound("The Project is not in the system");
            }
            _context.Projects.Remove(dbProject);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProjects());


        }
    }
}
