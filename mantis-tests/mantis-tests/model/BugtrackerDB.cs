﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace mantis_tests
{
    public class BugtrackerDB : LinqToDB.Data.DataConnection
    {
        public BugtrackerDB() : base("Bugtracker") { }

        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }

        public ITable<AccData> Users { get { return GetTable<AccData>(); } }
    }
}
