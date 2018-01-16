using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Android.Animation;
using Android.Views.Animations;

namespace loading_bar_animation_android
{
    [Activity(Label = "loading_bar_animation_android", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        View view1;
        View view2;
		View view3;
		View view4;
		View view5;
		View view6;
        RelativeLayout viewC1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            view1 = FindViewById<View>(Resource.Id.view1);
            view2 = FindViewById<View>(Resource.Id.view2);
            view3 = FindViewById<View>(Resource.Id.view3);
            view4 = FindViewById<View>(Resource.Id.view4);
            view5 = FindViewById<View>(Resource.Id.view5);
            view6 = FindViewById<View>(Resource.Id.view6);

            viewC1 = FindViewById<RelativeLayout>(Resource.Id.viewC1);
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            ViewGroup.MarginLayoutParams lParams = (ViewGroup.MarginLayoutParams) viewC1.LayoutParameters;

            animateView(view1);
            animateView(view2, viewC1.Width + lParams.RightMargin);
            animateView(view3, viewC1.Width + lParams.RightMargin);
            animateView(view4);
            animateView(view5);
            animateView(view6);
        }

        void animateView(View view, int margin = 0){

            view.SetX(-view.Width - margin);

			Display display = WindowManager.DefaultDisplay;
			Point displaySize = new Point();
			display.GetSize(displaySize);

			ObjectAnimator animator = ObjectAnimator.OfFloat(view, "translationX", displaySize.X + view.Width - margin);
			animator.SetDuration(2000);
			animator.RepeatCount = Animation.Infinite;
			animator.Start();
        }
    }
}

