using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Interfaces;
using Bistros.Core.Domain.Entities;
using Bistros.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Infrastructure.Persistance.Repositories
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly BistrosContext _context;
        private readonly IMapper _mapper;

        public EfCategoryRepository(BistrosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultCategoryDto>> GetCategoryList()
        {
            var values = await _context.Categories.Include(x => x.Foods).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);

        }
    }
}
