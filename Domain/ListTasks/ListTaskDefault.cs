using Domain.DTOs.ListTasks.AddListTask;
using Domain.ListTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ListTasks
{
    public class ListTaskDefault
    {
        public ListTaskDefault()
        {
            ListTasks = new List<AddListTaskRequest>();

            var listTask1 = new AddListTaskRequest();
            listTask1.Name = "Cơ hội";

            var listTask2 = new AddListTaskRequest();
            listTask2.Name = "Báo giá";

            var listTask3 = new AddListTaskRequest();
            listTask3.Name = "Đơn hàng";

            var listTask4 = new AddListTaskRequest();
            listTask4.Name = "Hoàn thành";

            ListTasks.Add(listTask1);
            ListTasks.Add(listTask2);
            ListTasks.Add(listTask3);
            ListTasks.Add(listTask4);
        }
        public List<AddListTaskRequest> ListTasks { get; set; }
    }
}
