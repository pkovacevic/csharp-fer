﻿using CourseWorkDuo.Entities;
using System;
using Tynamix.ObjectFiller;

namespace CourseWorkDuo.Entities.Db.Seed
{
    public static class RandomizerExtensions
    {
        public static Filler<Student> SetupStudentGenerator(this Filler<Student> randomStudentGenerator)
        {
            randomStudentGenerator.Setup().
                OnProperty(x => x.Id).IgnoreIt().
                OnProperty(x => x.FirstName).Use(new RealNames(NameStyle.FirstName)).
                OnProperty(x => x.LastName).Use(new RealNames(NameStyle.LastName)).
                OnProperty(x => x.StudentCode).Use(new StudentCodeRandomizer()).
                OnProperty(x => x.Gender).Use(new GenderRandomizer()).
                OnProperty(x => x.CreatedAt).Use(DateTime.UtcNow).
                OnProperty(x => x.UpdatedAt).Use(default(DateTime?));
            return randomStudentGenerator;
        }

    }
}