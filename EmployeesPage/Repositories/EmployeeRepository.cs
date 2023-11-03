﻿using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                employee.Passports = GetPassportsForEmployee(employee.Id);
                employee.EduDocuments = GetEduDocumentsForEmployee(employee.Id);
                employee.Workplaces = GetPlacesOfWorkForEmployee(employee.Id);
            }

            return employees;
        }
    }
}