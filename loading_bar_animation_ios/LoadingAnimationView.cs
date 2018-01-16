using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace loading_bar_animation_ios
{
    public partial class LoadingAnimationView : UIView
    {
		UIView uiViewToMove;
        int animationTime = 2;
        int animationDelay = 0;
        int animtionWidth = 200;

        public int AnimationTime { get => animationTime; set => animationTime = value; }
        public int AnimationDelay { get => animationDelay; set => animationDelay = value; }
        public int AnimtionWidth { get => animtionWidth; set => animtionWidth = value; }

        public LoadingAnimationView(IntPtr handle) : base(handle)
		{
		}

        public void StartAnimation()
		{

			BuildAnimation(animtionWidth);

			Animate(animationTime, 0, UIViewAnimationOptions.Repeat,
				() => {
                    uiViewToMove.Frame = new CGRect(
                        new CGPoint(animtionWidth + this.Frame.Size.Width, 0),
                        new CGSize(animtionWidth, this.Frame.Size.Height)
                );
				}, null
			);
		}

		public void StartOpacityAnimation()
		{
			this.Layer.BackgroundColor = new UIColor(0.92f, 0.92f, 0.92f, 1.0f).CGColor;

			Animate(animationTime, animationDelay, UIViewAnimationOptions.Repeat,
				() => {
					Layer.BackgroundColor = new UIColor(0.96f, 0.96f, 0.96f, 0.5f).CGColor;
				}, null
			);
		}

		public void StartSyncronizedAnimation()
		{

            BuildAnimation(this.Frame.Location.X + animtionWidth);

			Animate(animationTime, animationDelay, UIViewAnimationOptions.Repeat,
				() => {
                uiViewToMove.Frame = new CGRect(-(this.Frame.Location.X) + UIScreen.MainScreen.Bounds.Width + animtionWidth, 
                                                uiViewToMove.Frame.Y, uiViewToMove.Frame.Width, uiViewToMove.Frame.Height);
				}, null
			);
		}

		void BuildAnimation(double startPosition)
		{

			uiViewToMove = new UIView(
				new CGRect(
					new CGPoint(-startPosition, 0),
					new CGSize(animtionWidth, this.Frame.Size.Height)
				)
			);

			var gradientLayer = new CAGradientLayer();
			gradientLayer.Frame = uiViewToMove.Bounds;
			gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
			gradientLayer.EndPoint = new CGPoint(1.0, 0.5);

			CGColor[] startColors = new CGColor[3];
			startColors[0] = new UIColor(0.96f, 0.96f, 0.96f, 1.0f).CGColor;
			startColors[1] = new UIColor(0.92f, 0.92f, 0.92f, 1.0f).CGColor;
			startColors[2] = new UIColor(0.96f, 0.96f, 0.96f, 1.0f).CGColor;

			gradientLayer.Colors = startColors;
			uiViewToMove.Layer.AddSublayer(gradientLayer);
			uiViewToMove.ClipsToBounds = true;

			this.Layer.BackgroundColor = new UIColor(0.96f, 0.96f, 0.96f, 1.0f).CGColor;
			this.ClipsToBounds = true;
			this.AddSubview(uiViewToMove);
			this.SendSubviewToBack(uiViewToMove);
		}
	}
}