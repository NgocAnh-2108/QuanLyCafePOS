using System;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyCafePOS.Models;
using QuanLyCafePOS.UI.Controls;

namespace QuanLyCafePOS.UI.Forms
{
    public partial class MainForm : Form
    {
        private bool defaultPageLoaded;

        public MainForm()
        {
            InitializeComponent();
            UpdateUserLabel();
            ApplyPermissions();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsInDesignMode() && !defaultPageLoaded)
            {
                ShowPage("Bán hàng / Order", new PosControl());
                defaultPageLoaded = true;
            }
        }

        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private void UpdateUserLabel()
        {
            string name = string.IsNullOrWhiteSpace(AppSession.HoTen) ? "Người dùng" : AppSession.HoTen;
            string role = string.IsNullOrWhiteSpace(AppSession.ChucVu) ? (AppSession.IsAdmin ? "Quản lý" : "Nhân viên") : AppSession.ChucVu;
            lblUser.Text = "Người dùng: " + name + "  |  " + role;
        }

        private void ApplyPermissions()
        {
            bool isAdmin = AppSession.IsAdmin;
            btnMenu.Visible = isAdmin;
            btnStaff.Visible = isAdmin;
            btnReport.Visible = isAdmin;

            btnPos.Visible = true;
            btnReservation.Visible = true;
            btnCustomer.Visible = isAdmin;
            btnInventory.Visible = true;
        }

        private void ShowPage(string title, UserControl control)
        {
            lblPageTitle.Text = title;
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void BtnPos_Click(object sender, EventArgs e)
        {
            ShowPage("Bán hàng / Order", new PosControl());
        }

        private void BtnReservation_Click(object sender, EventArgs e)
        {
            ShowPage("Đặt trước bàn", new ReservationControl());
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            ShowPage("Quản lý khách hàng", new CustomerControl());
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            ShowPage("Quản lý thực đơn", new MenuControl());
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            ShowPage("Quản lý kho nguyên liệu", new InventoryControl());
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
            ShowPage("Quản lý nhân viên", new StaffControl());
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            ShowPage("Báo cáo doanh thu", new ReportControl());
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Clear();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppSession.Clear();
        }
    }
}
