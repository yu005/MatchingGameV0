using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{
    public class MatchingButton : Button
    {
        //
        private Image backImage;
        private Image frontImage;
        //
        private bool _isShowing = false;
        //
        public MatchingButton(Image backImage, Image frontImage)
        {
            //
            this.backImage = backImage;
            this.frontImage = frontImage;
            this._isShowing = false;
            //
            this.Size = new Size(100, 100);
            this.BackgroundImage = this.backImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }
        //
        public void Show()
        {
            this.BackgroundImage = this.frontImage;
            this._isShowing = true;
        }
        //
        public void Hide()
        {
            this.BackgroundImage = this.backImage;
            this._isShowing = false;
        }
        //
        public bool isShowing()
        {
            return this._isShowing;
        }
    }
}
