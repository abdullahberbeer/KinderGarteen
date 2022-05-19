using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.DTO;
using ServerApp.Models;
using ServerApp.Repo;

namespace ServerApp.Controllers
{
    [ApiController]
    public class UsersController:Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IImageRepository IImageRepository;
        private readonly IMapper _mapper;
        public UsersController(IStudentRepository studentRepository,IImageRepository IImageRepository,IMapper mapper)
        {
            _studentRepository=studentRepository;
            _mapper=mapper;
            this.IImageRepository =IImageRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllUsers(){
            var users = await _studentRepository.GetAllUserAsync();
            return Ok(_mapper.Map<List<UserForListDTO>>(users));
        }
         [HttpGet]
        [Route("[controller]/periods")]
        public async Task<IActionResult> GetAllPeriods(){
            var period = await _studentRepository.GetAllPeriods();
            return Ok(_mapper.Map<List<PeriodsForListDTO>>(period));
        }
         [HttpGet]
        [Route("[controller]/lessons")]
        public async Task<IActionResult> GetAllLessons(){
            var lesson = await _studentRepository.GetAllLessons();
            return Ok(_mapper.Map<List<LessonsForListDTO>>(lesson));
        }
 [HttpGet]
        [Route("[controller]/{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] int userId){
            var user = await _studentRepository.GetUserAsync(userId);
            return Ok(_mapper.Map<UserForDetailDTO>(user));
        }
         [HttpGet]
        [Route("[controller]/note/{studentId}")]
        public async Task<IActionResult> GetNote([FromRoute] int studentId){
            var note = await _studentRepository.GetNoteByIdAsync(studentId);
            return Ok(_mapper.Map<List<NoteForDetailDTO>>(note));
        }
        [HttpGet]
        [Route("[controller]/classes/{teacherId}")]
        public async Task<IActionResult> GetClassesById([FromRoute] int teacherId){
            var classess = await _studentRepository.GetClassByUserId(teacherId);
            return Ok(_mapper.Map<List<ClassForUserDTO>>(classess));
        }
        [HttpGet]
        [Route("[controller]/classesforlistuser/{classId}")]
        public async Task<IActionResult> GetClassesForListUsers([FromRoute] int classId){
            var classess = await _studentRepository.GetClass(classId);
            return Ok(_mapper.Map<ClassForListUsers>(classess));
        }
           [HttpGet]
        [Route("[controller]/periodfindername/{periodId}")]
        public async Task<IActionResult> GetPeriodName([FromRoute] int periodId){
            var note = await _studentRepository.GetPeriodName(periodId);
            return Ok(_mapper.Map<NameFinderDTO>(note));
        }
        [HttpPost]
        [Route("[controller]/addnote")]
        public async Task<IActionResult> AddNotes([FromBody]NoteForAdd model)
        {

            var notes = await _studentRepository.AddNote(_mapper.Map<Note>(model));
            if(notes!=null){
                return Ok(_mapper.Map<Note>(notes));
            }
            return BadRequest("Bir hata oluştu.");
        }
         [HttpPut]
        [Route("[controller]/{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId,[FromBody]UserForUpdateDTO model){
            if(await _studentRepository.ExistUser(userId)){
                  var user = await _studentRepository.UpdateUser(userId,_mapper.Map<User>(model));

                  if(user!=null){
                      return Ok(_mapper.Map<User>(user));
                  }
            }
            
            
            return NotFound();
        }
        [HttpPost]
        [Route("[controller]/{userId}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] int userId,IFormFile profileImage){
            var validExtensions = new List<string>{
                ".jpeg",
                ".png",
                ".gif",
                ".jpg"
            };

            if(profileImage!=null && profileImage.Length>0){
                    var extensions = Path.GetExtension(profileImage.FileName);

                    if(validExtensions.Contains(extensions)){

                        if(await _studentRepository.ExistUser(userId)){
                        var fileName = Guid.NewGuid() +Path.GetExtension(profileImage.FileName);
                        var fileImagePath =await IImageRepository.Upload(profileImage,fileName);
                        if(await _studentRepository.UpdateProfileImage(userId,fileImagePath)){
                            return Ok(fileImagePath);
                        }
                        return StatusCode(StatusCodes.Status500InternalServerError,"Sunucu Hatası!");
                        }
                    }
                    return BadRequest("Hatalı Format");
            }
            return NotFound();
        }
    }
}