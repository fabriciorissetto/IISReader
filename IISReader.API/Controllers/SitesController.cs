using IISReader.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace IISReader.API.Controllers
{
    public class SitesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Site> Index([FromUri]List<string> filtroSites = null)
        {
            var sitesFound = new Microsoft.Web.Administration.ServerManager()
                                    .Sites
                                    .Where(x => filtroSites.Count == 0 || filtroSites.Any(y => x.Name.Contains(y)))
                                    .ToList();

            for (int i = 0; i < sitesFound.Count(); i++)
                yield return ParseSite(sitesFound[i]);
        }

        private Site ParseSite(Microsoft.Web.Administration.Site iisSite)
        {
            var site = new Site();

            site.Name = iisSite.Name;

            foreach (var application in iisSite.Applications.Where(x => x.Path != "/"))
            {
                var paths = application.Path.Split('/')
                                    .Where(path => path != string.Empty)
                                    .ToList();

                if (paths.Count() >= 2)
                {
                    ParseProject(site, paths);
                }
            }

            return site;
        }

        private void ParseProject(Site site, List<string> paths)
        {
            var projectName = paths.First();
            var environmentName = paths.Count() == 3 ? paths.ElementAt(1) : string.Empty;
            var applicationName = paths.Last();

            var existingProject = site.Projects.FirstOrDefault(x => x.Name == projectName && x.Environment == environmentName);
            if (existingProject == null)
            {
                var project = new Project()
                {
                    Name = projectName,
                    Environment = environmentName,
                    Applications = new List<string>() { applicationName }
                };

                site.Projects.Add(project);
            }
            else
                existingProject.Applications.Add(applicationName);
        }
    }
}