using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Domain.Entity.Base
{
    public interface IEntity<TKey> 
    {
        TKey GetKey();
    }
}
