﻿using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LeaveManagementSystem.Web.Services
{
    public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
    {



        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;


        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            var data = await _context.LeaveTypes.ToListAsync();

            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            return viewData;

        }


        public async Task<T?> Get <T>(int id) where T : class
        {

            var data = _context.LeaveTypes.FirstOrDefault(x => x.Id == id);

            if (data == null)
            {

                return null;

            }

            var viewData = _mapper?.Map<T>(data);
            return viewData;

        }


        public async Task Remove(int id)
        {
            var data = _context.LeaveTypes.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {

                _context.Remove(data);
                await _context.SaveChangesAsync();

            }


        }



        public async Task Edit(LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }


        public async Task Create(LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();


        }

        public async Task<bool> CheckIfLeaveTypeNameExists(string? name)
        {
            var lowercaseName = name.ToLower();

            return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
        }

        public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveType)

        {
            var lowercaseName = leaveType.Name.ToLower();

            return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName) && q.Id != leaveType.Id);
        }

        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }






    }
}


