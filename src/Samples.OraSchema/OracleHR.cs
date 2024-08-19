using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Samples.OraSchema
{
    public partial class OracleHR : Form
    {
        public OracleHR()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ClearControls();
            try
            {
                if (string.IsNullOrEmpty(userName.Text))
                    DisplayError("Empty user name!");
                else if (string.IsNullOrEmpty(password.Text))
                    DisplayError("Empty password!");
                else if (string.IsNullOrEmpty(dataSource.Text))
                    DisplayError("Empty datasource!");
                else
                {
                    OracleConnectionStringBuilder strBuilder = new OracleConnectionStringBuilder();
                    strBuilder.UserID = userName.Text;
                    strBuilder.Password = password.Text;
                    strBuilder.DataSource = dataSource.Text;
                    OracleConnection conn = ConnectionManager.OpenAndGetConnection(strBuilder.ConnectionString);
                    var dt = new DataTable();
                    OracleCommand cmd = new OracleCommand("select object_name, object_type from user_objects", conn);
                    cmd.CommandType = CommandType.Text;
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    adapter.Fill(dt);
                    data.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                DisplayError("exception: " + ex.Message);
            }
        }

        void DisplayError(string s)
        {
            lbloutput.Text = string.Empty;
            lbloutput.ForeColor = Color.Red;
            lbloutput.Text = s;
        }

        void ClearControls()
        {
            lbloutput.Text = string.Empty;
            lbloutput.ForeColor = Color.Black;
        }

        static void Main(string[] args)
        {
            Application.Run(new OracleHR());
        }

    }
}
