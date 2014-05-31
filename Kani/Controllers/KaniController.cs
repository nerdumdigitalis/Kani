using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Kani.Biz;
using Kani.Core;
using Kani.Core.Enums;

namespace Kani.Controllers
{
    public class KaniController
    {
        private Table _table;
        private ScoreBoard _scoreBoard;
        private readonly GameBiz _gameBiz = new GameBiz();
        private readonly CardMover _mover = new CardMover();
        private PlayingCard _card;
        private readonly ManualResetEvent _waitObject = new ManualResetEvent(false);
        private bool _waitOver;

        public event EventHandler<GenericArgs<Control>> DisplayControlOnView;
        //public event EventHandler<GenericArgs<Control>> RemoveControlFromView;


        public void NewGame()
        {
            if (_table != null)
            {
                RemoveControl(_table);
            }
            if (_scoreBoard != null) RemoveControl(_scoreBoard);
            _table = new Table();
            _table = new TableFactory().SetTable(_table);
            _scoreBoard = new ScoreBoardFactory().SetScoreBoard();
            DisplayControlOnView(null, new GenericArgs<Control> { Value = _table });
            DisplayControlOnView(null, new GenericArgs<Control> { Value = _scoreBoard });
            foreach (var card in _table.Players[(int)Players.Player1].Hand.PlayersHand)
            {
                card.Click += delegate(object sender, EventArgs e)
                                  {
                                      _card = sender as PlayingCard;
                                      _waitObject.Set();
                                  };
            }
        }

        public void Start()
        {
            var gameThread = new Thread(Game);
            gameThread.Start();
        }

        private void Game()
        {
            PrepareTableForSay();
            Loop(Say, SayOver, Dummy);
            ClearTableForRequestRound();
            Loop(Request, RequestOver, Dummy);
            WaitLoop();
            ClearTableForGame();
            Loop(Laydown, GameOver, RoundOver);
            UpdateScoreBoard();
        }

