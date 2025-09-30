using BusinessLogic.Exceptions;
using DataAccess;

namespace BusinessLogic
{
    internal class NoteService(INoteRepository noteRepository) : INoteService
    {
        public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
        {
            var note = new Note 
            {
                Text = text
            };

            await noteRepository.CreateAsync(note, cancellationToken);
        }

        public async Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken);

            if(note is null)
            {
                throw new NotFoundException($"Note with ID {id} not found!");
            }

            return note.Text!;
        }

        public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken);

            if (note is null)
            {
                throw new NotFoundException($"Note with ID {id} not found!");
            }

            note.Text = newText;
            await noteRepository.UpdateAsync(note, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await noteRepository.GetByIdAsync(id, cancellationToken);

            if (note is null)
            {
                throw new NotFoundException($"Note with ID {id} not found!");
            }

            await noteRepository.DeleteAsync(note, cancellationToken);
        }
    }
}
