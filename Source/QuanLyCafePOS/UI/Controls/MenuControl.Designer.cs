namespace QuanLyCafePOS.UI.Controls
{
    partial class MenuControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.TableLayoutPanel formLayout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblNoImage;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridView grid;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblNoImage = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.rootLayout.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.formLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.formPanel, 0, 0);
            this.rootLayout.Controls.Add(this.grid, 0, 1);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 2;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Size = new System.Drawing.Size(950, 600);
            this.rootLayout.TabIndex = 0;
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.formLayout);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(3, 3);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.formPanel.Size = new System.Drawing.Size(944, 204);
            this.formPanel.TabIndex = 0;
            // 
            // formLayout
            // 
            this.formLayout.ColumnCount = 8;
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formLayout.Location = new System.Drawing.Point(14, 10);
            this.formLayout.Name = "formLayout";
            this.formLayout.RowCount = 5;
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formLayout.Size = new System.Drawing.Size(914, 182);
            this.formLayout.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý thực đơn";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formLayout.Controls.Add(this.lblTitle, 0, 0);
            this.formLayout.SetColumnSpan(this.lblTitle, 7);
            // 
            // labels
            // 
            this.lblName.Text = "Tên món";
            this.lblCategory.Text = "Loại";
            this.lblPrice.Text = "Giá bán";
            this.lblUnit.Text = "Đơn vị";
            this.lblImage.Text = "Đường dẫn ảnh";
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[] { this.lblName, this.lblCategory, this.lblPrice, this.lblUnit, this.lblImage };
            foreach (System.Windows.Forms.Label label in labels)
            {
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            }
            this.formLayout.Controls.Add(this.lblName, 0, 1);
            this.formLayout.Controls.Add(this.lblCategory, 1, 1);
            this.formLayout.Controls.Add(this.lblPrice, 2, 1);
            this.formLayout.Controls.Add(this.lblUnit, 3, 1);
            this.formLayout.Controls.Add(this.lblImage, 4, 1);
            this.formLayout.SetColumnSpan(this.lblImage, 3);
            // 
            // inputs
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Leave += new System.EventHandler(this.TxtPrice_Leave);
            this.txtUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnit.Text = "ly";
            this.txtImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImage.ReadOnly = true;
            this.formLayout.Controls.Add(this.txtName, 0, 2);
            this.formLayout.Controls.Add(this.cboCategory, 1, 2);
            this.formLayout.Controls.Add(this.txtPrice, 2, 2);
            this.formLayout.Controls.Add(this.txtUnit, 3, 2);
            this.formLayout.Controls.Add(this.txtImage, 4, 2);
            this.formLayout.SetColumnSpan(this.txtImage, 3);
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.White;
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(700, 3);
            this.picProduct.Margin = new System.Windows.Forms.Padding(3);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(210, 130);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 20;
            this.picProduct.TabStop = false;
            this.formLayout.Controls.Add(this.picProduct, 7, 0);
            this.formLayout.SetRowSpan(this.picProduct, 5);
            // 
            // lblNoImage
            // 
            this.lblNoImage.AutoSize = false;
            this.lblNoImage.BackColor = System.Drawing.Color.White;
            this.lblNoImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblNoImage.ForeColor = System.Drawing.Color.Gray;
            this.lblNoImage.Location = new System.Drawing.Point(0, 0);
            this.lblNoImage.Name = "lblNoImage";
            this.lblNoImage.Size = new System.Drawing.Size(210, 130);
            this.lblNoImage.TabIndex = 21;
            this.lblNoImage.Text = "Chưa có ảnh";
            this.lblNoImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // row 3 controls
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActive.Text = "Đang bán";
            SetupButton(this.btnChooseImage, "Tải ảnh", System.Drawing.Color.FromArgb(92, 49, 20));
            SetupButton(this.btnClearImage, "Bỏ ảnh", System.Drawing.Color.FromArgb(196, 55, 45));
            this.btnChooseImage.Click += new System.EventHandler(this.BtnChooseImage_Click);
            this.btnClearImage.Click += new System.EventHandler(this.BtnClearImage_Click);
            this.lblSearch.Text = "Tìm";
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.formLayout.Controls.Add(this.chkActive, 0, 3);
            this.formLayout.Controls.Add(this.btnChooseImage, 1, 3);
            this.formLayout.Controls.Add(this.btnClearImage, 2, 3);
            this.formLayout.Controls.Add(this.lblSearch, 3, 3);
            this.formLayout.Controls.Add(this.txtSearch, 4, 3);
            this.formLayout.SetColumnSpan(this.txtSearch, 3);
            // 
            // bottom buttons
            // 
            SetupButton(this.btnAdd, "Thêm", System.Drawing.Color.FromArgb(56, 121, 61));
            SetupButton(this.btnUpdate, "Sửa", System.Drawing.Color.FromArgb(236, 132, 28));
            SetupButton(this.btnHide, "Ẩn món", System.Drawing.Color.FromArgb(92, 49, 20));
            SetupButton(this.btnDelete, "Xóa", System.Drawing.Color.FromArgb(196, 55, 45));
            SetupButton(this.btnReload, "Tải lại", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            this.formLayout.Controls.Add(this.btnAdd, 0, 4);
            this.formLayout.Controls.Add(this.btnUpdate, 1, 4);
            this.formLayout.Controls.Add(this.btnHide, 2, 4);
            this.formLayout.Controls.Add(this.btnDelete, 3, 4);
            this.formLayout.Controls.Add(this.btnReload, 4, 4);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 213);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(944, 384);
            this.grid.TabIndex = 1;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(950, 600);
            this.rootLayout.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formLayout.ResumeLayout(false);
            this.formLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupButton(System.Windows.Forms.Button button, string text, System.Drawing.Color color)
        {
            button.BackColor = color;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.Dock = System.Windows.Forms.DockStyle.Fill;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }
    }
}
