//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyQuizApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public int Id { get; set; }
        public string Answer1 { get; set; }
        public Nullable<bool> IsCorrect { get; set; }
        public Nullable<int> QuestionId { get; set; }
    
        public virtual Question Question { get; set; }
    }
}