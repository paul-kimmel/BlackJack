using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Softconcepts.BlackJackLib;

namespace WinBlackJack
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItemSuit;
		private System.Windows.Forms.MenuItem menuItemClubs;
		private System.Windows.Forms.MenuItem menuItemDiamonds;
		private System.Windows.Forms.MenuItem menuItemHearts;
		private System.Windows.Forms.MenuItem menuItemSpades;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItemSuit = new System.Windows.Forms.MenuItem();
			this.menuItemClubs = new System.Windows.Forms.MenuItem();
			this.menuItemDiamonds = new System.Windows.Forms.MenuItem();
			this.menuItemHearts = new System.Windows.Forms.MenuItem();
			this.menuItemSpades = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem2,
																																							this.menuItemSuit,
																																							this.menuItem3,
																																							this.menuItem4});
			this.menuItem1.Text = "Test";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem8,
																																							this.menuItem9,
																																							this.menuItem10,
																																							this.menuItem11,
																																							this.menuItem12,
																																							this.menuItem13,
																																							this.menuItem14,
																																							this.menuItem15,
																																							this.menuItem16,
																																							this.menuItem17,
																																							this.menuItem18,
																																							this.menuItem19,
																																							this.menuItem20});
			this.menuItem2.Text = "Card";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "A";
			this.menuItem8.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "2";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.menuItem10.Text = "3";
			this.menuItem10.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "4";
			this.menuItem11.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 4;
			this.menuItem12.Text = "5";
			this.menuItem12.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.Text = "6";
			this.menuItem13.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 6;
			this.menuItem14.Text = "7";
			this.menuItem14.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 7;
			this.menuItem15.Text = "8";
			this.menuItem15.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 8;
			this.menuItem16.Text = "9";
			this.menuItem16.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 9;
			this.menuItem17.Text = "10";
			this.menuItem17.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 10;
			this.menuItem18.Text = "J";
			this.menuItem18.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 11;
			this.menuItem19.Text = "Q";
			this.menuItem19.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 12;
			this.menuItem20.Text = "K";
			this.menuItem20.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItemSuit
			// 
			this.menuItemSuit.Index = 1;
			this.menuItemSuit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																								 this.menuItemClubs,
																																								 this.menuItemDiamonds,
																																								 this.menuItemHearts,
																																								 this.menuItemSpades});
			this.menuItemSuit.Text = "Suit";
			this.menuItemSuit.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItemClubs
			// 
			this.menuItemClubs.Checked = true;
			this.menuItemClubs.Index = 0;
			this.menuItemClubs.Text = "Clubs";
			this.menuItemClubs.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItemDiamonds
			// 
			this.menuItemDiamonds.Index = 1;
			this.menuItemDiamonds.Text = "Diamonds";
			this.menuItemDiamonds.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItemHearts
			// 
			this.menuItemHearts.Index = 2;
			this.menuItemHearts.Text = "Hearts";
			this.menuItemHearts.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItemSpades
			// 
			this.menuItemSpades.Index = 3;
			this.menuItemSpades.Text = "Spades";
			this.menuItemSpades.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuItem3.Text = "Random Hand";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click_1);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Random Dealer Hand";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 494);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(576, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "statusBar1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(576, 516);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "TestCards";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			PaintCard(e.Graphics);
		}
		
		private Card card = null;
		private void PaintCard(Graphics g)
		{
			if( card == null ) return;
			((GraphicCard)card).Paint(g, 75, 50, 50, 100);
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			int suit = GetSuit();
			string cardValue = ((MenuItem)sender).Text;
			
			switch(cardValue)
			{
				case "A":
					card = new Ace((Suit)suit);
					break;
				case "2":
					card = new Two((Suit)suit);
					break;
				case "3":
					card = new Three((Suit)suit);
					break;
				case "4":
					card = new Four((Suit)suit);
					break;
				case "5":
					card = new Five((Suit)suit);
					break;
				case "6":
					card = new Six((Suit)suit);
					break;
				case "7":
					card = new Seven((Suit)suit);
					break;
				case "8":
					card = new Eight((Suit)suit);
					break;
				case "9":
					card = new Nine((Suit)suit);
					break;
				case "10":
					card = new Ten((Suit)suit);
					break;
				case "J":
					card = new Jack((Suit)suit);
					break;
				case "Q":
					card = new Queen((Suit)suit);
					break;
				case "K":
					card = new King((Suit)suit);
					break;
			}
			
			Invalidate();
		}
			
		private int GetSuit()
		{
			for( int i=0; i<menuItemSuit.MenuItems.Count; i++)
				if( menuItemSuit.MenuItems[i].Checked )
					return i;
					
			//default to clubs
			return 0;
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			foreach(MenuItem item in menuItemSuit.MenuItems)
				item.Checked = false;
				
			((MenuItem)sender).Checked = !((MenuItem)sender).Checked;
			
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Card.cdtTerm();
		}

		private void menuItem3_Click_1(object sender, System.EventArgs e)
		{
			Refresh();
			BlackJack bj = new BlackJack(2, 6);
			bj.GetPlayer(1).GraphicPrintHand(CreateGraphics(), 75, 50, 75, 100);
			
			while(!bj.GetPlayer(1).IsBust() && bj.GetPlayer(1).GetHandValueHigh() < 17)
			{
				bj.DealToPlayer(1);
				Refresh();
				bj.GetPlayer(1).GraphicPrintHand(CreateGraphics(), 75, 50, 75, 100);
			}
			
			statusBar1.Text = bj.GetPlayer(1).GetHandValueHigh().ToString();
				
		}
	}
}
