﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Exam_Cell
{
    public partial class Allotment : Form
    {
        Connection con = new Connection();
        
        public Allotment()
        {
            InitializeComponent();
        }

        private void SingleAllotment_button_Click(object sender, EventArgs e)
        {
            Allot_University();
        }
        void Allot_University()
        {                        
            //get registered students details
            SqlCommand command2 = new SqlCommand("select * from Registered_candidates order by Reg_no", con.ActiveCon());
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);
            if (table_students.Rows.Count == 0)
            {
                MessageBox.Show("No Candidates Registered to Allot, Register the candidates First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            //get rooms details
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority", con.ActiveCon());
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            if (table_rooms.Rows.Count == 0)
            {
                MessageBox.Show("No Rooms Assigned to Allot, Create Rooms First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            //get distinct dates
            SqlCommand commanddate = new SqlCommand("select distinct Date from Timetable order by Date", con.ActiveCon());
            SqlDataAdapter adapterdate = new SqlDataAdapter(commanddate);
            DataTable table_distinctdate = new DataTable();
            adapterdate.Fill(table_distinctdate);
            if(table_distinctdate.Rows.Count==0)
            {
                MessageBox.Show("No Timetable Assigned to Allot, Create Timetable First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                
            }

            //////////// TRY WHETHER THIS WILL WORK ////////////

            //ALLOTMENT START
            foreach (DataRow rowdate in table_distinctdate.Rows)
            {
                string session = "Forenoon";
                for (int z = 0; z < 2; z++)
                {
                    //Get Timetable details
                    SqlCommand command = new SqlCommand("select Date,Session,Course,Exam_Code from Timetable where Date=@Date and Session=@Session order by Date,Session,Course", con.ActiveCon());
                    command.Parameters.AddWithValue("@Date", rowdate["Date"].ToString());
                    command.Parameters.AddWithValue("@Session", session);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table_timetable = new DataTable();
                    adapter.Fill(table_timetable);

                    if (table_timetable.Rows.Count != 0)
                    {
                        List<string> reg_students = new List<string>();
                        List<string> name_students = new List<string>();
                        List<string> branch_students = new List<string>();
                        List<string> date_students = new List<string>();
                        List<string> course_students = new List<string>();
                        List<string> Exam_Code_students = new List<string>();

                        foreach (DataRow row in table_timetable.Rows)
                        {
                            string date = row["Date"].ToString();
                            string course = row["Course"].ToString();
                            string examcode = row["Exam_Code"].ToString();
                            
                            foreach (DataRow row2 in table_students.Rows)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    name_students.Add(row2["Name"].ToString());
                                    reg_students.Add(row2["Reg_no"].ToString());
                                    branch_students.Add(row2["Branch"].ToString());
                                    date_students.Add(row["Date"].ToString());
                                    course_students.Add(row["Course"].ToString());
                                    Exam_Code_students.Add(row["Exam_Code"].ToString());
                                }
                            }
                        }
                        int count = 0;
                        foreach (DataRow roomrow in table_rooms.Rows)
                        {
                            int series = Int32.Parse(roomrow["A_Series"].ToString());
                            int flag=0;
                            for(int i=0;i<series;i++)
                            {
                                SqlCommand command4 = new SqlCommand("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Branch,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Branch,@Exam_Code,@Course)", con.ActiveCon());
                                command4.Parameters.AddWithValue("@Date", date_students[count]);
                                command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                                command4.Parameters.AddWithValue("@Seat", "A" + (i + 1));
                                command4.Parameters.AddWithValue("@Session", session);
                                command4.Parameters.AddWithValue("@Reg_no", reg_students[count]);
                                command4.Parameters.AddWithValue("@Name", name_students[count]);
                                command4.Parameters.AddWithValue("@Branch", branch_students[count]);
                                command4.Parameters.AddWithValue("@Exam_Code", Exam_Code_students[count]);
                                command4.Parameters.AddWithValue("@Course", course_students[count]);
                                command4.ExecuteNonQuery();
                                
                                if (reg_students.Last() == reg_students[count])
                                {
                                    flag = 1;
                                    break;
                                }
                                count++;
                            }
                            if (flag == 1)
                                break;
                        }
                    }
                    session = "Afternoon";
                }
            }
            //////////// TRY WHETHER THIS WILL WORK //////////// 


            //foreach (DataRow rowdate in table_distinctdate.Rows)
            //{
            //    string session = "Forenoon";
            //    for (int z = 0; z < 2; z++)
            //    {
            //        //Get Timetable details
            //        SqlCommand command = new SqlCommand("select Date,Session,Course,Exam_Code from Timetable where Date=@Date and Session=@Session order by Date,Session", con.ActiveCon());
            //        command.Parameters.AddWithValue("@Date", rowdate["Date"].ToString());
            //        command.Parameters.AddWithValue("@Session", session);
            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataTable table_timetable = new DataTable();
            //        adapter.Fill(table_timetable);

            //        if(table_timetable.Rows.Count !=0)
            //        {
            //            // initialize and get room values outside loop
            //            List<string> roomno = new List<string>();
            //            List<string> Aseries = new List<string>();

            //            foreach (DataRow roomrow in table_rooms.Rows)
            //            {
            //                roomno.Add(roomrow["Room_No"].ToString());
            //                Aseries.Add(roomrow["A_Series"].ToString());
            //            }
            //            int sr = 0, j = 0;
            //            int series = Int32.Parse(Aseries[sr].ToString());
            //            string room = roomno[sr];

            //            foreach (DataRow row in table_timetable.Rows)
            //            {
            //                string date = row["Date"].ToString();
            //                string course = row["Course"].ToString();
            //                string examcode = row["Exam_Code"].ToString();

            //                List<string> reg_students = new List<string>();
            //                List<string> name_students = new List<string>();
            //                List<string> branch_students = new List<string>();
            //                foreach (DataRow row2 in table_students.Rows)
            //                {
            //                    string student_course = row2["Course"].ToString();
            //                    if (student_course.ToUpper().Contains(course.ToUpper()))
            //                    {
            //                        name_students.Add(row2["Name"].ToString());
            //                        reg_students.Add(row2["Reg_no"].ToString());
            //                        branch_students.Add(row2["Branch"].ToString());
            //                    }
            //                }
            //                int count = 0;
            //                for (int i = 0; i < series; i++)
            //                {
            //                    SqlCommand command4 = new SqlCommand("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Branch,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Branch,@Exam_Code,@Course)", con.ActiveCon());
            //                    command4.Parameters.AddWithValue("@Date", date);
            //                    command4.Parameters.AddWithValue("@Room_No", room);
            //                    command4.Parameters.AddWithValue("@Seat", "A" + (j + 1));
            //                    command4.Parameters.AddWithValue("@Session", session);
            //                    command4.Parameters.AddWithValue("@Reg_no", reg_students[count]);
            //                    command4.Parameters.AddWithValue("@Name", name_students[count]);
            //                    command4.Parameters.AddWithValue("@Branch", branch_students[count]);
            //                    command4.Parameters.AddWithValue("@Exam_Code", examcode);
            //                    command4.Parameters.AddWithValue("@Course", course);
            //                    command4.ExecuteNonQuery();
            //                    j += 1;
            //                    if (j == series)
            //                    {
            //                        sr += 1;
            //                        series = Int32.Parse(Aseries[sr].ToString());
            //                        room = roomno[sr];
            //                        i = -1;
            //                        j = 0;
            //                    }
            //                    if (reg_students.Last() == reg_students[count])
            //                    {
            //                        break;
            //                    }
            //                    count++;
            //                }
            //            }
            //        }                                       
            //        session = "Afternoon";
            //    }              
            //}
            MessageBox.Show("University Seating Allot Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Allot_Series()
        {            
            //get registered students details
            SqlCommand command2 = new SqlCommand("select * from Series_candidates order by Course, Class, Name", con.ActiveCon());
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);
            if (table_students.Rows.Count == 0)
            {
                MessageBox.Show("No Candidates Registered to Allot, Register the candidates First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //get rooms details
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority", con.ActiveCon());
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            Alloted_dgv.DataSource = table_rooms;
            if (table_rooms.Rows.Count == 0)
            {
                MessageBox.Show("No Rooms Assigned to Allot, Create Rooms First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //get distinct dates
            SqlCommand commanddate = new SqlCommand("select distinct Date from Timetable order by Date", con.ActiveCon());
            SqlDataAdapter adapterdate = new SqlDataAdapter(commanddate);
            DataTable table_distinctdate = new DataTable();
            adapterdate.Fill(table_distinctdate);
            if (table_distinctdate.Rows.Count == 0)
            {
                MessageBox.Show("No Timetable Assigned to Allot, Create Timetable First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int totalstudents = table_students.Rows.Count;
            //ALLOTMENT START
            foreach (DataRow rowdate in table_distinctdate.Rows)
            {
                string session = "Forenoon";
                for (int z = 0; z < 2; z++)
                {
                    //Get Timtable details
                    SqlCommand command = new SqlCommand("select Date,Session,Course,Exam_Code from Timetable where Date=@Date and Session=@Session order by Date,Session,Course", con.ActiveCon());
                    command.Parameters.AddWithValue("@Date", rowdate["Date"].ToString());
                    command.Parameters.AddWithValue("@Session", session);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table_timetable = new DataTable();
                    adapter.Fill(table_timetable);

                    if (table_timetable.Rows.Count != 0)
                    {
                        List<string> reg_studentsA = new List<string>();
                        List<string> name_studentsA = new List<string>();
                        List<string> course_studentsA = new List<string>();
                        List<string> class_studentsA = new List<string>();
                        List<string> date_studentsA = new List<string>();
                        List<string> examcode_studentsA = new List<string>();
                        List<string> reg_studentsB = new List<string>();
                        List<string> name_studentsB = new List<string>();
                        List<string> course_studentsB = new List<string>();
                        List<string> class_studentsB = new List<string>();
                        List<string> date_studentsB = new List<string>();
                        List<string> examcode_studentsB = new List<string>();
                        DataTable SelectedStudents = new DataTable();
                        SelectedStudents = table_students.Clone();

                        foreach (DataRow row in table_timetable.Rows)
                        {
                            string date = row["Date"].ToString();
                            string course = row["Course"].ToString();
                            string examcode = row["Exam_Code"].ToString();

                            foreach (DataRow row2 in table_students.Rows)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    SelectedStudents.ImportRow(row2);
                                }
                            }
                        }
                        int no_of_students = SelectedStudents.Rows.Count;
                        var top50 = SelectedStudents.AsEnumerable()
                                .Take(no_of_students / 2);
                        var bottom50 = SelectedStudents.AsEnumerable()
                                .Skip(no_of_students / 2);

                        foreach(DataRow row in table_timetable.Rows)
                        {
                            string date = row["Date"].ToString();
                            string course = row["Course"].ToString();
                            string examcode = row["Exam_Code"].ToString();

                            foreach (DataRow row2 in top50)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    name_studentsA.Add(row2["Name"].ToString());
                                    date_studentsA.Add(row["Date"].ToString());
                                    examcode_studentsA.Add(row["Exam_Code"].ToString());
                                    reg_studentsA.Add(row2["Reg_no"].ToString());
                                    course_studentsA.Add(row2["Course"].ToString());
                                    class_studentsA.Add(row2["Class"].ToString());
                                }
                            }
                            foreach (DataRow row2 in bottom50)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    name_studentsB.Add(row2["Name"].ToString());
                                    date_studentsB.Add(row["Date"].ToString());
                                    examcode_studentsB.Add(row["Exam_Code"].ToString());
                                    reg_studentsB.Add(row2["Reg_no"].ToString());
                                    course_studentsB.Add(row2["Course"].ToString());
                                    class_studentsB.Add(row2["Class"].ToString());
                                }                                
                            }
                        }
                        int count = 0;
                        foreach (DataRow roomrow in table_rooms.Rows)
                        {
                            int series = Int32.Parse(roomrow["A_Series"].ToString());
                            int flag = 0 ;
                            for(int i=0;i<series;i++)
                            {
                                SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)", con.ActiveCon());
                                command4.Parameters.AddWithValue("@Date", date_studentsA[count]);
                                command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                                command4.Parameters.AddWithValue("@Seat", "A" + (i + 1));
                                command4.Parameters.AddWithValue("@Session", session);
                                command4.Parameters.AddWithValue("@Reg_no", reg_studentsA[count]);
                                command4.Parameters.AddWithValue("@Name", name_studentsA[count]);
                                command4.Parameters.AddWithValue("@Class", class_studentsA[count]);
                                command4.Parameters.AddWithValue("@Exam_Code", examcode_studentsA[count]);
                                command4.Parameters.AddWithValue("@Course", course_studentsA[count]);
                                command4.ExecuteNonQuery();

                                if (reg_studentsA.Last() == reg_studentsA[count])
                                {
                                    flag = 1;
                                    break;
                                }
                                count++;
                            }
                            if (flag == 1)
                                break;
                        }
                        count = 0;
                        foreach (DataRow roomrow in table_rooms.Rows)
                        {
                            int series = Int32.Parse(roomrow["B_Series"].ToString());
                            int flag = 0;
                            for (int i = 0; i < series; i++)
                            {
                                SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)", con.ActiveCon());
                                command4.Parameters.AddWithValue("@Date", date_studentsB[count]);
                                command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                                command4.Parameters.AddWithValue("@Seat", "B" + (i + 1));
                                command4.Parameters.AddWithValue("@Session", session);
                                command4.Parameters.AddWithValue("@Reg_no", reg_studentsB[count]);
                                command4.Parameters.AddWithValue("@Name", name_studentsB[count]);
                                command4.Parameters.AddWithValue("@Class", class_studentsB[count]);
                                command4.Parameters.AddWithValue("@Exam_Code", examcode_studentsB[count]);
                                command4.Parameters.AddWithValue("@Course", course_studentsB[count]);
                                command4.ExecuteNonQuery();

                                if (reg_studentsB.Last() == reg_studentsB[count])
                                {
                                    flag = 1;
                                    break;
                                }
                                count++;
                            }
                            if (flag == 1)
                                break;
                        }
                    }
                    session = "Afternoon";
                }
            }
            MessageBox.Show("Series Seating Allot Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MultiAllotment_button_Click(object sender, EventArgs e)
        {
            Allot_Series();
        }

        private void Shift_button_Click(object sender, EventArgs e)
        {
            if (FromSeries_combobox.SelectedIndex != 0 && ToSeries_combobox.SelectedIndex != 0 && FromRoom_textbox.Text != "" && FromStart_textbox.Text != "" && FromEnd_textbox.Text != "" && ToRoom_textbox.Text != "" && ToStart_textbox.Text != "")
            {
                DialogResult result = MessageBox.Show("Are You Sure To SHIFT the Selected Students ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string fromroom = FromRoom_textbox.Text, fromseries = FromSeries_combobox.Text, fromstart = FromStart_textbox.Text, fromend = FromEnd_textbox.Text;
                        string toroom = ToRoom_textbox.Text, toseries = ToSeries_combobox.Text, tostart = ToStart_textbox.Text;
                        int fromstartint = Int32.Parse(fromstart);
                        int fromendint = Int32.Parse(fromend);
                        int tostartint = Int32.Parse(tostart);
                        if (Unv_radio.Checked)
                        {
                            SqlCommand comm = new SqlCommand("Select Room_No,Seat,Reg_no from University_Alloted where Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SqlDataAdapter adapter = new SqlDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + tostartint;
                                        tostartint++;
                                        break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SqlCommand comm2 = new SqlCommand("update University_Alloted set Room_No=@Room_No,Seat=@Seat where Reg_no=@Reg_no", con.ActiveCon());
                                comm2.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm2.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm2.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm2.ExecuteNonQuery();
                            }
                            MessageBox.Show("Shift Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Series_radio.Checked)
                        {
                            SqlCommand comm = new SqlCommand("Select Room_No,Seat,Reg_no from Series_Alloted where Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SqlDataAdapter adapter = new SqlDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + tostartint;
                                        tostartint++;
                                        break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SqlCommand comm2 = new SqlCommand("update Series_Alloted set Room_No=@Room_No,Seat=@Seat where Reg_no=@Reg_no", con.ActiveCon());
                                comm2.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm2.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm2.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm2.ExecuteNonQuery();
                            }
                            MessageBox.Show("Shift Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Give necessary details", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void RoomPrint_button_Click(object sender, EventArgs e)
        {
            RoomExcel_panel.Enabled = true;
            DisplaySheet_Panel.Enabled = false;
            Signature_panel.Enabled = false;
            RoomExcel_panel.BringToFront();
            Generation_Panel.Enabled = false;
        }

        private void Save_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog(); 
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    Folder_path_text.Text = fdb.SelectedPath;
                }
            }

        private void Excel_generate_btn_Click(object sender, EventArgs e)
        {
            if (Unv_radio.Checked || Series_radio.Checked)
            {
                Excel_Generation_function(0);
            }
            else
                MessageBox.Show("Select Exam Type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RoomPanelClose_btn_Click(object sender, EventArgs e)
        {
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            RoomExcel_panel.Enabled = false;
        }

        private void SignatureSheet_button_Click(object sender, EventArgs e)
        {
            Signature_panel.Enabled = true;
            Signature_panel.BringToFront();
            Generation_Panel.Enabled = false;
            RoomExcel_panel.Enabled = false;
            DisplaySheet_Panel.Enabled = false;
        }

        private void Signature_close_btn_Click(object sender, EventArgs e)
        {
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            Signature_panel.Enabled = false;
        }

        private void Signature_generate_btn_Click(object sender, EventArgs e)
        {
            if (Unv_radio.Checked || Series_radio.Checked)
            {
                Excel_Generation_function(1);
            }
            else
                MessageBox.Show("Select Exam Type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Excel_Generation_function(int f)
        {
            if (Folder_path_text.Text != "")
            {
                int flag = 0;
                string commandtext;
                if (Series_radio.Checked)
                    commandtext = "SELECT Distinct Date from Series_Alloted";
                else
                    commandtext = "SELECT Distinct Date from University_Alloted";
                DataTable dstnctdatatable = new DataTable();
                SqlCommand command = new SqlCommand(commandtext, con.ActiveCon());
                SqlDataAdapter distinctadapter = new SqlDataAdapter(command);
                distinctadapter.Fill(dstnctdatatable);

                if (dstnctdatatable.Rows.Count == 0)
                {
                    MessageBox.Show("Allot Students First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (f == 0)
                    {
                        Generation_Panel.BringToFront();
                        Generation_Panel.Enabled = true;
                        RoomExcel_panel.Enabled = false;
                    }
                    else if (f == 1)
                    {
                        Generation_Panel.BringToFront();
                        Generation_Panel.Enabled = true;
                        Signature_panel.Enabled = false;
                    }
                    flag = 1;
                }
                else
                {
                    foreach (DataRow dr in dstnctdatatable.Rows)
                    {

                        string session = "Forenoon";
                        for (int count = 0; count < 2; count++)
                        {                            
                            DataTable dt = new DataTable();

                            if (Series_radio.Checked)
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SqlCommand cmd = new SqlCommand("SELECT Seat,Reg_no,Name,Exam_code,Room_No from Series_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                adptr.Fill(dt);
                            }
                            else
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SqlCommand cmd = new SqlCommand("SELECT Seat,Reg_no,Name,Exam_code,Room_No from University_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                adptr.Fill(dt);
                            }

                            DataTable dstnctroomdatatable = new DataTable();
                            if(Series_radio.Checked)
                            {
                                SqlCommand commandroom = new SqlCommand("SELECT Distinct Room_No from Series_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                commandroom.Parameters.AddWithValue("@Session", session);
                                SqlDataAdapter distinctroomadapter = new SqlDataAdapter(commandroom);
                                distinctroomadapter.Fill(dstnctroomdatatable);
                            }
                            else
                            {
                                SqlCommand commandroom = new SqlCommand("SELECT Distinct Room_No from University_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                commandroom.Parameters.AddWithValue("@Session", session);
                                SqlDataAdapter distinctroomadapter = new SqlDataAdapter(commandroom);
                                distinctroomadapter.Fill(dstnctroomdatatable);
                            }

                            if (dt.Rows.Count != 0)
                            {
                                using(var package = new ExcelPackage())
                                {
                                    foreach (DataRow dstrw in dstnctroomdatatable.Rows)
                                    {
                                        string checkroom = dstrw["Room_No"].ToString();
                                        //Add a new worksheet to the empty workbook
                                        var worksheet = package.Workbook.Worksheets.Add(checkroom);
                                        //Insert Items to ExcelSheet
                                        worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                                        if (f == 0)
                                        {
                                            worksheet.Cells["A2"].Value = MonthYear_textbox.Text;
                                            worksheet.Cells["A3"].Value = "STUDENTS LIST";
                                        }
                                        else if (f == 1)
                                        {
                                            worksheet.Cells["A2"].Value = Signature_examtype_textbox.Text;
                                            worksheet.Cells["A3"].Value = "ATTENDANCE STATEMENT";
                                        }
                                        worksheet.Cells["A4"].Value = checkroom;
                                        worksheet.Cells["E4"].Value = dr["Date"].ToString() + " " + session;

                                        using (var range = worksheet.Cells["A1:F1"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A2:F2"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 12;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A3:F3"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A4:C4"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                        }
                                        using (var range = worksheet.Cells["A4:F4"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                        }

                                        // column headings
                                        worksheet.Cells[5, 1].Value = "Sl.No";
                                        worksheet.Cells[5, 1].Style.Font.Name = "Arial";
                                        worksheet.Cells[5, 1].Style.Font.Size = 10;
                                        worksheet.Cells[5, 1].Style.Font.Bold = true;
                                        if (f == 1)
                                            worksheet.Cells[5, dt.Columns.Count + 2].Value = "Signature";
                                        for (int i = 0; i < dt.Columns.Count; i++)
                                        {
                                            worksheet.Cells[5, i + 2].Value = dt.Columns[i].ColumnName;
                                            worksheet.Cells[5, i + 2].Style.Font.Name = "Arial";
                                            worksheet.Cells[5, i + 2].Style.Font.Size = 10;
                                            worksheet.Cells[5, i + 2].Style.Font.Bold = true;
                                        }

                                        // rows
                                        int rc = 0;
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            if (dt.Rows[i]["Room_No"].ToString() == checkroom)
                                            {
                                                worksheet.Cells[rc + 6, 1].Value = rc + 1;    //Sl.No Filling
                                                for (int j = 0; j < dt.Columns.Count; j++)
                                                {
                                                    worksheet.Cells[rc + 6, j + 2].Value = dt.Rows[i][j];
                                                }
                                                rc++;
                                            }

                                        }
                                        if (f == 0)
                                        {
                                            using (var range = worksheet.Cells[5, 1, dt.Rows.Count + 4, dt.Columns.Count + 1])
                                            {
                                                range.AutoFitColumns();
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            }
                                        }
                                        else if (f == 1)
                                        {
                                            using (var range = worksheet.Cells[5, 1, dt.Rows.Count + 4, dt.Columns.Count + 2])
                                            {
                                                range.AutoFitColumns();
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            }
                                            worksheet.Cells[dt.Rows.Count + 6, 1].Value = " Write the Register Numbers of the absentees in the box";
                                            using (var range = worksheet.Cells[dt.Rows.Count + 7, 1, dt.Rows.Count + 15, 4])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            }
                                            worksheet.Cells[dt.Rows.Count + 15, 5].Value = " Name and Signature of Invigilator(s)";
                                        }
                                    }
                                    //Save Excel File
                                    /* below might get error since Date has '\' in between ... CHECK if we have to use array 
                                    or something else to remove the '\' .   */

                                    string path = Folder_path_text.Text + @"\Room Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";
                                    if (f == 1)
                                        path = Folder_path_text.Text + @"\Signature Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";
                                    
                                    Stream stream = File.Create(path);
                                    package.SaveAs(stream);
                                    stream.Close();

                                    session = "Afternoon";
                                }
                            }
                        }



                    }
                }
                if (flag == 0)
                    MessageBox.Show("Excel files created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Filepath is not given", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (f == 0)
            {
                Generation_Panel.BringToFront();
                Generation_Panel.Enabled = true;
                RoomExcel_panel.Enabled = false;
            }
            else if (f == 1)
            {
                Generation_Panel.BringToFront();
                Generation_Panel.Enabled = true;
                Signature_panel.Enabled = false;
            }
        }

        private void DisplaySheet_generate_btn_Click(object sender, EventArgs e)
        {
            if(Unv_radio.Checked || Series_radio.Checked)
            {
                if (Folder_path_text.Text != "")
                {
                    int flag = 0;
                    string commandtext;
                    if (Series_radio.Checked)
                        commandtext = "SELECT Distinct Date from Series_Alloted";
                    else
                        commandtext = "SELECT Distinct Date from University_Alloted";
                    DataTable dstnctdatatable = new DataTable();
                    SqlCommand command = new SqlCommand(commandtext, con.ActiveCon());
                    SqlDataAdapter distinctadapter = new SqlDataAdapter(command);
                    distinctadapter.Fill(dstnctdatatable);

                    if (dstnctdatatable.Rows.Count == 0)
                    {
                        flag = 1;
                        MessageBox.Show("Allot Students First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Generation_Panel.BringToFront();
                        Generation_Panel.Enabled = true;
                        DisplaySheet_Panel.Enabled = false;
                        return;
                    }
                    else
                    {
                        foreach (DataRow dr in dstnctdatatable.Rows)
                        {

                            string session = "Forenoon";
                            for (int count = 0; count < 2; count++)
                            {
                                DataTable dt = new DataTable();

                                if (Series_radio.Checked)
                                {
                                    //Create a query and fill the data table with the data from the DB            
                                    SqlCommand cmd = new SqlCommand("SELECT Reg_no,Room_No,Seat,Exam_code,Course,Class from Series_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                    cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                    cmd.Parameters.AddWithValue("@Session", session);
                                    SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                    adptr.Fill(dt);
                                }
                                else
                                {
                                    //Create a query and fill the data table with the data from the DB            
                                    SqlCommand cmd = new SqlCommand("SELECT Reg_no,Room_No,Seat,Exam_code,Course,Branch from University_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                    cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                    cmd.Parameters.AddWithValue("@Session", session);
                                    SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                    adptr.Fill(dt);
                                }
                                DataTable dt2 = new DataTable();
                                if (Unv_radio.Checked)
                                {                                    
                                    SqlCommand commandroom = new SqlCommand("SELECT Distinct Branch from University_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                    commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                    commandroom.Parameters.AddWithValue("@Session", session);
                                    SqlDataAdapter adptr2 = new SqlDataAdapter(commandroom);
                                    adptr2.Fill(dt2);
                                }
                                else
                                {                                    
                                    SqlCommand commandroom = new SqlCommand("SELECT Distinct Class from Series_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                    commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                    commandroom.Parameters.AddWithValue("@Session", session);
                                    SqlDataAdapter adptr2 = new SqlDataAdapter(commandroom);
                                    adptr2.Fill(dt2);
                                }
                                

                                //dt.Columns.Add("Branch", typeof(string));
                                //foreach (DataRow getreg in dt.Rows)
                                //{
                                //    foreach (DataRow getdr in dt2.Rows)
                                //    {
                                //        if (getreg["Reg_no"].ToString() == getdr["Reg_no"].ToString())
                                //        {
                                //            getreg["Branch"] = getdr["Branch"].ToString();

                                //            break;
                                //        }
                                //    }
                                //}

                                //// datatable with distinct branch from 'dt'
                                //DataTable distinctBranch = dt.DefaultView.ToTable(true, "Branch");
                                //MessageBox.Show("--Tester-- \n Check whether distinct code works in dgv");
                                //AllotedStudentsRooms_dgv.DataSource = distinctBranch; ////only for testing delete after that
                                //MessageBox.Show("--Tester-- \n Check whether distinct code works in dgv");
                                //Excel Designing
                                if (dt.Rows.Count != 0)
                                {
                                    using (var package = new ExcelPackage())
                                    {
                                        foreach (DataRow dstrw in dt2.Rows)
                                        {
                                            string checkbranch;
                                            if (Unv_radio.Checked)
                                                checkbranch = dstrw["Branch"].ToString();
                                            else
                                                checkbranch = dstrw["Class"].ToString();

                                            //Add a new worksheet to the empty workbook
                                            var worksheet = package.Workbook.Worksheets.Add(checkbranch);
                                            //Insert Items to ExcelSheet
                                            worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                                            worksheet.Cells["A2"].Value = Display_examtype_textbox.Text;
                                            worksheet.Cells["A3"].Value = dr["Date"].ToString() + " " + session;
                                            worksheet.Cells["A4"].Value = checkbranch;
                                            worksheet.Cells["A5"].Value = "Register No - Room No - Seat No";
                                            using (var range = worksheet.Cells["A5"])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }
                                            using (var range = worksheet.Cells["A1:D1"])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 16;
                                                range.Style.Font.Bold = true;
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;                                                
                                            }
                                            using (var range = worksheet.Cells["A2:D2"])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            }
                                            using (var range = worksheet.Cells["A3:D3"])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            }
                                            using (var range = worksheet.Cells["A4:D4"])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            }

                                            if(Unv_radio.Checked)
                                            {                                                
                                                SqlCommand coursecommand = new SqlCommand("Select Course from University_Alloted where Branch=@Branch and Date=@Date and Session=@Session ", con.ActiveCon());
                                                coursecommand.Parameters.AddWithValue("@Branch", checkbranch);
                                                coursecommand.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                                coursecommand.Parameters.AddWithValue("@Session", session);
                                                string Course = (string)coursecommand.ExecuteScalar();
                                                worksheet.Cells["A6"].Value = Course;
                                                using (var range = worksheet.Cells["A6"])
                                                {
                                                    range.Style.Font.Name = "Arial";
                                                    range.Style.Font.Size = 14;
                                                    range.Style.Font.Bold = true;
                                                } 
                                                SqlCommand coursecmd = new SqlCommand("SELECT Reg_no,Room_No,Seat from University_Alloted Where Date=@Date and Session=@Session and Course=@Course order by Reg_no", con.ActiveCon());
                                                coursecmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                                coursecmd.Parameters.AddWithValue("@Session", session);
                                                coursecmd.Parameters.AddWithValue("@Course", Course);
                                                DataTable coursedt = new DataTable();
                                                SqlDataAdapter courseadptr = new SqlDataAdapter(coursecmd);
                                                courseadptr.Fill(coursedt);
                                                int j = 1, k = 7;
                                                for(var i=0;i<coursedt.Rows.Count;i++)
                                                {
                                                    if (j == 4)
                                                    {
                                                        k++;
                                                        j = 1;
                                                    }
                                                    worksheet.Cells[k , j].Value = coursedt.Rows[i][0] + " - " + coursedt.Rows[i][1] + " - " + coursedt.Rows[i][2];
                                                    j++;
                                                }
                                                using (var range = worksheet.Cells[7,1,k,3])
                                                {
                                                    range.Style.Font.Name = "Arial";
                                                    range.Style.Font.Size = 14;
                                                    range.Style.Font.Bold = true;
                                                    range.AutoFitColumns();
                                                }
                                            }
                                            else
                                            {
                                                SqlCommand coursecommand = new SqlCommand("Select Distinct Course from Series_Alloted where Class=@Class and Date=@Date and Session=@Session ", con.ActiveCon());
                                                coursecommand.Parameters.AddWithValue("@Class", checkbranch);
                                                coursecommand.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                                coursecommand.Parameters.AddWithValue("@Session", session);
                                                DataTable coursedata = new DataTable();
                                                SqlDataAdapter coursedataadptr = new SqlDataAdapter(coursecommand);
                                                coursedataadptr.Fill(coursedata);
                                                int c = 6 ;
                                                foreach(DataRow dataRow in coursedata.Rows)
                                                {
                                                    worksheet.Cells[c,1].Value = dataRow["Course"].ToString();                                                    
                                                    using (var range = worksheet.Cells[c,1])
                                                    {
                                                        range.Style.Font.Name = "Arial";
                                                        range.Style.Font.Size = 14;
                                                        range.Style.Font.Bold = true;
                                                    }
                                                    c++;
                                                    SqlCommand coursecmd = new SqlCommand("SELECT Reg_no,Room_No,Seat from Series_Alloted Where Date=@Date and Session=@Session and Course=@Course order by Reg_no", con.ActiveCon());
                                                    coursecmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                                    coursecmd.Parameters.AddWithValue("@Session", session);
                                                    coursecommand.Parameters.AddWithValue("@Course", dataRow["Course"].ToString());
                                                    DataTable coursedt = new DataTable();
                                                    SqlDataAdapter courseadptr = new SqlDataAdapter(coursecmd);
                                                    courseadptr.Fill(coursedt);
                                                    int j = 1;
                                                    for (var i = 0; i < coursedt.Rows.Count; i++)
                                                    {
                                                        if (j == 4)
                                                        {
                                                            c++;
                                                            j = 1;
                                                        }
                                                        worksheet.Cells[c, j].Value = coursedt.Rows[i][0] + " - " + coursedt.Rows[i][1] + " - " + coursedt.Rows[i][2];
                                                        j++;
                                                    }
                                                    using (var range = worksheet.Cells[7, 1, c, 3])
                                                    {
                                                        range.Style.Font.Name = "Arial";
                                                        range.Style.Font.Size = 14;
                                                        range.Style.Font.Bold = true;
                                                        range.AutoFitColumns();
                                                    }
                                                    c++;
                                                }                                                
                                            }                                            
                                        }
                                        //Save Excel File
                                        /* below might get error since Date has '\' in between ... CHECK if we have to use array 
                                        or something else to remove the '\' .   */
                                        string path = Folder_path_text.Text + @"\Display Sheet " + dr["Date"].ToString() + session + ".xlsx";
                                        Stream stream = File.Create(path);
                                        package.SaveAs(stream);
                                        stream.Close();

                                        session = "Afternoon";
                                    }
                                }
                            }
                        }
                    }
                    if(flag==0)
                        MessageBox.Show("Excel files created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Filepath is not given", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Generation_Panel.BringToFront();
                Generation_Panel.Enabled = true;
                DisplaySheet_Panel.Enabled = false;
            }
            else
                MessageBox.Show("Select Exam Type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DisplayPanel_closebtn_Click(object sender, EventArgs e)
        {
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            DisplaySheet_Panel.Enabled = false;
        }

        private void DisplayPrint_button_Click(object sender, EventArgs e)
        {
            DisplaySheet_Panel.Enabled = true;
            DisplaySheet_Panel.BringToFront();
            Generation_Panel.Enabled = false;
            Signature_panel.Enabled = false;
            RoomExcel_panel.Enabled = false;
        }

        private void Allotment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = false;
            panel1.Enabled = false;
            groupBox1.Enabled = false;
            DisplaySheet_Panel.Enabled = false;
            Signature_panel.Enabled = false;
            RoomExcel_panel.Enabled = false;
        }

        void AllotedDGVFill()
        {
            DataTable dataTable = new DataTable();
            if (Unv_radio.Checked)
            {
                SqlCommand comm = new SqlCommand("select * from University_Alloted where Date=@Date and Session=@Session order by Room_No,Seat",con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);                
                adapter.Fill(dataTable);                
            }
            else
            {
                SqlCommand comm = new SqlCommand("select * from Series_Alloted where Date=@Date and Session=@Session order by Room_No,Seat",con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dataTable);
            }
            dgvfill.DataSource = null;
            dgvfill.DataSource = dataTable;
            Alloted_dgv.DataSource = null;
            Alloted_dgv.DataSource = dgvfill;
            NoOfStudents_Brief.Text = dataTable.Rows.Count.ToString();

            SqlCommand comm2 = new SqlCommand("select Room_No,A_Series,B_Series from Rooms", con.ActiveCon());
            SqlDataAdapter adapter2 = new SqlDataAdapter(comm2);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);

            DataTable dataTable3 = dataTable2.Clone();
            foreach (DataRow dr2 in dataTable2.Rows)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    if (dr["Room_No"].ToString() == dr2["Room_No"].ToString())
                    {
                        dataTable3.ImportRow(dr2);
                    }
                }
            }
            roomfill.DataSource = null;
            roomfill.DataSource = dataTable3;
            AllotedRooms_dgv.DataSource = null;
            AllotedRooms_dgv.DataSource = roomfill;

        }
        void AllotedBriefDGVFill()
        {
            if (Unv_radio.Checked)
            {
                SqlCommand comm = new SqlCommand("select Distinct Exam_Code,Course from University_Alloted where Date=@Date and Session=@Session", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dataTablebrief = new DataTable();
                adapter.Fill(dataTablebrief);
                dataTablebrief.Columns.Add("No of Students", typeof(int));
                foreach (DataRow dr in dataTablebrief.Rows)
                {
                    SqlCommand comm2 = new SqlCommand("select Count(Reg_No) from University_Alloted where Exam_Code=@Exam_Code", con.ActiveCon());
                    comm2.Parameters.AddWithValue("@Exam_Code", dr["Exam_Code"]);
                    int count = (int)comm2.ExecuteScalar();
                    dr["No of Students"] = count;
                }
                briefdgv.DataSource = null;
                briefdgv.DataSource = dataTablebrief;
            }
            else
            {
                SqlCommand comm = new SqlCommand("select Distinct Exam_Code,Class from Series_Alloted where Date=@Date and Session=@Session", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.Columns.Add("No of Students", typeof(int));
                foreach (DataRow dr in dataTable.Rows)
                {
                    SqlCommand comm2 = new SqlCommand("select Count(Reg_No) from Series_Alloted where Exam_Code=@Exam_Code", con.ActiveCon());
                    comm2.Parameters.AddWithValue("@Exam_Code", dr["Exam_Code"]);
                    int count = (int)comm2.ExecuteScalar();
                    dr["No of Students"] = count;
                }
                briefdgv.DataSource = null;
                briefdgv.DataSource = dataTable;
            }
            AllotedBrief_dgv.DataSource = null;
            AllotedBrief_dgv.DataSource = briefdgv;
        }
        void AllotedStudentsDGVFill()
        {
            if (Unv_radio.Checked)
            {
                SqlCommand comm = new SqlCommand("select Reg_no,Name,Exam_Code,Room_No,Seat from University_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                comm.Parameters.AddWithValue("@Room_No", AllocatedRoom_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dataTabledgv = new DataTable();
                adapter.Fill(dataTabledgv);
                AllotedStudentsRooms_dgv.DataSource = null;
                AllotedStudentsRooms_dgv.DataSource = dataTabledgv;
                NoOfStudents_Room.Text = dataTabledgv.Rows.Count.ToString();
            }
            else if (Series_radio.Checked)
            {
                SqlCommand comm = new SqlCommand("select Reg_no,Name,Exam_Code,Room_No,Seat from Series_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                comm.Parameters.AddWithValue("@Room_No", AllocatedRoom_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                AllotedStudentsRooms_dgv.DataSource = null;
                AllotedStudentsRooms_dgv.DataSource = dataTable;
                NoOfStudents_Room.Text = dataTable.Rows.Count.ToString();
            }
        }        
        void AllocatedRoomComboboxFill()
        {
            DataTable dataTablecombo = new DataTable();
            if(Series_radio.Checked)
            {
                SqlCommand comm = new SqlCommand("select Distinct Room_No from Series_Alloted where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dataTablecombo);
            }
            else
            {
                SqlCommand comm = new SqlCommand("select Distinct Room_No from University_Alloted where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(dataTablecombo);
            }

            DataRow top = dataTablecombo.NewRow();
            top[0] = "-Select-";
            dataTablecombo.Rows.InsertAt(top, 0);
            AllocatedRoom_combobox.DisplayMember = "Room_No";
            AllocatedRoom_combobox.ValueMember = "Room_No";
            AllocatedRoom_combobox.DataSource = dataTablecombo;

            AllocatedRoom_combobox.SelectedIndex = 0;
        }

        private void Unv_radio_CheckedChanged(object sender, EventArgs e)
        {
            Generation_Panel.Enabled = true;
            panel1.Enabled = true;
            groupBox1.Enabled = true;
            RefreshAll();
        }

        private void Series_radio_CheckedChanged(object sender, EventArgs e)
        {
            Generation_Panel.Enabled = true;
            panel1.Enabled = true;
            groupBox1.Enabled = true;
            RefreshAll();
        }
        BindingSource roomfill = new BindingSource();
        BindingSource dgvfill = new BindingSource();
        BindingSource briefdgv = new BindingSource();
        

        private void AllocatedRoom_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AllocatedRoom_combobox.SelectedIndex!=0)
            {
                AllotedStudentsDGVFill();
            }
        }
        void RefreshAll()
        {
            AllotedBrief_dgv.DataSource = null;
            AllotedRooms_dgv.DataSource = null;
            AllotedStudentsRooms_dgv.DataSource = null;
            Alloted_dgv.DataSource = null;
            NoOfStudents_Brief.Clear();
            NoOfStudents_Room.Clear();
            AllocatedRoom_combobox.DataSource = null;
            FromRoom_textbox.Clear();
            FromStart_textbox.Clear();
            FromEnd_textbox.Clear();
            ToStart_textbox.Clear();
            ToRoom_textbox.Clear();
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "dd-MM-yyyy";
            DateTimePicker.Value = DateTime.Now;
            Session_combobox.SelectedIndex = 0;
            FromSeries_combobox.SelectedIndex = 0;
            ToSeries_combobox.SelectedIndex = 0;
        }

        private void Swap_button_Click(object sender, EventArgs e)
        {
            if(FromSeries_combobox.SelectedIndex!=0 && ToSeries_combobox.SelectedIndex!=0 && FromRoom_textbox.Text!="" && FromStart_textbox.Text!="" && FromEnd_textbox.Text !="" && ToRoom_textbox.Text!="" && ToStart_textbox.Text !="")
            {
                DialogResult result = MessageBox.Show("Are You Sure To SWAP the Selected Students ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string fromroom = FromRoom_textbox.Text, fromseries = FromSeries_combobox.Text, fromstart = FromStart_textbox.Text, fromend = FromEnd_textbox.Text;
                        string toroom = ToRoom_textbox.Text, toseries = ToSeries_combobox.Text, tostart = ToStart_textbox.Text;
                        int fromstartint = Int32.Parse(fromstart);
                        int fromendint = Int32.Parse(fromend);
                        int tostartint = Int32.Parse(tostart);
                        int fromtemp = fromstartint, totemp = tostartint;
                        if (Unv_radio.Checked)
                        {
                            SqlCommand comm = new SqlCommand("Select Room_No,Seat,Reg_no from University_Alloted where Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SqlDataAdapter adapter = new SqlDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            SqlCommand comm2 = new SqlCommand("Select Room_No,Seat,Reg_no from University_Alloted where Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm2.Parameters.AddWithValue("@Room_No", toroom);
                            SqlDataAdapter adapter2 = new SqlDataAdapter(comm2);
                            DataTable dataTable2 = new DataTable();
                            adapter2.Fill(dataTable2);
                            int f = 0;
                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                f++;
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + totemp;
                                        totemp++;
                                        break;
                                    }
                                }
                            }
                            for (int i = tostartint; i < tostartint + f; i++)
                            {
                                MessageBox.Show(toseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable2.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == toseries + i)
                                    {
                                        dataRow["Room_No"] = fromroom;
                                        dataRow["Seat"] = fromseries + fromtemp;
                                        fromtemp++;
                                        break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SqlCommand comm3 = new SqlCommand("update University_Alloted set Room_No=@Room_No,Seat=@Seat where Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            foreach (DataRow dataRow in dataTable2.Rows)
                            {
                                SqlCommand comm3 = new SqlCommand("update University_Alloted set Room_No=@Room_No,Seat=@Seat where Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            MessageBox.Show("Swap Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Series_radio.Checked)
                        {
                            SqlCommand comm = new SqlCommand("Select Room_No,Seat,Reg_no from Series_Alloted where Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SqlDataAdapter adapter = new SqlDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            SqlCommand comm2 = new SqlCommand("Select Room_No,Seat,Reg_no from Series_Alloted where Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm2.Parameters.AddWithValue("@Room_No", toroom);
                            SqlDataAdapter adapter2 = new SqlDataAdapter(comm2);
                            DataTable dataTable2 = new DataTable();
                            adapter2.Fill(dataTable2);
                            int f = 0;
                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                f++;
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + totemp;
                                        totemp++;
                                        break;
                                    }
                                }
                            }
                            for (int i = tostartint; i < tostartint + f; i++)
                            {
                                MessageBox.Show(toseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable2.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == toseries + i)
                                    {
                                        dataRow["Room_No"] = fromroom;
                                        dataRow["Seat"] = fromseries + fromtemp;
                                        fromtemp++;
                                        break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SqlCommand comm3 = new SqlCommand("update Series_Alloted set Room_No=@Room_No,Seat=@Seat where Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            foreach (DataRow dataRow in dataTable2.Rows)
                            {
                                SqlCommand comm3 = new SqlCommand("update Series_Alloted set Room_No=@Room_No,Seat=@Seat where Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            MessageBox.Show("Swap Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Give necessary Details", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void SearchDGVFill_Click(object sender, EventArgs e)
        {
            AllocatedRoomComboboxFill();
            AllotedDGVFill();
            AllotedBriefDGVFill();
        }
    }
}

        



