using Api.AgileProj.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Api.AgileProj.Data.Entity.Model.Action;
using Task = Api.AgileProj.Data.Entity.Model.Task;

namespace Api.AgileProj.Data.Context.Contract
{
    public interface IAgileProjDBContext : IDbContext 
    {
        DbSet<Account> Accounts { get; set; }

        DbSet<Action> Actions { get; set; }

        DbSet<Project> Projects { get; set; }

        DbSet<TakePart> TakeParts { get; set; }

        DbSet<Task> Tasks { get; set; }
    }
}
