namespace QuanLyCafePOS.UI.Controls
{
    partial class PosControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel panelTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutLeft;
        private System.Windows.Forms.Panel panelTableHeader;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Button btnReloadTables;
        private System.Windows.Forms.Panel panelOrderType;
        private System.Windows.Forms.RadioButton rdoDineIn;
        private System.Windows.Forms.RadioButton rdoTakeAway;
        private System.Windows.Forms.Label lblSelectedTable;
        private System.Windows.Forms.FlowLayoutPanel tablePanel;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMenu;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.Panel panelMenuTools;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel productPanel;
        private System.Windows.Forms.Panel panelInvoice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutInvoice;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.DataGridView cartGrid;
        private System.Windows.Forms.FlowLayoutPanel panelQtyButtons;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TableLayoutPanel panelCustomer;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Button btnClearCustomer;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.TableLayoutPanel panelMoney;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblCustomerPay;
        private System.Windows.Forms.TextBox txtCustomerPay;
        private System.Windows.Forms.Label lblPaymentCurrent;
        private System.Windows.Forms.Label lblLoyaltyDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TableLayoutPanel panelActionButtons;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.FlowLayoutPanel panelPaymentMethods;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.PrintPreviewDialog printPreviewReceipt;
        private System.Drawing.Printing.PrintDocument printDocumentReceipt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelTables = new System.Windows.Forms.Panel();
            this.tableLayoutLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panelTableHeader = new System.Windows.Forms.Panel();
            this.lblTables = new System.Windows.Forms.Label();
            this.btnReloadTables = new System.Windows.Forms.Button();
            this.panelOrderType = new System.Windows.Forms.Panel();
            this.rdoDineIn = new System.Windows.Forms.RadioButton();
            this.rdoTakeAway = new System.Windows.Forms.RadioButton();
            this.lblSelectedTable = new System.Windows.Forms.Label();
            this.tablePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLegend = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.tableLayoutMenu = new System.Windows.Forms.TableLayoutPanel();
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.panelMenuTools = new System.Windows.Forms.Panel();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.productPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInvoice = new System.Windows.Forms.Panel();
            this.tableLayoutInvoice = new System.Windows.Forms.TableLayoutPanel();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.cartGrid = new System.Windows.Forms.DataGridView();
            this.panelQtyButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panelCustomer = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.btnClearCustomer = new System.Windows.Forms.Button();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.panelMoney = new System.Windows.Forms.TableLayoutPanel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblCustomerPay = new System.Windows.Forms.Label();
            this.txtCustomerPay = new System.Windows.Forms.TextBox();
            this.lblPaymentCurrent = new System.Windows.Forms.Label();
            this.lblLoyaltyDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.panelActionButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.panelPaymentMethods = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.printPreviewReceipt = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentReceipt = new System.Drawing.Printing.PrintDocument();
            this.rootLayout.SuspendLayout();
            this.panelTables.SuspendLayout();
            this.tableLayoutLeft.SuspendLayout();
            this.panelTableHeader.SuspendLayout();
            this.panelOrderType.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.tableLayoutMenu.SuspendLayout();
            this.panelMenuTools.SuspendLayout();
            this.panelInvoice.SuspendLayout();
            this.tableLayoutInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartGrid)).BeginInit();
            this.panelQtyButtons.SuspendLayout();
            this.panelCustomer.SuspendLayout();
            this.panelMoney.SuspendLayout();
            this.panelActionButtons.SuspendLayout();
            this.panelPaymentMethods.SuspendLayout();
            this.SuspendLayout();
            // rootLayout
            this.rootLayout.ColumnCount = 3;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.rootLayout.Controls.Add(this.panelTables, 0, 0);
            this.rootLayout.Controls.Add(this.panelMenu, 1, 0);
            this.rootLayout.Controls.Add(this.panelInvoice, 2, 0);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 1;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Size = new System.Drawing.Size(1050, 620);
            this.rootLayout.TabIndex = 0;
            // panelTables
            this.panelTables.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.panelTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTables.Controls.Add(this.tableLayoutLeft);
            this.panelTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTables.Location = new System.Drawing.Point(3, 3);
            this.panelTables.Name = "panelTables";
            this.panelTables.Padding = new System.Windows.Forms.Padding(10);
            this.panelTables.Size = new System.Drawing.Size(277, 614);
            this.panelTables.TabIndex = 0;
            // tableLayoutLeft
            this.tableLayoutLeft.ColumnCount = 1;
            this.tableLayoutLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLeft.Controls.Add(this.panelTableHeader, 0, 0);
            this.tableLayoutLeft.Controls.Add(this.panelOrderType, 0, 1);
            this.tableLayoutLeft.Controls.Add(this.lblSelectedTable, 0, 2);
            this.tableLayoutLeft.Controls.Add(this.tablePanel, 0, 3);
            this.tableLayoutLeft.Controls.Add(this.lblLegend, 0, 4);
            this.tableLayoutLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutLeft.RowCount = 5;
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutLeft.Size = new System.Drawing.Size(255, 592);
            // panelTableHeader
            this.panelTableHeader.Controls.Add(this.lblTables);
            this.panelTableHeader.Controls.Add(this.btnReloadTables);
            this.panelTableHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTables.AutoSize = true;
            this.lblTables.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTables.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.lblTables.Location = new System.Drawing.Point(3, 8);
            this.lblTables.Text = "SƠ ĐỒ BÀN";
            SetupSmallButton(this.btnReloadTables, "Tải lại", System.Drawing.Color.FromArgb(92, 49, 20));
            this.btnReloadTables.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnReloadTables.Location = new System.Drawing.Point(178, 5);
            this.btnReloadTables.Size = new System.Drawing.Size(70, 29);
            this.btnReloadTables.Click += new System.EventHandler(this.BtnReloadTables_Click);
            // panelOrderType
            this.panelOrderType.Controls.Add(this.rdoDineIn);
            this.panelOrderType.Controls.Add(this.rdoTakeAway);
            this.panelOrderType.Dock = System.Windows.Forms.DockStyle.Fill;
            SetupRadioButton(this.rdoDineIn, "Uống tại chỗ", System.Drawing.Color.FromArgb(56, 121, 61), new System.Drawing.Point(3, 6), new System.Drawing.Size(122, 32));
            this.rdoDineIn.Checked = true;
            this.rdoDineIn.CheckedChanged += new System.EventHandler(this.RdoDineIn_CheckedChanged);
            SetupRadioButton(this.rdoTakeAway, "Mang về", System.Drawing.Color.FromArgb(43, 112, 171), new System.Drawing.Point(131, 6), new System.Drawing.Size(118, 32));
            this.rdoTakeAway.CheckedChanged += new System.EventHandler(this.RdoTakeAway_CheckedChanged);
            // lblSelectedTable
            this.lblSelectedTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedTable.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectedTable.ForeColor = System.Drawing.Color.FromArgb(236, 132, 28);
            this.lblSelectedTable.Text = "Uống tại chỗ: chọn bàn để order";
            this.lblSelectedTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // tablePanel
            this.tablePanel.AutoScroll = true;
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            // lblLegend
            this.lblLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLegend.ForeColor = System.Drawing.Color.FromArgb(55, 38, 27);
            this.lblLegend.Text = "🟩 Trống   🟧 Đang phục vụ   🟦 Đặt trước";
            this.lblLegend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // panelMenu
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.tableLayoutMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(286, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.panelMenu.Size = new System.Drawing.Size(445, 614);
            // tableLayoutMenu
            this.tableLayoutMenu.ColumnCount = 1;
            this.tableLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMenu.Controls.Add(this.lblMenuTitle, 0, 0);
            this.tableLayoutMenu.Controls.Add(this.panelMenuTools, 0, 1);
            this.tableLayoutMenu.Controls.Add(this.productPanel, 0, 2);
            this.tableLayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMenu.RowCount = 3;
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // lblMenuTitle
            this.lblMenuTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitle.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.lblMenuTitle.Text = "THỰC ĐƠN";
            this.lblMenuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // panelMenuTools
            this.panelMenuTools.Controls.Add(this.cboCategory);
            this.panelMenuTools.Controls.Add(this.txtSearch);
            this.panelMenuTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.Location = new System.Drawing.Point(3, 8);
            this.cboCategory.Size = new System.Drawing.Size(140, 25);
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.CboCategory_SelectedIndexChanged);
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(153, 8);
            this.txtSearch.Size = new System.Drawing.Size(267, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // productPanel
            this.productPanel.AutoScroll = true;
            this.productPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            // panelInvoice
            this.panelInvoice.BackColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.panelInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInvoice.Controls.Add(this.tableLayoutInvoice);
            this.panelInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvoice.Location = new System.Drawing.Point(737, 3);
            this.panelInvoice.Name = "panelInvoice";
            this.panelInvoice.Padding = new System.Windows.Forms.Padding(10);
            this.panelInvoice.Size = new System.Drawing.Size(310, 614);
            // tableLayoutInvoice
            this.tableLayoutInvoice.ColumnCount = 1;
            this.tableLayoutInvoice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutInvoice.Controls.Add(this.lblInvoice, 0, 0);
            this.tableLayoutInvoice.Controls.Add(this.cartGrid, 0, 1);
            this.tableLayoutInvoice.Controls.Add(this.panelQtyButtons, 0, 2);
            this.tableLayoutInvoice.Controls.Add(this.panelCustomer, 0, 3);
            this.tableLayoutInvoice.Controls.Add(this.panelMoney, 0, 4);
            this.tableLayoutInvoice.Controls.Add(this.panelActionButtons, 0, 5);
            this.tableLayoutInvoice.Controls.Add(this.lblPaymentTitle, 0, 6);
            this.tableLayoutInvoice.Controls.Add(this.panelPaymentMethods, 0, 7);
            this.tableLayoutInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutInvoice.RowCount = 8;
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutInvoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            // lblInvoice
            this.lblInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblInvoice.Text = "HÓA ĐƠN - Chưa chọn bàn";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // cartGrid
            this.cartGrid.AllowUserToAddRows = false;
            this.cartGrid.AllowUserToDeleteRows = false;
            this.cartGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cartGrid.BackgroundColor = System.Drawing.Color.FromArgb(255, 252, 247);
            this.cartGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartGrid.MultiSelect = false;
            this.cartGrid.ReadOnly = true;
            this.cartGrid.RowHeadersVisible = false;
            this.cartGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // panelQtyButtons
            this.panelQtyButtons.Controls.Add(this.btnMinus);
            this.panelQtyButtons.Controls.Add(this.btnPlus);
            this.panelQtyButtons.Controls.Add(this.btnRemove);
            this.panelQtyButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            SetupSmallButton(this.btnMinus, "- SL", System.Drawing.Color.FromArgb(236, 132, 28));
            this.btnMinus.Size = new System.Drawing.Size(82, 32);
            this.btnMinus.Click += new System.EventHandler(this.BtnMinus_Click);
            SetupSmallButton(this.btnPlus, "+ SL", System.Drawing.Color.FromArgb(56, 121, 61));
            this.btnPlus.Size = new System.Drawing.Size(82, 32);
            this.btnPlus.Click += new System.EventHandler(this.BtnPlus_Click);
            SetupSmallButton(this.btnRemove, "Xóa món", System.Drawing.Color.FromArgb(196, 55, 45));
            this.btnRemove.Size = new System.Drawing.Size(96, 32);
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // panelCustomer
            this.panelCustomer.ColumnCount = 3;
            this.panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.panelCustomer.Controls.Add(this.lblCustomerTitle, 0, 0);
            this.panelCustomer.Controls.Add(this.txtCustomerSearch, 0, 1);
            this.panelCustomer.Controls.Add(this.btnFindCustomer, 1, 1);
            this.panelCustomer.Controls.Add(this.btnClearCustomer, 2, 1);
            this.panelCustomer.Controls.Add(this.lblCustomerInfo, 0, 2);
            this.panelCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomer.RowCount = 3;
            this.panelCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lblCustomerTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerTitle.Text = "KHÁCH HÀNG";
            this.lblCustomerTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerTitle.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblCustomerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelCustomer.SetColumnSpan(this.lblCustomerTitle, 3);
            this.txtCustomerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            SetupSmallButton(this.btnFindCustomer, "Tìm", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnFindCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFindCustomer.Click += new System.EventHandler(this.BtnFindCustomer_Click);
            SetupSmallButton(this.btnClearCustomer, "Bỏ", System.Drawing.Color.Gray);
            this.btnClearCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearCustomer.Click += new System.EventHandler(this.BtnClearCustomer_Click);
            this.lblCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerInfo.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.lblCustomerInfo.Text = "Khách lẻ - không áp dụng giảm thân thiết";
            this.lblCustomerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelCustomer.SetColumnSpan(this.lblCustomerInfo, 3);
            // panelMoney
            this.panelMoney.ColumnCount = 2;
            this.panelMoney.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.panelMoney.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMoney.Controls.Add(this.lblDiscount, 0, 0);
            this.panelMoney.Controls.Add(this.txtDiscount, 1, 0);
            this.panelMoney.Controls.Add(this.lblCustomerPay, 0, 1);
            this.panelMoney.Controls.Add(this.txtCustomerPay, 1, 1);
            this.panelMoney.Controls.Add(this.lblPaymentCurrent, 0, 2);
            this.panelMoney.Controls.Add(this.lblLoyaltyDiscount, 0, 3);
            this.panelMoney.Controls.Add(this.lblTotal, 0, 4);
            this.panelMoney.Controls.Add(this.lblChange, 0, 5);
            this.panelMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMoney.RowCount = 6;
            this.panelMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMoney.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.lblDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscount.Text = "Giảm thêm";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiscount.Text = "0 VNĐ";
            this.txtDiscount.TextChanged += new System.EventHandler(this.TxtDiscount_TextChanged);
            this.txtDiscount.Leave += new System.EventHandler(this.TxtMoney_Leave);
            this.lblCustomerPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerPay.Text = "Khách đưa";
            this.lblCustomerPay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCustomerPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerPay.Text = "0 VNĐ";
            this.txtCustomerPay.TextChanged += new System.EventHandler(this.TxtCustomerPay_TextChanged);
            this.txtCustomerPay.Leave += new System.EventHandler(this.TxtMoney_Leave);
            SetupMoneyLabel(this.lblPaymentCurrent, "PTTT: Tiền mặt");
            SetupMoneyLabel(this.lblLoyaltyDiscount, "Giảm thân thiết: 0 VNĐ");
            SetupMoneyLabel(this.lblTotal, "Tổng tiền: 0 VNĐ");
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(196, 55, 45);
            SetupMoneyLabel(this.lblChange, "Tiền thối: 0 VNĐ");
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(56, 121, 61);
            this.panelMoney.SetColumnSpan(this.lblPaymentCurrent, 2);
            this.panelMoney.SetColumnSpan(this.lblLoyaltyDiscount, 2);
            this.panelMoney.SetColumnSpan(this.lblTotal, 2);
            this.panelMoney.SetColumnSpan(this.lblChange, 2);
            // action buttons
            this.panelActionButtons.ColumnCount = 2;
            this.panelActionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelActionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelActionButtons.Controls.Add(this.btnPay, 0, 0);
            this.panelActionButtons.Controls.Add(this.btnHold, 1, 0);
            this.panelActionButtons.Controls.Add(this.btnPrint, 0, 1);
            this.panelActionButtons.Controls.Add(this.btnClear, 1, 1);
            this.panelActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActionButtons.RowCount = 2;
            this.panelActionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelActionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            SetupButton(this.btnPay, "💵 Thanh toán", System.Drawing.Color.FromArgb(56, 121, 61));
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);
            SetupButton(this.btnHold, "⏸ Tạm giữ", System.Drawing.Color.FromArgb(236, 132, 28));
            this.btnHold.Click += new System.EventHandler(this.BtnHold_Click);
            SetupButton(this.btnPrint, "🖨 Print Preview", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            SetupButton(this.btnClear, "🗑 Hủy món", System.Drawing.Color.FromArgb(196, 55, 45));
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // payment methods
            this.lblPaymentTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.FromArgb(92, 49, 20);
            this.lblPaymentTitle.Text = "CHỌN PHƯƠNG THỨC THANH TOÁN";
            this.lblPaymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelPaymentMethods.Controls.Add(this.btnCash);
            this.panelPaymentMethods.Controls.Add(this.btnBank);
            this.panelPaymentMethods.Controls.Add(this.btnCard);
            this.panelPaymentMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            SetupSmallButton(this.btnCash, "Tiền mặt", System.Drawing.Color.FromArgb(56, 121, 61));
            this.btnCash.Size = new System.Drawing.Size(84, 42);
            this.btnCash.Click += new System.EventHandler(this.BtnCash_Click);
            SetupSmallButton(this.btnBank, "Chuyển khoản", System.Drawing.Color.FromArgb(43, 112, 171));
            this.btnBank.Size = new System.Drawing.Size(105, 42);
            this.btnBank.Click += new System.EventHandler(this.BtnBank_Click);
            SetupSmallButton(this.btnCard, "Thẻ", System.Drawing.Color.FromArgb(116, 81, 164));
            this.btnCard.Size = new System.Drawing.Size(78, 42);
            this.btnCard.Click += new System.EventHandler(this.BtnCard_Click);
            // print
            this.printPreviewReceipt.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewReceipt.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewReceipt.ClientSize = new System.Drawing.Size(800, 600);
            this.printPreviewReceipt.Document = this.printDocumentReceipt;
            this.printPreviewReceipt.Enabled = true;
            this.printPreviewReceipt.Icon = null;
            this.printPreviewReceipt.Name = "printPreviewReceipt";
            this.printPreviewReceipt.UseAntiAlias = true;
            this.printPreviewReceipt.Visible = false;
            this.printDocumentReceipt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentReceipt_PrintPage);
            // PosControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 248, 238);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "PosControl";
            this.Size = new System.Drawing.Size(1050, 620);
            this.rootLayout.ResumeLayout(false);
            this.panelTables.ResumeLayout(false);
            this.tableLayoutLeft.ResumeLayout(false);
            this.panelTableHeader.ResumeLayout(false);
            this.panelTableHeader.PerformLayout();
            this.panelOrderType.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.tableLayoutMenu.ResumeLayout(false);
            this.panelMenuTools.ResumeLayout(false);
            this.panelMenuTools.PerformLayout();
            this.panelInvoice.ResumeLayout(false);
            this.tableLayoutInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cartGrid)).EndInit();
            this.panelQtyButtons.ResumeLayout(false);
            this.panelCustomer.ResumeLayout(false);
            this.panelCustomer.PerformLayout();
            this.panelMoney.ResumeLayout(false);
            this.panelMoney.PerformLayout();
            this.panelActionButtons.ResumeLayout(false);
            this.panelPaymentMethods.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetupRadioButton(System.Windows.Forms.RadioButton button, string text, System.Drawing.Color color, System.Drawing.Point location, System.Drawing.Size size)
        {
            button.Appearance = System.Windows.Forms.Appearance.Button;
            button.BackColor = color;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.Location = location;
            button.Size = size;
            button.Text = text;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.UseVisualStyleBackColor = false;
        }

        private void SetupSmallButton(System.Windows.Forms.Button button, string text, System.Drawing.Color color)
        {
            button.BackColor = color;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.White;
            button.Margin = new System.Windows.Forms.Padding(3);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
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
            button.Margin = new System.Windows.Forms.Padding(3);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private void SetupMoneyLabel(System.Windows.Forms.Label label, string text)
        {
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(55, 38, 27);
            label.AutoEllipsis = true;
            label.Text = text;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }
    }
}
