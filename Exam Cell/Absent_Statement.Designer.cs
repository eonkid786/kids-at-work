﻿namespace Exam_Cell
{
    partial class Absent_Statement
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
            this.Date_combobox = new System.Windows.Forms.ComboBox();
            this.Session_combobox = new System.Windows.Forms.ComboBox();
            this.Branch_combobox = new System.Windows.Forms.ComboBox();
            this.ExamCode_combobox = new System.Windows.Forms.ComboBox();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.No_of_candidates_ViewText = new System.Windows.Forms.TextBox();
            this.Prepare_Statement_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SubjectName_Combobox = new System.Windows.Forms.ComboBox();
            this.No_of_Present_ViewText = new System.Windows.Forms.TextBox();
            this.No_of_Absent_ViewText = new System.Windows.Forms.TextBox();
            this.Examination_Textbox = new System.Windows.Forms.TextBox();
            this.Eamination_Label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Filepath_textbox = new System.Windows.Forms.TextBox();
            this.Filepath_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Date_combobox
            // 
            this.Date_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Date_combobox.FormattingEnabled = true;
            this.Date_combobox.Location = new System.Drawing.Point(157, 37);
            this.Date_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Date_combobox.Name = "Date_combobox";
            this.Date_combobox.Size = new System.Drawing.Size(212, 24);
            this.Date_combobox.TabIndex = 0;
            // 
            // Session_combobox
            // 
            this.Session_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Session_combobox.FormattingEnabled = true;
            this.Session_combobox.Items.AddRange(new object[] {
            "-Select-",
            "Forenoon",
            "Afternoon"});
            this.Session_combobox.Location = new System.Drawing.Point(157, 78);
            this.Session_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Session_combobox.Name = "Session_combobox";
            this.Session_combobox.Size = new System.Drawing.Size(212, 24);
            this.Session_combobox.TabIndex = 1;
            // 
            // Branch_combobox
            // 
            this.Branch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Branch_combobox.FormattingEnabled = true;
            this.Branch_combobox.Location = new System.Drawing.Point(157, 118);
            this.Branch_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Branch_combobox.Name = "Branch_combobox";
            this.Branch_combobox.Size = new System.Drawing.Size(212, 24);
            this.Branch_combobox.TabIndex = 1;
            // 
            // ExamCode_combobox
            // 
            this.ExamCode_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExamCode_combobox.FormattingEnabled = true;
            this.ExamCode_combobox.Location = new System.Drawing.Point(157, 158);
            this.ExamCode_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExamCode_combobox.Name = "ExamCode_combobox";
            this.ExamCode_combobox.Size = new System.Drawing.Size(212, 24);
            this.ExamCode_combobox.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(479, 11);
            this.Dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dgv.Name = "Dgv";
            this.Dgv.RowTemplate.Height = 24;
            this.Dgv.Size = new System.Drawing.Size(508, 632);
            this.Dgv.TabIndex = 3;
            // 
            // No_of_candidates_ViewText
            // 
            this.No_of_candidates_ViewText.Enabled = false;
            this.No_of_candidates_ViewText.Location = new System.Drawing.Point(77, 420);
            this.No_of_candidates_ViewText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.No_of_candidates_ViewText.Multiline = true;
            this.No_of_candidates_ViewText.Name = "No_of_candidates_ViewText";
            this.No_of_candidates_ViewText.ReadOnly = true;
            this.No_of_candidates_ViewText.Size = new System.Drawing.Size(67, 40);
            this.No_of_candidates_ViewText.TabIndex = 4;
            // 
            // Prepare_Statement_btn
            // 
            this.Prepare_Statement_btn.Location = new System.Drawing.Point(123, 555);
            this.Prepare_Statement_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prepare_Statement_btn.Name = "Prepare_Statement_btn";
            this.Prepare_Statement_btn.Size = new System.Drawing.Size(149, 46);
            this.Prepare_Statement_btn.TabIndex = 5;
            this.Prepare_Statement_btn.Text = "Prepare Statement";
            this.Prepare_Statement_btn.UseVisualStyleBackColor = true;
            this.Prepare_Statement_btn.Click += new System.EventHandler(this.Prepare_Statement_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(35, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(35, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(35, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Branch/Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(35, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Exam Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(35, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Subject Name";
            // 
            // SubjectName_Combobox
            // 
            this.SubjectName_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectName_Combobox.FormattingEnabled = true;
            this.SubjectName_Combobox.Location = new System.Drawing.Point(157, 199);
            this.SubjectName_Combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubjectName_Combobox.Name = "SubjectName_Combobox";
            this.SubjectName_Combobox.Size = new System.Drawing.Size(212, 24);
            this.SubjectName_Combobox.TabIndex = 1;
            // 
            // No_of_Present_ViewText
            // 
            this.No_of_Present_ViewText.Enabled = false;
            this.No_of_Present_ViewText.Location = new System.Drawing.Point(164, 420);
            this.No_of_Present_ViewText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.No_of_Present_ViewText.Multiline = true;
            this.No_of_Present_ViewText.Name = "No_of_Present_ViewText";
            this.No_of_Present_ViewText.ReadOnly = true;
            this.No_of_Present_ViewText.Size = new System.Drawing.Size(67, 40);
            this.No_of_Present_ViewText.TabIndex = 4;
            // 
            // No_of_Absent_ViewText
            // 
            this.No_of_Absent_ViewText.Enabled = false;
            this.No_of_Absent_ViewText.Location = new System.Drawing.Point(251, 420);
            this.No_of_Absent_ViewText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.No_of_Absent_ViewText.Multiline = true;
            this.No_of_Absent_ViewText.Name = "No_of_Absent_ViewText";
            this.No_of_Absent_ViewText.ReadOnly = true;
            this.No_of_Absent_ViewText.Size = new System.Drawing.Size(67, 40);
            this.No_of_Absent_ViewText.TabIndex = 4;
            // 
            // Examination_Textbox
            // 
            this.Examination_Textbox.Location = new System.Drawing.Point(157, 308);
            this.Examination_Textbox.Name = "Examination_Textbox";
            this.Examination_Textbox.Size = new System.Drawing.Size(212, 22);
            this.Examination_Textbox.TabIndex = 7;
            // 
            // Eamination_Label
            // 
            this.Eamination_Label.AutoSize = true;
            this.Eamination_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Eamination_Label.Location = new System.Drawing.Point(35, 313);
            this.Eamination_Label.Name = "Eamination_Label";
            this.Eamination_Label.Size = new System.Drawing.Size(84, 17);
            this.Eamination_Label.TabIndex = 6;
            this.Eamination_Label.Text = "Examination";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(71, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Candidates";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(258, 388);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Absent";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(169, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Present";
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(157, 237);
            this.Search_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(91, 37);
            this.Search_btn.TabIndex = 5;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Filepath_textbox
            // 
            this.Filepath_textbox.Enabled = false;
            this.Filepath_textbox.Location = new System.Drawing.Point(91, 486);
            this.Filepath_textbox.Name = "Filepath_textbox";
            this.Filepath_textbox.Size = new System.Drawing.Size(212, 22);
            this.Filepath_textbox.TabIndex = 7;
            // 
            // Filepath_button
            // 
            this.Filepath_button.Location = new System.Drawing.Point(116, 513);
            this.Filepath_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Filepath_button.Name = "Filepath_button";
            this.Filepath_button.Size = new System.Drawing.Size(163, 31);
            this.Filepath_button.TabIndex = 5;
            this.Filepath_button.Text = "Save Path";
            this.Filepath_button.UseVisualStyleBackColor = true;
            this.Filepath_button.Click += new System.EventHandler(this.Filepath_button_Click);
            // 
            // Absent_Statement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(999, 654);
            this.Controls.Add(this.Filepath_textbox);
            this.Controls.Add(this.Examination_Textbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Eamination_Label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filepath_button);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Prepare_Statement_btn);
            this.Controls.Add(this.No_of_Absent_ViewText);
            this.Controls.Add(this.No_of_Present_ViewText);
            this.Controls.Add(this.No_of_candidates_ViewText);
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.SubjectName_Combobox);
            this.Controls.Add(this.ExamCode_combobox);
            this.Controls.Add(this.Branch_combobox);
            this.Controls.Add(this.Session_combobox);
            this.Controls.Add(this.Date_combobox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Absent_Statement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Absent_Statement";
            this.Load += new System.EventHandler(this.Absent_Statement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Date_combobox;
        private System.Windows.Forms.ComboBox Session_combobox;
        private System.Windows.Forms.ComboBox Branch_combobox;
        private System.Windows.Forms.ComboBox ExamCode_combobox;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.TextBox No_of_candidates_ViewText;
        private System.Windows.Forms.Button Prepare_Statement_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SubjectName_Combobox;
        private System.Windows.Forms.TextBox No_of_Present_ViewText;
        private System.Windows.Forms.TextBox No_of_Absent_ViewText;
        private System.Windows.Forms.TextBox Examination_Textbox;
        private System.Windows.Forms.Label Eamination_Label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox Filepath_textbox;
        private System.Windows.Forms.Button Filepath_button;
    }
}