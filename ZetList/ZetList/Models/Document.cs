using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZetList.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Info2 { get; set; }
        public string FilePath { get; set; }
        public string NameAndFilePath { get; set; }



    }
}
