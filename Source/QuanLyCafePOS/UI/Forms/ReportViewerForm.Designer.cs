namespace QuanLyCafePOS.UI.Forms
{
    partial class ReportViewerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnSaveTxt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage tabSummary;
        private System.Windows.Forms.TabPage tabTop;
        private System.Windows.Forms.TabPage tabPayment;
        private System.Windows.Forms.TabPage tabInvoices;
        private System.Windows.Forms.DataGridView gridSummary;
        private System.Windows.Forms.DataGridView gridTop;
        private System.Windows.Forms.DataGridView gridPayment;
        private System.Windows.Forms.DataGridView gridInvoice;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogReport;
        private System.Drawing.Printing.PrintDocument printDocumentReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnSaveTxt = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabReport = new System.Windows.Forms.TabControl();
            this.tabSummary = new System.Windows.Forms.TabPage();
            this.tabTop = new System.Windows.Forms.TabPage();
            this.tabPayment = new System.Windows.Forms.TabPage();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.gridTop = new System.Windows.Forms.DataGridView();
            this.gridPayment = new System.Windows.Forms.DataGridView();
            this.gridInvoice = new System.Windows.Forms.DataGridView();
            this.printPreviewDialogReport = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentReport = new System.Drawing.Printing.PrintDocument();
            this.topPanel.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.tabTop.SuspendLayout();
            this.tabPayment.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            this.SuspendLayout();
            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnPrintPreview);
            this.topPanel.Controls.Add(this.btnSaveTxt);
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 64;
            // lblTitle
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Size = new System.Drawing.Size(565, 40);
            this.lblTitle.Text = "REPORT VIEWER - BÁO CÁO DOANH THU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // buttons
            SetupButton(this.btnPrintPreview, "Print Preview", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnPrintPreview.Location = new System.Drawing.Point(600, 15);
            this.btnPrintPreview.Size = new System.Drawing.Size(120, 34);
            this.btnPrintPreview.Click += new System.EventHandler(this.BtnPrintPreview_Click);
            SetupButton(this.btnSaveTxt, "Lưu TXT/CSV", System.Drawing.Color.FromArgb(56, 121, 61));
            this.btnSaveTxt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveTxt.Location = new System.Drawing.Point(730, 15);
            this.btnSaveTxt.Size = new System.Drawing.Size(120, 34);
            this.btnSaveTxt.Click += new System.EventHandler(this.BtnSaveTxt_Click);
            SetupButton(this.btnClose, "Đóng", System.Drawing.Color.FromArgb(196, 55, 45));
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(860, 15);
            this.btnClose.Size = new System.Drawing.Size(90, 34);
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // tabReport
            this.tabReport.Controls.Add(this.tabSummary);
            this.tabReport.Controls.Add(this.tabTop);
            this.tabReport.Controls.Add(this.tabPayment);
            this.tabReport.Controls.Add(this.tabInvoices);
            this.tabReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            // tabSummary
            this.tabSummary.Text = "Tổng hợp";
            this.tabSummary.Controls.Add(this.gridSummary);
            SetupGrid(this.gridSummary);
            // tabTop
            this.tabTop.Text = "Top món";
            this.tabTop.Controls.Add(this.gridTop);
            SetupGrid(this.gridTop);
            // tabPayment
            this.tabPayment.Text = "Thanh toán";
            this.tabPayment.Controls.Add(this.gridPayment);
            SetupGrid(this.gridPayment);
            // tabInvoices
            this.tabInvoices.Text = "Hóa đơn";
            this.tabInvoices.Controls.Add(this.gridInvoice);
            SetupGrid(this.gridInvoice);
            // print preview
            this.printPreviewDialogReport.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogReport.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogReport.ClientSize = new System.Drawing.Size(800, 600);
            this.printPreviewDialogReport.Document = this.printDocumentReport;
            this.printPreviewDialogReport.Enabled = true;
            this.printPreviewDialogReport.Icon = null;
            this.printPreviewDialogReport.Name = "printPreviewDialogReport";
            this.printPreviewDialogReport.UseAntiAlias = true;
            this.printPreviewDialogReport.Visible = false;
            this.printDocumentReport.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentReport_PrintPage);
            // form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.Controls.Add(this.tabReport);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(920, 580);
            this.Name = "ReportViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Viewer - Cafe Cozy";
            this.topPanel.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.tabTop.ResumeLayout(false);
            this.tabPayment.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
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
