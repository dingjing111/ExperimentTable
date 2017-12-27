﻿using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows
{
    public partial class ManualExperimentWin : MetroFramework.Forms.MetroForm
    {
        #region singleton 
        private static ManualExperimentWin instance;
      //  private static object obj = new object();
        public static ManualExperimentWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
                //lock (obj)
               // {
                   // if (instance == null)
                   // {
                        instance = new ManualExperimentWin();
                   // }
               // }
            }
            return instance;
        }
        #endregion
        public ManualExperimentWin()
        {
            InitializeComponent();
        }
        private string valveid;

        public string Valveid
        {
            get
            {
                return valveid;
            }

            set
            {
                valveid = value;
            }
        }

        private void ManualExperimentWin_Load(object sender, EventArgs e)
        {
            this.valveid = ManualNumberInput.id;
            lblValveId.Text = this.valveid.ToString();
        }
    }
}
