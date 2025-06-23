namespace ClockApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.MonthCalendar calendar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(20, 20);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(51, 25);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "ЧАС";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(22, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 19);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "ДАТА";
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(20, 80);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.calendar);
            this.Name = "Form1";
            this.Text = "Повний годинник та календар";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
