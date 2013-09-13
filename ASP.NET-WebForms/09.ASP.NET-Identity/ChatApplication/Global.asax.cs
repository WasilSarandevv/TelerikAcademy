﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebFormsTemplate.Models;

namespace WebFormsTemplate
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());

            ApplicationDbContext db = new ApplicationDbContext();
            if (db.Roles.Count() == 0)
            {
                db.Roles.Add(new Role("Admin"));
                db.Roles.Add(new Role("Moderator"));
                db.Roles.Add(new Role("User"));
                db.SaveChanges();
            }
        }
    }
}