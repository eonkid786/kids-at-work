﻿namespace Exam_Cell
{
    partial class Student_Management
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Student_mngmnt_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Student_dgv = new System.Windows.Forms.DataGridView();
            this.ClassDgvView_checkbox = new System.Windows.Forms.CheckBox();
            this.UpgradeSemester_groupbox = new System.Windows.Forms.GroupBox();
            this.UpgradeSem_btn = new System.Windows.Forms.Button();
            this.DegradeClass_btn = new System.Windows.Forms.Button();
            this.ImportGroupbox = new System.Windows.Forms.GroupBox();
            this.Sheet_combobox = new System.Windows.Forms.ComboBox();
            this.Filepath_textbox = new System.Windows.Forms.TextBox();
            this.SelectExcel_btn = new System.Windows.Forms.Button();
            this.AddFromExcel_Btn = new System.Windows.Forms.Button();
            this.AssignClass_groupbox = new System.Windows.Forms.GroupBox();
            this.AssignClass_combobox = new System.Windows.Forms.ComboBox();
            this.AssignClassYOA_combobox = new System.Windows.Forms.ComboBox();
            this.AssignClassBranch_combobox = new System.Windows.Forms.ComboBox();
            this.Class_label = new System.Windows.Forms.Label();
            this.AssignClass_btn = new System.Windows.Forms.Button();
            this.Clear_btn_2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.add_stdnt_groupbox = new System.Windows.Forms.GroupBox();
            this.Branch_combobox = new System.Windows.Forms.ComboBox();
            this.Regno_textbox = new System.Windows.Forms.TextBox();
            this.YOA_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_textbox = new System.Windows.Forms.TextBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.AddStudent_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Student_mngmnt_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Student_dgv)).BeginInit();
            this.UpgradeSemester_groupbox.SuspendLayout();
            this.ImportGroupbox.SuspendLayout();
            this.AssignClass_groupbox.SuspendLayout();
            this.add_stdnt_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Student_mngmnt_panel
            // 
            this.Student_mngmnt_panel.Controls.Add(this.panel1);
            this.Student_mngmnt_panel.Controls.Add(this.ClassDgvView_checkbox);
            this.Student_mngmnt_panel.Controls.Add(this.UpgradeSemester_groupbox);
            this.Student_mngmnt_panel.Controls.Add(this.ImportGroupbox);
            this.Student_mngmnt_panel.Controls.Add(this.AssignClass_groupbox);
            this.Student_mngmnt_panel.Controls.Add(this.add_stdnt_groupbox);
            this.Student_mngmnt_panel.Controls.Add(this.Delete_btn);
            this.Student_mngmnt_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Student_mngmnt_panel.Location = new System.Drawing.Point(0, 0);
            this.Student_mngmnt_panel.Name = "Student_mngmnt_panel";
            this.Student_mngmnt_panel.Size = new System.Drawing.Size(1652, 718);
            this.Student_mngmnt_panel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Student_dgv);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(377, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 402);
            this.panel1.TabIndex = 10;
            // 
            // Student_dgv
            // 
            this.Student_dgv.AllowUserToAddRows = false;
            this.Student_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.Student_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Student_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Student_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Student_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Student_dgv.Location = new System.Drawing.Point(0, 0);
            this.Student_dgv.Name = "Student_dgv";
            this.Student_dgv.RowTemplate.Height = 24;
            this.Student_dgv.Size = new System.Drawing.Size(1129, 402);
            this.Student_dgv.TabIndex = 1;
            // 
            // ClassDgvView_checkbox
            // 
            this.ClassDgvView_checkbox.AutoSize = true;
            this.ClassDgvView_checkbox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassDgvView_checkbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClassDgvView_checkbox.Location = new System.Drawing.Point(226, 539);
            this.ClassDgvView_checkbox.Name = "ClassDgvView_checkbox";
            this.ClassDgvView_checkbox.Size = new System.Drawing.Size(131, 32);
            this.ClassDgvView_checkbox.TabIndex = 6;
            this.ClassDgvView_checkbox.Text = "Class View";
            this.ClassDgvView_checkbox.UseVisualStyleBackColor = true;
            this.ClassDgvView_checkbox.CheckedChanged += new System.EventHandler(this.ClassDgvView_checkbox_CheckedChanged);
            // 
            // UpgradeSemester_groupbox
            // 
            this.UpgradeSemester_groupbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UpgradeSemester_groupbox.Controls.Add(this.UpgradeSem_btn);
            this.UpgradeSemester_groupbox.Controls.Add(this.DegradeClass_btn);
            this.UpgradeSemester_groupbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpgradeSemester_groupbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.UpgradeSemester_groupbox.Location = new System.Drawing.Point(1148, 3);
            this.UpgradeSemester_groupbox.Name = "UpgradeSemester_groupbox";
            this.UpgradeSemester_groupbox.Size = new System.Drawing.Size(268, 218);
            this.UpgradeSemester_groupbox.TabIndex = 9;
            this.UpgradeSemester_groupbox.TabStop = false;
            this.UpgradeSemester_groupbox.Text = "Upgrade Semester";
            // 
            // UpgradeSem_btn
            // 
            this.UpgradeSem_btn.BackColor = System.Drawing.Color.Honeydew;
            this.UpgradeSem_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpgradeSem_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpgradeSem_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpgradeSem_btn.Location = new System.Drawing.Point(25, 59);
            this.UpgradeSem_btn.Name = "UpgradeSem_btn";
            this.UpgradeSem_btn.Size = new System.Drawing.Size(221, 43);
            this.UpgradeSem_btn.TabIndex = 0;
            this.UpgradeSem_btn.Text = "Upgrade Class Semester";
            this.UpgradeSem_btn.UseVisualStyleBackColor = false;
            this.UpgradeSem_btn.Click += new System.EventHandler(this.UpgradeSem_btn_Click);
            // 
            // DegradeClass_btn
            // 
            this.DegradeClass_btn.BackColor = System.Drawing.Color.Beige;
            this.DegradeClass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DegradeClass_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DegradeClass_btn.ForeColor = System.Drawing.Color.Red;
            this.DegradeClass_btn.Location = new System.Drawing.Point(89, 124);
            this.DegradeClass_btn.Name = "DegradeClass_btn";
            this.DegradeClass_btn.Size = new System.Drawing.Size(93, 34);
            this.DegradeClass_btn.TabIndex = 0;
            this.DegradeClass_btn.Text = "Degrade";
            this.DegradeClass_btn.UseVisualStyleBackColor = false;
            this.DegradeClass_btn.Click += new System.EventHandler(this.DegradeClass_btn_Click);
            // 
            // ImportGroupbox
            // 
            this.ImportGroupbox.Controls.Add(this.Sheet_combobox);
            this.ImportGroupbox.Controls.Add(this.Filepath_textbox);
            this.ImportGroupbox.Controls.Add(this.SelectExcel_btn);
            this.ImportGroupbox.Controls.Add(this.AddFromExcel_Btn);
            this.ImportGroupbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ImportGroupbox.Location = new System.Drawing.Point(24, 241);
            this.ImportGroupbox.Name = "ImportGroupbox";
            this.ImportGroupbox.Size = new System.Drawing.Size(326, 252);
            this.ImportGroupbox.TabIndex = 8;
            this.ImportGroupbox.TabStop = false;
            this.ImportGroupbox.Text = "Import Students";
            // 
            // Sheet_combobox
            // 
            this.Sheet_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sheet_combobox.FormattingEnabled = true;
            this.Sheet_combobox.Location = new System.Drawing.Point(20, 145);
            this.Sheet_combobox.Name = "Sheet_combobox";
            this.Sheet_combobox.Size = new System.Drawing.Size(285, 32);
            this.Sheet_combobox.TabIndex = 5;
            this.Sheet_combobox.SelectedIndexChanged += new System.EventHandler(this.Sheet_combobox_SelectedIndexChanged_1);
            // 
            // Filepath_textbox
            // 
            this.Filepath_textbox.Location = new System.Drawing.Point(20, 49);
            this.Filepath_textbox.Name = "Filepath_textbox";
            this.Filepath_textbox.ReadOnly = true;
            this.Filepath_textbox.Size = new System.Drawing.Size(285, 33);
            this.Filepath_textbox.TabIndex = 0;
            // 
            // SelectExcel_btn
            // 
            this.SelectExcel_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectExcel_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SelectExcel_btn.Location = new System.Drawing.Point(86, 88);
            this.SelectExcel_btn.Name = "SelectExcel_btn";
            this.SelectExcel_btn.Size = new System.Drawing.Size(152, 38);
            this.SelectExcel_btn.TabIndex = 0;
            this.SelectExcel_btn.Text = "Select Excel";
            this.SelectExcel_btn.UseVisualStyleBackColor = true;
            this.SelectExcel_btn.Click += new System.EventHandler(this.SelectExcel_btn_Click);
            // 
            // AddFromExcel_Btn
            // 
            this.AddFromExcel_Btn.Enabled = false;
            this.AddFromExcel_Btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFromExcel_Btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddFromExcel_Btn.Location = new System.Drawing.Point(77, 183);
            this.AddFromExcel_Btn.Name = "AddFromExcel_Btn";
            this.AddFromExcel_Btn.Size = new System.Drawing.Size(171, 38);
            this.AddFromExcel_Btn.TabIndex = 0;
            this.AddFromExcel_Btn.Text = "Add From Excel";
            this.AddFromExcel_Btn.UseVisualStyleBackColor = true;
            this.AddFromExcel_Btn.Click += new System.EventHandler(this.AddFromExcel_Btn_Click);
            // 
            // AssignClass_groupbox
            // 
            this.AssignClass_groupbox.Controls.Add(this.AssignClass_combobox);
            this.AssignClass_groupbox.Controls.Add(this.AssignClassYOA_combobox);
            this.AssignClass_groupbox.Controls.Add(this.AssignClassBranch_combobox);
            this.AssignClass_groupbox.Controls.Add(this.Class_label);
            this.AssignClass_groupbox.Controls.Add(this.AssignClass_btn);
            this.AssignClass_groupbox.Controls.Add(this.Clear_btn_2);
            this.AssignClass_groupbox.Controls.Add(this.label12);
            this.AssignClass_groupbox.Controls.Add(this.label13);
            this.AssignClass_groupbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignClass_groupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AssignClass_groupbox.Location = new System.Drawing.Point(627, 3);
            this.AssignClass_groupbox.Name = "AssignClass_groupbox";
            this.AssignClass_groupbox.Size = new System.Drawing.Size(500, 218);
            this.AssignClass_groupbox.TabIndex = 7;
            this.AssignClass_groupbox.TabStop = false;
            this.AssignClass_groupbox.Text = "Assign Class";
            // 
            // AssignClass_combobox
            // 
            this.AssignClass_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssignClass_combobox.FormattingEnabled = true;
            this.AssignClass_combobox.Location = new System.Drawing.Point(85, 104);
            this.AssignClass_combobox.Name = "AssignClass_combobox";
            this.AssignClass_combobox.Size = new System.Drawing.Size(389, 32);
            this.AssignClass_combobox.TabIndex = 5;
            this.AssignClass_combobox.SelectedIndexChanged += new System.EventHandler(this.AssignClass_combobox_SelectedIndexChanged);
            // 
            // AssignClassYOA_combobox
            // 
            this.AssignClassYOA_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssignClassYOA_combobox.FormattingEnabled = true;
            this.AssignClassYOA_combobox.Location = new System.Drawing.Point(85, 68);
            this.AssignClassYOA_combobox.Name = "AssignClassYOA_combobox";
            this.AssignClassYOA_combobox.Size = new System.Drawing.Size(389, 32);
            this.AssignClassYOA_combobox.TabIndex = 5;
            this.AssignClassYOA_combobox.SelectedIndexChanged += new System.EventHandler(this.AssignClassYOA_combobox_SelectedIndexChanged);
            // 
            // AssignClassBranch_combobox
            // 
            this.AssignClassBranch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssignClassBranch_combobox.FormattingEnabled = true;
            this.AssignClassBranch_combobox.Location = new System.Drawing.Point(85, 32);
            this.AssignClassBranch_combobox.Name = "AssignClassBranch_combobox";
            this.AssignClassBranch_combobox.Size = new System.Drawing.Size(389, 32);
            this.AssignClassBranch_combobox.TabIndex = 5;
            this.AssignClassBranch_combobox.SelectedIndexChanged += new System.EventHandler(this.AssignClassBranch_combobox_SelectedIndexChanged);
            // 
            // Class_label
            // 
            this.Class_label.AutoSize = true;
            this.Class_label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Class_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Class_label.Location = new System.Drawing.Point(17, 104);
            this.Class_label.Name = "Class_label";
            this.Class_label.Size = new System.Drawing.Size(48, 23);
            this.Class_label.TabIndex = 3;
            this.Class_label.Text = "Class";
            // 
            // AssignClass_btn
            // 
            this.AssignClass_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignClass_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AssignClass_btn.Location = new System.Drawing.Point(361, 146);
            this.AssignClass_btn.Name = "AssignClass_btn";
            this.AssignClass_btn.Size = new System.Drawing.Size(113, 36);
            this.AssignClass_btn.TabIndex = 0;
            this.AssignClass_btn.Text = "Assign Class";
            this.AssignClass_btn.UseVisualStyleBackColor = true;
            this.AssignClass_btn.Click += new System.EventHandler(this.AssignClass_btn_Click);
            // 
            // Clear_btn_2
            // 
            this.Clear_btn_2.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn_2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Clear_btn_2.Location = new System.Drawing.Point(85, 146);
            this.Clear_btn_2.Name = "Clear_btn_2";
            this.Clear_btn_2.Size = new System.Drawing.Size(103, 36);
            this.Clear_btn_2.TabIndex = 0;
            this.Clear_btn_2.Text = "Clear";
            this.Clear_btn_2.UseVisualStyleBackColor = true;
            this.Clear_btn_2.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(12, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 23);
            this.label12.TabIndex = 3;
            this.label12.Text = "Branch";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(17, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 23);
            this.label13.TabIndex = 3;
            this.label13.Text = "Y.O.A";
            // 
            // add_stdnt_groupbox
            // 
            this.add_stdnt_groupbox.Controls.Add(this.Branch_combobox);
            this.add_stdnt_groupbox.Controls.Add(this.Regno_textbox);
            this.add_stdnt_groupbox.Controls.Add(this.YOA_textbox);
            this.add_stdnt_groupbox.Controls.Add(this.label3);
            this.add_stdnt_groupbox.Controls.Add(this.Name_textbox);
            this.add_stdnt_groupbox.Controls.Add(this.Search_btn);
            this.add_stdnt_groupbox.Controls.Add(this.Clear_btn);
            this.add_stdnt_groupbox.Controls.Add(this.AddStudent_btn);
            this.add_stdnt_groupbox.Controls.Add(this.label1);
            this.add_stdnt_groupbox.Controls.Add(this.label2);
            this.add_stdnt_groupbox.Controls.Add(this.label4);
            this.add_stdnt_groupbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_stdnt_groupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_stdnt_groupbox.Location = new System.Drawing.Point(3, 3);
            this.add_stdnt_groupbox.Name = "add_stdnt_groupbox";
            this.add_stdnt_groupbox.Size = new System.Drawing.Size(603, 218);
            this.add_stdnt_groupbox.TabIndex = 6;
            this.add_stdnt_groupbox.TabStop = false;
            this.add_stdnt_groupbox.Text = "Add/Update Student";
            // 
            // Branch_combobox
            // 
            this.Branch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Branch_combobox.FormattingEnabled = true;
            this.Branch_combobox.Location = new System.Drawing.Point(86, 158);
            this.Branch_combobox.Name = "Branch_combobox";
            this.Branch_combobox.Size = new System.Drawing.Size(497, 32);
            this.Branch_combobox.TabIndex = 5;
            // 
            // Regno_textbox
            // 
            this.Regno_textbox.Location = new System.Drawing.Point(86, 35);
            this.Regno_textbox.Name = "Regno_textbox";
            this.Regno_textbox.Size = new System.Drawing.Size(369, 33);
            this.Regno_textbox.TabIndex = 2;
            // 
            // YOA_textbox
            // 
            this.YOA_textbox.Location = new System.Drawing.Point(86, 117);
            this.YOA_textbox.Name = "YOA_textbox";
            this.YOA_textbox.Size = new System.Drawing.Size(369, 33);
            this.YOA_textbox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // Name_textbox
            // 
            this.Name_textbox.Location = new System.Drawing.Point(86, 76);
            this.Name_textbox.Name = "Name_textbox";
            this.Name_textbox.Size = new System.Drawing.Size(369, 33);
            this.Name_textbox.TabIndex = 2;
            // 
            // Search_btn
            // 
            this.Search_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Search_btn.Location = new System.Drawing.Point(469, 32);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(114, 33);
            this.Search_btn.TabIndex = 0;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Clear_btn.Location = new System.Drawing.Point(469, 72);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(114, 33);
            this.Clear_btn.TabIndex = 0;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // AddStudent_btn
            // 
            this.AddStudent_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStudent_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddStudent_btn.Location = new System.Drawing.Point(469, 112);
            this.AddStudent_btn.Name = "AddStudent_btn";
            this.AddStudent_btn.Size = new System.Drawing.Size(114, 33);
            this.AddStudent_btn.TabIndex = 0;
            this.AddStudent_btn.Text = "Add";
            this.AddStudent_btn.UseVisualStyleBackColor = true;
            this.AddStudent_btn.Click += new System.EventHandler(this.AddStudent_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Y.O.A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reg No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(13, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Branch";
            // 
            // Delete_btn
            // 
            this.Delete_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.ForeColor = System.Drawing.Color.Red;
            this.Delete_btn.Location = new System.Drawing.Point(238, 582);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(112, 36);
            this.Delete_btn.TabIndex = 0;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Student_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1652, 718);
            this.Controls.Add(this.Student_mngmnt_panel);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Student_Management";
            this.Text = "Student_Management";
            this.Load += new System.EventHandler(this.Student_Management_Load);
            this.Student_mngmnt_panel.ResumeLayout(false);
            this.Student_mngmnt_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Student_dgv)).EndInit();
            this.UpgradeSemester_groupbox.ResumeLayout(false);
            this.ImportGroupbox.ResumeLayout(false);
            this.ImportGroupbox.PerformLayout();
            this.AssignClass_groupbox.ResumeLayout(false);
            this.AssignClass_groupbox.PerformLayout();
            this.add_stdnt_groupbox.ResumeLayout(false);
            this.add_stdnt_groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Student_mngmnt_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Student_dgv;
        private System.Windows.Forms.CheckBox ClassDgvView_checkbox;
        private System.Windows.Forms.GroupBox UpgradeSemester_groupbox;
        private System.Windows.Forms.Button UpgradeSem_btn;
        private System.Windows.Forms.Button DegradeClass_btn;
        private System.Windows.Forms.GroupBox ImportGroupbox;
        private System.Windows.Forms.ComboBox Sheet_combobox;
        private System.Windows.Forms.TextBox Filepath_textbox;
        private System.Windows.Forms.Button SelectExcel_btn;
        private System.Windows.Forms.Button AddFromExcel_Btn;
        private System.Windows.Forms.GroupBox AssignClass_groupbox;
        private System.Windows.Forms.ComboBox AssignClass_combobox;
        private System.Windows.Forms.ComboBox AssignClassYOA_combobox;
        private System.Windows.Forms.ComboBox AssignClassBranch_combobox;
        private System.Windows.Forms.Label Class_label;
        private System.Windows.Forms.Button AssignClass_btn;
        private System.Windows.Forms.Button Clear_btn_2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox add_stdnt_groupbox;
        private System.Windows.Forms.ComboBox Branch_combobox;
        private System.Windows.Forms.TextBox Regno_textbox;
        private System.Windows.Forms.TextBox YOA_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Name_textbox;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.Button AddStudent_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Delete_btn;
    }
}