using System.ComponentModel.DataAnnotations;

namespace simple_CRUD.Models
{
    public class User
    {
        [Key]
        public int U_Id { get; set; }
        public string U_Name { get; set; }
        public int U_Age { get; set; }
        public string U_Designation { get; set; }

    }
}
