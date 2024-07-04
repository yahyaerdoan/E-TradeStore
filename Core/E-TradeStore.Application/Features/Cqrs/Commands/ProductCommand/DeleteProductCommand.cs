namespace E_TradeStore.Application.Features.Cqrs.Commands.ProductCommand;

public class DeleteProductCommand
{
    public int Id { get; set; }

    public DeleteProductCommand(int id)
    {
        Id = id;
    }
}
