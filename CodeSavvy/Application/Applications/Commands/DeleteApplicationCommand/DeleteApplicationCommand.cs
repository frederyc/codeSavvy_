using MediatR;

namespace CodeSavvy.Application.Applications.Commands.DeleteApplicationCommand
{
    public class DeleteApplicationCommand : IRequest<Domain.Models.Application>
    {
        public int Id { get; set; }
    }
}
