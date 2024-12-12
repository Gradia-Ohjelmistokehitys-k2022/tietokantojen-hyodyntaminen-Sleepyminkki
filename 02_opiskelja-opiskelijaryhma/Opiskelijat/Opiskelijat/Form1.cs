using Opiskelijat.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Opiskelijat
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=(localdb)\\MSSQLLocalDB;" + "Trusted_Connection=yes;" + "database=Koulu;";
        public Form1()
        {
            InitializeComponent();
            LoadStudents();
            LoadGroups();
        }

        private void LoadStudents()
        {
            using var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("select OpiskelijaId, Nimi, RyhmaId, Tunnus from Opiskelija", dbConnection);
            var dataset = new DataTable();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset;
            dbConnection.Close();
        }

        private void LoadGroups()
        {
            using var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            string Sql = "select RyhmaId, RyhmaNimi from Ryhma";
            SqlCommand cmd = new SqlCommand(Sql, dbConnection);
            SqlDataReader datareader = cmd.ExecuteReader();

            var groups = new List<Ryhma>();
            while (datareader.Read())
            {
                groups.Add(new Ryhma
                {
                    Id = datareader.GetInt32(0),
                    RyhmaNimi = datareader.GetString(1)
                });
            }
            dbConnection.Close();

            comboBox1.DataSource = groups;
            comboBox1.DisplayMember = "RyhmaNimi";
            comboBox1.ValueMember = "Id";
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            using var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            SqlCommand myCommand = new SqlCommand("insert into Opiskelija (Nimi, RyhmaId, Tunnus) values (@NimiIn, @RyhmaIn, @TunnusIn)", dbConnection);

            myCommand.Parameters.Add("@NimiIn", SqlDbType.NVarChar).Value = textBox1.Text;
            myCommand.Parameters.Add("@RyhmaIn", SqlDbType.Int).Value = (int)comboBox1.SelectedValue;
            myCommand.Parameters.Add("@TunnusIn", SqlDbType.NVarChar).Value = textBox2.Text;

            myCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OpiskelijaId"].Value);

            using var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            SqlCommand deleteCommand = new SqlCommand("delete from Opiskelija where OpiskelijaId = @Id", dbConnection);
            deleteCommand.Parameters.Add("@Id", SqlDbType.Int).Value = selectedId;

            int rowsAffected = deleteCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Opiskelija poistettu");
            }
            else
            {
                MessageBox.Show("Error: opiskelijaa ei onnistuttu poistamaan");
            }

            dbConnection.Close();
            LoadStudents();
        }
    }
}
