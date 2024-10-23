using System.ComponentModel.DataAnnotations;

namespace BackEndApi.Models
{
    public class ContactVariables
    {
 
        [Key]
        public int id { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public string phoneNumber { get; set; }

        public string emailAddress { get; set; }



    }
}
