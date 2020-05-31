using FluentValidation;

namespace SimpleAgileBoard.Application.Boards.Commands.EditBoard
{
    public class EditBoardCommandValidator : AbstractValidator<EditBoardCommand>
    {
        public EditBoardCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NotePrefix).NotNull().NotEmpty();
        }
    }
}