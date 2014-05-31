using System;
using System.Windows.Forms;
using Kani.Controllers;
using Kani.Core;

namespace Kani
{
    public partial class PlayingTableView : Form
    {
        private readonly KaniController _game = new KaniController();

        public PlayingTableView()
        {
            InitializeComponent();
            _game.DisplayControlOnView += DisplayControlOnView;
            //_game.RemoveControlFromView += RemoveControl;
        }


        private void Play(object sender, EventArgs e)
        {
            _game.NewGame();
            _game.Start();
        }

        private void DisplayControlOnView(object sender, GenericArgs<Control> e)
        {
            if (e.Value != null) Controls.Add(e.Value);
        }

        //private void RemoveControl(object sender, GenericArgs<Control> e)
        //{
        //    if (e.Value != null) 
        //        Invoke((MethodInvoker) (delegate { Controls.Remove(e.Value); }));
        //}

    }
}
