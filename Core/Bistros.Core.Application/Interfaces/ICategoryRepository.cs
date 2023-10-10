using Bistros.Core.Application.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetCategoryList();
    }
}
