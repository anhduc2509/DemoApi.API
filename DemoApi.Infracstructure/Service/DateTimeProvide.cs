using DemoApi.Application.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Service
{
    public class DateTimeProvide : IDateTimeProvide
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
