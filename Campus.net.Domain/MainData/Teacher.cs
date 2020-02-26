﻿using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Teacher
    {
        public Guid Id { get; }
        public PersonData PersonData { get; }
        public TeacherExpData TeacherExpData { get; }
        public Department Department { get; }
        private List<TeacherSubjectGroup> _teacherSubjectGroups;
        public IReadOnlyCollection<TeacherSubjectGroup> TeacherSubjectGroups
        {
            get
            {
                return _teacherSubjectGroups.AsReadOnly();
            }
            private set
            {
                _teacherSubjectGroups = value.ToList();
            }
        }
        public IReadOnlyCollection<SubjectGroup> SubjectGroups => (from tsg in _teacherSubjectGroups where tsg.Teacher.Id.Equals(Id) select new SubjectGroup(tsg.Subject, tsg.Group)).ToList().AsReadOnly();

        public Teacher(Guid id, PersonData personData, TeacherExpData teacherExpData, List<TeacherSubjectGroup> teacherSubjectGroups, Department department)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(teacherExpData);
            CustomValidator.ValidateObject(teacherSubjectGroups);
            CustomValidator.ValidateObject(department);
            Id = id;
            PersonData = personData;
            TeacherExpData = teacherExpData;
            _teacherSubjectGroups = teacherSubjectGroups;
            Department = department;
        }
    }
}