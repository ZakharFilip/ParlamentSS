//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParlamentSS.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class seats_list
    {
        public int id_record { get; set; }
        public int id_composition { get; set; }
        public int id_member { get; set; }
        public string seat_type { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
    
        public virtual parliament_compositions parliament_compositions { get; set; }
        public virtual party_members party_members { get; set; }
    }
}
