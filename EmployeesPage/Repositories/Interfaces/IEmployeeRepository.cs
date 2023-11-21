using CommonClasses;
using System.Collections.Generic;

namespace Employees
{
    public interface IEmployeeRepository
    {
        List<EduDocument> GetEduDocumentsForEmployee(long employeeId);
        Employee GetEmployeeById(long employeeId);
        Order GetOrderById(long? orderId);
        List<Passport> GetPassportsForEmployee(long employeeId);
        List<Workplace> GetPlacesOfWorkForEmployee(long employeeId);
        List<Employee> GetEmployees();
        void UpdatePassport(Passport passport);
        void DeletePassport(long passportId);
        void SaveMainData(Employee employee);
        void UpdateEduDocument(EduDocument eduDocument);
        void DeleteEduDocument(long eduDocumentId);
        void UpdateWorkplace(Workplace workplace);
        void UpdateOrder(Order order);
        void DeleteWorkplace(long workplaceId);
        void DeleteEmployee(long employeeId);
    }
}