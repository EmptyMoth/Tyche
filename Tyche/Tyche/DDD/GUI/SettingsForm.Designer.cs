namespace Tyche.DDD.GUI
{
    partial class SettingsForm
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
            dataGridViewSettings = new DataGridView();
            label_Settings = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSettings).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSettings
            // 
            dataGridViewSettings.AllowUserToAddRows = false;
            dataGridViewSettings.AllowUserToDeleteRows = false;
            dataGridViewSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSettings.Location = new Point(12, 64);
            dataGridViewSettings.Name = "dataGridViewSettings";
            dataGridViewSettings.RowTemplate.Height = 25;
            dataGridViewSettings.Size = new Size(243, 150);
            dataGridViewSettings.TabIndex = 3;
            dataGridViewSettings.CellContentClick += dataGridView1_CellContentClick;
            dataGridViewSettings.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // label_Settings
            // 
            label_Settings.AutoSize = true;
            label_Settings.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_Settings.Location = new Point(12, 24);
            label_Settings.Name = "label_Settings";
            label_Settings.Size = new Size(84, 25);
            label_Settings.TabIndex = 4;
            label_Settings.Text = "Settings";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 235);
            Controls.Add(label_Settings);
            Controls.Add(dataGridViewSettings);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "SettingsForm";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSettings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewSettings;
        private DataGridViewTextBoxColumn Property;
        private DataGridViewTextBoxColumn Value;
        private Label label_Settings;
    }
}