namespace E_TradeStore.Application.Features.Cqrs.Results.Category
{
    public class GetCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