        private void PrepareTableForSay()
        {
            _table.Player1Say.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode != Keys.Enter) return;
                var textBox = sender as TextBox;
                if (textBox != null)
                    AssignPlayer1Say(textBox.Text);
            };
            DisplayControl(_table.Player1Say);
            DisplayControls(_table.SayLabels);
        }

        private bool Dummy()
        {
            return false;
        }

        private void ClearTableForGame()
        {

        }

        private void UpdateScoreBoard()
        {

        }

        private void Loop(Action action, Func<bool> loopOver, Func<bool> dummy)
        {
            while (!loopOver())
            {
                if (_table.Turn == (int)Players.Player1 && !dummy())
                {
                    _waitObject.WaitOne();
                }
                else
                {
                    Thread.Sleep(loopOver() ? 1300 : 700);
                }
                action();
            }
            Thread.Sleep(2000);
        }

        private void ClearTableForRequestRound()
        {
            RemoveControls(_table.SayLabels);
            RemoveControl(_table.Player1Say);
        }

        #region Game

        private void Laydown()
        {
            if (IsEndOfRound()) return;
            _card = _table.Turn == (int)Players.Player1 ? _card : _gameBiz.Play(_table);
            if (_table.Laydown.IsEmpty()) _table.LaydownSuit = _card.Suit; //Ertu að gera fyrstur? set fyrsta spilið sem borðsort

            if (_table.Turn == (int)Players.Player1)
            {
                //Átt þú spilið sem er beðið um?
                if (_table.HasRequestedCard() && _card.Id != _table.RequestedCard.Id) return;
                //Þú átt ekki spilið sem er beðið um

                //Ert ekki fyrstur að setja niður, er liturinn sá sami og er í borðinu
                if (_card.Suit != _table.LaydownSuit && _table.Players[_table.Turn].Hand.PlayersHand.HasLaydownSuit(_table.LaydownSuit)) return;
                //liturinn er sá sami og er í borðinu eða þú átt ekki spil í borðsortinni, mátt leggja spilið niður

            }
            if (_card.Id == _table.RequestedCard.Id) RemoveControl(_table.RequestedCard);
            ProcessLaydown();
            _waitObject.Reset();
        }

        private void ProcessLaydown()
        {
            _table.Laydown.Add(_card);
            _table.Players[_table.Turn].Hand.PlayersHand.Remove(_card);
            _mover.Move(_card, _table.Position.LayDownPositions[_table.Turn]);
            _table.Turn++;
            if (_table.Turn == 4) _table.Turn = 0;
        }

        private bool IsEndOfRound()
        {
            if (!RoundOver()) return false;
            var winner = _table.Laydown.Where(cards => cards.Suit == _table.LaydownSuit).ToList().HighestCard().BelongsTo;
            _table.Players[winner].Wins++;
            _scoreBoard.Invoke((MethodInvoker)delegate
            {
                _scoreBoard.PlayerScore[winner].Text =
                    _table.Players[winner].Wins.ToString();
            });
            _table.Turn = winner;
            foreach (var playingcard in _table.Laydown)
            {
                _mover.Move(playingcard, new Point(700, 500));
            }

            _table.Laydown.Clear();
            return true;
        }

        private bool GameOver()
        {
            return _table.Players.All(hands => hands.Hand.PlayersHand.IsEmpty()) && _table.Laydown.IsEmpty();
        }

        private bool RoundOver()
        {
            return _table.Laydown.Count == 4;
        }

        #endregion

        #region Say

        private void AssignPlayer1Say(string player1Say)
        {
            _table.Players[(int)Players.Player1].Say = Convert.ToInt32(player1Say);
            _waitObject.Set();
        }

        private void Say()
        {

            if (_table.Players[_table.Turn].Say <= _table.Game.Say)
            {
                _table.Players[_table.Turn].Say = 0;
            }
            else
            {
                _table.Game.Say = _table.Players[_table.Turn].Say;
            }
            _table.Invoke((MethodInvoker)delegate
            {
                _table.SayLabels[_table.Turn].Text =
                    _table.Players[_table.Turn].Say == 0
                        ? "Pass"
                        : (_table.Players[_table.Turn].Say ==
                           13
                               ? "Kani"
                               : _table.Players[_table.Turn].
                                     Say.ToString());
            });
            _table.Turn++;
            if (_table.Turn == 4) _table.Turn = 0;
            _waitObject.Reset();

        }

        private bool SayOver()
        {
            if (_table.Players.Count(hand => hand.Say != 0) == 1)
            {
                _table.Turn = _table.Players.IndexOf(_table.Players.Find(player => player.Say != 0));
                return true;
            }
            return false;
        }
        #endregion

        #region Request

        private bool RequestOver()
        {
            return !_table.IsRequest;
        }

        private void Request()
        {
            _table.RequestCard = _table.Turn == (int)Players.Player1 ? _card : _gameBiz.GetRequestCard(_table);
            _table.LaydownSuit = _table.RequestCard.Suit;

            if (_table.Turn == (int)Players.Player1)
            {
                FlashRequestCards();
            }
            else
            {
                _card = _table.RequestCard;
                _table.RequestedCard = _gameBiz.GetRequestedCard(_table);
                _table.Invoke((MethodInvoker)delegate
                {
                    _table.Controls.Add(_table.RequestedCard);
                });
            }

            ProcessLaydown();
            _table.IsRequest = false;
        }

        private void WaitLoop()
        {
            if (_table.Turn - 1 == (int)Players.Player1)
                while (!_waitOver)
                {
                    _waitObject.WaitOne();
                }
            _waitObject.Reset();
        }

        private void FlashRequestCards()
        {
            _table.RequestedCards = _table.LaydownSuit.GetRequestCards(_table.Players[(int)Players.Player1].Hand.PlayersHand);
            _table.Position.AssignRequestCardPositions(_table.RequestedCards);
            foreach (var card in _table.RequestedCards)
            {
                card.Click += OnRequestCardClick;
            }
            DisplayControls(_table.RequestedCards);
        }

        private void OnRequestCardClick(object sender, EventArgs e)
        {
            _table.RequestedCard = sender as PlayingCard;
            foreach (var card in _table.RequestedCards)
            {
                _table.Controls.Remove(card);
            }
            if (_table.RequestedCard != null)
            {
                _table.Controls.Add(_table.RequestedCard);
                _mover.Move(_table.RequestedCard, new Point(0, 0));
            }
            _waitOver = true;
            _waitObject.Set();
        }

        #endregion

        #region Generic private methods
        
        private void DisplayControls(IEnumerable<Control> cards)
        {
            _table.Invoke((MethodInvoker)delegate
            {
                foreach (var card in cards)
                {
                    _table.Controls.Add(card);
                }
            });
        }

        private void DisplayControl(Control card)
        {
            _table.Invoke((MethodInvoker)delegate
            {
                _table.Controls.Add(card);
            });
        }

        private void RemoveControls(IEnumerable<Control> controls)
        {
            _table.Invoke((MethodInvoker)delegate
            {
                foreach (var card in controls)
                {
                    _table.Controls.Remove(card);
                }

            });
        }

        private void RemoveControl(Control control)
        {
            _table.Invoke((MethodInvoker)delegate
            {
                _table.Controls.Remove(control);
            });
        }

        #endregion


    }

}

