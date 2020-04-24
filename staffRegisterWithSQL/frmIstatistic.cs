using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace staffRegisterWithSQL
{
    public partial class frmIstatistic : Form
    {
        public frmIstatistic()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-919AS9O;Initial Catalog=personalDatabase;Integrated Security=True");

        private void frmIstatistic_Load(object sender, EventArgs e)
        {

            SqlCommand commandOne = new SqlCommand("Select Count (*) From tblPerson", connect);
            connect.Open();
            SqlDataReader dr1 = commandOne.ExecuteReader();
            while (dr1.Read()) {
                lblTopPer.Text = dr1[0].ToString();
            }
            connect.Close();

            // Married Personel
            connect.Open();

            SqlCommand commandTwo = new SqlCommand("Select count (*) From tblPerson Where perMaritial=1", connect);
            SqlDataReader dr2 = commandTwo.ExecuteReader();
            while (dr2.Read()) {
                lblMarriedPer.Text = dr2[0].ToString();
            }
            connect.Close();

            // Single Personel
            connect.Open();
            SqlCommand commandThree = new SqlCommand("Select count (*) From tblPerson Where perMaritial=0", connect);
            SqlDataReader dr3 = commandThree.ExecuteReader();
            while (dr3.Read()) {
                lblSinglePer.Text = dr3[0].ToString();
            }
            connect.Close();

            //countOfCity
            connect.Open();

            SqlCommand commandFour = new SqlCommand("Select count(distinct(perCity)) From tblPerson", connect);
            SqlDataReader dr4= commandFour.ExecuteReader();
            while (dr4.Read()) {
                lblCityNumber.Text = dr4[0].ToString();
            }
            connect.Close();

            //totallyWage

            connect.Open();

            SqlCommand commandFive = new SqlCommand("Select sum(perWage) From tblPerson", connect);
            SqlDataReader dr5 = commandFive.ExecuteReader();
            while (dr5.Read()) {
                lblTopWage.Text = dr5[0].ToString();
            }
            connect.Close();

            //averageWage

            connect.Open();

            SqlCommand commandSix = new SqlCommand("Select avg(perWage) From tblPerson", connect);
            SqlDataReader dr6 = commandSix.ExecuteReader();
            while (dr6.Read()) {
                lblAverageWage.Text = dr6[0].ToString();            }

            connect.Close();














        }
    }
}
