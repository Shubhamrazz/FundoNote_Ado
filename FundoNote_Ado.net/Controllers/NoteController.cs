using BussinessLayer.Interface;
using DatabaseLayer.NoteModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNote_Ado.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        INoteBL noteBL;
        public NoteController(INoteBL noteBL)
        {
            this.noteBL = noteBL;
        }


        [Authorize]
        [HttpPost("AddNote")]
        public async Task<IActionResult> Index(NoteModel noteModel)
        {
            if (noteModel == null)
            {
                return BadRequest("Note is null.");
            }
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                await this.noteBL.AddNote(UserId, noteModel);
                return Ok(new { success = true, Message = "Note Created Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost("GetAllNotes")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                var result = await this.noteBL.GetAllNotes(UserId);
                return Ok(new { success = true, Message = "All Notes Fetch Successfully", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Authorize]
        [HttpPut("UpdateNote/{id}")]
        public async Task<IActionResult> UpdateNote(int id, UpdateNoteModel noteModel)
        {
            if (noteModel == null)
            {
                return BadRequest("Note is null.");
            }
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                await this.noteBL.UpdateNote(UserId, id, noteModel);
                return Ok(new { success = true, Message = "Update Successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Note Doesn't Exist")
                {
                    return BadRequest("Note Does not Exist");
                }
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("DeleteNote/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                await this.noteBL.DeleteNote(UserId, id);
                return Ok(new { success = true, Message = "Deleted SuccessFully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Note Does not Exists")
                {
                    return this.BadRequest(new { success = false, Message = "Note Does not Exists" });

                }
                throw ex;
            }
        }
    }
}
