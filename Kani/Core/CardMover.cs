using Transitions;
using System.Threading;
using System.Drawing;

namespace Kani.Core
{
    public class CardMover
    {
        public void LayDown(PlayingCard card, Point position)
        {
            Move(card, position);
            card.BackgroundImage = card.Image;
            card.Size = card.Image.Size;
        }

        public void Move(PlayingCard card, Point position)
        {
            var t = new Transition(new TransitionType_EaseInEaseOut(500));
            t.add(card, "Left", position.X);
            t.add(card, "Top", position.Y);
            t.run();

        }
    }
}
