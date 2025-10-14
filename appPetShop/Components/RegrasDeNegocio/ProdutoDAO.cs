using appPetShop.Configs;
using System.Data;

namespace appPetShop.Components.RegrasDeNegocio
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;
        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();
            var comando = _conexao.CreateCommand("SELECT * FROM produto;");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = leitor.GetString("nome_pro");
                produto.Descricao = leitor.GetString("descricao_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Valor = leitor.GetDouble("valor_unitario_pro");

                lista.Add(produto);
            }

            return lista;
        }
        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO produto VALUES (null, @_nome, @_descricao, @_qtd, @_preco)");

                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@_qtd", produto.Quantidade);
                comando.Parameters.AddWithValue("@_preco", produto.Valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;

            }
        }

        public void Deletar(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM Produto WHERE id_cli = @_id");
                comando.Parameters.AddWithValue("@_id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar produto: " + ex.Message);
            }

        }

    }
}
