using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Application.Interface.Service
{
    public interface IDateTimeProvide
    {
        DateTime UtcNow { get; }
    }
}
