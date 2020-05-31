using FluentValidation;

namespace SimpleAgileBoard.Application.Lanes.Commands.AddLane
{
    public class AddLaneCommandValidator : AbstractValidator<AddLaneCommand>
    {
        public AddLaneCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}