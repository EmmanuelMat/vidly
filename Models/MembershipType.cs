using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class MembershipType
    {
        public string Name { get; set; }
        public int Id { get; set; }
        [Column(TypeName = "BIT")]public bool SignUpFee { get; set; }

        public int DurationMonth { get; set; }
        public int DiscountRate { get; set; }  

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;


    }
}