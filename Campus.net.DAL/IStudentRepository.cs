﻿using Campus.net.Domain;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL
{
    public interface IStudentRepository : IRepository<Student>
    {
        IReadOnlyCollection<Student> GetPaginatedCountOfStudents(PaginationDto paginationDto);
    }
}
