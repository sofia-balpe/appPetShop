namespace appPetShop.Components.RegrasDeNegocio
{
    
    public class Cliente
    {
        // Propriedade de identificação única do cliente.
        public int Id { get; set; }

        // Nome completo do cliente.
        public string Nome { get; set; } = string.Empty;

        // Cadastro de Pessoa Física (CPF) do cliente.
        public string CPF { get; set; } = string.Empty;

        // Código de Endereçamento Postal (CEP) do cliente.
        public string CEP { get; set; } = string.Empty;

        // Nome da rua do endereço do cliente.
        public string Rua { get; set; } = string.Empty;

        // Nome do bairro do endereço do cliente.
        public string Bairro { get; set; } = string.Empty;

        // Número da residência do cliente.
        public string NumeroCasa { get; set; } = string.Empty;

        // Informações adicionais do endereço (opcional).
        // Mesmo sendo opcional, inicializar com string.Empty é mais seguro que null.
        public string Complemento { get; set; } = string.Empty;

        // Número de telefone para contato.
        public string Telefone { get; set; } = string.Empty;

        // Endereço de e-mail do cliente.
        public string Email { get; set; } = string.Empty;

        // Data de nascimento do cliente, armazenada como texto.
        public string DataNasc { get; set; } = string.Empty;
    }
}
