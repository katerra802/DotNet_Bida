using System;

namespace bida_test
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.chart_doanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_khachHang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoadformHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_doanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_khachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnLoadformHoaDon);
            this.panelMain.Controls.Add(this.chart_khachHang);
            this.panelMain.Controls.Add(this.chart_doanhThu);
            this.panelMain.Controls.Add(this.dtpStart);
            this.panelMain.Controls.Add(this.dtpEnd);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1309, 583);
            this.panelMain.TabIndex = 0;
            // 
            // dtpEnd
            // 
            this.dtpEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtpEnd.BorderColor = System.Drawing.Color.Transparent;
            this.dtpEnd.BorderRadius = 10;
            this.dtpEnd.Checked = true;
            this.dtpEnd.FillColor = System.Drawing.Color.White;
            this.dtpEnd.FocusedColor = System.Drawing.Color.Transparent;
            this.dtpEnd.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(303, 30);
            this.dtpEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(250, 54);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpEnd.Value = new System.DateTime(2024, 11, 21, 0, 0, 0, 0);
            this.dtpEnd.ValueChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.dtpEnd.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // dtpStart
            // 
            this.dtpStart.BorderColor = System.Drawing.Color.Transparent;
            this.dtpStart.BorderRadius = 10;
            this.dtpStart.Checked = true;
            this.dtpStart.FillColor = System.Drawing.Color.White;
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(30, 30);
            this.dtpStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(250, 54);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpStart.Value = new System.DateTime(2024, 11, 21, 0, 0, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.dtpStart.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // chart_doanhThu
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_doanhThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_doanhThu.Legends.Add(legend2);
            this.chart_doanhThu.Location = new System.Drawing.Point(30, 102);
            this.chart_doanhThu.Name = "chart_doanhThu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Doanh thu";
            this.chart_doanhThu.Series.Add(series2);
            this.chart_doanhThu.Size = new System.Drawing.Size(645, 465);
            this.chart_doanhThu.TabIndex = 5;
            this.chart_doanhThu.Text = "chart1";
            title2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Doanh Thu";
            this.chart_doanhThu.Titles.Add(title2);
            // 
            // chart_khachHang
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_khachHang.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_khachHang.Legends.Add(legend1);
            this.chart_khachHang.Location = new System.Drawing.Point(681, 102);
            this.chart_khachHang.Name = "chart_khachHang";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Khách hàng";
            this.chart_khachHang.Series.Add(series1);
            this.chart_khachHang.Size = new System.Drawing.Size(616, 465);
            this.chart_khachHang.TabIndex = 5;
            this.chart_khachHang.Text = "chart1";
            title1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Số lượng khách Hàng";
            this.chart_khachHang.Titles.Add(title1);
            // 
            // btnLoadformHoaDon
            // 
            this.btnLoadformHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadformHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadformHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadformHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadformHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadformHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnLoadformHoaDon.Location = new System.Drawing.Point(1035, 30);
            this.btnLoadformHoaDon.Name = "btnLoadformHoaDon";
            this.btnLoadformHoaDon.Size = new System.Drawing.Size(180, 45);
            this.btnLoadformHoaDon.TabIndex = 6;
            this.btnLoadformHoaDon.Text = "Xem Lịch sử hóa đơn";
            this.btnLoadformHoaDon.Click += new System.EventHandler(this.btnLoadformHoaDon_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 583);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKe";
            this.Text = "Thống Kê Hóa Đơn và Doanh Thu";
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_doanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_khachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_khachHang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_doanhThu;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEnd;
        private Guna.UI2.WinForms.Guna2Button btnLoadformHoaDon;
    }
}