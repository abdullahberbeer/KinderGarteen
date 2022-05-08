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
        [Route("[controller]/{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] int userId){
            var user = await _studentRepository.GetUserAsync(userId);
            return Ok(_mapper.Map<UserForDetailDTO>(user));
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