using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;
using MODEL;
using Android.Widget;
using Android.Views;

namespace MemoryGame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Game game;

        ImageView[] images;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // create game
            game = new Game();
            images = new ImageView[12];

            images[0] = FindViewById<ImageView>(Resource.Id.img1);
            images[0].Click += CardClick;

            images[1] = FindViewById<ImageView>(Resource.Id.img2);
            images[1].Click += CardClick;

            images[2] = FindViewById<ImageView>(Resource.Id.img3);
            images[2].Click += CardClick;

            images[3] = FindViewById<ImageView>(Resource.Id.img4);
            images[3].Click += CardClick;

            images[4] = FindViewById<ImageView>(Resource.Id.img5);
            images[4].Click += CardClick;

            images[5] = FindViewById<ImageView>(Resource.Id.img6);
            images[5].Click += CardClick;

            images[6] = FindViewById<ImageView>(Resource.Id.img7);
            images[6].Click += CardClick;

            images[7] = FindViewById<ImageView>(Resource.Id.img8);
            images[7].Click += CardClick;

            images[8] = FindViewById<ImageView>(Resource.Id.img9);
            images[8].Click += CardClick;

            images[9] = FindViewById<ImageView>(Resource.Id.img10);
            images[9].Click += CardClick;

            images[10] = FindViewById<ImageView>(Resource.Id.img11);
            images[10].Click += CardClick;

            images[11] = FindViewById<ImageView>(Resource.Id.img12);
            images[11].Click += CardClick;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private int getCardIndex(int id)
        {
            int index = -1;
            switch (id)
            {
                case Resource.Id.img1:
                    index = 0;
                    break;
                case Resource.Id.img2:
                    index = 1;
                    break;
                case Resource.Id.img3:
                    index = 2;
                    break;
                case Resource.Id.img4:
                    index = 3;
                    break;
                case Resource.Id.img5:
                    index = 4;
                    break;
                case Resource.Id.img6:
                    index = 5;
                    break;
                case Resource.Id.img7:
                    index = 6;
                    break;
                case Resource.Id.img8:
                    index = 7;
                    break;
                case Resource.Id.img9:
                    index = 8;
                    break;
                case Resource.Id.img10:
                    index = 9;
                    break;
                case Resource.Id.img11:
                    index = 10;
                    break;
                case Resource.Id.img12:
                    index = 11;
                    break;
            }
            return index;
        }

        private int getImageByCardValue(int value)
        {
            int resId = 0;
            switch (value)
            {
                case 1: case 12:
                    resId = Resource.Drawable.one;
                    break;
                case 2: case 11:
                    resId = Resource.Drawable.two;
                    break;
                case 3: case 10:
                    resId = Resource.Drawable.three;
                    break;
                case 4: case 9:
                    resId = Resource.Drawable.four;
                    break;
                case 5: case 8:
                    resId = Resource.Drawable.five;
                    break;
                case 6: case 7:
                    resId = Resource.Drawable.six;
                    break;
            }
            return resId;
        }

        private void CardClick(object sender, System.EventArgs e)
        {
            ImageView img = (ImageView)sender;
            int index = getCardIndex(img.Id);
            if (index != -1) {
                Card card = this.game.GetCard(index);
                // flip card
                card.Flip();
                // if flipped
                if (card.IsFlipped())
                {
                    // set card image
                    int id = getImageByCardValue(card.GetNameNum());
                    img.SetImageResource(id);

                    if (game.AreTheSamePicture(card) == -1)
                    {
                        img.SetImageResource(Resource.Drawable.Card_Back);
                        card.Flip();

                        for (int i = 0; i < 12; i++)
                        {
                            int index2 = getCardIndex(images[i].Id);
                            Card cardRecent = this.game.GetCard(index2);

                            if (images[i].Clickable == true && cardRecent.IsFlipped())
                            {
                                images[i].SetImageResource(Resource.Drawable.Card_Back);
                                cardRecent.Flip();
                                break;
                            }
                        }
                    }
                    else
                    {
                        img.Clickable = false;
                        for (int i = 0; i < 12; i++)
                        {
                            int index2 = getCardIndex(images[i].Id);
                            Card cardRecent = this.game.GetCard(index2);

                            if (images[i].Clickable == true && cardRecent.IsFlipped())
                            {
                                images[i].Clickable = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    img.SetImageResource(Resource.Drawable.Card_Back);
                }
            }
        }

    }
}