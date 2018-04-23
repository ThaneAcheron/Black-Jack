using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Threading.Tasks;
using System.Threading;
using System.Media;


namespace BlackJackCTI
{
    /// <summary>
    /// Description: This page of code configures the visual aspects of the program by using multiple image
    /// events. StoryBoards are used the animate the cards.
    /// Region AIActions contains the logic for the dealers decisions.
    /// 
    /// Author:  Craig Turner
    /// Created: FinshedDate: 2014/10/08
    /// OS used: Windows 7 x32
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainMenu and Variables 
        #region Variables

        //VARIABLES 

        //Used in the dispatchertimer method to sync the operations of the GUI to make a smooother look
        int countOne = 0;
        int countTwo = 0;

        //Version: used to incremeant new instances of the hit event
        int version = 1;
        int BankerVersion = 1;

        //PosY/PosX: used to incremeant the next position of the cards on the MainWindow
        int BankerposY = 344;
        int BankerposX = 65;
        int PlayerposY = 344;
        int PlayerposX = 271;
                                    //RUNTIME CARDS 
        //These images are used under the hit event to create new cards during runtime
        Image Img1;
        Image Img2;
        Image Img3;
        Image Img4;
        Image Img5;
        Image Img6;
        Image Img7;
        Image Img8;

        //These images are created until the dealer has reached a total value of 17
        Image BImg1;
        Image BImg2;
        Image BImg3;
        Image BImg4;
        Image BImg5;
        Image BImg6;
        Image BImg7;
        Image BImg8;

        //Used to hold the total values of the player and bankers hands

        int PlayerTotal;
        int BankerTotal;
        int resultint;
        string resultstring;

        //Delcare the dispatchertimer 
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        //Check if the card has been turned
        bool UpSideDownCard = true; 

        //Variable to determain weather the sound is on or not
        bool soundstatus = true;

        #endregion 
        #region Initialize
        public MainWindow()
        {
            InitializeComponent();

            //Hide GameButtons and images

            DealButton.Visibility = Visibility.Collapsed;
            HitButton.Visibility = Visibility.Collapsed;
            StayButton.Visibility = Visibility.Collapsed;
            EndSessionButton.Visibility = Visibility.Collapsed;
            Card1.Visibility = Visibility.Collapsed;
            Card2.Visibility = Visibility.Collapsed;
            Card5.Visibility = Visibility.Collapsed;
            Card4.Visibility = Visibility.Collapsed;
            NotificationPannel.Visibility = Visibility.Collapsed; 
            PlayerTotalValueLabel.Visibility = Visibility.Collapsed;
            LosesLabel.Visibility = Visibility.Collapsed;
            WinLabel.Visibility = Visibility.Collapsed;
            TieLabel.Visibility = Visibility.Collapsed;
            BankerTotalValueLabel.Visibility = Visibility.Collapsed;
            NotificationLabel.Visibility = Visibility.Collapsed;
            Card3.Visibility = Visibility.Collapsed;
            PlayerPointerText.Visibility = Visibility.Collapsed;
            BankerPointerText.Visibility = Visibility.Collapsed;
            DealGrey.Visibility = Visibility.Hidden;
            ContinueButton.Visibility = Visibility.Collapsed;
            HitGrey.Visibility = Visibility.Collapsed;
            StayGrey.Visibility = Visibility.Collapsed;

            BackGroundImage.Source = new BitmapImage(new Uri("/Images/standard.jpg", UriKind.RelativeOrAbsolute));

            //Set Defaults for images 

            HitButton.Source = new BitmapImage(new Uri("/Images/HitGreyedOut.jpg", UriKind.RelativeOrAbsolute));
            HitButton.IsEnabled = false; 

            StayButton.Source = new BitmapImage(new Uri("/Images/StayGreyedOut.jpg", UriKind.RelativeOrAbsolute));
            StayButton.IsEnabled = false;


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        #endregion 
        #region MainMenu

        private void NewGameButton_MouseEnter(object sender, MouseEventArgs e)
        {
            NewGameButton.Source = new BitmapImage(new Uri("/Images/NewMouseOver.jpg", UriKind.RelativeOrAbsolute));
        }

        private void NewGameButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewGameButton.Source = new BitmapImage(new Uri("/Images/NewMouseDown.jpg", UriKind.RelativeOrAbsolute));
        }

        private void NewGameButton_MouseLeave(object sender, MouseEventArgs e)
        {
            NewGameButton.Source = new BitmapImage(new Uri("/Images/NewMouseExit.jpg", UriKind.RelativeOrAbsolute));
        }

        private void NewGameButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BackGroundImage.Source = new BitmapImage(new Uri("/Images/GameStandard.jpg", UriKind.RelativeOrAbsolute));
            NewGameButton.Visibility = Visibility.Collapsed;
            QuitButton.Visibility = Visibility.Collapsed;
            DealButton.Visibility = Visibility.Visible;
            HitButton.Visibility = Visibility.Hidden;
            StayButton.Visibility = Visibility.Hidden;
            EndSessionButton.Visibility = Visibility.Visible;
            NotificationPannel.Visibility = Visibility.Visible;
            DealGrey.Visibility = Visibility.Visible;
            HitGrey.Visibility = Visibility.Visible;
            StayGrey.Visibility = Visibility.Visible;
            PlayerTotalValueLabel.Visibility = Visibility.Visible;
            LosesLabel.Visibility = Visibility.Visible;
            WinLabel.Visibility = Visibility.Visible;
            TieLabel.Visibility = Visibility.Visible;
            BankerTotalValueLabel.Visibility = Visibility.Visible;
            HitGrey.Visibility = Visibility.Visible;
            StayGrey.Visibility = Visibility.Visible;
            DealButton.Source = new BitmapImage(new Uri("/Images/DealNormal.jpg", UriKind.RelativeOrAbsolute));

            //Animate the notification pannel 

            NotificationLabel.Content = "Deal to start";
            NotificationLabel.Visibility = Visibility.Visible;

            NotificationLabel.RegisterName("Result1", NotificationLabel);

