﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opiskelijat.Models
{
    public partial class DatagridView : Component
    {
        public DatagridView()
        {
            InitializeComponent();
        }

        public DatagridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
