namespace E_TradeStore.Application.Features.Cqrs.Commands.ProductCommand;

public class UpdateProductCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
