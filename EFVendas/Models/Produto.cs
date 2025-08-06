namespace EFVendas.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public ICollection<PedidoItem> PedidoItens { get; set; }
}
