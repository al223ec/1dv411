using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv411.Domain.DbEntities
{
    public class Order : BaseDto
    {
        [Index]
        public Guid OrderGroupId { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Date { get; set; }

        /* * * * * * 
        * The MSDN documentation for datetime recommends using datetime2. Here is their recommendation:
        * Use the time, date, datetime2 and datetimeoffset data types for new work. These types align with the SQL Standard. 
        * They are more portable. time, datetime2 and datetimeoffset provide more seconds precision. datetimeoffset provides 
         * time zone support for globally deployed applications.
        * datetime2 has larger date range, a larger default fractional precision, and optional user-specified precision. 
         * Also depending on the user-specified precision it may use less storage.
        */
    }
}
