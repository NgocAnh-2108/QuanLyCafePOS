namespace QuanLyCafePOS.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.FlowLayoutPanel navPanel;
        private System.Windows.Forms.Button btnPos;
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TableLayoutPanel pageLayout;
        private System.Windows.Forms.Panel panelPageHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.navPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPos = new System.Windows.Forms.Button();
            this.btnReservation = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelBrand = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelPageHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.rootLayout.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.panelBrand.SuspendLayout();
            this.pageLayout.SuspendLayout();
            this.panelPageHeader.SuspendLayout();
            this.SuspendLayout();
            // rootLayout
            this.rootLayout.ColumnCount = 2;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.panelTop, 0, 0);
            this.rootLayout.Controls.Add(this.panelSidebar, 0, 1);
            this.rootLayout.Controls.Add(this.pageLayout, 1, 1);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Margin = new System.Windows.Forms.Padding(0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 2;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Size = new System.Drawing.Size(1284, 761);
            this.rootLayout.TabIndex = 0;
            this.rootLayout.SetColumnSpan(this.panelTop, 2);
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.panelTop.Controls.Add(this.lblAppTitle);
            this.panelTop.Controls.Add(this.lblUser);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1284, 72);
            this.panelTop.TabIndex = 0;
            // lblAppTitle
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(28, 20);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(190, 31);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "☕ CAFE COZY";
            // lblUser
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(754, 27);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(500, 22);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Người dùng";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(252, 242, 228);
            this.panelSidebar.Controls.Add(this.navPanel);
            this.panelSidebar.Controls.Add(this.panelBrand);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebar.Location = new System.Drawing.Point(0, 72);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(12, 14, 12, 12);
            this.panelSidebar.Size = new System.Drawing.Size(220, 689);
            this.panelSidebar.TabIndex = 1;
            // navPanel
            this.navPanel.AutoScroll = true;
            this.navPanel.Controls.Add(this.btnPos);
            this.navPanel.Controls.Add(this.btnReservation);
            this.navPanel.Controls.Add(this.btnCustomer);
            this.navPanel.Controls.Add(this.btnMenu);
            this.navPanel.Controls.Add(this.btnInventory);
            this.navPanel.Controls.Add(this.btnStaff);
            this.navPanel.Controls.Add(this.btnReport);
            this.navPanel.Controls.Add(this.btnLogout);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.navPanel.Location = new System.Drawing.Point(12, 14);
            this.navPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(196, 531);
            this.navPanel.TabIndex = 0;
            this.navPanel.WrapContents = false;
            // buttons
            SetupNavButton(this.btnPos, "🧾 Bán hàng / Order", 0);
            this.btnPos.Name = "btnPos";
            this.btnPos.Click += new System.EventHandler(this.BtnPos_Click);
            SetupNavButton(this.btnReservation, "📅 Đặt bàn", 1);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Click += new System.EventHandler(this.BtnReservation_Click);
            SetupNavButton(this.btnCustomer, "👤 Khách hàng", 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Click += new System.EventHandler(this.BtnCustomer_Click);
            SetupNavButton(this.btnMenu, "☕ Thực đơn", 3);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            SetupNavButton(this.btnInventory, "📦 Kho nguyên liệu", 4);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            SetupNavButton(this.btnStaff, "👥 Nhân viên", 5);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Click += new System.EventHandler(this.BtnStaff_Click);
            SetupNavButton(this.btnReport, "📊 Báo cáo", 6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Click += new System.EventHandler(this.BtnReport_Click);
            SetupNavButton(this.btnLogout, "🚪 Đăng xuất", 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // panelBrand
            this.panelBrand.Controls.Add(this.lblBrand);
            this.panelBrand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBrand.Location = new System.Drawing.Point(12, 545);
            this.panelBrand.Name = "panelBrand";
            this.panelBrand.Size = new System.Drawing.Size(196, 132);
            this.panelBrand.TabIndex = 1;
            // lblBrand
            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblBrand.Location = new System.Drawing.Point(0, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(196, 132);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "☕\r\nCAFE COZY\r\n96 Thông Thiên Học, Đà Lạt\r\nSĐT: 0979058531";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // pageLayout
            this.pageLayout.ColumnCount = 1;
            this.pageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pageLayout.Controls.Add(this.panelPageHeader, 0, 0);
            this.pageLayout.Controls.Add(this.contentPanel, 0, 1);
            this.pageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageLayout.Location = new System.Drawing.Point(220, 72);
            this.pageLayout.Margin = new System.Windows.Forms.Padding(0);
            this.pageLayout.Name = "pageLayout";
            this.pageLayout.RowCount = 2;
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.pageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pageLayout.Size = new System.Drawing.Size(1064, 689);
            this.pageLayout.TabIndex = 2;
            // panelPageHeader
            this.panelPageHeader.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.panelPageHeader.Controls.Add(this.lblPageTitle);
            this.panelPageHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPageHeader.Location = new System.Drawing.Point(0, 0);
            this.panelPageHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelPageHeader.Name = "panelPageHeader";
            this.panelPageHeader.Size = new System.Drawing.Size(1064, 44);
            this.panelPageHeader.TabIndex = 0;
            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(55, 38, 27);
            this.lblPageTitle.Location = new System.Drawing.Point(14, 12);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(139, 21);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Bán hàng / Order";
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 44);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(8);
            this.contentPanel.Size = new System.Drawing.Size(1064, 645);
            this.contentPanel.TabIndex = 1;
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe Cozy - POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.rootLayout.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.navPanel.ResumeLayout(false);
            this.panelBrand.ResumeLayout(false);
            this.pageLayout.ResumeLayout(false);
            this.panelPageHeader.ResumeLayout(false);
            this.panelPageHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        private void SetupNavButton(System.Windows.Forms.Button button, string text, int index)
        {
            button.BackColor = System.Drawing.Color.FromArgb(56, 121, 61);
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.Location = new System.Drawing.Point(0, index * 52);
            button.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            button.Name = "btnNav" + index.ToString();
            button.Size = new System.Drawing.Size(190, 42);
            button.TabIndex = index;
            button.Text = text;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.UseVisualStyleBackColor = false;
        }
    }
}
