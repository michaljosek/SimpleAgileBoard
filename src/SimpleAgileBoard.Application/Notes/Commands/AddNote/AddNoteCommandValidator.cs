using FluentValidation;

namespace SimpleAgileBoard.Application.Notes.Commands.AddNote
{
    public class AddNoteCommandValidator : AbstractValidator<AddNoteCommand>
    {
        public AddNoteCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}