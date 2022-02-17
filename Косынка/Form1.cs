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
	public partial class Form1 : Form
	{
		List<Panel> playing_panels;
		List<Panel> final_panels;
		List<Panel> all_panels;
		Game g = new Game();

		List<Card> Chosen = new List<Card>();

		public Form1()
		{
			InitializeComponent();
			playing_panels = new List<Panel>() { panel1, panel2, panel3, panel4, panel5, panel6, panel7 };
			final_panels = new List<Panel>() { panel10, panel11, panel12, panel13 };
			all_panels= new List<Panel>() { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel10, panel11, panel12, panel13, panel9 };
		}
		
		private void Form1_Load(object sender, EventArgs e)
		{
			g.FillDecks();
			DrawCards();
		}
		private void DrawCards()
		{
			for (int i = 0; i < playing_panels.Count; i++)
			{
				for (int j = 0; j < g.Playing_decks[i].Count; j++)
				{
					if (j == g.Playing_decks[i].Count - 1 && g.Playing_decks[i].ElementAt(j).Image == g.Playing_decks[i].ElementAt(j).back) g.Flip(g.Playing_decks[i].ElementAt(j));
					playing_panels[i].Controls[j].BackgroundImage = g.Playing_decks[i].ElementAt(j).Image;
					playing_panels[i].Controls[j].Tag = g.Playing_decks[i].ElementAt(j);
				}
				for (int j= g.Playing_decks[i].Count; j < 18;j++)
				{
					playing_panels[i].Controls[j].BackgroundImage = null;
					playing_panels[i].Controls[j].Tag = null;
				}
			}
			for (int i = 0; i < final_panels.Count; i++)
			{
				if (g.Final_decks[i].Count == 0)
				{
					final_panels[i].Controls[0].BackgroundImage = null;
					final_panels[i].Controls[0].Tag = null;
				}
				for (int j = 0; j < g.Final_decks[i].Count; j++)
				{
					if (g.Final_decks[i].ElementAt(j) != null)
					{
						final_panels[i].Controls[0].BackgroundImage = g.Final_decks[i].ElementAt(j).Image;
						final_panels[i].Controls[0].Tag = g.Final_decks[i].ElementAt(j);
					}
				}
			}
			if (g.throwed.Count != 0)
			{
				all_panels.Last().Controls[0].BackgroundImage = g.throwed.Last().Image;
				all_panels.Last().Controls[0].Tag = g.throwed.Last();
			}
			else
			{
				all_panels.Last().Controls[0].BackgroundImage = null;
				all_panels.Last().Controls[0].Tag = null;
			}
		}
		private void PB_Click(object sender, EventArgs e)
		{
			if (Chosen.Count == 0)
			{
				if ((sender as PictureBox).BackgroundImage != new Bitmap(Properties.Resources.igralnye_karty_rubashka_1988)) g.SetChosen((sender as PictureBox).Tag as Card, Chosen);
			}
			else g.MoveTo(Chosen, (sender as PictureBox).Tag as Card, all_panels.IndexOf((sender as PictureBox).Parent as Panel));
			DrawCards();
		}
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			g.TrowNew();
			DrawCards();
		}
	}
}
