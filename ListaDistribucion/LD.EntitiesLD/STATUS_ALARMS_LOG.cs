﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LD.EntitiesLD;

public partial class STATUS_ALARMS_LOG
{
    public long ID_STATUS { get; set; }

    public int? ID_ALARMA { get; set; }

    public int? ID_STATUS_SEND { get; set; }

    public string RECIPIENTS { get; set; }

    public string MESSAGE_SEND { get; set; }

    public string MESSAGE_ERROR { get; set; }

    public DateTime? DATE_CREATED { get; set; }

    public long? ID_ORGANIZATION { get; set; }

    public virtual STATUS_SEND_TYPE ID_STATUS_SENDNavigation { get; set; }
}