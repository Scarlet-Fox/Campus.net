﻿using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Shared;

namespace Campus.net.Domain.AdditionalData
{
    public class PersonalInfo
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public DateTimeOffset BirthDate { get; }
        public string Adress { get; } //проживания 

        public PersonalInfo(Guid id, string name, string surname, string patronymic, DateTimeOffset birthDate, string adress)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 20);
            CustomValidator.ValidateString(surname, 2, 20);
            CustomValidator.ValidateString(patronymic, 2, 20);
            CustomValidator.ValidateString(adress, 1, 80);
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Adress = adress;
        }
    }
}
