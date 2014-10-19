using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    public class PlayListListBox : ListBox
    {
        public PlayListListBox() :base()
        {
            var selector = this.GetValue(ListBox.ItemTemplateSelectorProperty) as DataTemplateSelector; 
        }

        public event EventHandler<KeyEventArgs> OnKeyActivated;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (OnKeyActivated != null)
            {
                OnKeyActivated(this, e);

                e.Handled = true;
            }


            //if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) // Is Alt key pressed
            //{
            //    if (e.Key == Key.Up)
            //    {
            //        if (OnSwap != null)
            //        {
            //            OnSwap(this, new SwapArgs{Direction =  Direction.Up, Args = e});

            //            e.Handled = true;
            //        }

            //    }
            //    if (e.Key == Key.Down)
            //    {
            //        if (OnSwap != null)
            //        {
            //            OnSwap(this, new SwapArgs { Direction = Direction.Down ,Args = e});

            //            e.Handled = true;
            //        }
            //    }
            //}

            //if (e.Key == Key.Up)
            //{
            //    if (OnSwap != null)
            //    {
            //        OnSwap(this, new SwapArgs { Direction = Direction.UpUp, Args = e });

            //        e.Handled = true;
            //    }
            //}


            //if (e.Key == Key.Down)
            //{
            //    if (OnSwap != null)
            //    {
            //        OnSwap(this, new SwapArgs { Direction = Direction.DownDown, Args = e });

            //        e.Handled = true;
            //    }
            //}

            if (!e.Handled)
                base.OnKeyDown(e);
        }
    }

   
}
