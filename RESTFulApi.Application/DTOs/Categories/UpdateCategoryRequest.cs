﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFulApi.Application.DTOs.Categories
{
    public record UpdateCategoryRequest(string Name, string? Description);
}
