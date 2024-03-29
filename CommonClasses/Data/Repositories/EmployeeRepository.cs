﻿using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Employees
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private DBContext DBContext => Context as DBContext;

        public EmployeeRepository(DBContext dBContext) : base(dBContext) { }

        public Employee GetEmployeeById(long employeeId)
        {
            var employee = DBContext.employees.SingleOrDefault(e => e.Id == employeeId);
            employee.Passports = GetPassportsForEmployee(employeeId);
            employee.EduDocuments = GetEduDocumentsForEmployee(employeeId);
            employee.Workplaces = GetPlacesOfWorkForEmployee(employeeId);
            return employee;
        }

        public void UpdatePassport(Passport passport)
        {
            var existingPassport = DBContext.passports
                .SingleOrDefault(p => p.Id == passport.Id);

            if (existingPassport != null)
            {
                existingPassport.DateOfBirth = passport.DateOfBirth;
                existingPassport.PlaceOfBirth = passport.PlaceOfBirth;
                existingPassport.DateOfIssue = passport.DateOfIssue;
                existingPassport.PlaceOfIssue = passport.PlaceOfIssue;
                existingPassport.Series = passport.Series;
                existingPassport.Number = passport.Number;
                existingPassport.Name = passport.Name;
                existingPassport.Surname = passport.Surname;
                existingPassport.MiddleName = passport.MiddleName;
                existingPassport.Gender = passport.Gender;

                DBContext.SaveChanges();
            }
            else
            {
                long? maxId = DBContext.passports.Any() ? DBContext.passports.Max(s => s.Id) : 0;
                passport.Id = maxId + 1;
                DBContext.passports.Add(passport);
                DBContext.SaveChanges();
            }
        }

        public void UpdateEduDocument(EduDocument eduDocument)
        {
            var existingEduDocument = DBContext.edu_documents
                .SingleOrDefault(p => p.Id == eduDocument.Id);

            if (existingEduDocument != null)
            {
                existingEduDocument.EduDocumentTypeId = eduDocument.EduDocumentTypeId;
                existingEduDocument.EduInstitutionId = eduDocument.EduInstitutionId;
                existingEduDocument.DateOfIssue = eduDocument.DateOfIssue;
                existingEduDocument.SpecialtyId = eduDocument.SpecialtyId;
                existingEduDocument.Series = eduDocument.Series;
                existingEduDocument.Number = eduDocument.Number;
                existingEduDocument.Name = eduDocument.Name;
                existingEduDocument.Surname = eduDocument.Surname;
                existingEduDocument.MiddleName = eduDocument.MiddleName;
                existingEduDocument.IsWithHonors = eduDocument.IsWithHonors;
                existingEduDocument.RegistrationNumber = eduDocument.RegistrationNumber;

                DBContext.SaveChanges();
            }
            else
            {
                long? maxId = DBContext.edu_documents.Any() ? DBContext.edu_documents.Max(s => s.Id) : 0;
                eduDocument.Id = maxId + 1;
                DBContext.edu_documents.Add(eduDocument);
                DBContext.SaveChanges();
            }
        }

        public void UpdateWorkplace(Workplace workplace)
        {
            var existingWorkplace = DBContext.places_of_work
                .SingleOrDefault(p => p.Id == workplace.Id);

            UpdateOrder(workplace.Order);

            if (existingWorkplace != null)
            {
                existingWorkplace.OrganizationId = workplace.OrganizationId;
                existingWorkplace.PositionId = workplace.PositionId;
                existingWorkplace.DivisionId = workplace.DivisionId;
                existingWorkplace.KindOfWork = workplace.KindOfWork;
                existingWorkplace.StartOfWork = workplace.StartOfWork;
                existingWorkplace.EndOfWork = workplace.EndOfWork;
                existingWorkplace.Reason = workplace.Reason;

                DBContext.SaveChanges();
            }
            else
            {
                long? maxId = DBContext.places_of_work.Any() ? DBContext.places_of_work.Max(s => s.Id) : 0;
                workplace.Id = maxId + 1;
                workplace.OrderId = workplace.Order.Id;
                DBContext.places_of_work.Add(workplace);

                DBContext.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = DBContext.orders
                .SingleOrDefault(p => p.Id == order.Id);

            if (existingOrder != null)
            {
                existingOrder.TypeOfOrderId = order.TypeOfOrderId;
                existingOrder.DateOfSigning = order.DateOfSigning;
                existingOrder.EffectiveDate = order.EffectiveDate;
                existingOrder.NumberOfOrder = order.NumberOfOrder;

                DBContext.SaveChanges();
            }
            else
            {
                long? maxId = DBContext.orders.Any() ? DBContext.orders.Max(s => s.Id) : 0;
                order.Id = maxId + 1;

                DBContext.orders.Add(order);

                DBContext.SaveChanges();
            }
        }

        public void SaveMainData(Employee employee)
        {
            var existingEmployee = DBContext.employees
                .SingleOrDefault(e => e.Id == employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Email = employee.Email;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
                existingEmployee.Snils = employee.Snils;
                existingEmployee.Inn = employee.Inn;
                existingEmployee.FiasGuid = employee.FiasGuid;
                existingEmployee.AcademicDegree = employee.AcademicDegree;
                existingEmployee.AcademicTitle = employee.AcademicTitle;

                DBContext.SaveChanges();
            }
            else
            {
                long? maxId = DBContext.employees.Any() ? DBContext.employees.Max(s => s.Id) : 0;
                employee.Id = maxId + 1;

                DBContext.employees.Add(employee);

                DBContext.SaveChanges();
            }
        }

        public void DeletePassport(long passportId)
        {
            var passportToDelete = DBContext.passports
                .SingleOrDefault(p => p.Id == passportId);

            if (passportToDelete != null)
            {
                DBContext.passports.Remove(passportToDelete);
                DBContext.SaveChanges();
            }
        }

        public void DeleteEduDocument(long eduDocumentId)
        {
            var eduDocumentToDelete = DBContext.edu_documents
                .SingleOrDefault(p => p.Id == eduDocumentId);

            if (eduDocumentToDelete != null)
            {
                DBContext.edu_documents.Remove(eduDocumentToDelete);
                DBContext.SaveChanges();
            }
        }

        public void DeleteWorkplace(long workplaceId)
        {
            var workplaceToDelete = DBContext.places_of_work
                .SingleOrDefault(p => p.Id == workplaceId);

            if (workplaceToDelete != null)
            {
                DBContext.places_of_work.Remove(workplaceToDelete);
                DBContext.SaveChanges();
            }
        }

        public void DeleteEmployee(long employeeId)
        {
            var employeeToDelete = DBContext.employees
                .SingleOrDefault(p => p.Id == employeeId);

            if (employeeToDelete != null)
            {
                DBContext.employees.Remove(employeeToDelete);
                DBContext.SaveChanges();
            }
        }

        public List<Passport> GetPassportsForEmployee(long employeeId)
        {
            var passports = DBContext.passports
                .Where(p => p.EmployeeId == employeeId)
                .OrderByDescending(p => p.DateOfIssue)
                .ToList();

            return passports;
        }

        public List<EduDocument> GetEduDocumentsForEmployee(long employeeId)
        {
            var eduDocuments = DBContext.edu_documents
                .Where(p => p.EmployeeId == employeeId)
                .ToList();

            return eduDocuments;
        }

        public List<Workplace> GetPlacesOfWorkForEmployee(long employeeId)
        {
            var workplaces = DBContext.places_of_work
                .Where(p => p.EmployeeId == employeeId)
                .ToList();
            foreach (var workplace in workplaces)
            {
                if (workplace.OrderId != null)
                {
                    workplace.Order = GetOrderById(workplace.OrderId);
                }
            }
            return workplaces;
        }

        public Order GetOrderById(long? orderId)
        {
            Order order = DBContext.orders.Find(orderId);

            return order;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = DBContext.employees.ToList();

            foreach (Employee employee in employees)
            {
                employee.Passports = GetPassportsForEmployee((long)employee.Id);
                employee.EduDocuments = GetEduDocumentsForEmployee((long)employee.Id);
                employee.Workplaces = GetPlacesOfWorkForEmployee((long)employee.Id);
            }

            return employees;
        }

        public List<Person> GetEmployeesWithoutQualificationIncreaseLastYearOrNoHigherEducation()
        {
            string sqlQuery = @"
                SELECT employee_id, surname, name, middle_name
                FROM passports
                WHERE (employee_id, date_of_issue) IN (
                    SELECT employee_id, MAX(date_of_issue) AS max_date
                    FROM passports
                    WHERE employee_id NOT IN (
                            SELECT DISTINCT employee_id
                            FROM edu_documents
                            INNER JOIN edu_document_types ON edu_documents.edu_document_type_id = edu_document_types.id
                            WHERE edu_document_types.name = 'Повышение квалификации' AND EXTRACT(YEAR FROM edu_documents.date_of_issue) = EXTRACT(YEAR FROM current_date) - 1
                        )
                    OR
                        employee_id NOT IN (
                            SELECT DISTINCT employee_id
                            FROM edu_documents
                            INNER JOIN edu_document_types ON edu_documents.edu_document_type_id = edu_document_types.id
                            WHERE edu_document_types.name = 'Диплом бакалавра' OR edu_document_types.name = 'Диплом магистра' OR edu_document_types.name = 'Диплом аспиранта'
                        )
                    GROUP BY employee_id
                )";

            return DBContext.persons.FromSqlRaw(sqlQuery).ToList();
        }

        public List<Person> GetDecemberVacationDetails()
        {
            string sqlQuery = @"
                SELECT employee_id, surname, name, middle_name
                FROM passports
                WHERE (employee_id, date_of_issue) IN (
	                SELECT employee_id, MAX(date_of_issue) AS max_date
	                FROM passports
	                WHERE employee_id IN ( 
			                SELECT DISTINCT employee_order.employee_id
			                FROM employee_order
			                INNER JOIN orders ON employee_order.order_id = orders.id
			                INNER JOIN types_of_orders ON types_of_orders.id = orders.type_of_order_id
			                WHERE types_of_orders.name = 'Отпуск' AND EXTRACT(MONTH FROM effective_date) = 12 AND EXTRACT(YEAR FROM effective_date) = 2023
			                )
                        OR
                        employee_id NOT IN ( 
			                SELECT DISTINCT employee_order.employee_id
			                FROM employee_order
			                INNER JOIN orders ON employee_order.order_id = orders.id
			                INNER JOIN types_of_orders ON types_of_orders.id = orders.type_of_order_id
			                WHERE types_of_orders.name = 'Отпуск' AND EXTRACT(MONTH FROM effective_date) < 12 AND EXTRACT(YEAR FROM effective_date) = 2023
			                )
	                GROUP BY employee_id
	                )";

            return DBContext.persons.FromSqlRaw(sqlQuery).ToList();
        }

        public List<PersonWithHours> GetCurrentWorkExperience()
        {
            string sqlQuery = @"
                SELECT p.employee_id, p.name, p.surname, p.middle_name, SUM(w.end_of_work - w.start_of_work) as total_work_duration
                FROM places_of_work AS w
                JOIN (
                    SELECT employee_id, name, surname, middle_name, ROW_NUMBER() OVER (PARTITION BY employee_id ORDER BY date_of_issue DESC) AS rn
                    FROM passports
                ) AS p ON w.employee_id = p.employee_id AND p.rn = 1
                GROUP BY p.employee_id, p.name, p.surname, p.middle_name";

            return DBContext.persons_and_hours.FromSqlRaw(sqlQuery).ToList();
        }
    }
}
