using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;

namespace PersonalServerManager.Entities
{
    public class ProjectsViewModel : ViewModelBase
    {
        private readonly AppDbContext _dbContext;

        public ProjectsViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProjectDetails> GetProjects()
        {
            return _dbContext.ProjectsDetails.ToList();
        }

        public void AddProject(ProjectDetails project)
        {
            _dbContext.ProjectsDetails.Add(project);

            _dbContext.SaveChanges();
        }

        public ProjectDetails GetProjectDetails(int projectId)
        {
            var project = _dbContext.ProjectsDetails.FirstOrDefault(s => s.Id == projectId);

            return project;
        }
    }
}
