using FluentValidation;

namespace SimpleAgileBoard.Application.Notes.Commands.EditNote
{
    public class EditNoteCommandValidator : AbstractValidator<EditNoteCommand>
    {
        public EditNoteCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}