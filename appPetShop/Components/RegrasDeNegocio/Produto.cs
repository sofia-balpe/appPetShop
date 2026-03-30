namespace appPetShop.Components.RegrasDeNegocio
{
    /// <summary>
    /// Representa um produto disponível para venda no PetShop.
    /// As propriedades de texto são inicializadas para evitar referências nulas.
    /// </summary>
    public class Produto
    {
        // Identificador único do produto.
        public int Id { get; set; }

        // Nome do produto (ex: Ração Premium, Brinquedo de Borracha).
        public string Nome { get; set; } = string.Empty;

        // Descrição detalhada do produto.
        public string Descricao { get; set; } = string.Empty;

        // Quantidade do produto em estoque.
        public int Quantidade { get; set; }

        // Preço de venda do produto.
        public double Valor { get; set; }
    }
}
