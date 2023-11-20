using DemoApi.Domain;
using DemoApi.Domain.Entity.Base;
using System;
using System.Collections.Generic;

namespace DemoApi.Infracstructure.Data;

public partial class Customer : BaseEntity, IEntity<string>
{
    public string Id { get; set; } 

    public string FristName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual Account IdNavigation { get; set; } = null!;

    public string GetKey()
    {
        return Id;
    }
}