            // Create a DoubleAnimation #1
            DoubleAnimation PointAnimate = new DoubleAnimation();
            PointAnimate.From = 5;
            PointAnimate.To = 0;
            PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(3));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate, NotificationLabel.Name);
            Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
            myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

            // Animate the button when it's clicked.           
            myWidthAnimatedButtonStoryboard2.Begin(this);
        }

        private void QuitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            QuitButton.Source = new BitmapImage(new Uri("/Images/QuitMouseOver.jpg", UriKind.RelativeOrAbsolute));
        }

        private void QuitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            QuitButton.Source = new BitmapImage(new Uri("/Images/QuitMouseDown.jpg", UriKind.RelativeOrAbsolute));
        }

        private void QuitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            QuitButton.Source = new BitmapImage(new Uri("/Images/QuitMouseExit.jpg", UriKind.RelativeOrAbsolute));
        }

        private void QuitButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion 

        //GameMenu
        #region HitEvents 
        private void HitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            HitButton.Source = new BitmapImage(new Uri("/Images/HitMouseOver.jpg", UriKind.RelativeOrAbsolute));
        }

        private void HitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HitButton.Source = new BitmapImage(new Uri("/Images/HitMouseDown.jpg", UriKind.RelativeOrAbsolute));
        }

        private void HitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            HitButton.Source = new BitmapImage(new Uri("/Images/HitNormal.jpg", UriKind.RelativeOrAbsolute));
        }

        private void HitButton_MouseUp(object sender, MouseButtonEventArgs e )
        {
            HitButton.Source = new BitmapImage(new Uri("/Images/HitNormal.jpg", UriKind.RelativeOrAbsolute));

            //Animate the notification 

            NotificationLabel.Content = "Hit!";
            NotificationLabel.Visibility = Visibility.Visible;

            NotificationLabel.RegisterName("Result1", NotificationLabel);

            // Create a DoubleAnimation #1
            DoubleAnimation PointAnimate1 = new DoubleAnimation();
            PointAnimate1.From = 5;
            PointAnimate1.To = 0;
            PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(3));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
            Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
            myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

            // Animate the button when it's clicked.           
            myWidthAnimatedButtonStoryboard2.Begin(this);

             // Create a new Image
            //Create an new instance of the image classes and set the proporties, a maxium of 8 cards 

             if (version == 1)
             {
                 Img1 = new Image();
                 Img1.Name = "NewCardOne";
                 Img1.Height = 123;
                 Img1.Width = 79;
                 try
                 {
                     this.RegisterName(Img1.Name, Img1);
                 }
                 catch
                 {
                     Img1.Visibility = Visibility.Collapsed;
                 }
                 (this.Content as Grid).Children.Add(Img1);
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img1);
                 PlayerTotal = NewCard.Total("User");
                 Img1.Visibility = Visibility.Visible;
             }
             else if (version == 2)
             {
                 Img2 = new Image();
                 Img2.Name = "NewCardTwo";
                 Img2.Height = 123;
                 Img2.Width = 79;
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img2);
                 this.RegisterName(Img2.Name, Img2);
                 (this.Content as Grid).Children.Add(Img2);
                 PlayerTotal = NewCard.Total("User");
             }
             else if (version == 3)
             {
                 Img3 = new Image();
                 Img3.Name = "NewCardThree";
                 Img3.Height = 123;
                 Img3.Width = 79;
                 this.RegisterName(Img3.Name, Img3);
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img3);
                 (this.Content as Grid).Children.Add(Img3);
                 PlayerTotal = NewCard.Total("User");
             } 
             else if (version == 4) 
             {
                 Img4 = new Image();
                 Img4.Name = "NewCardFour";
                 Img4.Height = 123;
                 Img4.Width = 79;
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img4);
                 this.RegisterName(Img4.Name, Img4);
                 (this.Content as Grid).Children.Add(Img4);
                 PlayerTotal = NewCard.Total("User");
             }
             else if (version == 5)
             {
                 Img5 = new Image();
                 Img5.Name = "NewCardFive";
                 Img5.Height = 123;
                 Img5.Width = 79;
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img5);
                 this.RegisterName(Img5.Name, Img5);
                 (this.Content as Grid).Children.Add(Img5);
                 PlayerTotal = NewCard.Total("User");
             }
             else if (version == 6)
             {
                 Img6 = new Image();
                 Img6.Name = "NewCardSix";
                 Img6.Height = 123;
                 Img6.Width = 79;
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img6);
                 this.RegisterName(Img6.Name, Img6);
                 (this.Content as Grid).Children.Add(Img6);
                 PlayerTotal = NewCard.Total("User");
             }
             else if (version == 7)
             {
                 Img7 = new Image();
                 Img7.Name = "NewCardSeven";
                 Img7.Height = 123;
                 Img7.Width = 79;
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img7);
                 this.RegisterName(Img7.Name, Img7);
                 (this.Content as Grid).Children.Add(Img7);
                 PlayerTotal = NewCard.Total("User");
             }
             else if (version == 8)
             {
                 Img8 = new Image();
                 Img8.Name = "NewCardEight";
                 Img8.Height = 123;
                 Img8.Width = 79;
                 CheckAndSetCards NewCard = new CheckAndSetCards(Img8);
                 this.RegisterName(Img8.Name, Img8);
                 (this.Content as Grid).Children.Add(Img8);
                 PlayerTotal = NewCard.Total("User");
             } 

            
             // Create a ThicknessAnimation to animate the margin of the images.
             ThicknessAnimation PointAni = new ThicknessAnimation();
             PointAni.From = new Thickness(-1000, -1000, 0, 0);
             PointAni.To = new Thickness(240,43,0,0);
             PlayerposY = PlayerposY + 50;
             PointAni.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

             // Configure the animation to target the images margin property.

             if (version == 1)
             {
                 Storyboard.SetTargetName(PointAni, Img1.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 2)
             {
                 Storyboard.SetTargetName(PointAni, Img2.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 3)
             {
                 Storyboard.SetTargetName(PointAni, Img3.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 4)
             {
                 Storyboard.SetTargetName(PointAni, Img4.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 5)
             {
                 Storyboard.SetTargetName(PointAni, Img5.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 6)
             {
                 Storyboard.SetTargetName(PointAni, Img6.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 7)
             {
                 Storyboard.SetTargetName(PointAni, Img7.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }
             else if (version == 8)
             {
                 Storyboard.SetTargetName(PointAni, Img8.Name);
                 Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
             }

             // Create a storyboard to contain the animation.
             Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
             myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

             // Animate the button when it's clicked.
             try
             {
                 myWidthAnimatedButtonStoryboard.Begin(this);
             }
             catch
             {
                 //continue
             }

             //Increment the version variable to start a new instance next event
             version = version + 1;

             //assign the label 
             PlayerTotalValueLabel.Content = PlayerTotal.ToString();

            //Animate the labels incase of an imdeiate result
             if (PlayerTotal > 21)
             {
                 //Hide the stay and hit buttons 

                 HitButton.Visibility = Visibility.Hidden;
                 StayButton.Visibility = Visibility.Hidden; 

                 //Animate the notification pannel 
                 NotificationLabel.Content = "♠ Bust ♠";
                 NotificationLabel.Visibility = Visibility.Visible;
                 PlayerPointerText.Visibility = Visibility.Visible; 

                 NotificationLabel.RegisterName("Result1",NotificationLabel);
                 PlayerPointerText.RegisterName("ArrowPlayer", PlayerPointerText);

                 // Create a DoubleAnimation #1
                 DoubleAnimation PointAnimate = new DoubleAnimation();
                 PointAnimate.From = 5;
                 PointAnimate.To = 0;
                 PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(2));

                 // Configure the animation to target the button's Width property.
                 Storyboard.SetTargetName(PointAnimate, NotificationLabel.Name);
                 Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));

                 // Create a storyboard to contain the animation.
                 Storyboard myWidthAnimatedButtonStoryboard3 = new Storyboard();
                 myWidthAnimatedButtonStoryboard3.Children.Add(PointAnimate);

                 // Animate the button when it's clicked.           
                 myWidthAnimatedButtonStoryboard2.Begin(this);


                 PointAnimate.From = 5;
                 PointAnimate.To = 0;
                 PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(2));

                 // Configure the animation to target the button's Width property.
                 Storyboard.SetTargetName(PointAnimate, PlayerPointerText.Name);
                 Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));

                 // Create a storyboard to contain the animation.
                 myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

                 // Animate the button when it's clicked.           
                 myWidthAnimatedButtonStoryboard2.Begin(this);

                 CheckAndSetCards GetTotal = new CheckAndSetCards();
                 BankerTotal = GetTotal.Total("OtherBanker");
                 version = 1;

                 //Sync events 
                 dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                 dispatcherTimer.Tick += new EventHandler(DispatcherTimer_TickTwo);
                 dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
                 dispatcherTimer.Start();

             } 
             else if (PlayerTotal == 21)
             {
                 //Hide the stay and hit buttons 

                 HitButton.Visibility = Visibility.Hidden;
                 StayButton.Visibility = Visibility.Hidden;

                 //Animate the notification pannel

                 NotificationLabel.Content = "♠ BlackJack! ♠";
                 NotificationLabel.Visibility = Visibility.Visible;

                 NotificationLabel.RegisterName("Result1", NotificationLabel);
                 // Create a ThicknessAnimation to animate the margin of the images.
                 DoubleAnimation PointAnimate = new DoubleAnimation();
                 PointAnimate.From = 5;
                 PointAnimate.To = 0;
                 PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(1));

                 // Configure the animation to target the button's Width property.
                 Storyboard.SetTargetName(PointAnimate, NotificationLabel.Name);
                 Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));

                 // Create a storyboard to contain the animation.
                 Storyboard myWidthAnimatedButtonStoryboard3 = new Storyboard();
                 myWidthAnimatedButtonStoryboard3.Children.Add(PointAnimate);

                 // Animate the button when it's clicked.           
                 myWidthAnimatedButtonStoryboard3.Begin(this);

                 PointAnimate.From = 5;
                 PointAnimate.To = 0;
                 PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(2));

                 // Configure the animation to target the button's Width property.
                 Storyboard.SetTargetName(PointAnimate, PlayerPointerText.Name);
                 Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));

                 // Create a storyboard to contain the animation.
                 myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

                 // Animate the button when it's clicked.           
                 myWidthAnimatedButtonStoryboard2.Begin(this);

                 CheckAndSetCards GetTotal = new CheckAndSetCards();
                 BankerTotal = GetTotal.Total("OtherBanker");
                 version = 1;

                 dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                 dispatcherTimer.Tick += new EventHandler(DispatcherTimer_TickTwo);
                 dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
                 dispatcherTimer.Start();                
             }

        }
        #endregion 
        #region DealEvents 

        private void DealButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DealButton.Source = new BitmapImage(new Uri("/Images/DealMouseOver.jpg", UriKind.RelativeOrAbsolute));
        }

        private void DealButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DealButton.Source = new BitmapImage(new Uri("/Images/DealNormal.jpg", UriKind.RelativeOrAbsolute));
        }

        private void DealButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DealButton.Source = new BitmapImage(new Uri("/Images/DealClickDown.jpg", UriKind.RelativeOrAbsolute));
        }

        private void DealButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Interface defaults  

            HitButton.Source = new BitmapImage(new Uri("/Images/HitNormal.jpg", UriKind.RelativeOrAbsolute));
            HitButton.IsEnabled = true;

            StayButton.Source = new BitmapImage(new Uri("/Images/StayNormal.jpg", UriKind.RelativeOrAbsolute));
            StayButton.IsEnabled = true;

            DealButton.Visibility = Visibility.Hidden;
            //Show the stay and hit buttons 

            HitButton.Visibility = Visibility.Visible;
            StayButton.Visibility = Visibility.Visible; 

            //Animate the notification pannel

            Card1.Visibility = Visibility.Visible;
            Card2.Visibility = Visibility.Visible;
            Card5.Visibility = Visibility.Visible;
            Card4.Visibility = Visibility.Visible;
            Card3.Visibility = Visibility.Visible;
            DealGrey.Visibility = Visibility.Visible;

            //Animate the notification 

            NotificationLabel.Content = "Dealing...";
            NotificationLabel.Visibility = Visibility.Visible;

            NotificationLabel.RegisterName("Result1", NotificationLabel);

            // Create a DoubleAnimation #1
            DoubleAnimation PointAnimate1 = new DoubleAnimation();
            PointAnimate1.From = 5;
            PointAnimate1.To = 0;
            PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(2));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
            Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard0 = new Storyboard();
            myWidthAnimatedButtonStoryboard0.Children.Add(PointAnimate1);

            // Animate the button when it's clicked.           
            myWidthAnimatedButtonStoryboard0.Begin(this);


                                 //CHECK AND SET IMAGES AND LABLES  
            
            //CheckAndSetCard Parameters: cardImage,RandomNumber,User(Player|Banker)

            Random random = new Random();
            int NewRandomNumber = random.Next();
            CheckAndSetCards check1 = new CheckAndSetCards(Card1 , NewRandomNumber, "Player" );

            NewRandomNumber = random.Next();
            CheckAndSetCards check2 = new CheckAndSetCards(Card2, NewRandomNumber, "Player");

            NewRandomNumber = random.Next();
            CheckAndSetCards check3 = new CheckAndSetCards(Card5, NewRandomNumber, "Banker");

            NewRandomNumber = random.Next();
            CheckAndSetCards check4 = new CheckAndSetCards(Card4, NewRandomNumber, "Banker");
            
            //Set Player & bankers total labels 

            PlayerTotalValueLabel.Content = check2.Total("User").ToString();
            BankerTotalValueLabel.Content = check3.Total("Banker").ToString();

                                                     

                                           //*ANIMATION*//

            // Set the Name of the button so that it can be referred 
            Card1.Name  = "Card1";
            Card2.Name  = "Card2";
            Card5.Name = "Card5";
            Card4.Name = "Card4";
            Card3.Name = "Card3";

            // Register the names with the page to which the button belongs. 
            this.RegisterName(Card1.Name, Card1);
            this.RegisterName(Card2.Name, Card2);
            this.RegisterName(Card5.Name, Card5);
            this.RegisterName(Card4.Name, Card4);

                                   //ANIMATION
                                    //StoryBoards
                                     //USERS CARDS #1

            // Create a ThicknessAnimation to animate the margin of the images.
            ThicknessAnimation PointAni = new ThicknessAnimation();
            PointAni.From = new Thickness(217, -123, 1, 1);
            PointAni.To = new Thickness(PlayerposY, PlayerposX, 0, 0);
            PointAni.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAni, Card1.Name);
            Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));

            // Create a storyboard to contain the animation.
            Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
            myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

           // Animate the button when it's clicked.           
            myWidthAnimatedButtonStoryboard.Begin(this);

                                     //USERS CARDS #2

           PlayerposY = PlayerposY + 30;
           PointAni.From = new Thickness(217, -123, 1, 1);
           PointAni.To = new Thickness(PlayerposY, PlayerposX, 0, 0);
           PointAni.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
           Storyboard.SetTargetName(PointAni, Card2.Name);
           Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));

           // Create a storyboard to contain the animation.          
           myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

           // Animate the button when it's clicked.
           myWidthAnimatedButtonStoryboard.Begin(this);

                                   //BANKERS CARDS #1


           PointAni.From = new Thickness(217, -123, 1, 1);
           PointAni.To = new Thickness(BankerposY, BankerposX, 0, 0);
           PointAni.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
           Storyboard.SetTargetName(PointAni, Card5.Name);
           Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));

           // Create a storyboard to contain the animation.
           myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

           // Animate the button when it's clicked.
           myWidthAnimatedButtonStoryboard.Begin(this);

                                     //BANKERS CARDS #2
           BankerposY = BankerposY + 30;

           PointAni.From = new Thickness(217, -123, 1, 1);
           PointAni.To = new Thickness(BankerposY, BankerposX, 0, 0);
           PointAni.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
           Storyboard.SetTargetName(PointAni, Card4.Name);
           Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));

           // Create a storyboard to contain the animation.
           myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

           // Animate the button when it's clicked.
           myWidthAnimatedButtonStoryboard.Begin(this);

                                     //BANKERS CARDS #3

           PointAni.From = new Thickness(217, -123, 1, 1);
           PointAni.To = new Thickness(344, 65, 0, 0);
           PointAni.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
           Storyboard.SetTargetName(PointAni, Card3.Name);
           Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));

           // Create a storyboard to contain the animation.          
           myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

           // Animate the button when it's clicked.
           myWidthAnimatedButtonStoryboard.Begin(this);

           // Check weather a winning value was drawn: 
            //get players card value from the checkAndSetCards class

           CheckAndSetCards Check = new CheckAndSetCards();
           PlayerTotal = Check.Total("User");

           if (PlayerTotal == 21)
           {
               //Hide the stay and hit buttons 

               HitButton.Visibility = Visibility.Hidden;
               StayButton.Visibility = Visibility.Hidden;

               //Animate the notification pannel

               NotificationLabel.Content = "♠ BlackJack! ♠";
               NotificationLabel.Visibility = Visibility.Visible;
               PlayerPointerText.Visibility = Visibility.Visible; 

               NotificationLabel.RegisterName("Result1", NotificationLabel);
               PlayerPointerText.RegisterName("PlayerArrow", PlayerPointerText);

               // Create a ThicknessAnimation to animate the margin of the images.
               DoubleAnimation PointAnimate = new DoubleAnimation();
               PointAnimate.From = 5;
               PointAnimate.To = 0;
               PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(1));

               // Configure the animation to target the button's Width property.
               Storyboard.SetTargetName(PointAnimate, NotificationLabel.Name);
               Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));

               // Create a storyboard to contain the animation.
               Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
               myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

               //DoubleAnimation #2           
               myWidthAnimatedButtonStoryboard2.Begin(this);

               PointAnimate.From = 5;
               PointAnimate.To = 0;
               PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(2));

               // Configure the animation to target the button's Width property.
               Storyboard.SetTargetName(PointAnimate, PlayerPointerText.Name);
               Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));

               // Create a storyboard to contain the animation.
               myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

               // Animate the button when it's clicked.           
               myWidthAnimatedButtonStoryboard2.Begin(this);

               CheckAndSetCards GetTotal = new CheckAndSetCards();
               BankerTotal = GetTotal.Total("OtherBanker");
               version = 1;

               //Sync thsese events 

               dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
               dispatcherTimer.Tick += new EventHandler(DispatcherTimer_TickTwo);
               dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
               dispatcherTimer.Start();

           }
        }
