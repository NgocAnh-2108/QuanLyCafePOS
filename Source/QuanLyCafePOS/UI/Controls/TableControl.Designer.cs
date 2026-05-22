namespace QuanLyCafePOS.UI.Controls
{
    partial class TableControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblPeople;
        private System.Windows.Forms.TextBox txtPeople;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
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
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblPeople = new System.Windows.Forms.Label();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            this.formPanel.BackColor = System.Drawing.Color.FromArgb(255,252,247);
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(0,0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(950,145);
            this.formPanel.Controls.Add(this.lblTitle);
            this.formPanel.Controls.Add(this.lblName);
            this.formPanel.Controls.Add(this.txtName);
            this.formPanel.Controls.Add(this.lblArea);
            this.formPanel.Controls.Add(this.txtArea);
            this.formPanel.Controls.Add(this.lblStatus);
            this.formPanel.Controls.Add(this.cboStatus);
            this.formPanel.Controls.Add(this.lblPeople);
            this.formPanel.Controls.Add(this.txtPeople);
            this.formPanel.Controls.Add(this.btnAdd);
            this.formPanel.Controls.Add(this.btnUpdate);
            this.formPanel.Controls.Add(this.btnDelete);
            this.formPanel.Controls.Add(this.btnReset);
            this.formPanel.Controls.Add(this.btnReload);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI",13F,System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(56,121,61); this.lblTitle.Location = new System.Drawing.Point(14,12); this.lblTitle.Text = "Quản lý bàn và trạng thái phục vụ";
            this.lblName.AutoSize = true; this.lblName.Location = new System.Drawing.Point(16,52); this.lblName.Text = "Tên bàn"; this.txtName.Location = new System.Drawing.Point(16,75); this.txtName.Size = new System.Drawing.Size(150,25);
            this.lblArea.AutoSize = true; this.lblArea.Location = new System.Drawing.Point(185,52); this.lblArea.Text = "Khu vực"; this.txtArea.Location = new System.Drawing.Point(185,75); this.txtArea.Size = new System.Drawing.Size(150,25); this.txtArea.Text = "Trong nhà";
            this.lblStatus.AutoSize = true; this.lblStatus.Location = new System.Drawing.Point(355,52); this.lblStatus.Text = "Trạng thái"; this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboStatus.Items.AddRange(new object[] {"Trống", "Đang phục vụ", "Đặt trước"}); this.cboStatus.SelectedIndex = 0; this.cboStatus.Location = new System.Drawing.Point(355,75); this.cboStatus.Size = new System.Drawing.Size(150,25);
            this.lblPeople.AutoSize = true; this.lblPeople.Location = new System.Drawing.Point(525,52); this.lblPeople.Text = "Số người"; this.txtPeople.Location = new System.Drawing.Point(525,75); this.txtPeople.Size = new System.Drawing.Size(80,25); this.txtPeople.Text = "0";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(56,121,61); this.btnAdd.FlatAppearance.BorderSize = 0; this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAdd.ForeColor = System.Drawing.Color.White; this.btnAdd.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnAdd.Location = new System.Drawing.Point(16,108); this.btnAdd.Size = new System.Drawing.Size(90,30); this.btnAdd.Text = "Thêm"; this.btnAdd.UseVisualStyleBackColor = false; this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(236,132,28); this.btnUpdate.FlatAppearance.BorderSize = 0; this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnUpdate.ForeColor = System.Drawing.Color.White; this.btnUpdate.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnUpdate.Location = new System.Drawing.Point(114,108); this.btnUpdate.Size = new System.Drawing.Size(90,30); this.btnUpdate.Text = "Sửa"; this.btnUpdate.UseVisualStyleBackColor = false; this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(196,55,45); this.btnDelete.FlatAppearance.BorderSize = 0; this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDelete.ForeColor = System.Drawing.Color.White; this.btnDelete.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnDelete.Location = new System.Drawing.Point(212,108); this.btnDelete.Size = new System.Drawing.Size(90,30); this.btnDelete.Text = "Xóa"; this.btnDelete.UseVisualStyleBackColor = false; this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(43,112,171); this.btnReset.FlatAppearance.BorderSize = 0; this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnReset.ForeColor = System.Drawing.Color.White; this.btnReset.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnReset.Location = new System.Drawing.Point(310,108); this.btnReset.Size = new System.Drawing.Size(110,30); this.btnReset.Text = "Trả bàn"; this.btnReset.UseVisualStyleBackColor = false; this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(92,49,20); this.btnReload.FlatAppearance.BorderSize = 0; this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnReload.ForeColor = System.Drawing.Color.White; this.btnReload.Font = new System.Drawing.Font("Segoe UI",9F,System.Drawing.FontStyle.Bold); this.btnReload.Location = new System.Drawing.Point(428,108); this.btnReload.Size = new System.Drawing.Size(90,30); this.btnReload.Text = "Tải lại"; this.btnReload.UseVisualStyleBackColor = false; this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            this.grid.AllowUserToAddRows = false; this.grid.AllowUserToDeleteRows = false; this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.grid.BackgroundColor = System.Drawing.Color.FromArgb(255,252,247); this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.grid.Dock = System.Windows.Forms.DockStyle.Fill; this.grid.MultiSelect = false; this.grid.ReadOnly = true; this.grid.RowHeadersVisible = false; this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.BackColor = System.Drawing.Color.FromArgb(255,248,238); this.Controls.Add(this.grid); this.Controls.Add(this.formPanel); this.Font = new System.Drawing.Font("Segoe UI",10F); this.Name = "TableControl"; this.Size = new System.Drawing.Size(950,600);
            this.formPanel.ResumeLayout(false); this.formPanel.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit(); this.ResumeLayout(false);
        }
    }
}
