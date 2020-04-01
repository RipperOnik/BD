﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваяБд
{
    public partial class ScheduleStudent : Form
    {
        public ScheduleStudent(string group_name)
        {
            InitializeComponent();
            string mybdpath = "D:\\Модели данных макет и отчеты\\БД Спортивная школа.accdb";
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
            OleDbConnection connection = new OleDbConnection(conStr);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            connection.Open();
      
            String query = String.Format("select Group_name as Группа, " +
                "Trainers.Full_name as Тренер, Place as Номер_зала, start_time as время_начала, " +
                "end_time as время_конца, [kind of sport].Sport_name as Вид_спорта, " +
                "Day as День, Rating as Рейтинг " +
                "from ((Lessons " +
                "inner join Trainers on (Lessons.Trainer = Trainers.Id_of_trainer)) " +
                "inner join [Group] on ([Lessons].[Group] = [Group].[Id_ of_Group])) " +
                "inner join [kind of sport] on ([Lessons].Sport = [kind of sport].Id_of_sport) " +
                "where Group_name = '{0}'", group_name); // говно ебанное 

            OleDbCommand command = new OleDbCommand(query, connection); 
            connection.Close();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }
        public ScheduleStudent()
        {
            InitializeComponent();
            string mybdpath = "D:\\Модели данных макет и отчеты\\БД Спортивная школа.accdb";
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
            OleDbConnection connection = new OleDbConnection(conStr);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            connection.Open();

            String query = "select Group_name as Группа, " +
                "Trainers.Full_name as Тренер, Place as Номер_зала, start_time as время_начала, " +
                "end_time as время_конца, [kind of sport].Sport_name as Вид_спорта, " +
                "Day as День, Rating as Рейтинг " +
                "from ((Lessons " +
                "inner join Trainers on (Lessons.Trainer = Trainers.Id_of_trainer)) " +
                "inner join [Group] on ([Lessons].[Group] = [Group].[Id_ of_Group])) " +
                "inner join [kind of sport] on ([Lessons].Sport = [kind of sport].Id_of_sport) " +
                "order by Group_name";

            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Close();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }

        private void ScheduleStudent_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_Спортивная_школаDataSet1.Lessons". При необходимости она может быть перемещена или удалена.
            this.lessonsTableAdapter.Fill(this.бД_Спортивная_школаDataSet1.Lessons);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_Спортивная_школаDataSet1.Копия_Список_учеников_группы". При необходимости она может быть перемещена или удалена.
            this.копия_Список_учеников_группыTableAdapter.Fill(this.бД_Спортивная_школаDataSet1.Копия_Список_учеников_группы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_Спортивная_школаDataSet1._Копия_Group_s_schedule". При необходимости она может быть перемещена или удалена.
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
