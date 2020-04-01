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
    public partial class Place_report : Form
    {
        public Place_report()
        {
            InitializeComponent();
            string mybdpath = "D:\\Модели данных макет и отчеты\\БД Спортивная школа.accdb";
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mybdpath;
            OleDbConnection connection = new OleDbConnection(conStr);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            connection.Open();

            String query = "select  Place.Number_of_hall as Номер_зала, Place.destination as Назначение, Square as Площадь from Place";

            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Close();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);
        }
    }
}
