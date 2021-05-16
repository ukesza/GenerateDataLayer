using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Sample.Entities
{
    /// <summary>
    /// Represents a TableA.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("TableA")]
	public class TableA 
    {
        [Key]
        public int Id { get; set; }
 
        public string StringColumn { get; set; }
    }
}      
