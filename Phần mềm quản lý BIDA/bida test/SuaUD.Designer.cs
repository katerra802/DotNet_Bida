namespace bida_test
{
    partial class SuaUD
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
            this.txtUudai = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUDTittle = new System.Windows.Forms.Label();
            this.btnSuaUD = new Guna.UI2.WinForms.Guna2Button();
            this.txtDieukienUD = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenUD = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenUD = new System.Windows.Forms.Label();
            this.lblDieukien = new System.Windows.Forms.Label();
            this.lblUD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUudai
            // 
            this.txtUudai.BorderColor = System.Drawing.Color.Gray;
            this.txtUudai.BorderRadius = 10;
            this.txtUudai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUudai.DefaultText = "";
            this.txtUudai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUudai.Location = new System.Drawing.Point(33, 258);
            this.txtUudai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUudai.Name = "txtUudai";
            this.txtUudai.PasswordChar = '\0';
            this.txtUudai.PlaceholderText = "Ưu đãi";
            this.txtUudai.SelectedText = "";
            this.txtUudai.Size = new System.Drawing.Size(251, 38);
            this.txtUudai.TabIndex = 15;
            this.txtUudai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUudai_KeyPress);
            // 
            // lblUDTittle
            // 
            this.lblUDTittle.AutoSize = true;
            this.lblUDTittle.Location = new System.Drawing.Point(29, 26);
            this.lblUDTittle.Name = "lblUDTittle";
            this.lblUDTittle.Size = new System.Drawing.Size(135, 16);
            this.lblUDTittle.TabIndex = 13;
            this.lblUDTittle.Text = "Thông Tin Ưu đãi mới";
            // 
            // btnSuaUD
            // 
            this.btnSuaUD.BorderRadius = 10;
            this.btnSuaUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSuaUD.ForeColor = System.Drawing.Color.White;
            this.btnSuaUD.Location = new System.Drawing.Point(33, 332);
            this.btnSuaUD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaUD.Name = "btnSuaUD";
            this.btnSuaUD.Size = new System.Drawing.Size(251, 38);
            this.btnSuaUD.TabIndex = 12;
            this.btnSuaUD.Text = "Sửa Ưu đãi";
            this.btnSuaUD.Click += new System.EventHandler(this.btnSuaUD_Click);
            // 
            // txtDieukienUD
            // 
            this.txtDieukienUD.BorderColor = System.Drawing.Color.Gray;
            this.txtDieukienUD.BorderRadius = 10;
            this.txtDieukienUD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDieukienUD.DefaultText = "";
            this.txtDieukienUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDieukienUD.Location = new System.Drawing.Point(33, 168);
            this.txtDieukienUD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDieukienUD.Name = "txtDieukienUD";
            this.txtDieukienUD.PasswordChar = '\0';
            this.txtDieukienUD.PlaceholderText = "Điều kiện ưu đãi";
            this.txtDieukienUD.SelectedText = "";
            this.txtDieukienUD.Size = new System.Drawing.Size(251, 38);
            this.txtDieukienUD.TabIndex = 11;
            this.txtDieukienUD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDieukienUD_KeyPress);
            // 
            // txtTenUD
            // 
            this.txtTenUD.BorderColor = System.Drawing.Color.Gray;
            this.txtTenUD.BorderRadius = 10;
            this.txtTenUD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenUD.DefaultText = "";
            this.txtTenUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenUD.Location = new System.Drawing.Point(33, 84);
            this.txtTenUD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenUD.Name = "txtTenUD";
            this.txtTenUD.PasswordChar = '\0';
            this.txtTenUD.PlaceholderText = "Tên ưu đãi";
            this.txtTenUD.SelectedText = "";
            this.txtTenUD.Size = new System.Drawing.Size(251, 38);
            this.txtTenUD.TabIndex = 10;
            this.txtTenUD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenUD_KeyPress);
            // 
            // lblTenUD
            // 
            this.lblTenUD.AutoSize = true;
            this.lblTenUD.Location = new System.Drawing.Point(30, 64);
            this.lblTenUD.Name = "lblTenUD";
            this.lblTenUD.Size = new System.Drawing.Size(70, 16);
            this.lblTenUD.TabIndex = 16;
            this.lblTenUD.Text = "Tên ưu đãi";
            // 
            // lblDieukien
            // 
            this.lblDieukien.AutoSize = true;
            this.lblDieukien.Location = new System.Drawing.Point(30, 148);
            this.lblDieukien.Name = "lblDieukien";
            this.lblDieukien.Size = new System.Drawing.Size(62, 16);
            this.lblDieukien.TabIndex = 17;
            this.lblDieukien.Text = "Điều kiện";
            // 
            // lblUD
            // 
            this.lblUD.AutoSize = true;
            this.lblUD.Location = new System.Drawing.Point(30, 238);
            this.lblUD.Name = "lblUD";
            this.lblUD.Size = new System.Drawing.Size(46, 16);
            this.lblUD.TabIndex = 18;
            this.lblUD.Text = "Ưu đãi";
            // 
            // SuaUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 439);
            this.Controls.Add(this.lblUD);
            this.Controls.Add(this.lblDieukien);
            this.Controls.Add(this.lblTenUD);
            this.Controls.Add(this.txtUudai);
            this.Controls.Add(this.lblUDTittle);
            this.Controls.Add(this.btnSuaUD);
            this.Controls.Add(this.txtDieukienUD);
            this.Controls.Add(this.txtTenUD);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SuaUD";
            this.Text = "SuaUD";
            this.Load += new System.EventHandler(this.SuaUD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtUudai;
        private System.Windows.Forms.Label lblUDTittle;
        private Guna.UI2.WinForms.Guna2Button btnSuaUD;
        private Guna.UI2.WinForms.Guna2TextBox txtDieukienUD;
        private Guna.UI2.WinForms.Guna2TextBox txtTenUD;
        private System.Windows.Forms.Label lblTenUD;
        private System.Windows.Forms.Label lblDieukien;
        private System.Windows.Forms.Label lblUD;
    }
}