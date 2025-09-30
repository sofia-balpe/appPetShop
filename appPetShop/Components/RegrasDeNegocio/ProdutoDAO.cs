using appPetShop.Configs;
namespace appPetShop.Components.RegrasDeNegocio
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;
        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO produto VALUES (null, null, @_nome, @_descricao, @_qtd, @_preco)");

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
    }
}
