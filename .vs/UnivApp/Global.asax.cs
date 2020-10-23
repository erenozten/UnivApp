using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UnivApp.Models;
using UnivApp.DAL;
using System.Data.Entity.Infrastructure.Interception;

namespace UnivApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateSampleData.CreateStudents(); // OK 1
            CreateSampleData.CreateDepartments(); // OK 2
            CreateSampleData.CreateCourses(); // OK 3
            CreateSampleData.CreateInstructors();  // OK 4
            CreateSampleData.CreateEnrollments(); // OK 5
            CreateSampleData.CreateOfficeAssignments(); // OK 6


        }

    }
}
