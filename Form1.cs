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

namespace CadastroSQL
{
    public partial class FormulariosCadastro : Form
    {
        public FormulariosCadastro()
        {
            InitializeComponent();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            //criamos a string de conexao
            // no Betaone é o nome do seu pc ou servidor,   no catalog é o nome do database
    
              SqlConnection conn = new SqlConnection("Data Source=KOTANA\\SQLEXPRESS;Initial Catalog=ShelderPoke;Integrated Security=True");
            //cria a string de inserção do sql
            string sql = "INSERT INTO dbo.cadastro(id,nome,email,telefone) VALUES (@id,@nome,@email,@telefone)";
            Random numeroID = new Random();
            numeroID.Next();

            try
            {
                //cria um objeto do tipo comando passando como parametro a string sql e conn
                SqlCommand c = new SqlCommand(sql, conn);

                //insere os dados da textbox no comando sql
                c.Parameters.Add(new SqlParameter("@id", numeroID.Next()));
                c.Parameters.Add(new SqlParameter("@nome", this.BoxNome.Text));
                c.Parameters.Add(new SqlParameter("@email", this.BoxEmail.Text));
                c.Parameters.Add(new SqlParameter("@telefone", this.BoxTel.Text));
                //abrimos a conexao com o banco de dados
                conn.Open();
                //executa o comando sql no banco de dados
                c.ExecuteNonQuery();
                //fechamos a conexao
                conn.Close();
                MessageBox.Show("Enviados com sucesso!");
            }catch(SqlException ex)
            {
                MessageBox.Show("Ocorreu o erro: "+ ex);
            }

           

        }
    }
}
