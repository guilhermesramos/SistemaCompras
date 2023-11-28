using SolicitAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;
        public void RegistrarCompra(SolicitAgg.SolicitacaoCompra entity)
        {
            context.Set<SolicitAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}
