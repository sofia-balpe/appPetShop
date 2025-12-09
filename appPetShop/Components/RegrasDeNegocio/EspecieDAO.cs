using appPetShop.Configs;

namespace appPetShop.Components.RegrasDeNegocio
{
    public class EspecieDAO
    {
        private readonly Conexao _conexao;
        public EspecieDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Especie> ListarTodos()
        {
            var lista = new List<Especie>();
            var comando = _conexao.CreateCommand("SELECT * FROM especie;");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var especie = new Especie();
                especie.Id = leitor.GetInt32("id_esp");
                especie.Nome = leitor.GetString("nome_esp");
                especie.NomeCientifico = leitor.GetString("nomeCient_esp");
                especie.Alimento = leitor.GetString("alimen_esp");
                especie.Habitat = leitor.GetString("habitat_esp");

                lista.Add(especie);
            }

            return lista;
        }

        public void Deletar(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE FROM especie WHERE id_esp = @_id");
                comando.Parameters.AddWithValue("@_id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar especie: " + ex.Message);
            }

        }

        public void Atualizar(Especie especie)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"UPDATE especie SET nome_esp = @_nome, nomeCient_esp = @_nomeCient, alimen_esp = @_alimento, habitat_esp = 
                @_habitat");

                comando.Parameters.AddWithValue("@_nome", especie.Nome);
                comando.Parameters.AddWithValue("@_nomeCient", especie.NomeCientifico);
                comando.Parameters.AddWithValue("@_alimento", especie.Alimento);
                comando.Parameters.AddWithValue("@_habitat", especie.Habitat);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar especie: " + ex.Message);
            }
        }

        public void Inserir(Especie especie)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO especie VALUES (null, @_nome, @_nomeCient, @_alimen, @_habitat)");

                comando.Parameters.AddWithValue("@_nome", especie.Nome);
                comando.Parameters.AddWithValue("@_nomeCient", especie.NomeCientifico);
                comando.Parameters.AddWithValue("@_alimen", especie.Alimento);
                comando.Parameters.AddWithValue("@_habitat", especie.Habitat);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
