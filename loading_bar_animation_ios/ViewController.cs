using System;

using UIKit;

namespace loading_bar_animation_ios
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            startBtn.TouchUpInside += (sender, e) => {
                containerAnimation1.StartAnimation();
                containerAnimation2.StartAnimation();
                containerAnimation3.StartAnimation();

                containerAnimation4.StartSyncronizedAnimation();
				containerAnimation5.StartSyncronizedAnimation();
				containerAnimation6.StartSyncronizedAnimation();

                containerAnimation7.StartOpacityAnimation();
                containerAnimation8.StartOpacityAnimation();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
