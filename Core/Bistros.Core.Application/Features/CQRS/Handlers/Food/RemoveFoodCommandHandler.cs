using Bistros.Core.Application.Features.CQRS.Commands;
using Bistros.Core.Application.Interfaces;
using Bistros.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Handlers
{
	public class RemoveFoodCommandHandler : IRequestHandler<RemoveFoodCommandRequest>
	{
		private readonly IRepository<Food> _repository;

		public RemoveFoodCommandHandler(IRepository<Food> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveFoodCommandRequest request, CancellationToken cancellationToken)
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
