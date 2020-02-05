﻿using Campus.net.Domain.AdditionalData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.MainData
{
    public class Group
    {
        public Guid Id { get; }
        private readonly List<Student> _students;
        private readonly List<Subject> _subjects;
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
        public IReadOnlyCollection<Subject> Subjects => _subjects.AsReadOnly();
        public GroupName GroupName { get; }

        public Group(Guid id, List<Student> students, List<Subject> subjects, GroupName groupName)
        {
            Id = id;
            _students = students;
            _subjects = subjects;
            GroupName = groupName;
        }
    }
}
