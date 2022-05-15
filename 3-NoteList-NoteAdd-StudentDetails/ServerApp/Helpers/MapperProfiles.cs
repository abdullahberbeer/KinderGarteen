using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Helpers
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
           CreateMap<User,UserForListDTO>().ReverseMap();
           CreateMap<User,UserForDetailDTO>().ReverseMap();
           CreateMap<User,UserForUpdateDTO>().ReverseMap();
           CreateMap<Note,NoteForAdd>().ReverseMap();
           CreateMap<Note,NoteForDetailDTO>().ReverseMap();
         
          
        
           CreateMap<Period,PeriodsForListDTO>().ReverseMap();
          
           CreateMap<Lesson,LessonsForListDTO>().ReverseMap();
           CreateMap<Period,NameFinderDTO>().ReverseMap();
           CreateMap<Lesson,NameFinderDTO>().ReverseMap();
        }
    }
}