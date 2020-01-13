namespace Kibol_Alert.Models
{
    public class Chant
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public string Lyrics { get; set; }
    }
}
