using DatabaseLayer.NoteModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface INoteBL
    {
        Task AddNote(int UserId, NoteModel noteModel);
        Task UpdateNote(int UserId, int NoteId, UpdateNoteModel noteModel);
        Task<List<NoteResponseModel>> GetAllNotes(int UserId);

    }
}
