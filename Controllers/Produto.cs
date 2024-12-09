namespace ECommerce.Controllers
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public double Peso { get; set; }

        public string Marca { get; set; }


        public Produto()
        {
            
        }

        public Produto(int id, string nome, double preco, double peso, string marca)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Peso = peso;
            Marca = marca;
        }
    }
}
