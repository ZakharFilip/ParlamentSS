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
    
    public partial class club_achievements
    {
        public int achievement_id { get; set; }
        public int id_party { get; set; }
        public string title { get; set; }
        public System.DateTime achievement_date { get; set; }
        public string description { get; set; }
    
        public virtual parties parties { get; set; }
    }
}
