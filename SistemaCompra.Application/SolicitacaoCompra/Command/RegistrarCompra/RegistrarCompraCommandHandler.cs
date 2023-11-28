using MediatR;
using SistemaCompra.Application.Produto.Command.AtualizarPreco;
using SistemaCompra.Domain.ProdutoAggregate;
using SolicitAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    internal class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {

        private readonly SolicitAgg.ISolicitacaoCompraRepository _repository;

        public RegistrarCompraCommandHandler(SolicitAgg.ISolicitacaoCompraRepository repository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _repository = repository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            SolicitAgg.SolicitacaoCompra solicitacaoCompra = new SolicitAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);

            _repository.RegistrarCompra(solicitacaoCompra);

            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}
