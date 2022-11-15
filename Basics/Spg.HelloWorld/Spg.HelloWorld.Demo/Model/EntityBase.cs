using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Property! = Set-/Get-Methode
        /// </summary>
        [Key]
        public int Id { get; set; }
        public DateTime LastChangeDate { get; set; }
        public int LastChangeUserId { get; set; }
    }
}
