namespace ScratchPad
{
  partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      this.TextBox = new System.Windows.Forms.TextBox();
      this.SaveTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // TextBox
      // 
      this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.TextBox.Location = new System.Drawing.Point(0, 0);
      this.TextBox.Multiline = true;
      this.TextBox.Name = "TextBox";
      this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.TextBox.Size = new System.Drawing.Size(933, 588);
      this.TextBox.TabIndex = 0;
      this.TextBox.WordWrap = false;
      // 
      // SaveTimer
      // 
      this.SaveTimer.Interval = 15000;
      this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(933, 588);
      this.Controls.Add(this.TextBox);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "MainForm";
      this.Text = "Scratch Pad";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.Form_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Timer SaveTimer;
    }
}

