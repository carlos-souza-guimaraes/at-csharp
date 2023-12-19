using System.ComponentModel.DataAnnotations;
using LojaDeAlgumaCoisa.Models;
public class Carro
{

    public int Id { get; set; }
    public string Linha { get; set; }
    public string ModeloId { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }

    [Display(Name = "Preço")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }


    [Display(Name = "Disponível")]
    public bool Vendido { get; set; }
    public string VendidoFormatado => Vendido ? "Sim" : "Não";

    [Display(Name = "Entrada na coleção")]
    [DisplayFormat(DataFormatString = "{0:MMMM yyyy}")]
    public DateTime Registro { get; set; }
    public string ImageUri { get; set; }
}