using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class EmployeesTable
    {
        public EmployeesTable()
        {
            Employees = new ObservableCollection<EmployeeEntity>();
            for (int i = 0; i < 15; i++)
            {
                Employees.Add(new EmployeeEntity());
            }
        }

        public ObservableCollection<EmployeeEntity> Employees { get; set; }
    }
}