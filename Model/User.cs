/* No need to declare these with .NET 6.0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/

namespace FirstWebAPI.Model
{
    // Creating User public class
    public class User
    {
         /*
            TIP: 
            write : 'prop' and then click TAB to autocomplete
         */

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

