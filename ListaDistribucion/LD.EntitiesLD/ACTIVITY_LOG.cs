﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LD.EntitiesLD;

public partial class ACTIVITY_LOG
{
    public long ID_LOG { get; set; }

    public long ID_CLIENT { get; set; }

    public string OPERATION { get; set; }

    public int ID_USER { get; set; }

    public DateTime DATE_OPERATION { get; set; }

    public string OLD_VALUE { get; set; }

    public string NEW_VALUE { get; set; }
}