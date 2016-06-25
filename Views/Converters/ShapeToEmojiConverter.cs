using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mvvmdex.Views.Converters
{
	public class ShapeToEmojiConverter : IValueConverter 
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var shape = (string)value;

			switch (shape)
			{
				case "ball":
					return "⚫";
				case "squiggle":
					return "🐍";
				case "fish":
					return "🐟";
				case "arms":
					return "👐";
				case "blob":
					return "🌀";
				case "upright":
					return "🚶";
				case "legs":
					return "👟";
				case "quadruped":
					return "🐎";
				case "wings":
					return "🐦";
				case "tentacles":
					return "🐙";
				case "heads":
					return "👥";
				case "humanoid":
					return "💃";
				case "bug-wings":
					return "🐝";
				case "armor":
					return "🐜";
				default:
					return "🚫";

			}

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

