﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ExperimentTableDetectSystem.service
{
   public class PeakHelper
    {
        #region 字段
        public double[] AllValue;
        private PcanHelper pcanhelper;
        public System.Threading.Timer readTimer { get; set; }
        #endregion

        #region 单例 私有构造函数
        private static volatile PeakHelper instance = null;
        private PeakHelper(PcanHelper pcan)
        {
            this.AllValue = new double[11];
            this.pcanhelper = pcan;
            try
            { pcan.initialize();
              TPCANStatus result=pcan.setValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("控制器初始化出错"+ex.Message);
            }
            //后台每隔一段时间读取一次数据
            this.readTimer = new System.Threading.Timer(_ =>
            {
                try
                {
                    ReadAllReadableValues();

                }
                catch (Exception ex)
                {
                    readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                   // hasData = false;
                    //throw ex;
                    System.Windows.Forms.MessageBox.Show("PEAKHelper读数据出错");
                }
            }, null, Timeout.Infinite, Timeout.Infinite);
        }
       
        /// <summary>
        /// 初始化peakhelper，使用 pcanhelper
        /// </summary>
        /// <param name="pcan"></param>
        /// <returns></returns>
        public static PeakHelper Initialize(PcanHelper pcan)
        {
            if (instance != null)
            {
                throw new Exception("peakHelper重复初始化报错");
            }
            instance = new PeakHelper(pcan);
            return instance;
        }

        public static PeakHelper GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("peakhelper未初始化，请先调用Initialize()");
            }
            return instance;
        }
        #endregion

        #region 方法
        private static readonly object obj = new object();
        /// <summary>
        /// 读
        /// </summary>
        private void ReadAllReadableValues()
        {
            lock (obj)
            { AllValue= pcanhelper.ReadMessages();
            }
        }

        public void startTimer(int period)
        {
            readTimer.Change(0, period);
        }

        public void stopTimer()
        {
            readTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="msg"></param>
        public void write(TPCANMsg msg)
        {
            pcanhelper.writeee(msg);
        }
        #endregion

    }
}
