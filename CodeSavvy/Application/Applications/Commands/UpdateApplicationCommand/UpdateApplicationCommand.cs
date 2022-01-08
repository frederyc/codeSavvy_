using MediatR;

namespace CodeSavvy.Application.Applications.Commands.UpdateApplicationCommand
{
    public class UpdateApplicationCommand : IRequest<Domain.Models.Application>
    {
        public int Id { get; set; }
        public string Resume { get; set; }
    }
}
