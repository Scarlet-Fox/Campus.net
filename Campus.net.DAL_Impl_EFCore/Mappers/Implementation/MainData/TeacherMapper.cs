﻿using System.Collections.Generic;
using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.Relational;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.Relational;
using Campus.net.Domain.MainData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class TeacherMapper : ITeacherMapper
    {
        private readonly CampusDbContext _context;
        private readonly ITsgMapper _tsgMapper;
        private readonly IPersonDataMapper _personDataMapper;
        private readonly ITeacherExpDataMapper _teacherExpDataMapper;
        public TeacherMapper(CampusDbContext context)
        {
            _context = context;
            _tsgMapper = new TsgMapper(context);
            _personDataMapper = new PersonDataMapper();
            _teacherExpDataMapper = new TeacherExpDataMapper();
        }

        public TeacherDbModel ModelToEntity(Teacher item)
        {
            return new TeacherDbModel(item.Id, item.PersonData.Id, item.TeacherExpData.Id, item.DepartmentId);
        }

        public Teacher EntityToModel(TeacherDbModel item)
        {
            var tsDbModelLinks = _context.TeacherSubjects.Where(ts => ts.TeacherDbModelId.Equals(item.Id)).ToList();
            var tsgDbModelList = new List<TeacherSubject_GroupDbModel>();
            foreach (var ts in tsDbModelLinks)
            {
                tsgDbModelList.AddRange(_context.TeacherSubject_Groups.ToList()
                    .Where(tsg => tsg.TeacherSubjectDbModelId.Equals(ts.Id)));
            }
            return new Teacher(
                (from teacherSubjectGroupDbModel in tsgDbModelList select _tsgMapper.EntityToModel(teacherSubjectGroupDbModel)).ToList(),
                item.Id,
                _personDataMapper.EntityToModel(_context.PersonDatas.Find(item.PersonDataDbModelId)),
                _teacherExpDataMapper.EntityToModel(_context.TeacherExpDatas.Find(item.TeacherExpDataDbModelId)),
                item.DepartmentDbModelId
            );
        }
    }
}
