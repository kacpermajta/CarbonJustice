namespace CarbonJustice
{
    partial class DistrictPopup
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRepress = new System.Windows.Forms.Button();
            this.buttonPropag = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSearch.Location = new System.Drawing.Point(21, 19);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(79, 41);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Rutynowe legitymowanie";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonRepress
            // 
            this.buttonRepress.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonRepress.Location = new System.Drawing.Point(121, 19);
            this.buttonRepress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRepress.Name = "buttonRepress";
            this.buttonRepress.Size = new System.Drawing.Size(79, 41);
            this.buttonRepress.TabIndex = 1;
            this.buttonRepress.Text = "Represje";
            this.buttonRepress.UseVisualStyleBackColor = true;
            this.buttonRepress.Click += new System.EventHandler(this.buttonRepress_Click);
            // 
            // buttonPropag
            // 
            this.buttonPropag.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonPropag.Location = new System.Drawing.Point(219, 19);
            this.buttonPropag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPropag.Name = "buttonPropag";
            this.buttonPropag.Size = new System.Drawing.Size(79, 41);
            this.buttonPropag.TabIndex = 2;
            this.buttonPropag.Text = "Propaganda";
            this.buttonPropag.UseVisualStyleBackColor = true;
            this.buttonPropag.Click += new System.EventHandler(this.buttonPropag_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(171, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Wróć";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DistrictPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(68)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(320, 114);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPropag);
            this.Controls.Add(this.buttonRepress);
            this.Controls.Add(this.buttonSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "DistrictPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Możliwe działania w dzielnicy:";
            this.Load += new System.EventHandler(this.DistrictPopup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRepress;
        private System.Windows.Forms.Button buttonPropag;
        private System.Windows.Forms.Button button1;
    }
}