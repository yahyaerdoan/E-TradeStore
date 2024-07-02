namespace E_TradeStore.Application.Features.Cqrs.Commands.Category
{
    public class DeleteCategoryCommand
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
