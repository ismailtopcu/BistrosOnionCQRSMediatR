using Bistros.Core.Application.Features.CQRS.Commands.Category;
using Bistros.Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Handlers.Category
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest>
    {
        private readonly IRepository<Domain.Entities.Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Domain.Entities.Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return;
            }
            else
            {
                await _repository.DeleteAsync(value);
            }
        }

        
    }
}
