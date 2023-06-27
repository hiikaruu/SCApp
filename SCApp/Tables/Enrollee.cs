using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SCApp.Tables
{
    [Table("Enrollees")]
    public class Enrollee
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Unique]
        [Required]
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string DtBirth { get; set; }
        public string FullYear { get; set; }
        public string Gender { get; set; }
        public string Сitizenship { get; set; }
        public string Subject { get; set; }
        public string Region { get; set; }
        public string Class { get; set; }
        public string Score { get; set; }
        public string Snils { get; set; }
        public string Education { get; set; }
        public string Speciality { get; set; }
        public string Disability { get; set; }
        public string Ward { get; set; }
        public string Certificate { get; set; }
        public string Enrollment { get; set; }
        public string Year { get; set; }
        public byte[] WardDoc { get; set; }
        public byte[] DisabilityDoc { get; set; }
        public byte[] CertificateDoc { get; set; }
        
        
    }
}
