namespace FortBuenaVista.DesktopApp
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
            this.ButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FoundationButton = new System.Windows.Forms.RadioButton();
            this.PillarButton = new System.Windows.Forms.RadioButton();
            this.CanvasPanel = new System.Windows.Forms.Panel();
            this.ButtonFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonFlowLayoutPanel
            // 
            this.ButtonFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ButtonFlowLayoutPanel.Controls.Add(this.FoundationButton);
            this.ButtonFlowLayoutPanel.Controls.Add(this.PillarButton);
            this.ButtonFlowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.ButtonFlowLayoutPanel.Name = "ButtonFlowLayoutPanel";
            this.ButtonFlowLayoutPanel.Size = new System.Drawing.Size(200, 438);
            this.ButtonFlowLayoutPanel.TabIndex = 0;
            // 
            // FoundationButton
            // 
            this.FoundationButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.FoundationButton.Checked = true;
            this.FoundationButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FoundationButton.Location = new System.Drawing.Point(3, 3);
            this.FoundationButton.Name = "FoundationButton";
            this.FoundationButton.Size = new System.Drawing.Size(91, 30);
            this.FoundationButton.TabIndex = 0;
            this.FoundationButton.TabStop = true;
            this.FoundationButton.Text = "Foundation";
            this.FoundationButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FoundationButton.UseVisualStyleBackColor = true;
            this.FoundationButton.CheckedChanged += new System.EventHandler(this.ComponentButton_CheckedChanged);
            // 
            // PillarButton
            // 
            this.PillarButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.PillarButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PillarButton.Location = new System.Drawing.Point(100, 3);
            this.PillarButton.Name = "PillarButton";
            this.PillarButton.Size = new System.Drawing.Size(91, 30);
            this.PillarButton.TabIndex = 1;
            this.PillarButton.Text = "Pillar";
            this.PillarButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PillarButton.UseVisualStyleBackColor = true;
            this.PillarButton.CheckedChanged += new System.EventHandler(this.ComponentButton_CheckedChanged);
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CanvasPanel.BackColor = System.Drawing.Color.LightSalmon;
            this.CanvasPanel.Location = new System.Drawing.Point(218, 12);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(594, 438);
            this.CanvasPanel.TabIndex = 1;
            this.CanvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 462);
            this.Controls.Add(this.CanvasPanel);
            this.Controls.Add(this.ButtonFlowLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Fort Buena Vista";
            this.ButtonFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ButtonFlowLayoutPanel;
        private System.Windows.Forms.Panel CanvasPanel;
        private System.Windows.Forms.RadioButton FoundationButton;
        private System.Windows.Forms.RadioButton PillarButton;

    }
}

