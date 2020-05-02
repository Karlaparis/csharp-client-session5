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
using System.Diagnostics;

namespace Homework5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		bool turn = true; //true for X and false is for O
		int count = 0; // counts the number of turns
		String[] buttonArray = new String[9];
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			var column = Grid.GetColumn(button);
			var row = Grid.GetRow(button);
			var index = column + (row * 3);

			if (turn)
			{
				button.Content = "X";
				button.IsEnabled = false;// Allows placement only on empty spots 
				uxTurn.Text = "This is O's Turn";
			}
			else
			{
				button.Content = "O";
				button.IsEnabled = false;
				uxTurn.Text = "This is X's Turn";
			}

			buttonArray[index] = button.Content.ToString();
			turn = !turn;
			count++;

			if (count >= 3)
			{
				if (count < 9)
				{ Checkwinner(buttonArray); }
			};

		}


		private void Checkwinner(String[] buttonArray)

		{
			bool thereIsaWinner = false;

			//Horizontal Checks********************************************************************************************************

			if (!string.IsNullOrEmpty(buttonArray[0]) && !string.IsNullOrEmpty(buttonArray[1]) && !string.IsNullOrEmpty(buttonArray[2]))
			{
				if (buttonArray[0] == buttonArray[1] && buttonArray[1] == buttonArray[2])

					thereIsaWinner = true;				
			}

			if (!string.IsNullOrEmpty(buttonArray[3]) && !string.IsNullOrEmpty(buttonArray[4]) && !string.IsNullOrEmpty(buttonArray[5]))
			{
				if (buttonArray[3] == buttonArray[4] && buttonArray[4] == buttonArray[5])

					thereIsaWinner = true;				
			}

			if (!string.IsNullOrEmpty(buttonArray[6]) && !string.IsNullOrEmpty(buttonArray[7]) && !string.IsNullOrEmpty(buttonArray[8]))
			{
				if (buttonArray[6] == buttonArray[7] && buttonArray[7] == buttonArray[8])

					thereIsaWinner = true;
			}


			//Vertical Checks**********************************************************************************************************

			if (!string.IsNullOrEmpty(buttonArray[0]) && !string.IsNullOrEmpty(buttonArray[3]) && !string.IsNullOrEmpty(buttonArray[6]))
			{
				if (buttonArray[0] == buttonArray[3] && buttonArray[3] == buttonArray[6])
					thereIsaWinner = true;
			}

			if (!string.IsNullOrEmpty(buttonArray[1]) && !string.IsNullOrEmpty(buttonArray[4]) && !string.IsNullOrEmpty(buttonArray[7]))
			{
				if (buttonArray[1] == buttonArray[4] && buttonArray[4] == buttonArray[7])

					thereIsaWinner = true;
			}

			if (!string.IsNullOrEmpty(buttonArray[2]) && !string.IsNullOrEmpty(buttonArray[5]) && !string.IsNullOrEmpty(buttonArray[8]))
			{
				if (buttonArray[2] == buttonArray[5] && buttonArray[5] == buttonArray[8])

					thereIsaWinner = true;
			}

			//Diagonal Checks**************************************************************************************************************

			if (!string.IsNullOrEmpty(buttonArray[2]) && !string.IsNullOrEmpty(buttonArray[4]) && !string.IsNullOrEmpty(buttonArray[6]))
			{
				if (buttonArray[2] == buttonArray[4] && buttonArray[4] == buttonArray[6])

					thereIsaWinner = true;
			}

			if (!string.IsNullOrEmpty(buttonArray[0]) && !string.IsNullOrEmpty(buttonArray[4]) && !string.IsNullOrEmpty(buttonArray[8]))
			{
				if (buttonArray[0] == buttonArray[4] && buttonArray[4] == buttonArray[8])

					thereIsaWinner = true;
			}


			if (thereIsaWinner)
			{
				string winner = "";

				if (turn)

					winner = "O";

				else winner = "X";

				uxTurn.Text = winner + " is a Winner!";

				uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
				{
					button.IsEnabled = false;
				});
			}
		}


		private void uxNewGame_Click(object sender, RoutedEventArgs e)
		{
			uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
			{
				button.IsEnabled = true;
				button.Content = string.Empty;

			});

			turn = true;
			count = 0;
			buttonArray[0] = "";
			buttonArray[1] = "";
			buttonArray[2] = "";
			buttonArray[3] = "";
			buttonArray[4] = "";
			buttonArray[5] = "";
			buttonArray[6] = "";
			buttonArray[7] = "";
			buttonArray[8] = "";
		}

		private void uxExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

	}
}
