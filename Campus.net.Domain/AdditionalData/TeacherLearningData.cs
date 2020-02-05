﻿using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.Domain.AdditionalData
{
    public class TeacherLearningData
    {
        public Guid Id { get; }
        private readonly List<Group> _groups;
        private readonly List<Subject> _subjects;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public IReadOnlyCollection<Subject> Subjects => _subjects.AsReadOnly();

        public TeacherLearningData(Guid id, List<Group> groups, List<Subject> subjects)
        {
            Id = id;
            _groups = groups;
            _subjects = subjects;
        }
    }
}
