using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Produto
    {
        public int Id { get; set; }

		[Display(Name = "Nome")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string Name { get; set; }

        public double Preco { get; set; }

        public string Peso { get; set; }

        public string Marca { get; set; }


        public Produto()
        {

        }

        public Produto(int id, string name, double preco, string peso, string marca)
        {
            Id = id;
            Name = name;
            Preco = preco;
            Peso = peso;
            Marca = marca;
        }
    }
}
