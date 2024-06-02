﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OutpatientClinicDoctorModule
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class frm_LogIn : Form
    {
        /// <summary>
        /// 医生
        /// </summary>
        private Doctor Doctor { get; set; }
        /// <summary>
        /// 医生（业务逻辑层）
        /// </summary>
        private IDoctorBll DoctorBll;
        /// <summary>
        /// 构造函数
        /// </summary>
        public frm_LogIn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoctorBll = new DoctorBll();
            this.txb_No.Validating += Txb_DoctorNo_Validating;
            this.txb_Password.Validating += Txb_Password_Validating;
            this.ErrorProvider.BlinkRate = 500;
            this.AcceptButton = this.btn_LogIn;
        }
        /// <summary>
        /// 传参
        /// </summary>
        /// <param name="DoctorNo"></param>
        public frm_LogIn(string no) : this()
        {
            this.txb_No.Text = no;
        }
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Txb_Password_Validating(object sender, CancelEventArgs e)
        {
            string password = this.txb_Password.Text;
            this.ErrorProvider.SetError(this.txb_Password, "");
            bool isEmpty = string.IsNullOrEmpty(password);
            if (isEmpty)
            {
                this.ErrorProvider.SetError(this.txb_Password, "密码不能为空");
                return;
            }
            this.ErrorProvider.SetError(this.txb_Password, "");
        }

        /// <summary>
        /// 验证工号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txb_DoctorNo_Validating(object sender, CancelEventArgs e)
        {
            string No = this.txb_No.Text;
            this.ErrorProvider.SetError(this.txb_No, "");
            bool isEmpty = string.IsNullOrEmpty(No);
            if (isEmpty)
            {
                this.ErrorProvider.SetError(this.txb_No, "工号不能为空");
                return;
            }
            bool isLengthValid = (No.Length == this.DoctorBll.NoLength);
            if (!isLengthValid)
            {
                this.ErrorProvider.SetError
                    (this.txb_No, $"工号长度应为{this.DoctorBll.NoLength}");
                return;
            }
            bool isExisting = this.DoctorBll.CheckExist(No);
            if (!isExisting)
            {
                this.ErrorProvider.SetError(this.txb_No, "工号不存在");
                return;
            }
            this.ErrorProvider.SetError(this.txb_No, "");
        }

        /// <summary>
        /// 单击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            string No = this.txb_No.Text.Trim();
            string password = this.txb_Password.Text.Trim();
            this.Doctor = this.DoctorBll.LogIn(No, password);
            MessageBox.Show(this.DoctorBll.Message);
            if (!this.DoctorBll.HasLoggedIn)
            {
                this.txb_Password.Focus();
                this.txb_Password.SelectAll();
                return;
            }
            MessageBox.Show($"即将打开医生 {this.Doctor.Name} 的主界面。");
            frm_Home frm_Home = new frm_Home(this.Doctor);
            frm_Home.ShowDialog();
        }
        /// <summary>
        /// 单击注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Register_Click(object sender, EventArgs e)
        {
            frm_SignUp frm_SignUp = new frm_SignUp();
            frm_SignUp.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// 单击找回密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RetrievePassword_Click(object sender, EventArgs e)
        {
            frm_RetrievePassword frm_RetrievePassword = new frm_RetrievePassword();
            frm_RetrievePassword.ShowDialog();
            this.Close();
        }
    }
}