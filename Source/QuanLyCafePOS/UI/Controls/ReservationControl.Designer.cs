namespace QuanLyCafePOS.UI.Controls
{
    partial class ReservationControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel formLayout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPeople;
        private System.Windows.Forms.TextBox txtPeople;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtBookingDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtBookingTime;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView grid;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.formLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPeople = new System.Windows.Forms.Label();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtBookingDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtBookingTime = new System.Windows.Forms.DateTimePicker();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.formLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.formLayout);
            this.splitContainer.Panel2.Controls.Add(this.grid);
            this.splitContainer.Size = new System.Drawing.Size(950, 600);
            this.splitContainer.SplitterDistance = 330;
            // formLayout
            this.formLayout.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.formLayout.ColumnCount = 2;
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formLayout.Padding = new System.Windows.Forms.Padding(12);
            this.formLayout.RowCount = 15;
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            for (int i = 2; i < 9; i++) this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // title
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.lblTitle.Text = "Đặt trước bàn";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formLayout.Controls.Add(this.lblTitle, 0, 0);
            this.formLayout.SetColumnSpan(this.lblTitle, 2);
            this.lblSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelected.ForeColor = System.Drawing.Color.FromArgb(236, 132, 28);
            this.lblSelected.Text = "Chưa chọn lịch đặt bàn";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formLayout.Controls.Add(this.lblSelected, 0, 1);
            this.formLayout.SetColumnSpan(this.lblSelected, 2);
            // labels
            this.lblTable.Text = "Bàn";
            this.lblCustomerName.Text = "Tên khách";
            this.lblPhone.Text = "SĐT";
            this.lblPeople.Text = "Số người";
            this.lblDate.Text = "Ngày đặt";
            this.lblTime.Text = "Giờ đặt";
            this.lblNote.Text = "Ghi chú";
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[] { lblTable, lblCustomerName, lblPhone, lblPeople, lblDate, lblTime, lblNote };
            foreach (System.Windows.Forms.Label label in labels) { label.Dock = System.Windows.Forms.DockStyle.Fill; label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; }
            this.cboTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPeople.Dock = System.Windows.Forms.DockStyle.Fill; this.txtPeople.Text = "2";
            this.dtBookingDate.Dock = System.Windows.Forms.DockStyle.Fill; this.dtBookingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBookingTime.Dock = System.Windows.Forms.DockStyle.Fill; this.dtBookingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time; this.dtBookingTime.ShowUpDown = true;
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formLayout.Controls.Add(this.lblTable, 0, 2); this.formLayout.Controls.Add(this.cboTable, 1, 2);
            this.formLayout.Controls.Add(this.lblCustomerName, 0, 3); this.formLayout.Controls.Add(this.txtCustomerName, 1, 3);
            this.formLayout.Controls.Add(this.lblPhone, 0, 4); this.formLayout.Controls.Add(this.txtPhone, 1, 4);
            this.formLayout.Controls.Add(this.lblPeople, 0, 5); this.formLayout.Controls.Add(this.txtPeople, 1, 5);
            this.formLayout.Controls.Add(this.lblDate, 0, 6); this.formLayout.Controls.Add(this.dtBookingDate, 1, 6);
            this.formLayout.Controls.Add(this.lblTime, 0, 7); this.formLayout.Controls.Add(this.dtBookingTime, 1, 7);
            this.formLayout.Controls.Add(this.lblNote, 0, 8); this.formLayout.Controls.Add(this.txtNote, 1, 8);
            // buttons
            SetupButton(this.btnAdd, "Đặt bàn", System.Drawing.Color.FromArgb(56, 121, 61));
            SetupButton(this.btnCheckIn, "Nhận bàn", System.Drawing.Color.FromArgb(43, 112, 171));
            SetupButton(this.btnCancel, "Hủy đặt", System.Drawing.Color.FromArgb(196, 55, 45));
            SetupButton(this.btnReload, "Tải lại", System.Drawing.Color.FromArgb(92, 49, 20));
            SetupButton(this.btnClear, "Làm mới", System.Drawing.Color.Gray);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnCheckIn.Click += new System.EventHandler(this.BtnCheckIn_Click);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            this.formLayout.Controls.Add(this.btnAdd, 0, 9); this.formLayout.Controls.Add(this.btnCheckIn, 1, 9);
            this.formLayout.Controls.Add(this.btnCancel, 0, 10); this.formLayout.Controls.Add(this.btnReload, 1, 10);
            this.formLayout.Controls.Add(this.btnClear, 0, 11); this.formLayout.SetColumnSpan(this.btnClear, 2);
            // grid
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.MultiSelect = false;
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // ReservationControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ReservationControl";
            this.Size = new System.Drawing.Size(950, 600);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.formLayout.ResumeLayout(false);
            this.formLayout.PerformLayout();
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
