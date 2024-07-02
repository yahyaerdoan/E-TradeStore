namespace E_TradeStore.Application.Features.Cqrs.Commands.Category
{
    public class UpdateCategoryCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
