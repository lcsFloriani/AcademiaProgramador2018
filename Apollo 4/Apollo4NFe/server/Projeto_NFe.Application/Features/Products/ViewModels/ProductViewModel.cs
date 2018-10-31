namespace Projeto_NFe.Application.Features.Products.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }
        public double AliquotICMS { get => 0.04; }
        public double AliquotIPI { get => 0.10; }
    }
}
