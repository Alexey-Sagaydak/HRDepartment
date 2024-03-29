﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;

namespace CommonClasses
{
    public enum AcademicDegree
    {
        [Description ("Не имеется")]
        none = 0,

        [Description("Кандидат наук")]
        candidate_of_sciences = 1,

        [Description("Доктор наук")]
        doctor_of_sciences = 2
    }

    public enum AcademicTitle
    {
        [Description("Не имеется")]
        none = 0,

        [Description("Доцент")]
        associate_professor = 1,

        [Description("Профессор")]
        professor = 2
    }

    public class Employee
    {
        [Column("id")]
        public long? Id { get; set; }

        [Column("fiasguid")]
        public long FiasGuid { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("academic_degree")]
        [EnumDataType(typeof(AcademicDegree))]
        public AcademicDegree AcademicDegree { get; set; }

        [Column("academic_title")]
        [EnumDataType(typeof(AcademicTitle))]
        public AcademicTitle AcademicTitle { get; set; }

        [Column("snils")]
        public string Snils { get; set; }

        [Column("inn")]
        public string Inn { get; set; }

        [Column("email")]
        public string Email { get; set; }

        public List<Passport> Passports { get; set; }
        public List<Workplace> Workplaces { get; set; }
        public List<EduDocument> EduDocuments { get; set; }
        public List<Order> Orders { get; set; }

        public Employee()
        {
            Id = null;
            Passports = new List<Passport>();
            Workplaces = new List<Workplace>();
            EduDocuments = new List<EduDocument>();
            Orders = new List<Order>();
        }
    }
}
