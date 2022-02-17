using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Косынка
{
	public enum esuit { hearts, diamonds, spades, clubs }
	public enum ecolor { red, black }
	class Card
	{
		esuit suit;
		ecolor color;
		int value;
		Image image;
		public Image back = new Bitmap(Properties.Resources.igralnye_karty_rubashka_1988);
		Image front;
		public Card(esuit s,int v, Image i)
		{
			suit = s;
			if (suit == esuit.diamonds || suit == esuit.hearts) color = ecolor.red;
			else color = ecolor.black;
			value = v;
			front = i;
			image = back;
		}
		public esuit Suit
		{
			get { return suit; }
		}
		public ecolor Color
		{
			get { return color; }
		}
		public int Value
		{
			get { return value; }
		}
		public Image Image
		{
			get { return image; }
			set { image = value; }
		}
		public Image Front
		{
			get { return front; }
			set { front = value; }
		}
	}
}
