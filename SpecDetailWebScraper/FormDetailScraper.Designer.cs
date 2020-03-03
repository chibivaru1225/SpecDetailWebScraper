namespace SpecDetailWebScraper
{
    partial class FormDetailScraper
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailScraper));
            this.gbSearchHistory = new System.Windows.Forms.GroupBox();
            this.lvSearchHistory = new System.Windows.Forms.ListView();
            this.chEmptyColumn1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSearchWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSearchMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSearchTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResultNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.chEmptyColumn2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPageTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ss1 = new System.Windows.Forms.StatusStrip();
            this.tssl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbResultPrev = new System.Windows.Forms.GroupBox();
            this.lblURLDetail = new System.Windows.Forms.TextBox();
            this.lblTitleDetail = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtResultPrev = new System.Windows.Forms.TextBox();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.btnF1 = new System.Windows.Forms.Button();
            this.btnF2 = new System.Windows.Forms.Button();
            this.btnF3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnF4 = new System.Windows.Forms.Button();
            this.gbSearchHistory.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.ss1.SuspendLayout();
            this.gbResultPrev.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchHistory
            // 
            this.gbSearchHistory.Controls.Add(this.lvSearchHistory);
            this.gbSearchHistory.Location = new System.Drawing.Point(108, 5);
            this.gbSearchHistory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.gbSearchHistory.Name = "gbSearchHistory";
            this.gbSearchHistory.Size = new System.Drawing.Size(475, 200);
            this.gbSearchHistory.TabIndex = 0;
            this.gbSearchHistory.TabStop = false;
            this.gbSearchHistory.Text = "検索履歴";
            // 
            // lvSearchHistory
            // 
            this.lvSearchHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEmptyColumn1,
            this.chSearchWord,
            this.chSearchMode,
            this.chSearchTime,
            this.chResultNumber});
            this.lvSearchHistory.FullRowSelect = true;
            this.lvSearchHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSearchHistory.Location = new System.Drawing.Point(6, 18);
            this.lvSearchHistory.MultiSelect = false;
            this.lvSearchHistory.Name = "lvSearchHistory";
            this.lvSearchHistory.Size = new System.Drawing.Size(463, 176);
            this.lvSearchHistory.TabIndex = 0;
            this.lvSearchHistory.UseCompatibleStateImageBehavior = false;
            this.lvSearchHistory.View = System.Windows.Forms.View.Details;
            this.lvSearchHistory.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvSearchHistory_ColumnWidthChanging);
            this.lvSearchHistory.SelectedIndexChanged += new System.EventHandler(this.lvSearchHistory_SelectedIndexChanged);
            this.lvSearchHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDetailScraper_KeyDown);
            // 
            // chEmptyColumn1
            // 
            this.chEmptyColumn1.Text = "";
            this.chEmptyColumn1.Width = 20;
            // 
            // chSearchWord
            // 
            this.chSearchWord.Text = "検索ワード";
            this.chSearchWord.Width = 200;
            // 
            // chSearchMode
            // 
            this.chSearchMode.Text = "検索モード";
            this.chSearchMode.Width = 80;
            // 
            // chSearchTime
            // 
            this.chSearchTime.Text = "検索時間";
            this.chSearchTime.Width = 80;
            // 
            // chResultNumber
            // 
            this.chResultNumber.Text = "結果件数";
            // 
            // gbResult
            // 
            this.gbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResult.Controls.Add(this.lvSearchResult);
            this.gbResult.Location = new System.Drawing.Point(586, 5);
            this.gbResult.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(393, 200);
            this.gbResult.TabIndex = 1;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "検索結果";
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEmptyColumn2,
            this.chPageTitle});
            this.lvSearchResult.FullRowSelect = true;
            this.lvSearchResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSearchResult.Location = new System.Drawing.Point(6, 18);
            this.lvSearchResult.MultiSelect = false;
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(381, 176);
            this.lvSearchResult.TabIndex = 0;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            this.lvSearchResult.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvSearchResult_ColumnWidthChanging);
            this.lvSearchResult.SelectedIndexChanged += new System.EventHandler(this.lvSearchResult_SelectedIndexChanged);
            this.lvSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDetailScraper_KeyDown);
            // 
            // chEmptyColumn2
            // 
            this.chEmptyColumn2.Text = "";
            this.chEmptyColumn2.Width = 20;
            // 
            // chPageTitle
            // 
            this.chPageTitle.Text = "ページタイトル";
            this.chPageTitle.Width = 340;
            // 
            // ss1
            // 
            this.ss1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl1});
            this.ss1.Location = new System.Drawing.Point(5, 534);
            this.ss1.Name = "ss1";
            this.ss1.Size = new System.Drawing.Size(974, 22);
            this.ss1.TabIndex = 3;
            this.ss1.Text = "statusStrip1";
            // 
            // tssl1
            // 
            this.tssl1.Name = "tssl1";
            this.tssl1.Size = new System.Drawing.Size(0, 17);
            // 
            // gbResultPrev
            // 
            this.gbResultPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultPrev.Controls.Add(this.lblURLDetail);
            this.gbResultPrev.Controls.Add(this.lblTitleDetail);
            this.gbResultPrev.Controls.Add(this.lblURL);
            this.gbResultPrev.Controls.Add(this.lblTitle);
            this.gbResultPrev.Controls.Add(this.txtResultPrev);
            this.gbResultPrev.Location = new System.Drawing.Point(5, 211);
            this.gbResultPrev.Name = "gbResultPrev";
            this.gbResultPrev.Size = new System.Drawing.Size(974, 320);
            this.gbResultPrev.TabIndex = 2;
            this.gbResultPrev.TabStop = false;
            this.gbResultPrev.Text = "結果プレビュー";
            // 
            // lblURLDetail
            // 
            this.lblURLDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblURLDetail.Location = new System.Drawing.Point(84, 40);
            this.lblURLDetail.Name = "lblURLDetail";
            this.lblURLDetail.ReadOnly = true;
            this.lblURLDetail.Size = new System.Drawing.Size(884, 19);
            this.lblURLDetail.TabIndex = 1;
            // 
            // lblTitleDetail
            // 
            this.lblTitleDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleDetail.Location = new System.Drawing.Point(84, 15);
            this.lblTitleDetail.Name = "lblTitleDetail";
            this.lblTitleDetail.ReadOnly = true;
            this.lblTitleDetail.Size = new System.Drawing.Size(884, 19);
            this.lblTitleDetail.TabIndex = 0;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(19, 43);
            this.lblURL.Margin = new System.Windows.Forms.Padding(3);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(59, 12);
            this.lblURL.TabIndex = 2;
            this.lblURL.Text = "ページURL:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 12);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ページタイトル:";
            // 
            // txtResultPrev
            // 
            this.txtResultPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultPrev.Location = new System.Drawing.Point(6, 65);
            this.txtResultPrev.Multiline = true;
            this.txtResultPrev.Name = "txtResultPrev";
            this.txtResultPrev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultPrev.Size = new System.Drawing.Size(962, 249);
            this.txtResultPrev.TabIndex = 2;
            this.txtResultPrev.Enter += new System.EventHandler(this.txtResultPrev_Enter);
            this.txtResultPrev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDetailScraper_KeyDown);
            this.txtResultPrev.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtResultPrev_MouseDown);
            // 
            // bgw1
            // 
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            this.bgw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(6, 18);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(88, 39);
            this.btnF1.TabIndex = 0;
            this.btnF1.Text = "[F1]\r\n検索";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // btnF2
            // 
            this.btnF2.Location = new System.Drawing.Point(6, 63);
            this.btnF2.Name = "btnF2";
            this.btnF2.Size = new System.Drawing.Size(88, 39);
            this.btnF2.TabIndex = 1;
            this.btnF2.Text = "[F2]\r\nコピー";
            this.btnF2.UseVisualStyleBackColor = true;
            this.btnF2.Click += new System.EventHandler(this.btnF2_Click);
            // 
            // btnF3
            // 
            this.btnF3.Location = new System.Drawing.Point(6, 108);
            this.btnF3.Name = "btnF3";
            this.btnF3.Size = new System.Drawing.Size(88, 39);
            this.btnF3.TabIndex = 2;
            this.btnF3.Text = "[F3]\r\nコピー後閉じる";
            this.btnF3.UseVisualStyleBackColor = true;
            this.btnF3.Click += new System.EventHandler(this.btnF3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnF4);
            this.groupBox1.Controls.Add(this.btnF3);
            this.groupBox1.Controls.Add(this.btnF1);
            this.groupBox1.Controls.Add(this.btnF2);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "コマンド";
            // 
            // btnF4
            // 
            this.btnF4.Location = new System.Drawing.Point(6, 153);
            this.btnF4.Name = "btnF4";
            this.btnF4.Size = new System.Drawing.Size(88, 39);
            this.btnF4.TabIndex = 3;
            this.btnF4.Text = "[F4]\r\n保存先開く";
            this.btnF4.UseVisualStyleBackColor = true;
            this.btnF4.Click += new System.EventHandler(this.btnF4_Click);
            // 
            // FormDetailScraper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbResultPrev);
            this.Controls.Add(this.ss1);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbSearchHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetailScraper";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "スペック検索";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDetailScraper_KeyDown);
            this.gbSearchHistory.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            this.ss1.ResumeLayout(false);
            this.ss1.PerformLayout();
            this.gbResultPrev.ResumeLayout(false);
            this.gbResultPrev.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchHistory;
        private System.Windows.Forms.ColumnHeader chEmptyColumn1;
        private System.Windows.Forms.ColumnHeader chSearchWord;
        private System.Windows.Forms.ColumnHeader chSearchMode;
        private System.Windows.Forms.ColumnHeader chSearchTime;
        private System.Windows.Forms.ColumnHeader chResultNumber;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.StatusStrip ss1;
        private System.Windows.Forms.GroupBox gbResultPrev;
        private System.Windows.Forms.TextBox txtResultPrev;
        private System.Windows.Forms.ColumnHeader chEmptyColumn2;
        private System.Windows.Forms.ColumnHeader chPageTitle;
        private System.ComponentModel.BackgroundWorker bgw1;
        private System.Windows.Forms.ListView lvSearchHistory;
        private System.Windows.Forms.ToolStripStatusLabel tssl1;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox lblURLDetail;
        private System.Windows.Forms.TextBox lblTitleDetail;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.Button btnF2;
        private System.Windows.Forms.Button btnF3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnF4;
    }
}

