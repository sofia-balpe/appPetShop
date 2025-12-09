using appPetShop.Configs;
using System.Data;

namespace appPetShop.Components.RegrasDeNegocio
{
    public class PetDAO
    {

        private readonly Conexao _conexao;
        public PetDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Pet> ListarTodos()
        {
            var lista = new List<Pet>();
            var comando = _conexao.CreateCommand(@"SELECT p.id_pet, p.nome_pet, e.nome_esp, p.raca_pet, p.data_nascimento_pet, p.idade_pet, p.porte_pet, p.peso_pet, p.id_cli_fk, c.nome_cli
                                                 FROM pet AS p JOIN cliente AS c ON p.id_cli_fk = c.id_cli
                                                 JOIN especie as e ON e.id_esp = p.id_esp_fk;");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var pet = new Pet();

                pet.Id = leitor.GetInt32("id_pet");

                pet.Nome = leitor.IsDBNull("nome_pet")
                    ? null
                    : leitor.GetString("nome_pet");

                pet.NomeEspecie = leitor.IsDBNull("nome_esp")
                    ? null
                    : leitor.GetString("nome_esp");

                pet.Raca = leitor.IsDBNull("raca_pet")
                    ? null
                    : leitor.GetString("raca_pet");

                pet.Data_Nascimento = leitor.IsDBNull("data_nascimento_pet")
                    ? null
                    : leitor.GetString("data_nascimento_pet");

                pet.Idade = leitor.IsDBNull("idade_pet")
                    ? 0
                    : leitor.GetInt32("idade_pet");

                pet.Porte = leitor.IsDBNull("porte_pet")
                    ? null
                    : leitor.GetString("porte_pet");

                pet.Peso = leitor.IsDBNull("peso_pet")
                    ? 0
                    : leitor.GetDouble("peso_pet");

                pet.NomeCliente = leitor.IsDBNull("nome_cli")
                    ? null
                    : leitor.GetString("nome_cli");

                lista.Add(pet);
            }

            return lista;
        }

        public List<Cliente> ListarClientes()
        {
            var lista = new List<Cliente>();
            var comando = _conexao.CreateCommand("SELECT id_cli, nome_cli FROM cliente");

            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = leitor.GetString("nome_cli");
                lista.Add(cliente);
            }

            return lista;
        }

        public List<Especie> ListarEspecies()
        {
            var lista = new List<Especie>();
            var comando = _conexao.CreateCommand("SELECT id_esp, nome_esp FROM especie");

            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var especie = new Especie();
                especie.Id = leitor.GetInt32("id_esp");
                especie.Nome = leitor.GetString("nome_esp");
                lista.Add(especie);
            }

            return lista;
        }

        public void Inserir(Pet pet)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"INSERT INTO pet 
                (nome_pet, id_esp_fk, raca_pet, data_nascimento_pet, idade_pet, porte_pet, peso_pet, id_cli_fk)
                VALUES (@_nome, @_especie, @_raca, @_dataNasc, @_idade, @_porte, @_peso, @_idCli)");

                comando.Parameters.AddWithValue("@_nome", pet.Nome);
                comando.Parameters.AddWithValue("@_especie", pet.Id_Especie);
                comando.Parameters.AddWithValue("@_raca", pet.Raca);
                comando.Parameters.AddWithValue("@_dataNasc", pet.Data_Nascimento);
                comando.Parameters.AddWithValue("@_idade", pet.Idade);
                comando.Parameters.AddWithValue("@_porte", pet.Porte);
                comando.Parameters.AddWithValue("@_peso", pet.Peso);
                comando.Parameters.AddWithValue("@_idCli", pet.Id_Cliente);

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
                var comando = _conexao.CreateCommand("DELETE FROM pet WHERE id_pet = @_id");
                comando.Parameters.AddWithValue("@_id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar pet: " + ex.Message);
            }

        }

        public void Atualizar(Pet pet)
        {
            try
            {
                var comando = _conexao.CreateCommand(@"UPDATE pet SET nome_pet = @_nome, especie_pet = @_especie, raca_pet = @_raca, data_nascimento_pet = 
                @_dataNasc, idade_pet = @_idade, porte_pet = @_porte, peso_pet = @_peso, id_cli_fk = @_idCli WHERE id_pet = @_id");

                comando.Parameters.AddWithValue("@_nome", pet.Nome);
                comando.Parameters.AddWithValue("@_especie", pet.Id_Especie);
                comando.Parameters.AddWithValue("@_raca", pet.Raca);
                comando.Parameters.AddWithValue("@_dataNasc", pet.Data_Nascimento);
                comando.Parameters.AddWithValue("@_idade", pet.Idade);
                comando.Parameters.AddWithValue("@_porte", pet.Porte);
                comando.Parameters.AddWithValue("@_peso", pet.Peso);
                comando.Parameters.AddWithValue("@_idCli", pet.Id_Cliente);
                comando.Parameters.AddWithValue("@_id", pet.Id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar pet: " + ex.Message);
            }
        }

    }
}
