namespace bida_test
{
    partial class ThemUD
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
            this.txtTenUD = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDieukienUD = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemUD = new Guna.UI2.WinForms.Guna2Button();
            this.lblUDTittle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUudai = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // txtTenUD
            // 
            this.txtTenUD.BorderColor = System.Drawing.Color.Gray;
            this.txtTenUD.BorderRadius = 10;
            this.txtTenUD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenUD.DefaultText = "";
            this.txtTenUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenUD.ForeColor = System.Drawing.Color.Black;
            this.txtTenUD.Location = new System.Drawing.Point(33, 52);
            this.txtTenUD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenUD.Name = "txtTenUD";
            this.txtTenUD.PasswordChar = '\0';
            this.txtTenUD.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTenUD.PlaceholderText = "Tên ưu đãi";
            this.txtTenUD.SelectedText = "";
            this.txtTenUD.Size = new System.Drawing.Size(250, 38);
            this.txtTenUD.TabIndex = 1;
            // 
            // txtDieukienUD
            // 
            this.txtDieukienUD.BorderColor = System.Drawing.Color.Gray;
            this.txtDieukienUD.BorderRadius = 10;
            this.txtDieukienUD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDieukienUD.DefaultText = "";
            this.txtDieukienUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDieukienUD.ForeColor = System.Drawing.Color.Black;
            this.txtDieukienUD.Location = new System.Drawing.Point(33, 109);
            this.txtDieukienUD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDieukienUD.Name = "txtDieukienUD";
            this.txtDieukienUD.PasswordChar = '\0';
            this.txtDieukienUD.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDieukienUD.PlaceholderText = "Điều kiện ưu đãi";
            this.txtDieukienUD.SelectedText = "";
            this.txtDieukienUD.Size = new System.Drawing.Size(250, 38);
            this.txtDieukienUD.TabIndex = 2;
            this.txtDieukienUD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDieukienUD_KeyPress);
            // 
            // btnThemUD
            // 
            this.btnThemUD.BorderRadius = 10;
            this.btnThemUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemUD.ForeColor = System.Drawing.Color.White;
            this.btnThemUD.Location = new System.Drawing.Point(33, 228);
            this.btnThemUD.Name = "btnThemUD";
            this.btnThemUD.Size = new System.Drawing.Size(250, 38);
            this.btnThemUD.TabIndex = 4;
            this.btnThemUD.Text = "Thêm Ưu đãi";
            this.btnThemUD.Click += new System.EventHandler(this.btnThemUD_Click);
            // 
            // lblUDTittle
            // 
            this.lblUDTittle.AutoSize = true;
            this.lblUDTittle.Location = new System.Drawing.Point(30, 11);
            this.lblUDTittle.Name = "lblUDTittle";
            this.lblUDTittle.Size = new System.Drawing.Size(135, 16);
            this.lblUDTittle.TabIndex = 5;
            this.lblUDTittle.Text = "Thông Tin Ưu đãi mới";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // txtUudai
            // 
            this.txtUudai.BorderColor = System.Drawing.Color.Gray;
            this.txtUudai.BorderRadius = 10;
            this.txtUudai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUudai.DefaultText = "";
            this.txtUudai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUudai.ForeColor = System.Drawing.Color.Black;
            this.txtUudai.Location = new System.Drawing.Point(33, 167);
            this.txtUudai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUudai.Name = "txtUudai";
            this.txtUudai.PasswordChar = '\0';
            this.txtUudai.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtUudai.PlaceholderText = "Ưu đãi %(ví dụ: 10 = 0.1) max = 50%";
            this.txtUudai.SelectedText = "";
            this.txtUudai.Size = new System.Drawing.Size(250, 38);
            this.txtUudai.TabIndex = 8;
            this.txtUudai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUudai_KeyPress);
            // 
            // ThemUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 344);
            this.Controls.Add(this.txtUudai);
            this.Controls.Add(this.lblUDTittle);
            this.Controls.Add(this.btnThemUD);
            this.Controls.Add(this.txtDieukienUD);
            this.Controls.Add(this.txtTenUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ThemUD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Khách Hàng Mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtTenUD;
        private Guna.UI2.WinForms.Guna2TextBox txtDieukienUD;
        private Guna.UI2.WinForms.Guna2Button btnThemUD;
        private System.Windows.Forms.Label lblUDTittle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtUudai;
    }
}