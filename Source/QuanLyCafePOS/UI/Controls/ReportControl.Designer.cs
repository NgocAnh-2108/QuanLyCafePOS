namespace QuanLyCafePOS.UI.Controls
{
    partial class ReportControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel cardsPanel;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Panel cardOrders;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Panel cardBest;
        private System.Windows.Forms.Label lblBestTitle;
        private System.Windows.Forms.Label lblBestSeller;
        private System.Windows.Forms.TableLayoutPanel detailLayout;
        private System.Windows.Forms.TableLayoutPanel topRowLayout;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.DataGridView gridTop;
        private System.Windows.Forms.Panel paymentPanel;
        private System.Windows.Forms.Label lblPaymentReportTitle;
        private System.Windows.Forms.DataGridView gridPayment;
        private System.Windows.Forms.Panel invoicePanel;
        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.DataGridView gridInvoice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cardRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.cardOrders = new System.Windows.Forms.Panel();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.cardBest = new System.Windows.Forms.Panel();
            this.lblBestTitle = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();
            this.detailLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topRowLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.gridTop = new System.Windows.Forms.DataGridView();
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.lblPaymentReportTitle = new System.Windows.Forms.Label();
            this.gridPayment = new System.Windows.Forms.DataGridView();
            this.invoicePanel = new System.Windows.Forms.Panel();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.gridInvoice = new System.Windows.Forms.DataGridView();
            this.filterPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.cardsPanel.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardOrders.SuspendLayout();
            this.cardBest.SuspendLayout();
            this.detailLayout.SuspendLayout();
            this.topRowLayout.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTop)).BeginInit();
            this.paymentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayment)).BeginInit();
            this.invoicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.lblTitle);
            this.filterPanel.Controls.Add(this.lblFrom);
            this.filterPanel.Controls.Add(this.dtFrom);
            this.filterPanel.Controls.Add(this.lblTo);
            this.filterPanel.Controls.Add(this.dtTo);
            this.filterPanel.Controls.Add(this.btnView);
            this.filterPanel.Controls.Add(this.btnExport);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(950, 88);
            this.filterPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(121)))), ((int)(((byte)(61)))));
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo doanh thu và Report Viewer";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrom.Location = new System.Drawing.Point(16, 54);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(51, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "Từ ngày";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(80, 49);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(120, 25);
            this.dtFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTo.Location = new System.Drawing.Point(220, 54);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(57, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "Đến ngày";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(296, 49);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(120, 25);
            this.dtTo.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(112)))), ((int)(((byte)(171)))));
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(435, 45);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(130, 32);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "Xem báo cáo";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(121)))), ((int)(((byte)(61)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(575, 45);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 32);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Mở Report Viewer";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.cardsPanel, 0, 0);
            this.mainLayout.Controls.Add(this.detailLayout, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 88);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(950, 512);
            this.mainLayout.TabIndex = 1;
            // 
            // cardsPanel
            // 
            this.cardsPanel.Controls.Add(this.cardRevenue);
            this.cardsPanel.Controls.Add(this.cardOrders);
            this.cardsPanel.Controls.Add(this.cardBest);
            this.cardsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardsPanel.Location = new System.Drawing.Point(0, 0);
            this.cardsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.cardsPanel.Name = "cardsPanel";
            this.cardsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 8);
            this.cardsPanel.Size = new System.Drawing.Size(950, 110);
            this.cardsPanel.TabIndex = 0;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.cardRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardRevenue.Controls.Add(this.lblRevenueTitle);
            this.cardRevenue.Controls.Add(this.lblRevenue);
            this.cardRevenue.Location = new System.Drawing.Point(3, 13);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Size = new System.Drawing.Size(260, 86);
            this.cardRevenue.TabIndex = 0;
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.AutoSize = true;
            this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(49)))), ((int)(((byte)(20)))));
            this.lblRevenueTitle.Location = new System.Drawing.Point(16, 14);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(128, 15);
            this.lblRevenueTitle.TabIndex = 0;
            this.lblRevenueTitle.Text = "Doanh thu trong kỳ";
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(121)))), ((int)(((byte)(61)))));
            this.lblRevenue.Location = new System.Drawing.Point(14, 42);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(48, 32);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "0 VNĐ";
            // 
            // cardOrders
            // 
            this.cardOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.cardOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardOrders.Controls.Add(this.lblOrdersTitle);
            this.cardOrders.Controls.Add(this.lblOrders);
            this.cardOrders.Location = new System.Drawing.Point(269, 13);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Size = new System.Drawing.Size(190, 86);
            this.cardOrders.TabIndex = 1;
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(49)))), ((int)(((byte)(20)))));
            this.lblOrdersTitle.Location = new System.Drawing.Point(16, 14);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(46, 15);
            this.lblOrdersTitle.TabIndex = 0;
            this.lblOrdersTitle.Text = "Số đơn";
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(132)))), ((int)(((byte)(28)))));
            this.lblOrders.Location = new System.Drawing.Point(14, 42);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(78, 32);
            this.lblOrders.TabIndex = 1;
            this.lblOrders.Text = "0 đơn";
            // 
            // cardBest
            // 
            this.cardBest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.cardBest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardBest.Controls.Add(this.lblBestTitle);
            this.cardBest.Controls.Add(this.lblBestSeller);
            this.cardBest.Location = new System.Drawing.Point(465, 13);
            this.cardBest.Name = "cardBest";
            this.cardBest.Size = new System.Drawing.Size(260, 86);
            this.cardBest.TabIndex = 2;
            // 
            // lblBestTitle
            // 
            this.lblBestTitle.AutoSize = true;
            this.lblBestTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(49)))), ((int)(((byte)(20)))));
            this.lblBestTitle.Location = new System.Drawing.Point(16, 14);
            this.lblBestTitle.Name = "lblBestTitle";
            this.lblBestTitle.Size = new System.Drawing.Size(95, 15);
            this.lblBestTitle.TabIndex = 0;
            this.lblBestTitle.Text = "Món bán chạy";
            // 
            // lblBestSeller
            // 
            this.lblBestSeller.AutoSize = true;
            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(55)))), ((int)(((byte)(45)))));
            this.lblBestSeller.Location = new System.Drawing.Point(14, 42);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(93, 30);
            this.lblBestSeller.TabIndex = 1;
            this.lblBestSeller.Text = "Chưa có";
            // 
            // detailLayout
            // 
            this.detailLayout.ColumnCount = 1;
            this.detailLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detailLayout.Controls.Add(this.topRowLayout, 0, 0);
            this.detailLayout.Controls.Add(this.invoicePanel, 0, 1);
            this.detailLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailLayout.Location = new System.Drawing.Point(0, 110);
            this.detailLayout.Margin = new System.Windows.Forms.Padding(0);
            this.detailLayout.Name = "detailLayout";
            this.detailLayout.RowCount = 2;
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detailLayout.Size = new System.Drawing.Size(950, 402);
            this.detailLayout.TabIndex = 1;
            // 
            // topRowLayout
            // 
            this.topRowLayout.ColumnCount = 2;
            this.topRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.topRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.topRowLayout.Controls.Add(this.topPanel, 0, 0);
            this.topRowLayout.Controls.Add(this.paymentPanel, 1, 0);
            this.topRowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topRowLayout.Location = new System.Drawing.Point(0, 0);
            this.topRowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.topRowLayout.Name = "topRowLayout";
            this.topRowLayout.RowCount = 1;
            this.topRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topRowLayout.Size = new System.Drawing.Size(950, 190);
            this.topRowLayout.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.gridTop);
            this.topPanel.Controls.Add(this.lblTopTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10, 38, 10, 10);
            this.topPanel.Size = new System.Drawing.Size(516, 184);
            this.topPanel.TabIndex = 0;
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.AutoSize = true;
            this.lblTopTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(49)))), ((int)(((byte)(20)))));
            this.lblTopTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(125, 19);
            this.lblTopTitle.TabIndex = 0;
            this.lblTopTitle.Text = "Top món bán chạy";
            // 
            // gridTop
            // 
            this.gridTop.AllowUserToAddRows = false;
            this.gridTop.AllowUserToDeleteRows = false;
            this.gridTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTop.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTop.Location = new System.Drawing.Point(10, 38);
            this.gridTop.Name = "gridTop";
            this.gridTop.ReadOnly = true;
            this.gridTop.RowHeadersVisible = false;
            this.gridTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTop.Size = new System.Drawing.Size(494, 134);
            this.gridTop.TabIndex = 1;
            // 
            // paymentPanel
            // 
            this.paymentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.paymentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paymentPanel.Controls.Add(this.gridPayment);
            this.paymentPanel.Controls.Add(this.lblPaymentReportTitle);
            this.paymentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPanel.Location = new System.Drawing.Point(525, 3);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Padding = new System.Windows.Forms.Padding(10, 38, 10, 10);
            this.paymentPanel.Size = new System.Drawing.Size(422, 184);
            this.paymentPanel.TabIndex = 1;
            // 
            // lblPaymentReportTitle
            // 
            this.lblPaymentReportTitle.AutoSize = true;
            this.lblPaymentReportTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(49)))), ((int)(((byte)(20)))));
            this.lblPaymentReportTitle.Location = new System.Drawing.Point(12, 10);
            this.lblPaymentReportTitle.Name = "lblPaymentReportTitle";
            this.lblPaymentReportTitle.Size = new System.Drawing.Size(224, 19);
            this.lblPaymentReportTitle.TabIndex = 0;
            this.lblPaymentReportTitle.Text = "Doanh thu theo phương thức TT";
            // 
            // gridPayment
            // 
            this.gridPayment.AllowUserToAddRows = false;
            this.gridPayment.AllowUserToDeleteRows = false;
            this.gridPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPayment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPayment.Location = new System.Drawing.Point(10, 38);
            this.gridPayment.Name = "gridPayment";
            this.gridPayment.ReadOnly = true;
            this.gridPayment.RowHeadersVisible = false;
            this.gridPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPayment.Size = new System.Drawing.Size(400, 134);
            this.gridPayment.TabIndex = 1;
            // 
            // invoicePanel
            // 
            this.invoicePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.invoicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicePanel.Controls.Add(this.gridInvoice);
            this.invoicePanel.Controls.Add(this.lblInvoiceTitle);
            this.invoicePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoicePanel.Location = new System.Drawing.Point(3, 193);
            this.invoicePanel.Name = "invoicePanel";
            this.invoicePanel.Padding = new System.Windows.Forms.Padding(10, 38, 10, 10);
            this.invoicePanel.Size = new System.Drawing.Size(944, 206);
            this.invoicePanel.TabIndex = 1;
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.AutoSize = true;
            this.lblInvoiceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(49)))), ((int)(((byte)(20)))));
            this.lblInvoiceTitle.Location = new System.Drawing.Point(12, 10);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(183, 19);
            this.lblInvoiceTitle.TabIndex = 0;
            this.lblInvoiceTitle.Text = "Danh sách hóa đơn đã bán";
            // 
            // gridInvoice
            // 
            this.gridInvoice.AllowUserToAddRows = false;
            this.gridInvoice.AllowUserToDeleteRows = false;
            this.gridInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInvoice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInvoice.Location = new System.Drawing.Point(10, 38);
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.ReadOnly = true;
            this.gridInvoice.RowHeadersVisible = false;
            this.gridInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInvoice.Size = new System.Drawing.Size(922, 156);
            this.gridInvoice.TabIndex = 1;
            // 
            // ReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.filterPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ReportControl";
            this.Size = new System.Drawing.Size(950, 600);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.cardsPanel.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardRevenue.PerformLayout();
            this.cardOrders.ResumeLayout(false);
            this.cardOrders.PerformLayout();
            this.cardBest.ResumeLayout(false);
            this.cardBest.PerformLayout();
            this.detailLayout.ResumeLayout(false);
            this.topRowLayout.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTop)).EndInit();
            this.paymentPanel.ResumeLayout(false);
            this.paymentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayment)).EndInit();
            this.invoicePanel.ResumeLayout(false);
            this.invoicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
