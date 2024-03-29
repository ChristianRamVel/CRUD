﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // base.OnStartup(e);
            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            facade.EnsureCreated(); // Comprueba si existe la base de datos y las tablas
        }
    }
}
