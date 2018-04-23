using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;


namespace BlackJackCTI
{
    /// <summary>
    /// Description: This page contains the logic for setting, sorting and acumulating the
    /// Player & Banker Cards.
    /// Author:  Craig Turner
    /// Created: FinshedDate: 2014/10/08
    /// OS used: Windows 7 x32
    /// </summary>
    class CheckAndSetCards
    {
        #region VariablesAndStaticConstructor
        //Varibales 
        private int NewRandomNumber;
        static private int TotalBanker;
        static private int TotalPlayer;
        static private bool SingleCast = false;
        static private int OtherTotalBanker;
        ArrayList PlayerCurrentValues = new ArrayList();
        ArrayList BankerCurrentValues = new ArrayList();

        public CheckAndSetCards()
        {
            ///Initialize
        }
        #endregion 

        #region CheckAndSetConstructorDeal

        public CheckAndSetCards (Image image , int seed , string User ) 
    {

        Random RandomNumber = new Random(seed);
        NewRandomNumber = RandomNumber.Next(52);
            //Check if the card has been drawn already
             //Player collection 
        if (User == "Player")
        {
            while (PlayerCurrentValues.Contains(NewRandomNumber))
            {
                NewRandomNumber = RandomNumber.Next(52);
            }
            PlayerCurrentValues.Add(NewRandomNumber);
        }
            //Dealer Collection
        else if (User == "Banker")
        {
            for (int loop = 0; loop < BankerCurrentValues.Count; loop++)
            {
                while (BankerCurrentValues.Contains(NewRandomNumber))
                {
                    NewRandomNumber = RandomNumber.Next(52);
                }
                BankerCurrentValues.Add(NewRandomNumber);
            }
        }
            //The following code acumulates the totals of the banker and the user and sets the appropriate image
        switch (NewRandomNumber)
        {
            case 0:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Ace.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }
                }
                else if (User == "Banker" & SingleCast == true )
                {
                    if (TotalBanker + 11 > 21)
                    {
                        TotalBanker = TotalBanker + 1;
                    }
                    else
                    {
                        TotalBanker = TotalBanker + 11;
                    }
                }
               if (User == "Banker" )
                {
                    if (OtherTotalBanker + 11 > 21)
                    {
                        OtherTotalBanker = TotalBanker + 1;
                    }
                    else
                    {
                        OtherTotalBanker = TotalBanker + 11;
                    }
                }
                break;
            case 1:        
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Eight.png", UriKind.RelativeOrAbsolute));

                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 8;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 8;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 8;
                } 
                break;
            case 2:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Five.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 5;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 5;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 5;
                } 
                break; 
            case 3:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Four.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 4;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 4;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 4;
                } 
                break; 
            case 4:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Jack.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                } 
                break; 
            case 5:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-King.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                } 
                break; 
            case 6:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Nine.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 9;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 9;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 9;
                } 
                break; 
            case 7:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Queen.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                } 
                break; 
            case 8:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Seven.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 7;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 7;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 7;
                } 
                break; 
            case 9:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Six.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 6;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 6;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 6;
                } 
                break; 
            case 10:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Ten.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                } 
                break; 
            case 11:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Three.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 3;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 3;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 3;
                } 
                break; 
            case 12:
                image.Source = new BitmapImage(new Uri("/Images/Clubs-Two.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 2;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 2;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 2;
                } 
                break; 
            case 13 :
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Ace.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    if (TotalBanker + 11 > 21)
                    {
                        TotalBanker = TotalBanker + 1;
                    }
                    else
                    {
                        TotalBanker = TotalBanker + 11;
                    }

                }
                if (User == "Banker" )
                {
                    if (TotalBanker + 11 > 21)
                    {
                        OtherTotalBanker = TotalBanker + 1;
                    }
                    else
                    {
                        OtherTotalBanker = TotalBanker + 11;
                    }
                } 
                break; 
            case 14:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Eight.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 8;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 8;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 8;
                }
                break; 
            case 15:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Five.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 5;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 5;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 5;
                }
                break; 
            case 16:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Four.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 4;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 4;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 4;
                }
                break;
            case 17:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Jack.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 18:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-King.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break;
            case 19:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Nine.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 9;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 9;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 9;
                }
                break; 
            case 20:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Queen.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 21:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Seven.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 7;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 7;
                }
                if (User == "Banker" )
                {
                    OtherTotalBanker = OtherTotalBanker + 7;
                }
                break; 
            case 22:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Six.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 6;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 6;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 6;
                }
                break; 
            case 23:
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Ten.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 24 :
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Three.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 3;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 3;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 3;
                }
                break; 
            case 25 :
                image.Source = new BitmapImage(new Uri("/Images/Diamonds-Two.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 2;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 2;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 2;
                }
                break; 
            case 26:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Ace.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    if (TotalBanker + 11 > 21)
                    {
                        TotalBanker = TotalBanker + 1;
                    }
                    else
                    {
                        TotalBanker = TotalBanker + 11;
                    }
                }
                if (User == "Banker" )
                {
                    if (TotalBanker + 11 > 21)
                    {
                        OtherTotalBanker = OtherTotalBanker + 1;
                    }
                    else
                    {
                        OtherTotalBanker = OtherTotalBanker + 11;
                    }
                }
                break; 
            case 27:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Eight.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 8;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 8;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 8;
                }
                break; 
            case 28:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Five.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 5;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 5;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 5;
                }
                break; 
            case 29:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Four.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 4;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 4;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 4;
                }
                break; 
            case 30:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Jack.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 31:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-King.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker" )
                {

                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 32:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Nine.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 9;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 9;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 9;
                }
                break; 
            case 33:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Queen.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 34:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Seven.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 7;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 7;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 7;
                }
                break; 
            case 35:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Six.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 6;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 6;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 6;
                }
                break; 
            case 36:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Ten.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 37:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Three.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 3;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 3;
                }
                if (User == "Banker")
                {

                    OtherTotalBanker = OtherTotalBanker + 3;
                }
                break; 
            case 38:
                image.Source = new BitmapImage(new Uri("/Images/Hearts-Two.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 2;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 2;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 2;
                }
                break;
            case 39:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Ace.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else 
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    if (TotalBanker + 11 > 21)
                    {
                        TotalBanker = TotalBanker + 1;
                    }
                    else
                    {
                        TotalBanker = TotalBanker + 11;
                    }
                }
                if (User == "Banker")
                {

                    if (OtherTotalBanker + 11 > 21)
                    {
                        OtherTotalBanker = OtherTotalBanker + 1;
                    }
                    else
                    {
                        OtherTotalBanker = OtherTotalBanker + 11;
                    }
                }
                break; 
            case 40:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Eight.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 8;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 8;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 8;
                }
                break; 
            case 41:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Five.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 5;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 5;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 5;
                }
                break;
            case 42:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Four.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 4;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 4;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 4;
                }
                break; 
            case 43:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Jack.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 44:
                image.Source = new BitmapImage(new Uri("/Images/Spades-King.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 45:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Nine.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 9;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 9;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 9;
                }
                break; 
            case 46:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Queen.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 47:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Seven.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 7;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 7;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 7;
                }
                break; 
            case 48:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Six.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 6;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 6;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 6;
                }
                break; 
            case 49:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Ten.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 10;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 10;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 10;
                }
                break; 
            case 50:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Three.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 3;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 3;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 3;
                }
                break; 
            case 51:
                image.Source = new BitmapImage(new Uri("/Images/Spades-Two.png", UriKind.RelativeOrAbsolute));
                if (User == "Player")
                {
                    TotalPlayer = TotalPlayer + 2;
                }
                else if (User == "Banker" & SingleCast == true)
                {
                    TotalBanker = TotalBanker + 2;
                }
                if (User == "Banker")
                {
                    OtherTotalBanker = OtherTotalBanker + 2;
                }
                break;               
        }
            //Use this varaible to make sure that the bankers seccond card is only returned as a total
        if (User == "Banker")
        {
            SingleCast = true;
        }
     }
        #endregion 
        #region CheckAndSetConstructorHit
        public CheckAndSetCards(Image image)
        {
            Random RandomNumber = new Random();
            NewRandomNumber = RandomNumber.Next(52);

            for (int loop = 0; loop < PlayerCurrentValues.Count; loop++)
            {
                while (PlayerCurrentValues.Contains(NewRandomNumber))
                {
                    NewRandomNumber = RandomNumber.Next(52);
                }
                PlayerCurrentValues.Add(NewRandomNumber);
            }

            switch (NewRandomNumber)
            {

                case 0:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Ace.png", UriKind.RelativeOrAbsolute));
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }
                    break;
                case 1:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Eight.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 8;

                    break;
                case 2:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Five.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 5;

                    break;
                case 3:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Four.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 4;

                    break;
                case 4:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Jack.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 5:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-King.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 6:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Nine.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 9;

                    break;
                case 7:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Queen.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 8:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Seven.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 7;

                    break;
                case 9:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Six.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 6;

                    break;
                case 10:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Ten.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 11:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Three.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 3;

                    break;
                case 12:
                    image.Source = new BitmapImage(new Uri("/Images/Clubs-Two.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 2;

                    break;
                case 13:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Ace.png", UriKind.RelativeOrAbsolute));
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }

                    break;
                case 14:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Eight.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 8;

                    break;
                case 15:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Five.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 5;

                    break;
                case 16:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Four.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 4;

                    break;
                case 17:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Jack.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 18:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-King.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 19:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Nine.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 9;

                    break;
                case 20:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Queen.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 21:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Seven.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 7;
                    break;

                case 22:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Six.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 6;

                    break;
                case 23:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Ten.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 24:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Three.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 3;

                    break;
                case 25:
                    image.Source = new BitmapImage(new Uri("/Images/Diamonds-Two.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 2;

                    break;
                case 26:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Ace.png", UriKind.RelativeOrAbsolute));
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }

                    break;
                case 27:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Eight.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 8;

                    break;
                case 28:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Five.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 5;

                    break;
                case 29:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Four.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 4;

                    break;
                case 30:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Jack.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 31:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-King.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 32:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Nine.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 9;

                    break;
                case 33:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Queen.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;
                    break;
                case 34:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Seven.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 7;

                    break;
                case 35:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Six.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 6;
                    break;
                case 36:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Ten.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 37:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Three.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 3;

                    break;
                case 38:
                    image.Source = new BitmapImage(new Uri("/Images/Hearts-Two.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 2;

                    break;
                case 39:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Ace.png", UriKind.RelativeOrAbsolute));
                    if (TotalPlayer + 11 > 21)
                    {
                        TotalPlayer = TotalPlayer + 1;
                    }
                    else
                    {
                        TotalPlayer = TotalPlayer + 11;
                    }

                    break;
                case 40:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Eight.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 8;

                    break;
                case 41:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Five.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 5;

                    break;
                case 42:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Four.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 4;

                    break;
                case 43:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Jack.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;
                    break;
                case 44:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-King.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 45:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Nine.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 9;

                    break;
                case 46:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Queen.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 47:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Seven.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 7;

                    break;
                case 48:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Six.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 6;

                    break;
                case 49:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Ten.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 10;

                    break;
                case 50:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Three.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 3;

                    break;
                case 51:
                    image.Source = new BitmapImage(new Uri("/Images/Spades-Two.png", UriKind.RelativeOrAbsolute));
                    TotalPlayer = TotalPlayer + 2;

                    break;
            }

        }
        #endregion 

        #region ReturnValuesLabel
        //Return the total value to be displayed
        public int Total(string NewUser)
        {
            if (NewUser == "User")
            {
                return TotalPlayer;
            }
            else if (NewUser == "OtherBanker")
            {
                
                return OtherTotalBanker;
            } 
            else
            {
                return TotalBanker;
            }
        }
        #endregion 
        #region SetDefaults
        public CheckAndSetCards(string delete)
        {
            if (delete == "delete")
            {
                //Set Defualts to "Destruct the class"
                TotalPlayer = 0;
                TotalBanker = 0;
                SingleCast = false;
                OtherTotalBanker = 0;
                BankerCurrentValues.Clear();
                PlayerCurrentValues.Clear();
            }
            
        }
       #endregion 

    }
}
