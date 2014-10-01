﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestSharp;

using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to access information about Team Projects inside a
    /// TFS Project Collection.
    /// </summary>
    public class ProjectClient
    {
        internal ProjectClient(TfsClientExecutor executor)
        {
            Executor = executor;
        }

        private TfsClientExecutor Executor { get; set; }

        /// <summary>
        /// Get a list of all Team Projects within the current Project Collection.
        /// </summary>
        /// <param name="projectState">The state of the Team Project(s) to query</param>
        /// <param name="count">The maximum number of Team Projects to return</param>
        /// <param name="skip">The number of Team Projects to skip</param>
        /// <returns>The list of Team Projects that match the criteria</returns>
        public async Task<IEnumerable<Project>> GetProjects(
            ProjectState projectState = ProjectState.All,
            int count = 0,
            int skip = 0)
        {
            var request = new RestRequest("/_apis/projects");

            if (projectState != ProjectState.All)
            {
                request.AddParameter("statefilter", projectState.ToString());
            }

            if (count > 0)
            {
                request.AddParameter("top", count);
            }

            if (skip > 0)
            {
                request.AddParameter("$skip", skip);
            }

            ProjectList projects = await Executor.Execute<ProjectList>(request);
            return (projects != null) ? projects.Value : new List<Project>();
        }

        /// <summary>
        /// Get the Team Project by ID.
        /// </summary>
        /// <param name="id">The ID of the Team Project.</param>
        /// <returns>The Team Project, or <code>null</code> if none matched</returns>
        public async Task<Project> GetProject(Guid id)
        {
            Assert.NotNull(id, "id");

            var request = new RestRequest("/_apis/projects/{ProjectId}");
            request.AddUrlSegment("ProjectId", id.ToString());

            return await Executor.Execute<Project>(request);
        }

        /// <summary>
        /// Get the Team Project by name.
        /// </summary>
        /// <param name="name">The name of the Team Project.</param>
        /// <returns>The Team Project, or <code>null</code> if none matched</returns>
        public async Task<Project> GetProject(string name)
        {
            Assert.NotNull(name, "name");

            var request = new RestRequest("/_apis/projects/{Name}");
            request.AddUrlSegment("Name", name);

            return await Executor.Execute<Project>(request);
        }

        private class ProjectList
        {
            public int Count { get; set; }
            public List<Project> Value { get; set; }
        }
    }
}