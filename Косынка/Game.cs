using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Косынка
{
	class Game
	{
		Random random = new Random();
		List<Card> Deck = new List<Card>() { new Card(esuit.clubs, 2, new Bitmap(Properties.Resources._2_of_clubs)), new Card(esuit.clubs, 3, new Bitmap(Properties.Resources._3_of_clubs)), new Card(esuit.clubs, 4, new Bitmap(Properties.Resources._4_of_clubs)), new Card(esuit.clubs, 5, new Bitmap(Properties.Resources._5_of_clubs)), new Card(esuit.clubs, 6, new Bitmap(Properties.Resources._6_of_clubs)), new Card(esuit.clubs, 7, new Bitmap(Properties.Resources._7_of_clubs)), new Card(esuit.clubs, 8, new Bitmap(Properties.Resources._8_of_clubs)), new Card(esuit.clubs, 9, new Bitmap(Properties.Resources._9_of_clubs)), new Card(esuit.clubs, 10, new Bitmap(Properties.Resources._10_of_clubs)), new Card(esuit.clubs, 11, new Bitmap(Properties.Resources.jack_of_clubs2)), new Card(esuit.clubs, 12, new Bitmap(Properties.Resources.queen_of_clubs2)), new Card(esuit.clubs, 13, new Bitmap(Properties.Resources.king_of_clubs2)), new Card(esuit.clubs, 14, new Bitmap(Properties.Resources.ace_of_clubs)),
											  new Card(esuit.diamonds, 2, new Bitmap(Properties.Resources._2_of_diamonds)), new Card(esuit.diamonds, 3, new Bitmap(Properties.Resources._3_of_diamonds)), new Card(esuit.diamonds, 4, new Bitmap(Properties.Resources._4_of_diamonds)), new Card(esuit.diamonds, 5, new Bitmap(Properties.Resources._5_of_diamonds)), new Card(esuit.diamonds, 6, new Bitmap(Properties.Resources._6_of_diamonds)), new Card(esuit.diamonds, 7, new Bitmap(Properties.Resources._7_of_diamonds)), new Card(esuit.diamonds, 8, new Bitmap(Properties.Resources._8_of_diamonds)), new Card(esuit.diamonds, 9, new Bitmap(Properties.Resources._9_of_diamonds)), new Card(esuit.diamonds, 10, new Bitmap(Properties.Resources._10_of_diamonds)), new Card(esuit.diamonds, 11, new Bitmap(Properties.Resources.jack_of_diamonds2)), new Card(esuit.diamonds, 12, new Bitmap(Properties.Resources.queen_of_diamonds2)), new Card(esuit.diamonds, 13, new Bitmap(Properties.Resources.king_of_diamonds2)), new Card(esuit.diamonds, 14, new Bitmap(Properties.Resources.ace_of_diamonds)),
											  new Card(esuit.hearts, 2, new Bitmap(Properties.Resources._2_of_hearts)), new Card(esuit.hearts, 3, new Bitmap(Properties.Resources._3_of_hearts)), new Card(esuit.hearts, 4, new Bitmap(Properties.Resources._4_of_hearts)), new Card(esuit.hearts, 5, new Bitmap(Properties.Resources._5_of_hearts)), new Card(esuit.hearts, 6, new Bitmap(Properties.Resources._6_of_hearts)), new Card(esuit.hearts, 7, new Bitmap(Properties.Resources._7_of_hearts)), new Card(esuit.hearts, 8, new Bitmap(Properties.Resources._8_of_hearts)), new Card(esuit.hearts, 9, new Bitmap(Properties.Resources._9_of_hearts)), new Card(esuit.hearts, 10, new Bitmap(Properties.Resources._10_of_hearts)), new Card(esuit.hearts, 11, new Bitmap(Properties.Resources.jack_of_hearts2)), new Card(esuit.hearts, 12, new Bitmap(Properties.Resources.queen_of_hearts2)), new Card(esuit.hearts, 13, new Bitmap(Properties.Resources.king_of_hearts2)), new Card(esuit.hearts, 14, new Bitmap(Properties.Resources.ace_of_hearts)),
											  new Card(esuit.spades, 2, new Bitmap(Properties.Resources._2_of_spades)), new Card(esuit.spades, 3, new Bitmap(Properties.Resources._3_of_spades)), new Card(esuit.spades, 4, new Bitmap(Properties.Resources._4_of_spades)), new Card(esuit.spades, 5, new Bitmap(Properties.Resources._5_of_spades)), new Card(esuit.spades, 6, new Bitmap(Properties.Resources._6_of_spades)), new Card(esuit.spades, 7, new Bitmap(Properties.Resources._7_of_spades)), new Card(esuit.spades, 8, new Bitmap(Properties.Resources._8_of_spades)), new Card(esuit.spades, 9, new Bitmap(Properties.Resources._9_of_spades)), new Card(esuit.spades, 10, new Bitmap(Properties.Resources._10_of_spades)), new Card(esuit.spades, 11, new Bitmap(Properties.Resources.jack_of_spades2)), new Card(esuit.spades, 12, new Bitmap(Properties.Resources.queen_of_spades2)), new Card(esuit.spades, 13, new Bitmap(Properties.Resources.king_of_spades2)), new Card(esuit.spades, 14, new Bitmap(Properties.Resources.ace_of_spades))};
		List<Card> Deck1 = new List<Card>();
		List<Card> Deck2 = new List<Card>();
		List<Card> Deck3 = new List<Card>();
		List<Card> Deck4 = new List<Card>();
		List<Card> Deck5 = new List<Card>();
		List<Card> Deck6 = new List<Card>();
		List<Card> Deck7 = new List<Card>();
		List<Card> DeckC = new List<Card>();
		List<Card> DeckD = new List<Card>();
		List<Card> DeckH = new List<Card>();
		List<Card> DeckS = new List<Card>();
		List<Card> Throwed = new List<Card>();
		List<List<Card>> playing_decks;
		List<List<Card>> final_decks;
		List<List<Card>> all_decks;
		public Game()
		{
			for (int i = Deck.Count - 1; i >= 1; i--)
			{
				int j = random.Next(i + 1);
				var temp = Deck[j];
				Deck[j] = Deck[i];
				Deck[i] = temp;
			}
		}
		public void FillDecks()
		{
			playing_decks = new List<List<Card>>() { Deck1, Deck2, Deck3, Deck4, Deck5, Deck6, Deck7 };
			final_decks = new List<List<Card>>() { DeckC, DeckD, DeckH, DeckS};
			all_decks = new List<List<Card>>() { Deck1, Deck2, Deck3, Deck4, Deck5, Deck6, Deck7, DeckC, DeckD, DeckH, DeckS, Throwed};
			for (int i=0; i<7; i++)
			{
				for (int j=0; j<=i; j++)
				{
					playing_decks[i].Add(Deck[Deck.Count-1]);
					if (j == i) Flip(playing_decks[i].Last());
					Deck.RemoveAt(Deck.Count-1);
				}
			}
		}
		public void TrowNew()
		{
			if (Deck.Count != 0)
			{
				Throwed.Add(Deck.Last());
				Deck.Remove(Deck.Last());
				Flip(Throwed.Last());
			}
			else
			{
				Throwed.Reverse();
				while (Throwed.Count!=0)
				{
					Flip(Throwed.Last());
					Deck.Add(Throwed.Last());
					Throwed.Remove(Throwed.Last());
				}
				if (Deck.Count != 0)
				{
					Throwed.Add(Deck.Last());
					Deck.Remove(Deck.Last());
					Flip(Throwed.Last());
				}
			}
		}
		public void Flip(Card c)
		{
			if (c.Image == c.back) c.Image = c.Front;
			else c.Image = c.back;
		}
		public void SetChosen(Card c, List<Card> lc)
		{
			if (Throwed.Contains(c) || DeckC.Contains(c) || DeckD.Contains(c) || DeckH.Contains(c) || DeckS.Contains(c))
			{
				lc.Clear();
				lc.Add(c);
			}
			else
			{
				foreach (List<Card> x in all_decks)
				{
					if (x.Contains(c))
					{
						for (int i = x.IndexOf(c); i < x.Count; i++)
						{
							lc.Add(x[i]);
						}
					}
				}
			}
		}
		public void MoveTo(List<Card> chosen, Card moveTo, int deck)
		{
			foreach (List<Card> x in all_decks)
			{
				if (x.Contains(chosen[0]))
				{
					if (chosen.Count == 1 && (moveTo == null && (chosen[0].Value == 14 && (final_decks.Contains(all_decks[deck])))))
					{
						all_decks[deck].Add(chosen[0]);
						if (Throwed.Contains(x.Last())) Throwed.Remove(Throwed.Last());
						else x.Remove(x.Last());
					}
					else if (chosen.Count == 1 && moveTo != null && (moveTo.Value == 14 && chosen[0].Value == 2 && chosen[0].Suit == moveTo.Suit && (final_decks.Contains(all_decks[deck]))))
					{
						all_decks[deck].Add(chosen[0]);
						if (Throwed.Contains(x.Last())) Throwed.Remove(Throwed.Last());
						else x.Remove(x.Last());
					}
					else if ( moveTo == null && chosen[0].Value == 13 && (playing_decks.Contains(all_decks[deck])))
					{
						for (int i = 0; i < chosen.Count; i++)
						{
							all_decks[deck].Add(chosen[i]);
							if (Throwed.Contains(x.Last())) Throwed.Remove(Throwed.Last());
							else x.Remove(x.Last());
						}
					}
					else if (moveTo != null)
					{
						if (all_decks[deck].Last() == moveTo &&
						 (moveTo.Value - chosen[0].Value == 1 && moveTo.Color != chosen[0].Color && playing_decks.Contains(all_decks[deck]) ||
						 (chosen.Count == 1 && moveTo.Value - chosen[0].Value == -1 && moveTo.Suit== chosen[0].Suit && final_decks.Contains(all_decks[deck]))))
						{
							for (int i = 0; i < chosen.Count; i++)
							{
								all_decks[deck].Add(chosen[i]);
								if (Throwed.Contains(x.Last())) Throwed.Remove(Throwed.Last());
								else x.Remove(chosen[i]);
							}
						}
					}
				}
			}
			chosen.Clear();
			moveTo = null;
		}
		public List<List<Card>> Playing_decks
		{
			get { return playing_decks; }
		}
		public List<List<Card>> Final_decks
		{
			get { return final_decks; }
		}
		public List<List<Card>> All_decks
		{
			get { return all_decks; }
		}
		public List<Card> throwed
		{
			get { return Throwed; }
		}
	}
}
