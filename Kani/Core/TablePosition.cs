using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kani.Core
{
    public class TablePosition
    {

        private int _cardSpacing;
        private int _tableHeight;
        private int _tableWidth;
        private int _handLength;
        private int _margin;
        private int _cardHeight;
        private int _cardWidth;
        private Point _tableCenter;

        public List<Point> LayDownPositions { 
            get
            {
                return new List<Point>
                           {
                               new Point(_tableCenter.X - _cardSpacing - _cardSpacing/2 - 2*_cardWidth, _tableCenter.Y - _cardHeight/2),
                               new Point(_tableCenter.X - _cardSpacing/2 - _cardWidth, _tableCenter.Y - _cardHeight/2),
                               new Point(_tableCenter.X + _cardSpacing/2, _tableCenter.Y - _cardHeight/2),
                               new Point(_tableCenter.X + _cardSpacing + _cardSpacing/2 + _cardWidth, _tableCenter.Y - _cardHeight/2)
                           };
            }
        }

        public List<Point> SayPosition {
            get
            {
                return new List<Point>
                           {
                               new Point(380, 430),
                               new Point(150, 300),
                               new Point(380, 200),
                               new Point(550, 300)
                           };
            }
        }

        public Point PlayerSayPosition { 
            get { return new Point(380, 600); }
        }

        public TablePosition(Table table)
        {
            PopulatePositions(table.Size);
        }

        private void PopulatePositions(Size tableSize)
        {

            _tableHeight = tableSize.Height;
            _tableWidth = tableSize.Width;
            _cardHeight = 96;
            _cardWidth = 71;
            _cardSpacing = 20;
            _handLength = 12 * _cardSpacing + 71;
            _margin = 50;
            _tableCenter = new Point(_tableWidth/2, _tableHeight/2);
        }

        public Point GetDealingPosition(int hand, int card)
        {
            switch (hand)
            { 
                case 0:
                    return new Point((_tableWidth + _handLength / 2) / 2 - card * _cardSpacing, _tableHeight - _margin - _cardHeight);
                case 1:
                    return new Point(_margin, (_tableHeight + _handLength / 2) / 2 - card * _cardSpacing);
                case 2:
                    return new Point((_tableWidth + _handLength / 2) / 2 - card * _cardSpacing, _margin);
                case 3:
                    return new Point(_tableWidth - _margin - _cardHeight, (_tableHeight + _handLength / 2) / 2 - card * _cardSpacing);
                default:
                    throw new Exception("Illegal hand has been passed to GetDealingPosition");


            }
        }

        public List<PlayingCard> AssignRequestCardPositions(List<PlayingCard> cards)
        {
            var i = 0;
            foreach (var card in cards)
            {
                card.Location = new Point(_tableCenter.X + 100 - i*(_cardSpacing+10), _tableCenter.Y-100);
                i++;
            }
            return cards; 
        }

    }
}
