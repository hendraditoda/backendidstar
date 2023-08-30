using System;
using System.Collections.Generic;

namespace backendidstar.Models;

public partial class Audittrail
{
    public int Id { get; set; }

    public string? Action { get; set; }

    public string? TableName { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public DateTime? Datetime { get; set; }
}
