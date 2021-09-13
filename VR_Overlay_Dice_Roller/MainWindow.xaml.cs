using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace VR_Overlay_Dice_Roller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int intRollBase = 0;
        private int intRollAdv = 0;
        private int intRollDis = 0;
        private int intMod = 0;
        private int intDieCount = 1;
        private int intDieValue = 20;
        private Random rand;

        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();
        }

        private void sldrMod_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                intMod = (int)sldrMod.Value;
                lblMod.Content = sldrMod.Value;
            }
            catch (System.NullReferenceException)
            {
            }
            
        }

        private void sldrDieCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                intDieCount = (int)sldrDieCount.Value;
                lblDieCount.Content = sldrDieCount.Value;
            }
            catch (System.NullReferenceException)
            {
            }
            
        }

        private void btnD20_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 20;
            setDieActive(btnD20);
        }

        private void btnD12_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 12;
            setDieActive(btnD12);
        }

        private void btnD10_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 10;
            setDieActive(btnD10);
        }

        private void btnD8_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 8;
            setDieActive(btnD8);
        }

        private void btnD6_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 6;
            setDieActive(btnD6);
        }

        private void btnD4_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 4;
            setDieActive(btnD4);
        }

        private void btnD2_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 2;
            setDieActive(btnD2);
        }

        private void btnD100_Click(object sender, RoutedEventArgs e)
        {
            intDieValue = 100;
            setDieActive(btnD100);
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            intRollBase = 0;
            intRollAdv = 0;
            intRollDis = 0;
            for (int i = 0; i < intDieCount; i++)
            {
                int tempA = rollDie(intDieValue);
                int tempB = rollDie(intDieValue);
                if (tempA>tempB)
                {
                    intRollBase += tempA + intMod;
                    intRollAdv += tempA + intMod;
                    intRollDis += tempB + intMod;
                }
                else
                {
                    intRollBase += tempA + intMod;
                    intRollAdv += tempB + intMod;
                    intRollDis += tempA + intMod;
                }
            }

            lblBaseResult.Content = intRollBase;
            lblAdvResult.Content = intRollAdv;
            lblDisResult.Content = intRollDis;
            setImages(intDieValue);
        }

        private void setImages(int die)
        {
            switch (die)
            {
                case 2:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_Coin.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_Coin.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_Coin.png", UriKind.Relative));
                    break;
                case 4:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d4.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d4.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d4.png", UriKind.Relative));
                    break;
                case 6:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d6.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d6.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d6.png", UriKind.Relative));
                    break;
                case 8:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d8.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d8.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d8.png", UriKind.Relative));
                    break;
                case 10:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d10.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d10.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d10.png", UriKind.Relative));
                    break;
                case 12:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d12.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d12.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d12.png", UriKind.Relative));
                    break;
                case 20:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_D20.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_D20.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_D20.png", UriKind.Relative));
                    break;
                case 100:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d100.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d100.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_d100.png", UriKind.Relative));
                    break;
                default:
                    imgDiebase.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_D20.png", UriKind.Relative));
                    imgDieAdv.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_D20.png", UriKind.Relative));
                    imgDieDis.Source = new BitmapImage(new Uri("/Images/Vr_Overlay_dice_roller_D20.png", UriKind.Relative));
                    break;
            }
        }

        private int rollDie(int die)
        {
            return rand.Next(1, die + 1);
        }

        private void setDieActive(Button button)
        {
            clearDieBacks();
            button.Foreground = Brushes.Green;
            button.BorderBrush = Brushes.Green;
        }

        private void clearDieBacks()
        {
            btnD100.BorderBrush = Brushes.Gray;
            btnD100.Foreground = Brushes.White;

            btnD20.BorderBrush = Brushes.Gray;
            btnD20.Foreground = Brushes.White;

            btnD12.BorderBrush = Brushes.Gray;
            btnD12.Foreground = Brushes.White;

            btnD10.BorderBrush = Brushes.Gray;
            btnD10.Foreground = Brushes.White;

            btnD8.BorderBrush = Brushes.Gray;
            btnD8.Foreground = Brushes.White;

            btnD6.BorderBrush = Brushes.Gray;
            btnD6.Foreground = Brushes.White;

            btnD4.BorderBrush = Brushes.Gray;
            btnD4.Foreground = Brushes.White;

            btnD2.BorderBrush = Brushes.Gray;
            btnD2.Foreground = Brushes.White;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            sldrDieCount.Value = 0;
            sldrMod.Value = 0;
            intDieValue = 20;
            setDieActive(btnD20);
        }
    }
}
