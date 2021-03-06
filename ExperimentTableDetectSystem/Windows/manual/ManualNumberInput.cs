﻿using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.manual
{
    public partial class ManualNumberInput : MetroFramework.Forms.MetroForm
    {
        private DBHelper dbhelper=DBHelper.GetInstance();
        PeakHelper peak;
       private int i=1;
        public static int n = 1;
        #region singleton
        private static ManualNumberInput instance;
       
        public static ManualNumberInput getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {

                instance = new ManualNumberInput();
            }
            return instance;
        }
        #endregion

        private  string valveid;
        public static string id;
        public  string Valveid
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
        private string SendCompany;
        public static string company;

        private ManualNumberInput()
        {
            InitializeComponent();
            peak = PeakHelper.GetInstance();
        }
        /// <summary>
        /// 输入编号，发往厂家，插入到表tbProductId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtCompany.Text == "" || txtValveId.Text == "")
            {
                MessageBox.Show("请输入，不能为空");
            }
            else
            {
                this.valveid = txtValveId.Text;
                id = this.valveid;
                this.SendCompany = txtCompany.Text;
                company = this.SendCompany;


                string sqlstr = "select * from tbProductId where Id=" + "'" + txtValveId.Text + "'";


                if (!OperateDb.IsTableNull(sqlstr))//说明存在此id的记录，biao，须建立新名字。

                {
                    DataTable dt = OperateDb.readTableN(sqlstr);

                    n = dt.Rows.Count;
                    MessageBox.Show("此编号已测" + n.ToString() + "次");
                    //   i = int.Parse(dt.Rows[n-1][1].ToString());
                    n = n + 1;
                    MessageBox.Show("这是第" + n.ToString() + "测试。");

                }
                //n = i;

                try
                {
                    RecreateRecordManager.AddNewId(id, n, company);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加入阀编号表错误" + ex.Message);
                }



                this.Close();

                ManualExperimentWin win = ManualExperimentWin.getInstance();
                win.Show();
            }
        }

      
    }
}
