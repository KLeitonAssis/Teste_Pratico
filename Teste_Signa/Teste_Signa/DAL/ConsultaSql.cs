using System.Data;
using System.Data.SqlClient;

namespace Teste_Signa.DAL
{
    public class ConsultaSql
    {

        public List<Models.Pessoa> GetListaPessoas(string Conexao_BD)
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(Conexao_BD);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<Models.Pessoa> result = new List<Models.Pessoa>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_LISTA_PESSOA";
            comando.CommandTimeout = 3000;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.Add(new Models.Pessoa());
                    result[i].Id = ds.Tables[0].Rows[i]["PESSOA_ID"].ToString();
                    result[i].PessoaNo = ds.Tables[0].Rows[i]["NOME_FANTASIA"].ToString();
                    result[i].cpf = ds.Tables[0].Rows[i]["CNPJ_CPF"].ToString();
                }

            }
            return result;
        }

    }
}
