using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_MVC.Models
{
    /// <summary>
    /// TEntity: THis will be a Entity CLass
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ResponseObject<TEntity> where TEntity : class
    {
        /// <summary>
        /// ALl Records
        /// </summary>
        public List<TEntity>? Records { get; set; }
        /// <summary>
        /// SIngle REcord 
        /// </summary>
        public TEntity? Record { get; set; }
        /// <summary>
        /// MEssage of Execution either sucess or error
        /// </summary>
        public string? Message { get; set; }
    }
}
