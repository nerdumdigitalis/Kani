using System.Drawing;
using System.Windows.Forms;

namespace Kani
{
    public class PlayingCard : Panel
    {
        public string CardName { get; set; }
        public int Suit { get; set; }
        public string SuitName { get; set; }
        public int CardNumber { get; set; }
        public string CardNumberName { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public Image Image { get; set; }
        public Image BackImageVertical { get; set; }
        public Image BackImageHorizontal { get; set; }
        public Size VerticalSize { get; set; }
        public Size HorizontalSize { get; set; }
        public int BelongsTo { get; set; }

    }


}
