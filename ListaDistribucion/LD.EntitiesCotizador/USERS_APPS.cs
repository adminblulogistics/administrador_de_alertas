﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LD.EntitiesCotizador;

public partial class USERS_APPS
{
    public int ID_USER { get; set; }

    public string ID_USER_SF { get; set; }

    public string ID_USER_CW { get; set; }

    public string USERNAME { get; set; }

    public string DOCUMENT_NUMBER { get; set; }

    public string FIRST_NAME { get; set; }

    public string LAST_NAME { get; set; }

    public string POSITION { get; set; }

    public string EMAIL { get; set; }

    public bool? IS_ACTIVE { get; set; }

    public string BRANCH { get; set; }

    public int? ID_COMPANY { get; set; }

    public bool? CHANGE_COUNTRY { get; set; }

    public int? DEFAULT_ROL { get; set; }

    public virtual ICollection<SALES_SUPPORTS> SALES_SUPPORTSID_COMERCIALNavigation { get; set; } = new List<SALES_SUPPORTS>();

    public virtual ICollection<SALES_SUPPORTS> SALES_SUPPORTSID_SALE_SUPPORTNavigation { get; set; } = new List<SALES_SUPPORTS>();
}