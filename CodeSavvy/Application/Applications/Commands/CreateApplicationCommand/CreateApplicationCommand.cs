using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Applications.Commands.CreateApplicationCommand
{
    public class CreateApplicationCommand : IRequest<Domain.Models.Application>
    {
        public Job Job { get; set; }
        public Employee Employee { get; set; }
        public string Resume { get; set; }
    }
}
