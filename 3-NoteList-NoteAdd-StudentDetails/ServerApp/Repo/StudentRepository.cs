using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Repo
{
    public class StudentRepository : IStudentRepository
    {
        private readonly KinderGartenContext _context;
        public StudentRepository(KinderGartenContext context)
        {
            _context=context;
        }

        public async Task<Note> AddNote(Note note)
        {
           var notes = await _context.Notes.AddAsync(note);
           await _context.SaveChangesAsync();
           return notes.Entity;
        }

        public async Task<User> AddUser(User user)
        {
            var student =await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<User> DeleteUser(int userId)
        {
            var existstudent = await GetUserAsync(userId);
            if(existstudent!=null){
                _context.Users.Remove(existstudent);
                await _context.SaveChangesAsync();
                return existstudent;
            }
            return null;
        }
      
        public async Task<bool> ExistUser(int userId)
        {
          return await _context.Users.AnyAsync(x=>x.Id==userId);
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users.Include(nameof(Classes)).ToListAsync();
        }

       
        public async Task<List<Note>> GetNoteByIdAsync(int studentId)
        {
            return await _context.Notes.Where(x=>x.StudentId==studentId).Include(nameof(Lesson)).Include(nameof(Period)).ToListAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
           return await _context.Users.FirstOrDefaultAsync(x=>x.Id==userId);
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<List<Period>> GetAllPeriods()
        {
            return await _context.Periods.ToListAsync();
        }

        public async Task<bool> UpdateProfileImage(int userId, string profileImageUrl)
        {
           var user = await GetUserAsync(userId);
           if(user!=null){
               user.ProfileImageUrl=profileImageUrl;
               await _context.SaveChangesAsync();
               return true;
           }
           return false;
        }

        public async Task<User> UpdateUser(int userId, User user)
        {
              var existstudent = await GetUserAsync(userId);
              if(existstudent!=null){
                  existstudent.FirstName=user.FirstName;
                  existstudent.LastName=user.LastName;
                  existstudent.DateOfBirth=user.DateOfBirth;
                  existstudent.Created=DateTime.Now;
                  existstudent.Phone=user.Phone;
                  existstudent.Adres=user.Adres;
          
                  existstudent.Gender=user.Gender;
                  existstudent.ClassId=user.ClassId;
                  existstudent.Role=user.Role;
                  
                   await _context.SaveChangesAsync();
                 return existstudent;


              }
              return null;
        }

        public async Task<Period> GetPeriodName(int id)
        {
            return await _context.Periods.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Lesson> GetLessonName(int id)
        {
            return await _context.Lessons.FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}