﻿using System.Web;
using System.Web.Mvc;

namespace Laboratorio1_EstructuraDeDatos1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