#endregion 
        #region StayEvents 

        private void StayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            StayButton.Source = new BitmapImage(new Uri("/Images/StayMouseOver.jpg", UriKind.RelativeOrAbsolute));
        }

        private void StayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            StayButton.Source = new BitmapImage(new Uri("/Images/StayNormal.jpg", UriKind.RelativeOrAbsolute));
        }

        private void StayButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StayButton.Source = new BitmapImage(new Uri("/Images/StayClickDown.jpg", UriKind.RelativeOrAbsolute));
        }

        private void StayButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Hide the stay and hit buttons 

            HitButton.Visibility = Visibility.Hidden;
            StayButton.Visibility = Visibility.Hidden;

            //Animate the notification pannel

            NotificationLabel.Content = "Stay";
            NotificationLabel.Visibility = Visibility.Visible;

            NotificationLabel.RegisterName("Result1", NotificationLabel);

            // Create a DoubleAnimation #1
            DoubleAnimation PointAnimate = new DoubleAnimation();
            PointAnimate.From = 5;
            PointAnimate.To = 0;
            PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(3));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate, NotificationLabel.Name);
            Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
            myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

            // Animate the button when it's clicked.           
            myWidthAnimatedButtonStoryboard2.Begin(this);

            StayButton.Source = new BitmapImage(new Uri("/Images/StayNormal.jpg", UriKind.RelativeOrAbsolute));
            CheckAndSetCards getValue = new CheckAndSetCards();
            BankerTotal = getValue.Total("OtherBanker");

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_TickTwo);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }

        #endregion 
        #region EndSessionEvents 
        private void EndSessionButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EndSessionButton.Source = new BitmapImage(new Uri("/Images/EndSessionMouseOver.jpg", UriKind.RelativeOrAbsolute));
        }

        private void EndSessionButton_MouseLeave(object sender, MouseEventArgs e)
        {
            EndSessionButton.Source = new BitmapImage(new Uri("/Images/EndSessionNormal.jpg", UriKind.RelativeOrAbsolute));
        }

        private void EndSessionButton_MouseUp(object sender, MouseButtonEventArgs e )
        {
            //Show and return menu icons 

            EndSessionButton.Source = new BitmapImage(new Uri("/Images/EndSessionMouseUp.jpg", UriKind.RelativeOrAbsolute));
            NewGameButton.Visibility = Visibility.Visible;
            QuitButton.Visibility = Visibility.Visible;
            DealButton.Visibility = Visibility.Collapsed;
            HitButton.Visibility = Visibility.Collapsed;
            StayButton.Visibility = Visibility.Collapsed;
            EndSessionButton.Visibility = Visibility.Collapsed;
            Card1.Visibility = Visibility.Collapsed;
            Card2.Visibility = Visibility.Collapsed;
            Card5.Visibility = Visibility.Collapsed;
            Card4.Visibility = Visibility.Collapsed;
            Card3.Visibility = Visibility.Collapsed;
            NotificationPannel.Visibility = Visibility.Collapsed; 
            DealGrey.Visibility = Visibility.Collapsed;
            ContinueButton.Visibility = Visibility.Collapsed;
            HitGrey.Visibility = Visibility.Collapsed;
            StayGrey.Visibility = Visibility.Collapsed;
            PlayerTotalValueLabel.Visibility = Visibility.Collapsed;
            LosesLabel.Visibility = Visibility.Collapsed;
            WinLabel.Visibility = Visibility.Collapsed;
            TieLabel.Visibility = Visibility.Collapsed;
            BankerTotalValueLabel.Visibility = Visibility.Collapsed;
            NotificationLabel.Content = "";

            try
            {
                Img1.Visibility = Visibility.Collapsed;
                Img2.Visibility = Visibility.Collapsed;
                Img3.Visibility = Visibility.Collapsed;
                Img4.Visibility = Visibility.Collapsed;
                Img5.Visibility = Visibility.Collapsed;
                Img6.Visibility = Visibility.Collapsed;
                Img7.Visibility = Visibility.Collapsed;
                Img8.Visibility = Visibility.Collapsed;
            }
            catch
            {
                //continue
            }

            try
            {
                BImg1.Visibility = Visibility.Collapsed;
                BImg2.Visibility = Visibility.Collapsed;
                BImg3.Visibility = Visibility.Collapsed;
                BImg4.Visibility = Visibility.Collapsed;
                BImg5.Visibility = Visibility.Collapsed;
                BImg6.Visibility = Visibility.Collapsed;
                BImg7.Visibility = Visibility.Collapsed;
                BImg8.Visibility = Visibility.Collapsed;
            }
            catch
            {
                //Continue
            }
            //BackGround Image
            BackGroundImage.Source = new BitmapImage(new Uri("/Images/Standard.jpg", UriKind.RelativeOrAbsolute));

            //Return all defaults 
            //Call a Constructor that removes all total values 

            CheckAndSetCards SetZero = new CheckAndSetCards("delete"); 
            DealButton.IsEnabled = true;
            PlayerTotalValueLabel.Content = 0;
            BankerTotalValueLabel.Content = 0;         

            //Set the Postion values back to default

            version = 1;
            BankerVersion = 1;
            BankerposY = 344;
            BankerposX = 65;
            PlayerposY = 344;
            PlayerposX = 271;
            BankerTotal = 0;
            PlayerTotal = 0;
            PlayerTotalValueLabel.Content = "0";
            BankerTotalValueLabel.Content = "0";
            LosesLabel.Content = "0";
            WinLabel.Content = "0";
            TieLabel.Content = "0";

            //Unregister all newCards 

            try
            {
                this.UnregisterName("NewCardOne");
                this.UnregisterName("NewCardTwo");
                this.UnregisterName("NewCardThree");
                this.UnregisterName("NewCardFour");
                this.UnregisterName("NewCardFive");
                this.UnregisterName("NewCardSix");
                this.UnregisterName("NewCardSeven");
                this.UnregisterName("NewCardEight");
            }
            catch
            {
                //Continue
            }

            try
            {
                this.UnregisterName("BNewCardOne");
                this.UnregisterName("BNewCardTwo");
                this.UnregisterName("BNewCardThree");
                this.UnregisterName("BNewCardFour");
                this.UnregisterName("BNewCardFive");
                this.UnregisterName("BNewCardSix");
                this.UnregisterName("BNewCardSeven");
                this.UnregisterName("BNewCardEight");
            }
            catch
            {
                //Continue
            }

            //reset the timer and count values 

            UpSideDownCard = true;
            dispatcherTimer.Stop();
            dispatcherTimer.IsEnabled = false;
            countOne = 0;
            countTwo = 0;

            //Reverse upsideDownCard 

            Card3.RegisterName("UpsideCard", Card3);
            DoubleAnimation PointAnimate2 = new DoubleAnimation();
            PointAnimate2.From = 0;
            PointAnimate2.To = 1;
            PointAnimate2.Duration = new Duration(TimeSpan.FromSeconds(1));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate2, Card3.Name);
            Storyboard.SetTargetProperty(PointAnimate2, new PropertyPath(Image.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard3 = new Storyboard();
            myWidthAnimatedButtonStoryboard3.Children.Add(PointAnimate2);

            // Animate the button once
            if (UpSideDownCard == true)
            {
                myWidthAnimatedButtonStoryboard3.Begin(this);
                UpSideDownCard = false;
            }

            
        }

        private void EndSessionButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EndSessionButton.Source = new BitmapImage(new Uri("/Images/EndSessionDown.jpg", UriKind.RelativeOrAbsolute));        
        }

        #endregion 

        //Dealers actions, sync timers and calculation logic 
        #region AIActions 
        public void AiActions(int BankerTotal)
        {
            dispatcherTimer.Stop();
            UpSideDownCard = true;

            //Disable buttons 
            DealButton.Source = new BitmapImage(new Uri("/Images/DealGreyedOut.jpg", UriKind.RelativeOrAbsolute));
            DealButton.IsEnabled = false;

            HitButton.Source = new BitmapImage(new Uri("/Images/HitGreyedOut.jpg", UriKind.RelativeOrAbsolute));
            HitButton.IsEnabled = false;

            StayButton.Source = new BitmapImage(new Uri("/Images/StayGreyedOut.jpg", UriKind.RelativeOrAbsolute));
            StayButton.IsEnabled = false;

            //Animate notification button
            CheckAndSetCards value = new CheckAndSetCards();
            BankerTotal = value.Total("OtherBankerTotal");

            NotificationLabel.Content = "Dealers turn";
            NotificationLabel.Visibility = Visibility.Visible;

            NotificationLabel.RegisterName("Result1", NotificationLabel);

            // Create a DoubleAnimation #1
            DoubleAnimation PointAnimate = new DoubleAnimation();
            PointAnimate.From = 5;
            PointAnimate.To = 0;
            PointAnimate.Duration = new Duration(TimeSpan.FromSeconds(3));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate, NotificationLabel.Name);
            Storyboard.SetTargetProperty(PointAnimate, new PropertyPath(Label.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
            myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate);

            // Animate the button when it's clicked. 
            if (UpSideDownCard == true) 
            {
            myWidthAnimatedButtonStoryboard2.Begin(this);
            myWidthAnimatedButtonStoryboard2.Remove();
            }

            CheckAndSetCards ShowTotal = new CheckAndSetCards();
            

            //REVEAL UPSIDEDOWN CARD: 


            Card3.RegisterName("UpsideCard", Card3);
            DoubleAnimation PointAnimate2 = new DoubleAnimation();
            PointAnimate2.From = 1;
            PointAnimate2.To = 0;
            PointAnimate2.Duration = new Duration(TimeSpan.FromSeconds(1));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate2, Card3.Name);
            Storyboard.SetTargetProperty(PointAnimate2, new PropertyPath(Image.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard3 = new Storyboard();
            myWidthAnimatedButtonStoryboard3.Children.Add(PointAnimate2);

            // Animate the button once
            if (UpSideDownCard == true)
            {
                myWidthAnimatedButtonStoryboard3.Begin(this);
                UpSideDownCard = false;
            }

            
            //CONTROL STATAMENTS 
            //Draw new cards until the bankers total is equal to or larger than 17

            CheckAndSetCards NewCard3 = new CheckAndSetCards();
            BankerTotal = NewCard3.Total("OtherBanker");
            BankerTotalValueLabel.Content = BankerTotal;
            while (BankerTotal <= 17)
            {
                //Create an instance of a random class to seed the CheckAndSetCards class 
                Random randomnumber = new Random();
                int newRandomNumber = randomnumber.Next();

                if (BankerVersion == 1)
                {
                    BankerposY = 80; 
                    BankerposX = -250;
                }
                BankerposY = BankerposY + 50; 

                if (BankerVersion == 1)
                {
                    BImg1 = new Image();
                    BImg1.Name = "BNewCardOne";
                    BImg1.Height = 123;
                    BImg1.Width = 79;
                    this.RegisterName(BImg1.Name, BImg1);
                    (this.Content as Grid).Children.Add(BImg1);
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg1 , newRandomNumber , "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg1.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 2)
                {
                    BImg2 = new Image();
                    BImg2.Name = "BNewCardTwo";
                    BImg2.Height = 123;
                    BImg2.Width = 79;
                    this.RegisterName(BImg2.Name, BImg2);
                    (this.Content as Grid).Children.Add(BImg2);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg2, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg2.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 3)
                {
                    BImg3 = new Image();
                    BImg3.Name = "BNewCardThree";
                    BImg3.Height = 123;
                    BImg3.Width = 79;
                    this.RegisterName(BImg3.Name, BImg3);
                    (this.Content as Grid).Children.Add(BImg3);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg3, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg3.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 4)
                {
                    BImg4 = new Image();
                    BImg4.Name = "BNewCardFour";
                    BImg4.Height = 123;
                    BImg4.Width = 79;
                    this.RegisterName(BImg4.Name, BImg4);
                    (this.Content as Grid).Children.Add(BImg4);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg4, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg4.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 5)
                {
                    BImg5 = new Image();
                    BImg5.Name = "BNewCardFive";
                    BImg5.Height = 123;
                    BImg5.Width = 79;
                    this.RegisterName(BImg5.Name, BImg5);
                    (this.Content as Grid).Children.Add(BImg5);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg5, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg5.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 6)
                {
                    BImg6 = new Image();
                    BImg6.Name = "BNewCardSix";
                    BImg6.Height = 123;
                    BImg6.Width = 79;
                    this.RegisterName(BImg6.Name, BImg6);
                    (this.Content as Grid).Children.Add(BImg6);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg6, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg6.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 7)
                {
                    BImg7 = new Image();
                    BImg7.Name = "BNewCardSeven";
                    BImg7.Height = 123;
                    BImg7.Width = 79;
                    this.RegisterName(BImg7.Name, BImg7);
                    (this.Content as Grid).Children.Add(BImg7);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg7, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg7.Visibility = Visibility.Visible;
                }
                else if (BankerVersion == 8)
                {
                    BImg8 = new Image();
                    BImg8.Name = "BNewCardEight";
                    BImg8.Height = 123;
                    BImg8.Width = 79;
                    this.RegisterName(BImg8.Name, BImg8);
                    (this.Content as Grid).Children.Add(BImg8);
                    newRandomNumber = randomnumber.Next();
                    CheckAndSetCards NewCard = new CheckAndSetCards(BImg8, newRandomNumber, "Banker");
                    BankerTotal = NewCard.Total("OtherBanker");
                    BankerTotalValueLabel.Content = NewCard.Total("OtherBanker");
                    BImg8.Visibility = Visibility.Visible;
                }
                // Create a ThicknessAnimation to animate the margin of the images.
                ThicknessAnimation PointAni = new ThicknessAnimation();
                PointAni.From = new Thickness(-2174, -1234, 1, 1);
                PointAni.To = new Thickness(BankerposY, BankerposX, 0, 0);
                PointAni.Duration = new Duration(TimeSpan.FromSeconds(3));

                // Configure the animation to target the button's Width property.
                if (BankerVersion == 1)
                {
                    Storyboard.SetTargetName(PointAni, BImg1.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 2)
                {
                    Storyboard.SetTargetName(PointAni, BImg2.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 3)
                {
                    Storyboard.SetTargetName(PointAni, BImg3.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 4)
                {
                    Storyboard.SetTargetName(PointAni, BImg4.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 5)
                {
                    Storyboard.SetTargetName(PointAni, BImg5.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 6)
                {
                    Storyboard.SetTargetName(PointAni, BImg6.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 7)
                {
                    Storyboard.SetTargetName(PointAni, BImg7.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }
                else if (BankerVersion == 8)
                {
                    Storyboard.SetTargetName(PointAni, BImg8.Name);
                    Storyboard.SetTargetProperty(PointAni, new PropertyPath(Image.MarginProperty));
                }

                // Create a storyboard to contain the animation.
                Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
                myWidthAnimatedButtonStoryboard.Children.Add(PointAni);

                // Animate the button when it's clicked.           
                myWidthAnimatedButtonStoryboard.Begin(this);

                BankerTotalValueLabel.Content = ShowTotal.Total("OtherBanker");
                CheckAndSetCards NewCard2 = new CheckAndSetCards();  
                BankerTotal = NewCard2.Total("OtherBanker");
                BankerVersion = BankerVersion + 1;
            }
          
            //Sync this operation 

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
           
        }
        #endregion
        #region DispatcherTimers 

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //This code contains the logic for the win and lose senarios 
            countOne = countOne + 1;
            CheckAndSetCards check = new CheckAndSetCards();
            BankerTotal = check.Total("OtherBanker");

            if (countOne == 4)
            {
                if (PlayerTotal > 21)
                {
                    Result("Lose");
                    resultstring = LosesLabel.Content.ToString();
                    resultint = Int32.Parse(resultstring);
                    LosesLabel.Content = resultint + 1;
                    
                } 
                else if (PlayerTotal <= 21 & BankerTotal > 21)
                {
                    Result("Win");
                    resultstring = WinLabel.Content.ToString();
                    resultint = Int32.Parse(resultstring);
                    WinLabel.Content = resultint + 1;
                }
                else if (PlayerTotal <= 21 & BankerTotal <= 21)
                {
                    if (PlayerTotal < BankerTotal)
                    {
                        Result("Lose");
                        dispatcherTimer.Stop();
                        resultstring = LosesLabel.Content.ToString();
                        resultint = Int32.Parse(resultstring);
                        LosesLabel.Content = resultint + 1;
                    }
                    else if (PlayerTotal > BankerTotal)
                    {
                        Result("Win");
                        dispatcherTimer.Stop();
                        resultstring = WinLabel.Content.ToString();
                        resultint = Int32.Parse(resultstring);
                        WinLabel.Content = resultint + 1;
                    }
                    else if (PlayerTotal == BankerTotal)
                    {
                    Result("Tie");
                    dispatcherTimer.Stop();
                    resultstring = TieLabel.Content.ToString();
                    resultint = Int32.Parse(resultstring);
                    TieLabel.Content = resultint + 1;
                    }
                }
                
                
            }
        }
        private void DispatcherTimer_TickTwo (object sender , EventArgs e)
        {
          countTwo = countTwo + 1; 

            if (countTwo == 1) 
            { 
                    AiActions(BankerTotal);
            }
        }
        #endregion 

        //Result display logic and ContinueEvents 
        #region Result 

        private void Result(string result)
        {
            if (result == "Win")
            {
                BackGroundImage.Source = new BitmapImage(new Uri("Images/MaxWin.jpg", UriKind.RelativeOrAbsolute));

                //Animate the notification 

                NotificationLabel.Content = "GoodJob!";
                NotificationLabel.Visibility = Visibility.Visible;

                NotificationLabel.RegisterName("Result1", NotificationLabel);

                // Create a DoubleAnimation #1
                DoubleAnimation PointAnimate1 = new DoubleAnimation();
                PointAnimate1.From = 5;
                PointAnimate1.To = 0;
                PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(3));

                // Configure the animation to target the button's Width property.
                Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
                Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
                Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
                myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

                // Animate the button when it's clicked.           
                myWidthAnimatedButtonStoryboard2.Begin(this);

                //PlaySound if enabled 
                if (soundstatus == true)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Applause_Light);
                    player.Play();
                }
            }
            else if (result == "Lose")
            {
                BackGroundImage.Source = new BitmapImage(new Uri("/Images/MaxLose.jpg", UriKind.RelativeOrAbsolute));
                //Animate the notification 

                NotificationLabel.Content = "Unlucky!";
                NotificationLabel.Visibility = Visibility.Visible;

                NotificationLabel.RegisterName("Result1", NotificationLabel);

                // Create a DoubleAnimation #1
                DoubleAnimation PointAnimate1 = new DoubleAnimation();
                PointAnimate1.From = 5;
                PointAnimate1.To = 0;
                PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(3));

                // Configure the animation to target the button's Width property.
                Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
                Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
                Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
                myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

                // Animate the button when it's clicked.           
                myWidthAnimatedButtonStoryboard2.Begin(this);
                
                //Play sound
                if (soundstatus == true)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.cough);
                    player.Play();
                }
            }
            else if (result == "Tie")
            {
                BackGroundImage.Source = new BitmapImage(new Uri("/Images/MaxTie.jpg", UriKind.RelativeOrAbsolute));
                //Animate the notification 

                NotificationLabel.Content = "That was a close one!";
                NotificationLabel.Visibility = Visibility.Visible;

                NotificationLabel.RegisterName("Result1", NotificationLabel);

                // Create a DoubleAnimation #1
                DoubleAnimation PointAnimate1 = new DoubleAnimation();
                PointAnimate1.From = 5;
                PointAnimate1.To = 0;
                PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(3));

                // Configure the animation to target the button's Width property.
                Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
                Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
                Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
                myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

                // Animate the button when it's clicked.           
                myWidthAnimatedButtonStoryboard2.Begin(this);

                //Play sound
                if (soundstatus == true)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Applause_Light_2);
                    player.Play();
                }
            }

            //Remove and set to defaults: 

            Card1.Visibility = Visibility.Collapsed;
            Card2.Visibility = Visibility.Collapsed;
            Card5.Visibility = Visibility.Collapsed;
            Card4.Visibility = Visibility.Collapsed;
            Card3.Visibility = Visibility.Collapsed;

            try
            {
                Img1.Visibility = Visibility.Collapsed;
                Img2.Visibility = Visibility.Collapsed;
                Img3.Visibility = Visibility.Collapsed;
                Img4.Visibility = Visibility.Collapsed;
                Img5.Visibility = Visibility.Collapsed;
                Img6.Visibility = Visibility.Collapsed;
                Img7.Visibility = Visibility.Collapsed;
                Img8.Visibility = Visibility.Collapsed;
            }
            catch
            {
                //continue
            }

            try
            {
                BImg1.Visibility = Visibility.Collapsed;
                BImg2.Visibility = Visibility.Collapsed;
                BImg3.Visibility = Visibility.Collapsed;
                BImg4.Visibility = Visibility.Collapsed;
                BImg5.Visibility = Visibility.Collapsed;
                BImg6.Visibility = Visibility.Collapsed;
                BImg7.Visibility = Visibility.Collapsed;
                BImg8.Visibility = Visibility.Collapsed;
            }
            catch
            {
                //Continue
            }

            //Set

            ContinueButton.Visibility = Visibility.Visible;
            
        }
        #endregion 
        #region ContinueEvent 
        private void ContinueButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ContinueButton.Source = new BitmapImage(new Uri("/Images/ContinueStandard.jpg", UriKind.RelativeOrAbsolute));
        }

        private void ContinueButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ContinueButton.Source = new BitmapImage(new Uri("/Images/ContinueHighLighted.jpg", UriKind.RelativeOrAbsolute));
        } 

        private void ContinueButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DealGrey.Visibility = Visibility.Collapsed;
            BackGroundImage.Source = new BitmapImage(new Uri("/Images/GameStandard.jpg", UriKind.RelativeOrAbsolute));
            DealButton.Visibility = Visibility.Visible;
            DealButton.IsEnabled = true;

            //Return all defaults 
            //Call a Constructor that removes all total values 

            CheckAndSetCards SetZero = new CheckAndSetCards("delete");
            DealButton.IsEnabled = true;
            PlayerTotalValueLabel.Content = 0;
            BankerTotalValueLabel.Content = 0;

            //Set the Postion values back to default

            version = 1;
            BankerVersion = 1;
            BankerposY = 344;
            BankerposX = 65;
            PlayerposY = 344;
            PlayerposX = 271;
            BankerTotal = 0;
            PlayerTotal = 0;

            //Unregister all newCards 

            try
            {
                this.UnregisterName("NewCardOne");
                this.UnregisterName("NewCardTwo");
                this.UnregisterName("NewCardThree");
                this.UnregisterName("NewCardFour");
                this.UnregisterName("NewCardFive");
                this.UnregisterName("NewCardSix");
                this.UnregisterName("NewCardSeven");
                this.UnregisterName("NewCardEight");
            }
            catch
            {
                //Continue
            }

            try
            {
                this.UnregisterName("BNewCardOne");
                this.UnregisterName("BNewCardTwo");
                this.UnregisterName("BNewCardThree");
                this.UnregisterName("BNewCardFour");
                this.UnregisterName("BNewCardFive");
                this.UnregisterName("BNewCardSix");
                this.UnregisterName("BNewCardSeven");
                this.UnregisterName("BNewCardEight");
            }
            catch
            {
                //Continue
            }

            //reset the timer and count values 

            UpSideDownCard = true;
            dispatcherTimer.Stop();
            dispatcherTimer.IsEnabled = false;
            countOne = 0;
            countTwo = 0;
            ContinueButton.Visibility = Visibility.Collapsed;
            DealButton.Source = new BitmapImage(new Uri("/Images/DealNormal.jpg", UriKind.RelativeOrAbsolute));

            //reset the timer and count values 

            UpSideDownCard = true;
            dispatcherTimer.Stop();
            dispatcherTimer.IsEnabled = false;
            countOne = 0;
            countTwo = 0;

            //Reverse upsideDownCard 

            Card3.RegisterName("UpsideCard", Card3);
            DoubleAnimation PointAnimate2 = new DoubleAnimation();
            PointAnimate2.From = 0;
            PointAnimate2.To = 1;
            PointAnimate2.Duration = new Duration(TimeSpan.FromSeconds(1));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate2, Card3.Name);
            Storyboard.SetTargetProperty(PointAnimate2, new PropertyPath(Image.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard3 = new Storyboard();
            myWidthAnimatedButtonStoryboard3.Children.Add(PointAnimate2);

            // Animate the button once
            if (UpSideDownCard == true)
            {
                myWidthAnimatedButtonStoryboard3.Begin(this);
                UpSideDownCard = false;
            }

            //Animate the notification 

            NotificationLabel.Content = "Deal to start";
            NotificationLabel.Visibility = Visibility.Visible;

            NotificationLabel.RegisterName("Result1", NotificationLabel);

            // Create a DoubleAnimation #1
            DoubleAnimation PointAnimate1 = new DoubleAnimation();
            PointAnimate1.From = 5;
            PointAnimate1.To = 0;
            PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(3));

            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
            Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
            Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
            myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

            // Animate the button when it's clicked.           
            myWidthAnimatedButtonStoryboard2.Begin(this);

        }

        #endregion 

        //Sound logic
        #region SoundButton 
        private void MusicButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Switch the soundstatus around 

            if (soundstatus == true)
            {
                soundstatus = false;
                MusicButton.Source = new BitmapImage(new Uri("/Images/GameStandard off.jpg", UriKind.RelativeOrAbsolute));

                //Animate the notification 
                if (NotificationPannel.IsVisible == true)
                {
                    NotificationLabel.Content = "Sound Off";
                    NotificationLabel.Visibility = Visibility.Visible;

                    NotificationLabel.RegisterName("Result1", NotificationLabel);

                    // Create a DoubleAnimation #1
                    DoubleAnimation PointAnimate1 = new DoubleAnimation();
                    PointAnimate1.From = 5;
                    PointAnimate1.To = 0;
                    PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(1));

                    // Configure the animation to target the button's Width property.
                    Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
                    Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
                    Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
                    myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

                    // Animate the button when it's clicked.           
                    myWidthAnimatedButtonStoryboard2.Begin(this);
                }
            }
            else
            {
                soundstatus = true;
                MusicButton.Source = new BitmapImage(new Uri("/Images/MusicNoteOn.jpg", UriKind.RelativeOrAbsolute));

                //Animate the notificationbar 

                if (NotificationPannel.IsVisible == true)
                {
                    NotificationLabel.Content = "Sound On";
                    NotificationLabel.Visibility = Visibility.Visible;

                    NotificationLabel.RegisterName("Result1", NotificationLabel);

                    // Create a DoubleAnimation #1
                    DoubleAnimation PointAnimate1 = new DoubleAnimation();
                    PointAnimate1.From = 5;
                    PointAnimate1.To = 0;
                    PointAnimate1.Duration = new Duration(TimeSpan.FromSeconds(1));

                    // Configure the animation to target the button's Width property.
                    Storyboard.SetTargetName(PointAnimate1, NotificationLabel.Name);
                    Storyboard.SetTargetProperty(PointAnimate1, new PropertyPath(Label.OpacityProperty));
                    Storyboard myWidthAnimatedButtonStoryboard2 = new Storyboard();
                    myWidthAnimatedButtonStoryboard2.Children.Add(PointAnimate1);

                    // Animate the button when it's clicked.           
                    myWidthAnimatedButtonStoryboard2.Begin(this);
                }
            }
        }
        #endregion 

     

    }
}
