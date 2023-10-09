using MediatR;

namespace Bistros.Core.Application.Features.CQRS.Commands
{
	public class RemoveFoodCommandRequest :IRequest
	{
		public RemoveFoodCommandRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
