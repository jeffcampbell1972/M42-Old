using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M42.Data.Models
{
    [Table("MusicianGenres", Schema = "Music")]
    public class MusicianGenre
    {
        [Key]
        public int Id { get; set; }

        public int MusicianId { get; set; }
        public int GenreId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Genre Genre { get; set; }
    }
}