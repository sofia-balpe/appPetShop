namespace appPetShop.Components.RegrasDeNegocio
{
    public class Pet
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Id_Especie { get; set; }
        public string Raca {  get; set; }
        public string Data_Nascimento { get; set; }
        public double Idade { get; set; }
        public string Porte { get; set; }
        public double Peso { get; set; }
        public int Id_Cliente { get; set; }

        public string NomeCliente { get; set; }
        public string NomeEspecie { get; set; }
    }
}
