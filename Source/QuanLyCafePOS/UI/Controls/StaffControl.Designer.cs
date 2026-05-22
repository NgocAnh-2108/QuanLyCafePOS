namespace QuanLyCafePOS.UI.Controls
{
    partial class StaffControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridView grid;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.formPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            this.formPanel.BackColor = System.Drawing.Color.FromArgb(255,252,247); this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.formPanel.Dock = System.Windows.Forms.DockStyle.Top; this.formPanel.Size = new System.Drawing.Size(950,160);
            this.formPanel.Controls.Add(this.lblTitle); this.formPanel.Controls.Add(this.lblName); this.formPanel.Controls.Add(this.txtName); this.formPanel.Controls.Add(this.lblUsername); this.formPanel.Controls.Add(this.txtUsername); this.formPanel.Controls.Add(this.lblPassword); this.formPanel.Controls.Add(this.txtPassword); this.formPanel.Controls.Add(this.lblRole); this.formPanel.Controls.Add(this.cboRole); this.formPanel.Controls.Add(this.lblPhone); this.formPanel.Controls.Add(this.txtPhone); this.formPanel.Controls.Add(this.lblStatus); this.formPanel.Controls.Add(this.cboStatus); this.formPanel.Controls.Add(this.btnAdd); this.formPanel.Controls.Add(this.btnUpdate); this.formPanel.Controls.Add(this.btnDelete); this.formPanel.Controls.Add(this.btnReload);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI",13F,System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(56,121,61); this.lblTitle.Location = new System.Drawing.Point(14,12); this.lblTitle.Text = "Quản lý nhân viên, tài khoản đăng nhập và phân quyền";
            this.lblName.AutoSize = true; this.lblName.Location = new System.Drawing.Point(16,52); this.lblName.Text = "Họ tên"; this.txtName.Location = new System.Drawing.Point(16,75); this.txtName.Size = new System.Drawing.Size(170,25);
            this.lblUsername.AutoSize = true; this.lblUsername.Location = new System.Drawing.Point(200,52); this.lblUsername.Text = "Tài khoản"; this.txtUsername.Location = new System.Drawing.Point(200,75); this.txtUsername.Size = new System.Drawing.Size(120,25);
            this.lblPassword.AutoSize = true; this.lblPassword.Location = new System.Drawing.Point(336,52); this.lblPassword.Text = "Mật khẩu"; this.txtPassword.Location = new System.Drawing.Point(336,75); this.txtPassword.Size = new System.Drawing.Size(120,25); this.txtPassword.Text = "123456";
            this.lblRole.AutoSize = true; this.lblRole.Location = new System.Drawing.Point(472,52); this.lblRole.Text = "Chức vụ"; this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboRole.Items.AddRange(new object[] {"Quản lý", "Thu ngân", "Pha chế", "Phục vụ"}); this.cboRole.Location = new System.Drawing.Point(472,75); this.cboRole.Size = new System.Drawing.Size(120,25); this.cboRole.SelectedIndex = 1;
            this.lblPhone.AutoSize = true; this.lblPhone.Location = new System.Drawing.Point(608,52); this.lblPhone.Text = "SĐT"; this.txtPhone.Location = new System.Drawing.Point(608,75); this.txtPhone.Size = new System.Drawing.Size(120,25);
            this.lblStatus.AutoSize = true; this.lblStatus.Location = new System.Drawing.Point(744,52); this.lblStatus.Text = "Trạng thái"; this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboStatus.Items.AddRange(new object[] {"Đang làm", "Tạm nghỉ", "Đã nghỉ"}); this.cboStatus.Location = new System.Drawing.Point(744,75); this.cboStatus.Size = new System.Drawing.Size(120,25); this.cboStatus.SelectedIndex = 0;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(56,121,61); this.btnAdd.FlatAppearance.BorderSize = 0; this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAdd.ForeColor = System.Drawing.Color.White; this.btnAdd.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnAdd.Location = new System.Drawing.Point(16,118); this.btnAdd.Size = new System.Drawing.Size(90,30); this.btnAdd.Text = "Thêm"; this.btnAdd.UseVisualStyleBackColor = false; this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(236,132,28); this.btnUpdate.FlatAppearance.BorderSize = 0; this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnUpdate.ForeColor = System.Drawing.Color.White; this.btnUpdate.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnUpdate.Location = new System.Drawing.Point(114,118); this.btnUpdate.Size = new System.Drawing.Size(90,30); this.btnUpdate.Text = "Sửa"; this.btnUpdate.UseVisualStyleBackColor = false; this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(196,55,45); this.btnDelete.FlatAppearance.BorderSize = 0; this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDelete.ForeColor = System.Drawing.Color.White; this.btnDelete.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnDelete.Location = new System.Drawing.Point(212,118); this.btnDelete.Size = new System.Drawing.Size(90,30); this.btnDelete.Text = "Xóa"; this.btnDelete.UseVisualStyleBackColor = false; this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(43,112,171); this.btnReload.FlatAppearance.BorderSize = 0; this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnReload.ForeColor = System.Drawing.Color.White; this.btnReload.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnReload.Location = new System.Drawing.Point(310,118); this.btnReload.Size = new System.Drawing.Size(90,30); this.btnReload.Text = "Tải lại"; this.btnReload.UseVisualStyleBackColor = false; this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            this.grid.AllowUserToAddRows = false; this.grid.AllowUserToDeleteRows = false; this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.grid.BackgroundColor = System.Drawing.Color.FromArgb(255,252,247); this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.grid.Dock = System.Windows.Forms.DockStyle.Fill; this.grid.MultiSelect = false; this.grid.ReadOnly = true; this.grid.RowHeadersVisible = false; this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.BackColor = System.Drawing.Color.FromArgb(255,248,238); this.Controls.Add(this.grid); this.Controls.Add(this.formPanel); this.Font = new System.Drawing.Font("Segoe UI",10F); this.Name = "StaffControl"; this.Size = new System.Drawing.Size(950,600);
            this.formPanel.ResumeLayout(false); this.formPanel.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit(); this.ResumeLayout(false);
        }
    }
}
