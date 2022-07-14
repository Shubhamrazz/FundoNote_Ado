﻿using BussinessLayer.Interface;
using DatabaseLayer.NoteModels;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }
        public async Task AddNote(int UserId, NoteModel noteModel)
        {
            try
            {
                await this.noteRL.AddNote(UserId, noteModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<List<NoteResponseModel>> GetAllNotes(int UserId)
        //{
        //    try
        //    {
        //        return await this.noteRL.GetAllNotes(UserId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task UpdateNote(int UserId, int NoteId, UpdateNoteModel noteModel)
        {
            try
            {
                await this.noteRL.UpdateNote(UserId, NoteId, noteModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
