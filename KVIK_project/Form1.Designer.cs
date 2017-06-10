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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOtgruzka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddGood = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.32107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.67893F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddGood, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.71004F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.28996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(983, 493);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColQuant,
            this.ColLeft,
            this.ColOtgruzka,
            this.ColButton});
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView, 3);
            this.dataGridView.Size = new System.Drawing.Size(913, 487);
            this.dataGridView.TabIndex = 0;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Название";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColQuant
            // 
            this.ColQuant.HeaderText = "Общее кол";
            this.ColQuant.Name = "ColQuant";
            this.ColQuant.ReadOnly = true;
            // 
            // ColLeft
            // 
            this.ColLeft.HeaderText = "Осталось";
            this.ColLeft.Name = "ColLeft";
            this.ColLeft.ReadOnly = true;
            // 
            // ColOtgruzka
            // 
            this.ColOtgruzka.HeaderText = "Кол Отгрузить";
            this.ColOtgruzka.Name = "ColOtgruzka";
            // 
            // ColButton
            // 
            this.ColButton.HeaderText = "Отгрузить!";
            this.ColButton.Name = "ColButton";
            this.ColButton.Text = "Отгрузить!";
            // 
            // btnAddGood
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnAddGood, 2);
            this.btnAddGood.Location = new System.Drawing.Point(922, 3);
            this.btnAddGood.Name = "btnAddGood";
            this.btnAddGood.Size = new System.Drawing.Size(58, 152);
            this.btnAddGood.TabIndex = 1;
            this.btnAddGood.Text = "Добавить товар";
            this.btnAddGood.UseVisualStyleBackColor = true;
            this.btnAddGood.Click += new System.EventHandler(this.btnAddGood_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOtgruzka;
        private System.Windows.Forms.DataGridViewButtonColumn ColButton;
        private System.Windows.Forms.Button btnAddGood;
    }
}

