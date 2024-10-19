namespace MegaDesk1
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit = new System.Windows.Forms.Button();
            this.AddQuote = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.viewAllQuotesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(254, 205);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AddQuote
            // 
            this.AddQuote.Location = new System.Drawing.Point(12, 12);
            this.AddQuote.Name = "AddQuote";
            this.AddQuote.Size = new System.Drawing.Size(116, 23);
            this.AddQuote.TabIndex = 1;
            this.AddQuote.Text = "Add Quote";
            this.AddQuote.UseVisualStyleBackColor = true;
            this.AddQuote.Click += new System.EventHandler(this.AddQuote_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MegaDesk1.Properties.Resources.desk;
            this.pictureBox1.Location = new System.Drawing.Point(156, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 187);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // viewAllQuotesButton
            // 
            this.viewAllQuotesButton.Location = new System.Drawing.Point(12, 41);
            this.viewAllQuotesButton.Name = "viewAllQuotesButton";
            this.viewAllQuotesButton.Size = new System.Drawing.Size(116, 23);
            this.viewAllQuotesButton.TabIndex = 3;
            this.viewAllQuotesButton.Text = "View all quotes";
            this.viewAllQuotesButton.UseVisualStyleBackColor = true;
            this.viewAllQuotesButton.Click += new System.EventHandler(this.viewAllQuotesButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 240);
            this.Controls.Add(this.viewAllQuotesButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AddQuote);
            this.Controls.Add(this.Exit);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button AddQuote;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button viewAllQuotesButton;
    }
}

