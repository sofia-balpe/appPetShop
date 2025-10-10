namespace appPetShop.Components.RegrasDeNegocio
{
    /// <summary>
    /// Representa um animal de estimação (Pet) cadastrado no sistema.
    /// As propriedades de texto são inicializadas para evitar referências nulas.
    /// </summary>
    public class Pet
    {
        // Identificador único do pet.
        public int Id { get; set; }

        // Nome do pet.
        public string Nome { get; set; } = string.Empty;

        // Espécie do pet (ex: Cão, Gato, Pássaro).
        public string Especie { get; set; } = string.Empty;

        // Raça específica do pet.
        public string Raca { get; set; } = string.Empty;

        // Data de nascimento do pet, armazenada como texto.
        public string Data_Nascimento { get; set; } = string.Empty;

        // Idade do pet. Tipos numéricos como 'double' não precisam de inicialização aqui.
        public double Idade { get; set; }

        // Porte do pet (ex: Pequeno, Médio, Grande).
        public string Porte { get; set; } = string.Empty;

        // Peso do pet em quilogramas.
        public double Peso { get; set; }

        // Chave estrangeira para relacionar o pet ao seu dono (Cliente).
        public int Id_Cliente { get; set; }

        // Propriedade para armazenar o nome do cliente (dono do pet).
        // Útil para exibição em listas, evitando buscas extras no banco de dados.
        public string NomeCliente { get; set; } = string.Empty;
    }
}
