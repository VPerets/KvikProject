namespace KVIK_project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabContract = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddGood = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddContragent = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxContrags = new System.Windows.Forms.TextBox();
            this.buttonAddContract = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.dtDeadLine = new System.Windows.Forms.DateTimePicker();
            this.comboBoxOwners = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxContragents = new System.Windows.Forms.ComboBox();
            this.textBoxТNumberContract = new System.Windows.Forms.TextBox();
            this.dtFromContr = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddGoodsInContract = new System.Windows.Forms.Button();
            this.tabPagePrice = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttoEditPrice = new System.Windows.Forms.Button();
            this.lvGoodsPrices = new System.Windows.Forms.ListBox();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSum = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelOtgr = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.figure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.send = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Commentary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deadLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCommContract = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabContract.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tabPagePrice.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 496);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabContract);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPagePrice);
            this.tabControl.Controls.Add(this.tabPageInfo);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1038, 490);
            this.tabControl.TabIndex = 0;
            // 
            // tabContract
            // 
            this.tabContract.Controls.Add(this.tableLayoutPanel2);
            this.tabContract.Location = new System.Drawing.Point(4, 22);
            this.tabContract.Name = "tabContract";
            this.tabContract.Padding = new System.Windows.Forms.Padding(3);
            this.tabContract.Size = new System.Drawing.Size(1030, 464);
            this.tabContract.TabIndex = 0;
            this.tabContract.Text = "Договора";
            this.tabContract.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.571428F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.42857F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1021, 455);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.figure,
            this.Total,
            this.left,
            this.send,
            this.button,
            this.Commentary,
            this.deadLine});
            this.tableLayoutPanel2.SetColumnSpan(this.dataGridView1, 5);
            this.dataGridView1.Location = new System.Drawing.Point(3, 41);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1015, 411);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(207, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Искать по контрагенту";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1030, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Добавить ...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            this.tableLayoutPanel3.Controls.Add(this.buttonAddGood, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonAddGoodsInContract, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonAddContract, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.63717F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.36283F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 363F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1000, 457);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonAddGood
            // 
            this.buttonAddGood.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddGood.Location = new System.Drawing.Point(3, 3);
            this.buttonAddGood.Name = "buttonAddGood";
            this.buttonAddGood.Size = new System.Drawing.Size(317, 47);
            this.buttonAddGood.TabIndex = 0;
            this.buttonAddGood.Text = "Добавить продукт";
            this.buttonAddGood.UseVisualStyleBackColor = true;
            this.buttonAddGood.Click += new System.EventHandler(this.btnAddGood_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.buttonAddContragent, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(326, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(317, 47);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // buttonAddContragent
            // 
            this.buttonAddContragent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddContragent.Location = new System.Drawing.Point(3, 3);
            this.buttonAddContragent.Name = "buttonAddContragent";
            this.buttonAddContragent.Size = new System.Drawing.Size(152, 41);
            this.buttonAddContragent.TabIndex = 1;
            this.buttonAddContragent.Text = "Добавить контрагент";
            this.buttonAddContragent.UseVisualStyleBackColor = true;
            this.buttonAddContragent.Click += new System.EventHandler(this.buttonAddContragent_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBoxContrags, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(161, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(153, 41);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Название";
            // 
            // textBoxContrags
            // 
            this.textBoxContrags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContrags.Location = new System.Drawing.Point(3, 3);
            this.textBoxContrags.Name = "textBoxContrags";
            this.textBoxContrags.Size = new System.Drawing.Size(147, 20);
            this.textBoxContrags.TabIndex = 4;
            // 
            // buttonAddContract
            // 
            this.buttonAddContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddContract.Location = new System.Drawing.Point(3, 56);
            this.buttonAddContract.Name = "buttonAddContract";
            this.buttonAddContract.Size = new System.Drawing.Size(317, 34);
            this.buttonAddContract.TabIndex = 1;
            this.buttonAddContract.Text = "Добавить договор";
            this.buttonAddContract.UseVisualStyleBackColor = true;
            this.buttonAddContract.Click += new System.EventHandler(this.buttonAddContract_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.textBoxТNumberContract, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.dtDeadLine, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.comboBoxOwners, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.comboBoxContragents, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.dtFromContr, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tbCommContract, 1, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 96);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 6;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(317, 358);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // dtDeadLine
            // 
            this.dtDeadLine.Location = new System.Drawing.Point(161, 338);
            this.dtDeadLine.Name = "dtDeadLine";
            this.dtDeadLine.Size = new System.Drawing.Size(153, 20);
            this.dtDeadLine.TabIndex = 10;
            // 
            // comboBoxOwners
            // 
            this.comboBoxOwners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOwners.FormattingEnabled = true;
            this.comboBoxOwners.Location = new System.Drawing.Point(161, 271);
            this.comboBoxOwners.Name = "comboBoxOwners";
            this.comboBoxOwners.Size = new System.Drawing.Size(153, 21);
            this.comboBoxOwners.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Конечный срок";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 67);
            this.label2.TabIndex = 0;
            this.label2.Text = "Номер договора";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 67);
            this.label6.TabIndex = 7;
            this.label6.Text = "Фирма";
            // 
            // comboBoxContragents
            // 
            this.comboBoxContragents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxContragents.FormattingEnabled = true;
            this.comboBoxContragents.Location = new System.Drawing.Point(161, 204);
            this.comboBoxContragents.Name = "comboBoxContragents";
            this.comboBoxContragents.Size = new System.Drawing.Size(153, 21);
            this.comboBoxContragents.TabIndex = 5;
            // 
            // textBoxТNumberContract
            // 
            this.textBoxТNumberContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxТNumberContract.Location = new System.Drawing.Point(161, 3);
            this.textBoxТNumberContract.Name = "textBoxТNumberContract";
            this.textBoxТNumberContract.Size = new System.Drawing.Size(153, 20);
            this.textBoxТNumberContract.TabIndex = 3;
            // 
            // dtFromContr
            // 
            this.dtFromContr.Location = new System.Drawing.Point(161, 137);
            this.dtFromContr.Name = "dtFromContr";
            this.dtFromContr.Size = new System.Drawing.Size(152, 20);
            this.dtFromContr.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 67);
            this.label3.TabIndex = 1;
            this.label3.Text = "Дата";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 67);
            this.label4.TabIndex = 2;
            this.label4.Text = "Контрагент";
            // 
            // buttonAddGoodsInContract
            // 
            this.buttonAddGoodsInContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddGoodsInContract.Location = new System.Drawing.Point(649, 3);
            this.buttonAddGoodsInContract.Name = "buttonAddGoodsInContract";
            this.buttonAddGoodsInContract.Size = new System.Drawing.Size(348, 47);
            this.buttonAddGoodsInContract.TabIndex = 4;
            this.buttonAddGoodsInContract.Text = "Добавить спецификацию\r\n";
            this.buttonAddGoodsInContract.UseVisualStyleBackColor = true;
            this.buttonAddGoodsInContract.Click += new System.EventHandler(this.buttonAddGoodsInContract_Click);
            // 
            // tabPagePrice
            // 
            this.tabPagePrice.Controls.Add(this.tableLayoutPanel4);
            this.tabPagePrice.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrice.Name = "tabPagePrice";
            this.tabPagePrice.Size = new System.Drawing.Size(1030, 464);
            this.tabPagePrice.TabIndex = 2;
            this.tabPagePrice.Text = "Цены";
            this.tabPagePrice.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.71772F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.28228F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lvGoodsPrices, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(29, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(666, 386);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.buttoEditPrice, 0, 2);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(112, 212);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(106, 61);
            this.labelName.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 1;
            // 
            // buttoEditPrice
            // 
            this.buttoEditPrice.Location = new System.Drawing.Point(3, 125);
            this.buttoEditPrice.Name = "buttoEditPrice";
            this.buttoEditPrice.Size = new System.Drawing.Size(75, 23);
            this.buttoEditPrice.TabIndex = 2;
            this.buttoEditPrice.Text = "Изменить";
            this.buttoEditPrice.UseVisualStyleBackColor = true;
            this.buttoEditPrice.Click += new System.EventHandler(this.buttoEditPrice_Click);
            // 
            // lvGoodsPrices
            // 
            this.lvGoodsPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGoodsPrices.FormattingEnabled = true;
            this.lvGoodsPrices.Location = new System.Drawing.Point(121, 3);
            this.lvGoodsPrices.Name = "lvGoodsPrices";
            this.lvGoodsPrices.Size = new System.Drawing.Size(542, 212);
            this.lvGoodsPrices.TabIndex = 2;
            this.lvGoodsPrices.SelectedValueChanged += new System.EventHandler(this.lvGoodsPrices_SelectedValueChanged);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.tableLayoutPanel9);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Size = new System.Drawing.Size(1030, 464);
            this.tabPageInfo.TabIndex = 3;
            this.tabPageInfo.Text = "Инфо";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.04651F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.95349F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tableLayoutPanel9.Controls.Add(this.labelSum, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.labelOtgr, 1, 1);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(32, 22);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.5641F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.4359F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 316F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(768, 395);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // labelSum
            // 
            this.labelSum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(98, 0);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(106, 41);
            this.labelSum.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 41);
            this.label8.TabIndex = 0;
            this.label8.Text = "Всего на сумму";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 37);
            this.label9.TabIndex = 1;
            this.label9.Text = "Отгрузили";
            // 
            // labelOtgr
            // 
            this.labelOtgr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOtgr.AutoSize = true;
            this.labelOtgr.Location = new System.Drawing.Point(98, 41);
            this.labelOtgr.Name = "labelOtgr";
            this.labelOtgr.Size = new System.Drawing.Size(106, 37);
            this.labelOtgr.TabIndex = 3;
            // 
            // code
            // 
            this.code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.code.HeaderText = "Код";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.code.Width = 32;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // figure
            // 
            this.figure.HeaderText = "Чертёж";
            this.figure.Name = "figure";
            this.figure.ReadOnly = true;
            this.figure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            this.Total.HeaderText = "Всего(кол)";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // left
            // 
            this.left.HeaderText = "Осталось(кол)";
            this.left.Name = "left";
            this.left.ReadOnly = true;
            this.left.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // send
            // 
            this.send.HeaderText = "Отгрузить(кол)";
            this.send.Name = "send";
            this.send.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button
            // 
            this.button.HeaderText = "Подтвердить";
            this.button.Name = "button";
            this.button.Text = "Подтвердить";
            this.button.ToolTipText = "Подтвердить";
            this.button.UseColumnTextForButtonValue = true;
            // 
            // Commentary
            // 
            this.Commentary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Commentary.HeaderText = "Комментарий";
            this.Commentary.Name = "Commentary";
            this.Commentary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // deadLine
            // 
            this.deadLine.HeaderText = "Срок";
            this.deadLine.Name = "deadLine";
            this.deadLine.ReadOnly = true;
            this.deadLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 67);
            this.label10.TabIndex = 11;
            this.label10.Text = "Комментарий(продукция/электровоз)";
            // 
            // tbCommContract
            // 
            this.tbCommContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommContract.Location = new System.Drawing.Point(161, 70);
            this.tbCommContract.Name = "tbCommContract";
            this.tbCommContract.Size = new System.Drawing.Size(153, 20);
            this.tbCommContract.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabContract.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tabPagePrice.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tabPageInfo.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabContract;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonAddGood;
        private System.Windows.Forms.Button buttonAddContract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxТNumberContract;
        private System.Windows.Forms.DateTimePicker dtFromContr;
        private System.Windows.Forms.ComboBox comboBoxContragents;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonAddContragent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxContrags;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxOwners;
        private System.Windows.Forms.DateTimePicker dtDeadLine;
        private System.Windows.Forms.Button buttonAddGoodsInContract;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TabPage tabPagePrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttoEditPrice;
        private System.Windows.Forms.ListBox lvGoodsPrices;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelOtgr;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn figure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn left;
        private System.Windows.Forms.DataGridViewTextBoxColumn send;
        private System.Windows.Forms.DataGridViewButtonColumn button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commentary;
        private System.Windows.Forms.DataGridViewTextBoxColumn deadLine;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbCommContract;
    }
}

