namespace QuanLyCafePOS.UI.Controls
{
    partial class InventoryControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReloadAll;
        private System.Windows.Forms.Panel adminPanel;
        private System.Windows.Forms.Label lblAdminTitle;
        private System.Windows.Forms.Label lblIngredientName;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Label lblIngredientUnit;
        private System.Windows.Forms.TextBox txtIngredientUnit;
        private System.Windows.Forms.Label lblIngredientStock;
        private System.Windows.Forms.TextBox txtIngredientStock;
        private System.Windows.Forms.Label lblIngredientMinimum;
        private System.Windows.Forms.TextBox txtIngredientMinimum;
        private System.Windows.Forms.Label lblIngredientNote;
        private System.Windows.Forms.TextBox txtIngredientNote;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Button btnUpdateIngredient;
        private System.Windows.Forms.Button btnDeleteIngredient;
        private System.Windows.Forms.Button btnClearIngredient;
        private System.Windows.Forms.DataGridView gridIngredients;
        private System.Windows.Forms.Panel checkPanel;
        private System.Windows.Forms.Label lblIngredient;
        private System.Windows.Forms.ComboBox cboIngredient;
        private System.Windows.Forms.Label lblSystemStock;
        private System.Windows.Forms.TextBox txtSystemStock;
        private System.Windows.Forms.Label lblActualStock;
        private System.Windows.Forms.TextBox txtActualStock;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnAddCheck;
        private System.Windows.Forms.Button btnSaveCheck;
        private System.Windows.Forms.Button btnClearCheck;
        private System.Windows.Forms.Panel historyTopPanel;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Button btnReloadHistory;
        private System.Windows.Forms.DataGridView gridCheckHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReloadAll = new System.Windows.Forms.Button();
            this.adminPanel = new System.Windows.Forms.Panel();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            this.lblIngredientName = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.lblIngredientUnit = new System.Windows.Forms.Label();
            this.txtIngredientUnit = new System.Windows.Forms.TextBox();
            this.lblIngredientStock = new System.Windows.Forms.Label();
            this.txtIngredientStock = new System.Windows.Forms.TextBox();
            this.lblIngredientMinimum = new System.Windows.Forms.Label();
            this.txtIngredientMinimum = new System.Windows.Forms.TextBox();
            this.lblIngredientNote = new System.Windows.Forms.Label();
            this.txtIngredientNote = new System.Windows.Forms.TextBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.btnUpdateIngredient = new System.Windows.Forms.Button();
            this.btnDeleteIngredient = new System.Windows.Forms.Button();
            this.btnClearIngredient = new System.Windows.Forms.Button();
            this.gridIngredients = new System.Windows.Forms.DataGridView();
            this.checkPanel = new System.Windows.Forms.Panel();
            this.lblIngredient = new System.Windows.Forms.Label();
            this.cboIngredient = new System.Windows.Forms.ComboBox();
            this.lblSystemStock = new System.Windows.Forms.Label();
            this.txtSystemStock = new System.Windows.Forms.TextBox();
            this.lblActualStock = new System.Windows.Forms.Label();
            this.txtActualStock = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAddCheck = new System.Windows.Forms.Button();
            this.btnSaveCheck = new System.Windows.Forms.Button();
            this.btnClearCheck = new System.Windows.Forms.Button();
            this.historyTopPanel = new System.Windows.Forms.Panel();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.btnReloadHistory = new System.Windows.Forms.Button();
            this.gridCheckHistory = new System.Windows.Forms.DataGridView();
            this.rootLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.adminPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIngredients)).BeginInit();
            this.checkPanel.SuspendLayout();
            this.historyTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckHistory)).BeginInit();
            this.SuspendLayout();
            // rootLayout
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.headerPanel, 0, 0);
            this.rootLayout.Controls.Add(this.adminPanel, 0, 1);
            this.rootLayout.Controls.Add(this.gridIngredients, 0, 2);
            this.rootLayout.Controls.Add(this.checkPanel, 0, 3);
            this.rootLayout.Controls.Add(this.historyTopPanel, 0, 4);
            this.rootLayout.Controls.Add(this.gridCheckHistory, 0, 5);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Margin = new System.Windows.Forms.Padding(0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 6;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.btnReloadAll);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.headerPanel.Name = "headerPanel";
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 28);
            this.lblTitle.Text = "Kiểm hàng cuối ngày";
            // btnReloadAll
            SetupButton(this.btnReloadAll, "Tải lại", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnReloadAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnReloadAll.Location = new System.Drawing.Point(834, 12);
            this.btnReloadAll.Name = "btnReloadAll";
            this.btnReloadAll.Size = new System.Drawing.Size(100, 34);
            this.btnReloadAll.Click += new System.EventHandler(this.BtnReloadAll_Click);
            // adminPanel
            this.adminPanel.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.adminPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adminPanel.Controls.Add(this.lblAdminTitle);
            this.adminPanel.Controls.Add(this.lblIngredientName);
            this.adminPanel.Controls.Add(this.txtIngredientName);
            this.adminPanel.Controls.Add(this.lblIngredientUnit);
            this.adminPanel.Controls.Add(this.txtIngredientUnit);
            this.adminPanel.Controls.Add(this.lblIngredientStock);
            this.adminPanel.Controls.Add(this.txtIngredientStock);
            this.adminPanel.Controls.Add(this.lblIngredientMinimum);
            this.adminPanel.Controls.Add(this.txtIngredientMinimum);
            this.adminPanel.Controls.Add(this.lblIngredientNote);
            this.adminPanel.Controls.Add(this.txtIngredientNote);
            this.adminPanel.Controls.Add(this.btnAddIngredient);
            this.adminPanel.Controls.Add(this.btnUpdateIngredient);
            this.adminPanel.Controls.Add(this.btnDeleteIngredient);
            this.adminPanel.Controls.Add(this.btnClearIngredient);
            this.adminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.adminPanel.Name = "adminPanel";
            // lblAdminTitle
            this.lblAdminTitle.AutoSize = true;
            this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdminTitle.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblAdminTitle.Location = new System.Drawing.Point(16, 12);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(193, 20);
            this.lblAdminTitle.Text = "Thêm / sửa / xóa nguyên liệu";
            // lblIngredientName
            this.lblIngredientName.AutoSize = true;
            this.lblIngredientName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIngredientName.Location = new System.Drawing.Point(18, 48);
            this.lblIngredientName.Name = "lblIngredientName";
            this.lblIngredientName.Size = new System.Drawing.Size(90, 15);
            this.lblIngredientName.Text = "Tên nguyên liệu";
            // txtIngredientName
            this.txtIngredientName.Location = new System.Drawing.Point(20, 68);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(220, 25);
            // lblIngredientUnit
            this.lblIngredientUnit.AutoSize = true;
            this.lblIngredientUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIngredientUnit.Location = new System.Drawing.Point(252, 48);
            this.lblIngredientUnit.Name = "lblIngredientUnit";
            this.lblIngredientUnit.Size = new System.Drawing.Size(44, 15);
            this.lblIngredientUnit.Text = "Đơn vị";
            // txtIngredientUnit
            this.txtIngredientUnit.Location = new System.Drawing.Point(254, 68);
            this.txtIngredientUnit.Name = "txtIngredientUnit";
            this.txtIngredientUnit.Size = new System.Drawing.Size(90, 25);
            // lblIngredientStock
            this.lblIngredientStock.AutoSize = true;
            this.lblIngredientStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIngredientStock.Location = new System.Drawing.Point(356, 48);
            this.lblIngredientStock.Name = "lblIngredientStock";
            this.lblIngredientStock.Size = new System.Drawing.Size(52, 15);
            this.lblIngredientStock.Text = "Tồn kho";
            // txtIngredientStock
            this.txtIngredientStock.Location = new System.Drawing.Point(358, 68);
            this.txtIngredientStock.Name = "txtIngredientStock";
            this.txtIngredientStock.Size = new System.Drawing.Size(110, 25);
            this.txtIngredientStock.Text = "0";
            // lblIngredientMinimum
            this.lblIngredientMinimum.AutoSize = true;
            this.lblIngredientMinimum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIngredientMinimum.Location = new System.Drawing.Point(480, 48);
            this.lblIngredientMinimum.Name = "lblIngredientMinimum";
            this.lblIngredientMinimum.Size = new System.Drawing.Size(75, 15);
            this.lblIngredientMinimum.Text = "Tồn tối thiểu";
            // txtIngredientMinimum
            this.txtIngredientMinimum.Location = new System.Drawing.Point(482, 68);
            this.txtIngredientMinimum.Name = "txtIngredientMinimum";
            this.txtIngredientMinimum.Size = new System.Drawing.Size(110, 25);
            this.txtIngredientMinimum.Text = "0";
            // lblIngredientNote
            this.lblIngredientNote.AutoSize = true;
            this.lblIngredientNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIngredientNote.Location = new System.Drawing.Point(18, 100);
            this.lblIngredientNote.Name = "lblIngredientNote";
            this.lblIngredientNote.Size = new System.Drawing.Size(47, 15);
            this.lblIngredientNote.Text = "Ghi chú";
            // txtIngredientNote
            this.txtIngredientNote.Location = new System.Drawing.Point(20, 120);
            this.txtIngredientNote.Name = "txtIngredientNote";
            this.txtIngredientNote.Size = new System.Drawing.Size(720, 25);
            // btnAddIngredient
            SetupButton(this.btnAddIngredient, "Thêm nguyên liệu", System.Drawing.Color.FromArgb(56, 121, 61));
            this.btnAddIngredient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnAddIngredient.Location = new System.Drawing.Point(20, 158);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(160, 42);
            this.btnAddIngredient.Click += new System.EventHandler(this.BtnAddIngredient_Click);
            // btnUpdateIngredient
            SetupButton(this.btnUpdateIngredient, "Sửa nguyên liệu", System.Drawing.Color.FromArgb(242, 133, 18));
            this.btnUpdateIngredient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdateIngredient.Location = new System.Drawing.Point(190, 158);
            this.btnUpdateIngredient.Name = "btnUpdateIngredient";
            this.btnUpdateIngredient.Size = new System.Drawing.Size(160, 42);
            this.btnUpdateIngredient.Click += new System.EventHandler(this.BtnUpdateIngredient_Click);
            // btnDeleteIngredient
            SetupButton(this.btnDeleteIngredient, "Xóa nguyên liệu", System.Drawing.Color.FromArgb(204, 55, 47));
            this.btnDeleteIngredient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnDeleteIngredient.Location = new System.Drawing.Point(360, 158);
            this.btnDeleteIngredient.Name = "btnDeleteIngredient";
            this.btnDeleteIngredient.Size = new System.Drawing.Size(160, 42);
            this.btnDeleteIngredient.Click += new System.EventHandler(this.BtnDeleteIngredient_Click);
            // btnClearIngredient
            SetupButton(this.btnClearIngredient, "Làm mới", System.Drawing.Color.FromArgb(92, 49, 20));
            this.btnClearIngredient.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnClearIngredient.Location = new System.Drawing.Point(530, 158);
            this.btnClearIngredient.Name = "btnClearIngredient";
            this.btnClearIngredient.Size = new System.Drawing.Size(120, 42);
            this.btnClearIngredient.Click += new System.EventHandler(this.BtnClearIngredient_Click);
            // gridIngredients
            SetupGrid(this.gridIngredients);
            this.gridIngredients.Name = "gridIngredients";
            this.gridIngredients.SelectionChanged += new System.EventHandler(this.GridIngredients_SelectionChanged);
            // checkPanel
            this.checkPanel.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.checkPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkPanel.Controls.Add(this.lblIngredient);
            this.checkPanel.Controls.Add(this.cboIngredient);
            this.checkPanel.Controls.Add(this.lblSystemStock);
            this.checkPanel.Controls.Add(this.txtSystemStock);
            this.checkPanel.Controls.Add(this.lblActualStock);
            this.checkPanel.Controls.Add(this.txtActualStock);
            this.checkPanel.Controls.Add(this.lblUnit);
            this.checkPanel.Controls.Add(this.lblNote);
            this.checkPanel.Controls.Add(this.txtNote);
            this.checkPanel.Controls.Add(this.btnSaveCheck);
            this.checkPanel.Controls.Add(this.btnClearCheck);
            this.checkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.checkPanel.Name = "checkPanel";
            // lblIngredient
            this.lblIngredient.AutoSize = true;
            this.lblIngredient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIngredient.Location = new System.Drawing.Point(18, 18);
            this.lblIngredient.Name = "lblIngredient";
            this.lblIngredient.Size = new System.Drawing.Size(82, 19);
            this.lblIngredient.Text = "Nguyên liệu";
            // cboIngredient
            this.cboIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIngredient.FormattingEnabled = true;
            this.cboIngredient.Location = new System.Drawing.Point(22, 42);
            this.cboIngredient.Name = "cboIngredient";
            this.cboIngredient.Size = new System.Drawing.Size(260, 25);
            this.cboIngredient.SelectedIndexChanged += new System.EventHandler(this.CboIngredient_SelectedIndexChanged);
            // lblSystemStock
            this.lblSystemStock.AutoSize = true;
            this.lblSystemStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSystemStock.Location = new System.Drawing.Point(300, 18);
            this.lblSystemStock.Name = "lblSystemStock";
            this.lblSystemStock.Size = new System.Drawing.Size(95, 19);
            this.lblSystemStock.Text = "Tồn hệ thống";
            // txtSystemStock
            this.txtSystemStock.Location = new System.Drawing.Point(304, 42);
            this.txtSystemStock.Name = "txtSystemStock";
            this.txtSystemStock.ReadOnly = true;
            this.txtSystemStock.Size = new System.Drawing.Size(130, 25);
            // lblActualStock
            this.lblActualStock.AutoSize = true;
            this.lblActualStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActualStock.Location = new System.Drawing.Point(452, 18);
            this.lblActualStock.Name = "lblActualStock";
            this.lblActualStock.Size = new System.Drawing.Size(80, 19);
            this.lblActualStock.Text = "Tồn thực tế";
            // txtActualStock
            this.txtActualStock.Location = new System.Drawing.Point(456, 42);
            this.txtActualStock.Name = "txtActualStock";
            this.txtActualStock.Size = new System.Drawing.Size(130, 25);
            this.txtActualStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtActualStock_KeyDown);
            // lblUnit
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblUnit.Location = new System.Drawing.Point(594, 45);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(31, 19);
            this.lblUnit.Text = "đv";
            // lblNote
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNote.Location = new System.Drawing.Point(18, 82);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(58, 19);
            this.lblNote.Text = "Ghi chú";
            // txtNote
            this.txtNote.Location = new System.Drawing.Point(22, 106);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(564, 25);
            // btnAddCheck
            SetupButton(this.btnAddCheck, "Lưu kiểm hàng", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnAddCheck.Visible = false;
            this.btnAddCheck.Location = new System.Drawing.Point(-500, -500);
            this.btnAddCheck.Name = "btnAddCheck";
            this.btnAddCheck.Size = new System.Drawing.Size(10, 10);
            // btnSaveCheck
            SetupButton(this.btnSaveCheck, "Lưu kiểm hàng", System.Drawing.Color.FromArgb(56, 121, 61));
            this.btnSaveCheck.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveCheck.Location = new System.Drawing.Point(610, 92);
            this.btnSaveCheck.Name = "btnSaveCheck";
            this.btnSaveCheck.Size = new System.Drawing.Size(170, 42);
            this.btnSaveCheck.Click += new System.EventHandler(this.BtnSaveCheck_Click);
            // btnClearCheck
            SetupButton(this.btnClearCheck, "Nhập lại", System.Drawing.Color.FromArgb(92, 49, 20));
            this.btnClearCheck.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnClearCheck.Location = new System.Drawing.Point(790, 92);
            this.btnClearCheck.Name = "btnClearCheck";
            this.btnClearCheck.Size = new System.Drawing.Size(110, 42);
            this.btnClearCheck.Click += new System.EventHandler(this.BtnClearCheck_Click);
            // historyTopPanel
            this.historyTopPanel.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.historyTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.historyTopPanel.Controls.Add(this.lblHistoryTitle);
            this.historyTopPanel.Controls.Add(this.btnReloadHistory);
            this.historyTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyTopPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.historyTopPanel.Name = "historyTopPanel";
            // lblHistoryTitle
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblHistoryTitle.Location = new System.Drawing.Point(16, 12);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(199, 20);
            this.lblHistoryTitle.Text = "Lịch sử kiểm hàng cuối ngày";
            // btnReloadHistory
            SetupButton(this.btnReloadHistory, "Tải lịch sử", System.Drawing.Color.FromArgb(92, 49, 20));
            this.btnReloadHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnReloadHistory.Location = new System.Drawing.Point(816, 8);
            this.btnReloadHistory.Name = "btnReloadHistory";
            this.btnReloadHistory.Size = new System.Drawing.Size(118, 32);
            this.btnReloadHistory.Click += new System.EventHandler(this.BtnReloadHistory_Click);
            // gridCheckHistory
            SetupGrid(this.gridCheckHistory);
            this.gridCheckHistory.Name = "gridCheckHistory";
            // InventoryControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "InventoryControl";
            this.Size = new System.Drawing.Size(950, 620);
            this.rootLayout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.adminPanel.ResumeLayout(false);
            this.adminPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIngredients)).EndInit();
            this.checkPanel.ResumeLayout(false);
            this.checkPanel.PerformLayout();
            this.historyTopPanel.ResumeLayout(false);
            this.historyTopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckHistory)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupGrid(System.Windows.Forms.DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = System.Drawing.Color.FromArgb(255, 252, 247);
            grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }

        private void SetupButton(System.Windows.Forms.Button button, string text, System.Drawing.Color color)
        {
            button.BackColor = color;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }
    }
}
