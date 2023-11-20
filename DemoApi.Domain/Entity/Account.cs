using DemoApi.Domain;
using DemoApi.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApi.Infracstructure.Data;

public partial class Account : BaseEntity, IEntity<string>
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } 

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public string GetKey()
    {
        return this.Id;
    }
}
