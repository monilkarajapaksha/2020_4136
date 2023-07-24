using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_App.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public double GPA { get; set; }

       public string Image { get; set; }

        public string ImageUrl
        {
            get
            {
                return $"/Images/{Image}";
            }

        }
    }
}
