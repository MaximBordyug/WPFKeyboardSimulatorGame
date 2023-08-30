using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp_Keyboard
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<(Key, string, string)> buttonList = new List<(Key, string, string)>()
{
   
    (Key.Q, "q", "Q"),
    (Key.W, "w", "W"),
    (Key.E, "e", "E"),
    (Key.R, "r", "R"),
    (Key.T, "t", "T"),
    (Key.Y, "y", "Y"),
    (Key.U, "u", "U"),
    (Key.I, "i", "I"),
    (Key.O, "o", "O"),
    (Key.P, "p", "P"),
    (Key.A, "a", "A"),
    (Key.S, "s", "S"),
    (Key.D, "d", "D"),
    (Key.F, "f", "F"),
    (Key.G, "g", "G"),
    (Key.H, "h", "H"),
    (Key.J, "j", "J"),
    (Key.K, "k", "K"),
    (Key.L, "l", "L"),
    (Key.Z, "z", "Z"),
    (Key.X, "x", "X"),
    (Key.C, "c", "C"),
    (Key.V, "v", "V"),
    (Key.B, "b", "B"),
    (Key.N, "n", "N"),
    (Key.M, "m", "M"),
    (Key.D1, "1", "!"),
    (Key.D2, "2", "@"),
    (Key.D3, "3", "#"),
    (Key.D4, "4", "$"),
    (Key.D5, "5", "%"),
    (Key.D6, "6", "^"),
    (Key.D7, "7", "&"),
    (Key.D8, "8", "*"),
    (Key.D9, "9", "("),
    (Key.D0, "0", ")"),
    (Key.Oem3, "`", "`"),
     (Key.OemMinus, "-", "_"),
    (Key.OemPlus, "=", "+"),
    (Key.OemOpenBrackets, "[", "{"),
    (Key.OemCloseBrackets, "]", "}"),
    (Key.OemPipe, "\\", "|"),
    (Key.OemSemicolon, ";", ":"),
    (Key.OemQuotes, "'", "\""),
    (Key.OemComma, ",", "<"),
    (Key.OemPeriod, ".", ">"),
    (Key.OemQuestion, "/", "?"),
    (Key.Space, " ", " "),
    (Key.Enter, "Enter", "Enter"),
    (Key.LeftShift, "Shift", "Shift"),
    (Key.RightShift, "Shift", "Shift"),
    (Key.LeftCtrl, "Ctrl", "Ctrl"),
    (Key.LWin, "Win", "Win"),
    (Key.LeftAlt, "Alt", "Alt"),
    (Key.RightAlt, "Alt", "Alt"),
    (Key.RWin, "Win", "Win"),
    (Key.RightCtrl, "Ctrl", "Ctrl"),
    (Key.System, "Alt", "Alt"),
    (Key.Back, "Backspace", "Backspace"),
    (Key.Tab, "Tab", "Tab"),
    (Key.Capital, "Caps Lock", "Caps Lock"),

};
        //        Dictionary<Key, string> buttonsDictionary = new Dictionary<Key, string>()
        //    {
        //    { Key.D1, "1" },
        //    { Key.D2, "2" },
        //    { Key.D3, "3" },
        //    { Key.D4, "4" },
        //    { Key.D5, "5" },
        //    { Key.D6, "6" },
        //    { Key.D7, "7" },
        //    { Key.D8, "8" },
        //    { Key.D9, "9" },
        //    { Key.D0, "0" },
        //    { Key.OemMinus, "-" },
        //    { Key.OemPlus, "=" },
        //    { Key.Back, "Backspace" },
        //    { Key.Tab, "Tab" },
        //    { Key.Capital, "Caps Lock" },
        //    { Key.Q, "q" },
        //    { Key.W, "w" },
        //    { Key.E, "e" },
        //    { Key.R, "r" },
        //    { Key.T, "t" },
        //    { Key.Y, "y" },
        //    { Key.U, "u" },
        //    { Key.I, "i" },
        //    { Key.O, "o" },
        //    { Key.P, "p" },
        //    { Key.OemOpenBrackets, "[" },
        //    { Key.OemCloseBrackets, "]" },
        //    { Key.OemPipe, "\\" },
        //    { Key.A, "a" },
        //    { Key.S, "s" },
        //    { Key.D, "d" },
        //    { Key.F, "f" },
        //    { Key.G, "g" },
        //    { Key.H, "h" },
        //    { Key.J, "j" },
        //    { Key.K, "k" },
        //    { Key.L, "l" },
        //    { Key.OemSemicolon, ";" },
        //    { Key.OemQuotes, "'" },
        //    { Key.Enter, "Enter" },
        //    { Key.LeftShift, "Shift" },
        //    { Key.Z, "z" },
        //    { Key.X, "x" },
        //    { Key.C, "c" },
        //    { Key.V, "v" },
        //    { Key.B, "b" },
        //    { Key.N, "n" },
        //    { Key.M, "m" },
        //    { Key.OemComma, "," },
        //    { Key.OemPeriod, "." },
        //    { Key.OemQuestion, "/" },
        //    { Key.RightShift, "Shift" },
        //    { Key.LeftCtrl, "Ctrl" },
        //    { Key.LWin, "Win" },
        //    { Key.LeftAlt, "Alt" },
        //    { Key.Space, "Space" },
        //    { Key.RightAlt, "Alt" },
        //    { Key.RWin, "Win" },
        //    { Key.RightCtrl, "Ctrl" },
        //    { Key.System, "Alt" },
        //    { Key.Oem3, "`" },

        //};

        //        Dictionary<Key, string> buttonsDictionaryShift = new Dictionary<Key, string>()
        //    {
        //    { Key.D1, "!" },
        //    { Key.D2, "@" },
        //    { Key.D3, "#" },
        //    { Key.D4, "$" },
        //    { Key.D5, "%" },
        //    { Key.D6, "^" },
        //    { Key.D7, "&" },
        //    { Key.D8, "*" },
        //    { Key.D9, "(" },
        //    { Key.D0, ")" },
        //    { Key.OemMinus, "_" },
        //    { Key.OemPlus, "+" },
        //    { Key.OemOpenBrackets, "[" },
        //    { Key.OemCloseBrackets, "]" },
        //    { Key.OemPipe, "\\" },
        //    { Key.OemQuestion, "/" },
        //    { Key.Q, "Q" },
        //    { Key.W, "W" },
        //    { Key.E, "E" },
        //    { Key.R, "R" },
        //    { Key.T, "T" },
        //    { Key.Y, "Y" },
        //    { Key.U, "U" },
        //    { Key.I, "I" },
        //    { Key.O, "O" },
        //    { Key.P, "P" },
        //    { Key.A, "A" },
        //    { Key.S, "S" },
        //    { Key.D, "D" },
        //    { Key.F, "F" },
        //    { Key.G, "G" },
        //    { Key.H, "H" },
        //    { Key.J, "J" },
        //    { Key.K, "K" },
        //    { Key.L, "L" },
        //    { Key.Z, "Z" },
        //    { Key.X, "X" },
        //    { Key.C, "C" },
        //    { Key.V, "V" },
        //    { Key.B, "B" },
        //    { Key.N, "N" },
        //    { Key.M, "M" },
        //    { Key.Enter, "Enter" },
        //    { Key.LeftShift, "Shift" },
        //    { Key.RightShift, "Shift" },
        //    { Key.LeftCtrl, "Ctrl" },
        //    { Key.LWin, "Win" },
        //    { Key.LeftAlt, "Alt" },
        //    { Key.Space, "Space" },
        //    { Key.RightAlt, "Alt" },
        //    { Key.RWin, "Win" },
        //    { Key.RightCtrl, "Ctrl" },
        //    { Key.System, "Alt" },
        //    { Key.Oem3, "`" },
        //    { Key.Back, "Backspace" },
        //    { Key.Tab, "Tab" },
        //    { Key.Capital, "Caps Lock" }

        //        };
        bool shiftPress;
        bool CapsLockCheck;
        string keyPressed;
        //Brush savedButtonColor;
        //private HashSet<Key> pressedKeys = new HashSet<Key>();
        int cout;
        double startTime;
        int Level;
        DispatcherTimer dispatcherTimer;
        Color customColor;
        Color redColor;
        int errorCount;
        Color secondTextBlockColor;
        bool start;
        private MediaPlayer mediaPlayer;
        bool space;
        public MainWindow()
        {
            InitializeComponent();
            startTime = 1.2;
            shiftPress = false;
            cout = 1;
            errorCount = 0;
            customColor = Color.FromRgb(255, 165, 0);
            redColor = Color.FromRgb(255, 0, 10);
            secondTextBlockColor = Color.FromRgb(255, 165, 0);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(startTime);
            start = false;
            space = false;




        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            Random random = new Random();
            
            if (TextBlock1.Text.Length < 294)
            {

            
            int randomLevel1And2 = random.Next(0, 26);
            int randomLevel4And5 = random.Next(26, 37);
            int randomLevel6And7 = random.Next(37, 47);
            (Key key, string lowercaseLettersLevel1, string uppercaseLettersLevel2) Level1And2 = buttonList[randomLevel1And2];
            (Key key, string numbersLevel4, string notNumbersSymbolsLevel5) Level4And5 = buttonList[randomLevel4And5];
            (Key key, string symbolsBracesLevel6, string symbolsBracesLevel7) Level6And7 = buttonList[randomLevel6And7];
            string spaceLevel3 = " ";


            
            
            
            switch (Level)
            {
                case 1:
                    {
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                            if(TurnOffSoundCheckBox.IsChecked == false)
                            { 
                            MediaPlayer mediaPlayer = new MediaPlayer();
                            mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                            mediaPlayer.Play();
                            }
                            break;
                            
                        }
                       
                           
                case 2:
                    {
                        int randomNumber = random.Next(1, 3);
                        if (randomNumber == 1)
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                        if (randomNumber == 2)
                        AddTextWithCustomColorTextBlock1(Level1And2.uppercaseLettersLevel2, customColor);
                            if (TurnOffSoundCheckBox.IsChecked == false)
                            {
                                MediaPlayer mediaPlayer = new MediaPlayer();
                                mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                                mediaPlayer.Play();
                            }
                            break;
                        }
                case 3:
                    {
                        int randomNumber = random.Next(1, 4);
                        if (randomNumber == 1);
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                        if (randomNumber == 2)
                        AddTextWithCustomColorTextBlock1(Level1And2.uppercaseLettersLevel2, customColor);
                        if (randomNumber == 3)
                        AddTextWithCustomColorTextBlock1(spaceLevel3, customColor);
                            if (TurnOffSoundCheckBox.IsChecked == false)
                            {
                                MediaPlayer mediaPlayer = new MediaPlayer();
                                mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                                mediaPlayer.Play();
                            }
                            break;
                        }
                case 4:
                    {
                        int randomNumber = random.Next(1, 5);
                        if (randomNumber == 1)
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                        if (randomNumber == 2)
                        AddTextWithCustomColorTextBlock1(Level1And2.uppercaseLettersLevel2, customColor);
                        if (randomNumber == 3)
                        AddTextWithCustomColorTextBlock1(spaceLevel3, customColor);
                        if (randomNumber == 4)
                        AddTextWithCustomColorTextBlock1(Level4And5.numbersLevel4, customColor);
                            if (TurnOffSoundCheckBox.IsChecked == false)
                            {
                                MediaPlayer mediaPlayer = new MediaPlayer();
                                mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                                mediaPlayer.Play();
                            }
                            break;
                        }
                case 5:
                    {
                        int randomNumber = random.Next(1, 6);
                        if (randomNumber == 1)
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                        if (randomNumber == 2)
                        AddTextWithCustomColorTextBlock1(Level1And2.uppercaseLettersLevel2, customColor);
                        if (randomNumber == 3)
                        AddTextWithCustomColorTextBlock1(spaceLevel3, customColor);
                        if (randomNumber == 4)
                        AddTextWithCustomColorTextBlock1(Level4And5.numbersLevel4, customColor);
                        if (randomNumber == 5)
                        AddTextWithCustomColorTextBlock1(Level4And5.notNumbersSymbolsLevel5, customColor);
                            if (TurnOffSoundCheckBox.IsChecked == false)
                            {
                                MediaPlayer mediaPlayer = new MediaPlayer();
                                mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                                mediaPlayer.Play();
                            }
                            break;

                        }
                case 6:
                    {
                        int randomNumber = random.Next(1, 7);
                        if (randomNumber == 1)
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                        if (randomNumber == 2)
                        AddTextWithCustomColorTextBlock1(Level1And2.uppercaseLettersLevel2, customColor);
                        if (randomNumber == 3)
                        AddTextWithCustomColorTextBlock1(spaceLevel3, customColor);
                        if (randomNumber == 4)
                        AddTextWithCustomColorTextBlock1(Level4And5.numbersLevel4, customColor);
                        if (randomNumber == 5)
                        AddTextWithCustomColorTextBlock1(Level4And5.notNumbersSymbolsLevel5, customColor);
                        if (randomNumber == 6)
                        AddTextWithCustomColorTextBlock1(Level6And7.symbolsBracesLevel6, customColor);
                            if (TurnOffSoundCheckBox.IsChecked == false)
                            {
                                MediaPlayer mediaPlayer = new MediaPlayer();
                                mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                                mediaPlayer.Play();
                            }
                            break;
                        }
                case 7:
                    {
                        int randomNumber = random.Next(1, 8);
                        if (randomNumber == 1)
                        AddTextWithCustomColorTextBlock1(Level1And2.lowercaseLettersLevel1, customColor);
                        if (randomNumber == 2)
                        AddTextWithCustomColorTextBlock1(Level1And2.uppercaseLettersLevel2, customColor);
                        if (randomNumber == 3)
                        AddTextWithCustomColorTextBlock1(spaceLevel3, customColor);
                        if (randomNumber == 4)
                        AddTextWithCustomColorTextBlock1(Level4And5.numbersLevel4, customColor);
                        if (randomNumber == 5)
                        AddTextWithCustomColorTextBlock1(Level4And5.notNumbersSymbolsLevel5, customColor);
                        if (randomNumber == 6)
                        AddTextWithCustomColorTextBlock1(Level6And7.symbolsBracesLevel6, customColor);
                        if (randomNumber == 7)
                        AddTextWithCustomColorTextBlock1(Level6And7.symbolsBracesLevel7, customColor);
                            if (TurnOffSoundCheckBox.IsChecked == false)
                            {
                                MediaPlayer mediaPlayer = new MediaPlayer();
                                mediaPlayer.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\metronome.mp3"));
                                mediaPlayer.Play();
                            }
                            break;
                        }
                }

            }

            //string text = TextBlock1.Text;
            //if (!string.IsNullOrEmpty(text))
            //{
            //    char lastCharacter = text[text.Length - 1];

            //    
            //    if (char.IsDigit(lastCharacter))
            //    {
            //        TextBlock1.Background = Brushes.Red;
            //    }
            //    else if (char.IsLetter(lastCharacter))
            //    {
            //        TextBlock1.Background = Brushes.Blue;
            //    }
            //    else
            //    {
            //        TextBlock1.Background = Brushes.White;
            //    }
            //}



        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            ((Slider)sender).SelectionEnd = e.NewValue;
            TextBlockValue.Text = Convert.ToInt32(SliderName.Value).ToString();
            var time = SliderName.Value;
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Interval = TimeSpan.FromSeconds(startTime / time);
                SpeedPerMinute.Text = Convert.ToInt32(60 / (startTime / time)).ToString();
            }

        }

        private void SliderDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            TextBlockDifficulty.Text = Convert.ToInt32(SliderDifficulty.Value).ToString();
            Level = Convert.ToInt32(SliderDifficulty.Value);
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            //if (!pressedKeys.Contains(e.Key))
            //{
            //    pressedKeys.Add(e.Key);

            //    if (pressedKeys.Count == 2)
            //    {

            //        Key firstKey = pressedKeys.ElementAt(0);
            //        Key secondKey = pressedKeys.ElementAt(1);

            //        pressedKeys.Clear();
            //        //firstKey = Key.LeftShift; 

            //        key2Pressed = secondKey.ToString();
            //        pressedKeys.Remove(0);

            //        //MessageBox.Show(pressedKeys.ElementAt(0) + ":" + pressedKeys.ElementAt(1));
            //        //MessageBox.Show(secondKey.ToString());
            //    }
            //}

            Key key = e.Key;
            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {

                Grid2.Visibility = Visibility.Visible;
                shiftPress = true;
                Shift1.Style = (Style)FindResource("ShiftColor");
                Shift2.Style = (Style)FindResource("ShiftColor");
                CapsLock.Style = (Style)FindResource("ButtonСolor");
            }
            else
            {
                shiftPress = false;

            }

            if (Keyboard.IsKeyDown(Key.Capital))
            {

                Grid2.Visibility = Visibility.Visible;

                CapsLockCheck = true;
                cout += 1;
                if (cout == 3)
                {
                    cout = 1;
                    CapsLockCheck = false;
                    Grid2.Visibility = Visibility.Collapsed;
                }

                CapsLock.Style = (Style)FindResource("ShiftColor");
                Shift1.Style = (Style)FindResource("ButtonСolor");
                Shift2.Style = (Style)FindResource("ButtonСolor");
            }


            //if (buttonsDictionary.ContainsKey(e.Key))
            //{
            //    keyPressed = buttonsDictionary[e.Key];
            //}

            //if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            //{


            //    string key2Pressed = e.KeyboardDevice.Modifiers.ToString();

            //}
            //if (Keyboard.GetKeyStates(Key.LeftShift) == KeyStates.Down || Keyboard.GetKeyStates(Key.RightShift) == KeyStates.Down)
            //{

            //}
            //else
            //{
            //    keyPressed = e.Key.ToString();
            //}

            //if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            //    return;
            //else { 
            IterateButtonsInStackPanel(e.Key);

        


            //}
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                Grid2.Visibility = Visibility.Collapsed;
            }

            Key key = e.Key;

          
            IterateButtonsInStackPanel2(keyPressed);

        }

        private void AddTextWithCustomColorTextBlock1(string text, Color color)
        {
          
            SolidColorBrush brush = new SolidColorBrush(color);

            Run run = new Run(text);
            run.Foreground = brush;

            TextBlock1.Inlines.Add(run);
        }
        private void AddTextWithCustomColorTextBlock2(string text, Color color)
        {

            SolidColorBrush brush = new SolidColorBrush(color);

            Run run = new Run(text);
            run.Foreground = brush;

            TextBlock2.Inlines.Add(run);
        }
        private void IterateButtonsInStackPanel(Key key)
        {


            if (TextBlock2.Text.Length < 294)
            {
                bool trueCheck = false;
                if (!shiftPress)
                {
                    foreach (Grid allGrids in Grid0.Children.OfType<Grid>())
                    {

                        foreach (StackPanel stackPanel in Grid1.Children.OfType<StackPanel>())
                        {
                            foreach (Button button in stackPanel.Children.OfType<Button>())
                            {
                               
                                int count = 1;
                                foreach (var item in buttonList)
                                {

                                    count += 1;
                                    
                                    if (item.Item1 == key && (item.Item2.Equals(button.Content.ToString(), StringComparison.OrdinalIgnoreCase) || item.Item3.Equals(button.Content.ToString(), StringComparison.OrdinalIgnoreCase)))

                                    {

                                        button.Background = Brushes.LightBlue;
                                        if (!(count > 49) && trueCheck == false)
                                        {

                                            //if (!(TextBlock2 == null || string.IsNullOrEmpty(TextBlock2.Text)))
                                            //{
                                            //     if (TextBlock2.Text[Convert.ToInt32(TextBlock2.Text.Length) - 1] == TextBlock1.Text[Convert.ToInt32(TextBlock2.Text.Length) - 1])
                                            //    {
                                            //        secondTextBlockColor = redColor;

                                            //    }
                                            //}

                                            if (TextBlock1.Text.Length > TextBlock2.Text.Length)
                                            {


                                                if (string.IsNullOrEmpty(TextBlock2.Text))
                                                {

                                                    if (TextBlock1.Text[0].ToString() == button.Content.ToString())
                                                    {
                                                        AddTextWithCustomColorTextBlock2(button.Content.ToString(), secondTextBlockColor);
                                                    }
                                                    else
                                                    {
                                                        AddTextWithCustomColorTextBlock2(button.Content.ToString(), redColor);
                                                        errorCount++;
                                                        ErrorCountTextBlock.Text = errorCount.ToString();
                                                    }

                                                }
                                                else
                                                {
                                                    {
                                                        string letter1 = TextBlock1.Text[TextBlock2.Text.Length].ToString();
                                                        string letter2 = button.Content.ToString();
                                                        if (letter1 == letter2)
                                                        {
                                                            AddTextWithCustomColorTextBlock2(button.Content.ToString(), secondTextBlockColor);
                                                        }
                                                        else
                                                        {
                                                            AddTextWithCustomColorTextBlock2(button.Content.ToString(), redColor);
                                                            errorCount++;
                                                            ErrorCountTextBlock.Text = errorCount.ToString();
                                                        }

                                                    }
                                                }

                                            }

                                            trueCheck = true;
                                        }
                                        trueCheck = true;



                                        break;
                                    }

                                }

                            }

                        }
                    }

                }
                else
                {

                    foreach (StackPanel stackPanel in Grid2.Children.OfType<StackPanel>())
                    {
                        foreach (Button button in stackPanel.Children.OfType<Button>())
                        {

                            int count = 1;
                            foreach (var item in buttonList)
                            {

                                count += 1;
                                if (item.Item1 == key && (item.Item2.Equals(button.Content.ToString(), StringComparison.OrdinalIgnoreCase) || item.Item3.Equals(button.Content.ToString(), StringComparison.OrdinalIgnoreCase)))

                                {

                                    button.Background = Brushes.LightBlue;
                                    if (!(count > 49) && trueCheck == false)
                                    {

                                        //if (!(TextBlock2 == null || string.IsNullOrEmpty(TextBlock2.Text)))
                                        //{
                                        //     if (TextBlock2.Text[Convert.ToInt32(TextBlock2.Text.Length) - 1] == TextBlock1.Text[Convert.ToInt32(TextBlock2.Text.Length) - 1])
                                        //    {
                                        //        secondTextBlockColor = redColor;

                                        //    }
                                        //}

                                        if (TextBlock1.Text.Length > TextBlock2.Text.Length)
                                        {


                                            if (string.IsNullOrEmpty(TextBlock2.Text))
                                            {

                                                if (TextBlock1.Text[0].ToString() == button.Content.ToString())
                                                {
                                                    AddTextWithCustomColorTextBlock2(button.Content.ToString(), secondTextBlockColor);
                                                }
                                                else
                                                {
                                                    AddTextWithCustomColorTextBlock2(button.Content.ToString(), redColor);
                                                    errorCount++;
                                                    ErrorCountTextBlock.Text = errorCount.ToString();
                                                }

                                            }
                                            else
                                            {
                                                {
                                                    string letter1 = TextBlock1.Text[TextBlock2.Text.Length].ToString();
                                                    string letter2 = button.Content.ToString();
                                                    if (letter1 == letter2)
                                                    {
                                                        AddTextWithCustomColorTextBlock2(button.Content.ToString(), secondTextBlockColor);
                                                    }
                                                    else
                                                    {
                                                        AddTextWithCustomColorTextBlock2(button.Content.ToString(), redColor);
                                                        errorCount++;
                                                        ErrorCountTextBlock.Text = errorCount.ToString();
                                                    }

                                                }
                                            }

                                        }

                                        trueCheck = true;
                                    }
                                    trueCheck = true;



                                    break;
                                }

                            }

                        }
                    }

                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Game Over!\n\nNumber of Mistakes: {ErrorCountTextBlock.Text} \n\n Restart The Application?", "Game Over!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if(result == MessageBoxResult.Yes)
                {
                    Restart_Click(null, null);

                }
            }

        }

    



        private void IterateButtonsInStackPanel2(string key)
        {
            if (!shiftPress)
            {
                foreach (Grid allGrids in Grid0.Children.OfType<Grid>())
                {
                    foreach (StackPanel stackPanel in Grid1.Children.OfType<StackPanel>())
                    {
                        foreach (Button button in stackPanel.Children.OfType<Button>())
                        {

                            button.ClearValue(Button.BackgroundProperty);
                        }
                    }
                }
            }
            else
            {
                foreach (StackPanel stackPanel in Grid2.Children.OfType<StackPanel>())
                {
                    foreach (Button button in stackPanel.Children.OfType<Button>())
                    {

                        button.ClearValue(Button.BackgroundProperty);

                    }

                }

            }
            }

        private void TimerStart_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            dispatcherTimer.Start();
        }

        private void StopTimer_Click(object sender, RoutedEventArgs e)
        {
            if(start == true)
            { 
            dispatcherTimer.Stop();
            StartButton.Content = "Continue";
            }
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            System.Diagnostics.Process.Start(appPath);
            System.Windows.Application.Current.Shutdown();
        }
    }
    }
    

