//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1zadan.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class CookingSteps
    {
        public int idCookingSteps { get; set; }
        public Nullable<int> idRecipe { get; set; }
        public Nullable<int> stepNumber { get; set; }
        public string stepDiscription { get; set; }
    
        public virtual Recipes Recipes { get; set; }
    }
}
