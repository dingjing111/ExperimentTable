﻿using ExperimentTableDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.ExperimentData
{
    public partial class HistoryDataWin : MetroFramework.Forms.MetroForm
    {//时间列应为datetime类型
        public string productId;
        public int N;
        public int testSelection;
        SearchHelper searchhelper;
        
        public HistoryDataWin()
        {
            InitializeComponent();

        }

        private void HistoryDataWin_Load(object sender, EventArgs e)
        {
            searchhelper = SearchHelper.GetInstance();
            this.productId = DataSearchWin.id;
            this.N = DataSearchWin.n;
            this.testSelection = DataSearchWin.test;
            switch (testSelection)
            {
                case 1:this.Text = "主溢流阀调定测试"; searchhelper.SearchM1(productId, N, dgv);break;
                case 2:this.Text = "转向溢流阀调定测试"; searchhelper.SearchM2(productId, N, dgv);break;
                case 3:this.Text = "1.中位压力损失试验"; searchhelper.Searchf1(productId, N, dgv);break;
                case 4:this.Text = "2.转向优先阀流量测试"; searchhelper.Searchf2(productId, N, dgv);break;
                case 5:this.Text = "3.内泄漏测试"; searchhelper.Searchf3(productId, N, dgv);break;
                case 6:this.Text = "4.小门架上升、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf4(productId, N, dgv);break;
                case 7:this.Text = "5.小门架下降、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf5(productId, N, dgv);break;
                case 8:this.Text = "6.大门架上升、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf6(productId, N, dgv);break;
                case 9:this.Text = "7.大门架下降、压力损失测试"; searchhelper.Searchf7(productId, N, dgv);break;
               case 10:this.Text = "8.小门架前倾、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf8(productId, N, dgv);break;
                case 11:this.Text = "9.小门架后倾、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf9(productId, N, dgv);break;
                case 12: this.Text = "10.大门架前倾、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf10(productId, N, dgv);break;
                case 13:this.Text = "11.大门架后倾、压力损失、推动滑阀力与时间测试"; searchhelper.Searchf11(productId, N, dgv);break;
               case 14:this.Text = "12.小门架前倾自锁"; searchhelper.Searchf12(productId, N, dgv);break;
               
                case 15:this.Text = "13.大门架前倾自锁"; searchhelper.Searchf13(productId, N, dgv);     break;
                default: MessageBox.Show("请选择试验项目"); break;
            }
           
      


        }

       

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
