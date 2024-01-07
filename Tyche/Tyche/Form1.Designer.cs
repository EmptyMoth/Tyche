namespace Tyche;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        comboBox_Random = new ComboBox();
        label_Random = new Label();
        textBox_Description = new TextBox();
        label_Distribution = new Label();
        label_Description = new Label();
        comboBox_Distribution = new ComboBox();
        label_Tyche = new Label();
        button_Generate = new Button();
        label_Answer = new Label();
        textBox_Answer = new TextBox();
        numericUpDown_Min = new NumericUpDown();
        label_Min = new Label();
        label_Max = new Label();
        numericUpDown_Max = new NumericUpDown();
        button_GenerateRandomValue = new Button();
        ((System.ComponentModel.ISupportInitialize)numericUpDown_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown_Max).BeginInit();
        SuspendLayout();
        // 
        // comboBox_Random
        // 
        comboBox_Random.FormattingEnabled = true;
        comboBox_Random.Location = new Point(104, 49);
        comboBox_Random.Name = "comboBox_Random";
        comboBox_Random.Size = new Size(199, 23);
        comboBox_Random.TabIndex = 1;
        comboBox_Random.SelectedIndexChanged += comboBox_Random_SelectedIndexChanged;
        // 
        // label_Random
        // 
        label_Random.AutoSize = true;
        label_Random.Location = new Point(15, 49);
        label_Random.Name = "label_Random";
        label_Random.Size = new Size(52, 15);
        label_Random.TabIndex = 2;
        label_Random.Text = "Random";
        // 
        // textBox_Description
        // 
        textBox_Description.BackColor = Color.White;
        textBox_Description.BorderStyle = BorderStyle.FixedSingle;
        textBox_Description.Location = new Point(15, 152);
        textBox_Description.Multiline = true;
        textBox_Description.Name = "textBox_Description";
        textBox_Description.ReadOnly = true;
        textBox_Description.Size = new Size(288, 122);
        textBox_Description.TabIndex = 3;
        // 
        // label_Distribution
        // 
        label_Distribution.AutoSize = true;
        label_Distribution.Location = new Point(15, 87);
        label_Distribution.Name = "label_Distribution";
        label_Distribution.Size = new Size(69, 15);
        label_Distribution.TabIndex = 4;
        label_Distribution.Text = "Distribution";
        // 
        // label_Description
        // 
        label_Description.AutoSize = true;
        label_Description.Location = new Point(17, 125);
        label_Description.Name = "label_Description";
        label_Description.Size = new Size(67, 15);
        label_Description.TabIndex = 6;
        label_Description.Text = "Description";
        // 
        // comboBox_Distribution
        // 
        comboBox_Distribution.FormattingEnabled = true;
        comboBox_Distribution.Location = new Point(104, 84);
        comboBox_Distribution.Name = "comboBox_Distribution";
        comboBox_Distribution.Size = new Size(199, 23);
        comboBox_Distribution.TabIndex = 7;
        comboBox_Distribution.SelectedIndexChanged += comboBox_Distribution_SelectedIndexChanged;
        // 
        // label_Tyche
        // 
        label_Tyche.AutoSize = true;
        label_Tyche.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
        label_Tyche.Location = new Point(15, 9);
        label_Tyche.Name = "label_Tyche";
        label_Tyche.Size = new Size(73, 30);
        label_Tyche.TabIndex = 8;
        label_Tyche.Text = "Tyche";
        // 
        // button_Generate
        // 
        button_Generate.Location = new Point(15, 284);
        button_Generate.Name = "button_Generate";
        button_Generate.Size = new Size(138, 40);
        button_Generate.TabIndex = 9;
        button_Generate.Text = "GENERATE DISTRIBUTION VALUE";
        button_Generate.UseVisualStyleBackColor = true;
        button_Generate.Click += button_Generate_Click;
        // 
        // label_Answer
        // 
        label_Answer.AutoSize = true;
        label_Answer.Location = new Point(15, 361);
        label_Answer.Name = "label_Answer";
        label_Answer.Size = new Size(46, 15);
        label_Answer.TabIndex = 10;
        label_Answer.Text = "Answer";
        // 
        // textBox_Answer
        // 
        textBox_Answer.BackColor = Color.White;
        textBox_Answer.BorderStyle = BorderStyle.FixedSingle;
        textBox_Answer.Location = new Point(67, 359);
        textBox_Answer.Name = "textBox_Answer";
        textBox_Answer.ReadOnly = true;
        textBox_Answer.Size = new Size(236, 23);
        textBox_Answer.TabIndex = 11;
        // 
        // numericUpDown_Min
        // 
        numericUpDown_Min.Location = new Point(51, 330);
        numericUpDown_Min.Name = "numericUpDown_Min";
        numericUpDown_Min.Size = new Size(102, 23);
        numericUpDown_Min.TabIndex = 12;
        numericUpDown_Min.ValueChanged += numericUpDown_Min_ValueChanged;
        // 
        // label_Min
        // 
        label_Min.AutoSize = true;
        label_Min.Location = new Point(17, 332);
        label_Min.Name = "label_Min";
        label_Min.Size = new Size(28, 15);
        label_Min.TabIndex = 13;
        label_Min.Text = "Min";
        // 
        // label_Max
        // 
        label_Max.AutoSize = true;
        label_Max.Location = new Point(165, 332);
        label_Max.Name = "label_Max";
        label_Max.Size = new Size(30, 15);
        label_Max.TabIndex = 14;
        label_Max.Text = "Max";
        // 
        // numericUpDown_Max
        // 
        numericUpDown_Max.Location = new Point(201, 330);
        numericUpDown_Max.Name = "numericUpDown_Max";
        numericUpDown_Max.Size = new Size(102, 23);
        numericUpDown_Max.TabIndex = 15;
        numericUpDown_Max.ValueChanged += numericUpDown_Max_ValueChanged;
        // 
        // button_GenerateRandomValue
        // 
        button_GenerateRandomValue.Location = new Point(167, 284);
        button_GenerateRandomValue.Name = "button_GenerateRandomValue";
        button_GenerateRandomValue.Size = new Size(136, 40);
        button_GenerateRandomValue.TabIndex = 16;
        button_GenerateRandomValue.Text = "GENERATE RANDOM VALUE";
        button_GenerateRandomValue.UseVisualStyleBackColor = true;
        button_GenerateRandomValue.Click += button_GenerateRandomValue_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(333, 399);
        Controls.Add(button_GenerateRandomValue);
        Controls.Add(numericUpDown_Max);
        Controls.Add(label_Max);
        Controls.Add(label_Min);
        Controls.Add(numericUpDown_Min);
        Controls.Add(textBox_Answer);
        Controls.Add(label_Answer);
        Controls.Add(button_Generate);
        Controls.Add(label_Tyche);
        Controls.Add(comboBox_Distribution);
        Controls.Add(label_Description);
        Controls.Add(label_Distribution);
        Controls.Add(textBox_Description);
        Controls.Add(label_Random);
        Controls.Add(comboBox_Random);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        Text = "Tyche";
        ((System.ComponentModel.ISupportInitialize)numericUpDown_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown_Max).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private ComboBox comboBox_Random;
    private Label label_Random;
    private TextBox textBox_Description;
    private Label label_Distribution;
    private Label label_Description;
    private ComboBox comboBox_Distribution;
    private Label label_Tyche;
    private Button button_Generate;
    private Label label_Answer;
    private TextBox textBox_Answer;
    private NumericUpDown numericUpDown_Min;
    private Label label_Min;
    private Label label_Max;
    private NumericUpDown numericUpDown_Max;
    private Button button_GenerateRandomValue;
}