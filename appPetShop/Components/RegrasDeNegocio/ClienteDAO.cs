using appPetShop.Configs;

namespace appPetShop.Components.RegrasDeNegocio
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;
        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();
            var comando = _conexao.CreateCommand("SELECT * FROM cliente;");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = leitor.GetString( "nome_cli");
                cliente.CPF= leitor.GetString( "cpf_cli");
                cliente.CEP = leitor.GetString("cep_cli");
                cliente.Rua = leitor.GetString("rua_cli");
                cliente.Bairro = leitor.GetString("bairro_cli");
                cliente.NumeroCasa = leitor.GetString("numero_cli");
                cliente.Complemento = leitor.GetString("complemento_cli");
                cliente.Telefone = leitor.GetString("telefone_cli");
                cliente.Email = leitor.GetString("email_cli");
                cliente.DataNasc = leitor.GetString("dataNascimento_cli");

                lista.Add(cliente);
            }

            return lista;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cliente VALUES (null, @_nome, @_cpf, @_cep, @_rua,  @_bairro,  @_numero,  @_complemento,  @_telefone,  @_email,  @_dataNascimento)");

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@_cep", cliente.CEP);
                comando.Parameters.AddWithValue("@_rua", cliente.Rua);
                comando.Parameters.AddWithValue("@_bairro", cliente.Bairro);
                comando.Parameters.AddWithValue("@_numero", cliente.NumeroCasa);
                comando.Parameters.AddWithValue("@_complemento", cliente.Complemento);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_email", cliente.Email);
                comando.Parameters.AddWithValue("@_dataNascimento", cliente.DataNasc);
               

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
                var comando = _conexao.CreateCommand("DELETE FROM Cliente WHERE id_cli = @_id");
                comando.Parameters.AddWithValue("@_id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar cliente: " + ex.Message);
            }

        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"
                    UPDATE cliente 
                    SET 
                    nome_cli = @_nome,
                    cpf_cli = @_cpf,
                    cep_cli = @_cep,
                    rua_cli = @_rua,
                    bairro_cli = @_bairro,
                    numero_cli = @_numero,
                    complemento_cli = @_complemento,
                    telefone_cli = @_telefone,
                    email_cli = @_email,
                    dataNascimento_cli = @_dataNascimento
                    WHERE id_cli = @_id;
                ");

                comando.Parameters.AddWithValue("@_id", cliente.Id);
                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@_cep", cliente.CEP);
                comando.Parameters.AddWithValue("@_rua", cliente.Rua);
                comando.Parameters.AddWithValue("@_bairro", cliente.Bairro);
                comando.Parameters.AddWithValue("@_numero", cliente.NumeroCasa);
                comando.Parameters.AddWithValue("@_complemento", cliente.Complemento);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_email", cliente.Email);
                comando.Parameters.AddWithValue("@_dataNascimento", cliente.DataNasc);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente: " + ex.Message);
            }
        }


    }
}

