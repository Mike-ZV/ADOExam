//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADOExam.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vacancies
    {
        public int VacancyID { get; set; }
        public string VacancyName { get; set; }
        public string VacancyURL { get; set; }
        public string VacancyDescription { get; set; }
        public string VacancyAuthorEMail { get; set; }
        public System.DateTime VacancyPublishingDate { get; set; }
        public int CategoryID { get; set; }
    }
}
