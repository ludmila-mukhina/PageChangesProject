//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp8
{
    using System;
    using System.Collections.Generic;
    
    public partial class PassportTable
    {
        public int idCat { get; set; }
        public string UniqueNumber { get; set; }
        public string ColorCat { get; set; }
    
        public virtual CatTable CatTable { get; set; }
    }
}
