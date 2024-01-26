//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Diagnostics;
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
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanelPlayer;
		private System.Windows.Forms.StatusBarPanel statusBarPanelDealer;
		private System.Windows.Forms.StatusBarPanel statusBarPanelHint;		
			
		private BlackJack game = null;
		private System.Windows.Forms.StatusBarPanel statusBarPanelBet;
		private System.Windows.Forms.StatusBarPanel statusBarPanelBalance;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem Deal;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItemChoices;
		private System.Windows.Forms.MenuItem menuItemHit;
		private System.Windows.Forms.MenuItem menuItemDouble;
		private System.Windows.Forms.MenuItem menuItemSplit;
		private System.Windows.Forms.MenuItem menuItemSurrender;
		private System.Windows.Forms.MenuItem menuItemStand;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItemDecreaseBet;
		private System.Windows.Forms.MenuItem menuItemIncreaseBet;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButtonHit;
		private System.Windows.Forms.ToolBarButton toolBarButtonDouble;
		private System.Windows.Forms.ToolBarButton toolBarButtonSplit;
		private System.Windows.Forms.ToolBarButton toolBarButtonSurrender;
		private System.Windows.Forms.ToolBarButton toolBarButtonStand;
		private System.Windows.Forms.ToolBarButton toolBarButton;
		private System.Windows.Forms.ToolBarButton toolBarButtonIncrease;
		private System.Windows.Forms.ToolBarButton toolBarButtonDecrease;
		private System.ComponentModel.IContainer components;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanelPlayer = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelBet = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelBalance = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelDealer = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelHint = new System.Windows.Forms.StatusBarPanel();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.Deal = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItemChoices = new System.Windows.Forms.MenuItem();
			this.menuItemHit = new System.Windows.Forms.MenuItem();
			this.menuItemDouble = new System.Windows.Forms.MenuItem();
			this.menuItemSplit = new System.Windows.Forms.MenuItem();
			this.menuItemSurrender = new System.Windows.Forms.MenuItem();
			this.menuItemStand = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItemDecreaseBet = new System.Windows.Forms.MenuItem();
			this.menuItemIncreaseBet = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButtonHit = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonDouble = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSplit = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSurrender = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonStand = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonIncrease = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonDecrease = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelPlayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelBet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelBalance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDealer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelHint)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 494);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanelPlayer,
																						  this.statusBarPanelBet,
																						  this.statusBarPanelBalance,
																						  this.statusBarPanelDealer,
																						  this.statusBarPanelHint});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(576, 22);
			this.statusBar1.SizingGrip = false;
			this.statusBar1.TabIndex = 0;
			// 
			// statusBarPanelPlayer
			// 
			this.statusBarPanelPlayer.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelPlayer.Width = 115;
			// 
			// statusBarPanelBet
			// 
			this.statusBarPanelBet.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelBet.Width = 115;
			// 
			// statusBarPanelBalance
			// 
			this.statusBarPanelBalance.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelBalance.Width = 115;
			// 
			// statusBarPanelDealer
			// 
			this.statusBarPanelDealer.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelDealer.Width = 115;
			// 
			// statusBarPanelHint
			// 
			this.statusBarPanelHint.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelHint.Text = "Hint:";
			this.statusBarPanelHint.Width = 115;
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.Deal,
																					  this.menuItem7,
																					  this.menuItem24,
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem21});
			this.menuItem5.Text = "&Game";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuItem6.Text = "&New";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// Deal
			// 
			this.Deal.Index = 1;
			this.Deal.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.Deal.Text = "&Deal";
			this.Deal.Click += new System.EventHandler(this.Deal_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 3;
			this.menuItem24.Shortcut = System.Windows.Forms.Shortcut.F4;
			this.menuItem24.Text = "&Options";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.F7;
			this.menuItem1.Text = "Statistics";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 6;
			this.menuItem21.Text = "E&xit";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// menuItemChoices
			// 
			this.menuItemChoices.Index = 1;
			this.menuItemChoices.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemHit,
																							this.menuItemDouble,
																							this.menuItemSplit,
																							this.menuItemSurrender,
																							this.menuItemStand,
																							this.menuItem30,
																							this.menuItemDecreaseBet,
																							this.menuItemIncreaseBet});
			this.menuItemChoices.Text = "&Choices";
			// 
			// menuItemHit
			// 
			this.menuItemHit.Index = 0;
			this.menuItemHit.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItemHit.Text = "&Hit";
			this.menuItemHit.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItemDouble
			// 
			this.menuItemDouble.Index = 1;
			this.menuItemDouble.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.menuItemDouble.Text = "&Double";
			this.menuItemDouble.Click += new System.EventHandler(this.menuItem25_Click);
			// 
			// menuItemSplit
			// 
			this.menuItemSplit.Index = 2;
			this.menuItemSplit.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItemSplit.Text = "&Split";
			this.menuItemSplit.Click += new System.EventHandler(this.menuItemSplit_Click);
			// 
			// menuItemSurrender
			// 
			this.menuItemSurrender.Index = 3;
			this.menuItemSurrender.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.menuItemSurrender.Text = "Sur&render";
			this.menuItemSurrender.Click += new System.EventHandler(this.menuItem29_Click);
			// 
			// menuItemStand
			// 
			this.menuItemStand.Index = 4;
			this.menuItemStand.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this.menuItemStand.Text = "S&tand";
			this.menuItemStand.Click += new System.EventHandler(this.menuItem27_Click);
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 5;
			this.menuItem30.Text = "-";
			// 
			// menuItemDecreaseBet
			// 
			this.menuItemDecreaseBet.Index = 6;
			this.menuItemDecreaseBet.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItemDecreaseBet.Text = "Decrease Bet by Minimum";
			this.menuItemDecreaseBet.Click += new System.EventHandler(this.menuItem32_Click);
			// 
			// menuItemIncreaseBet
			// 
			this.menuItemIncreaseBet.Index = 7;
			this.menuItemIncreaseBet.Shortcut = System.Windows.Forms.Shortcut.Ins;
			this.menuItemIncreaseBet.Text = "Increase Bet by Minimum";
			this.menuItemIncreaseBet.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 2;
			this.menuItem22.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem23});
			this.menuItem22.Text = "&Help";
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 0;
			this.menuItem23.Text = "&About";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItemChoices,
																					  this.menuItem22});
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButtonHit,
																						this.toolBarButtonDouble,
																						this.toolBarButtonSplit,
																						this.toolBarButtonSurrender,
																						this.toolBarButtonStand,
																						this.toolBarButton,
																						this.toolBarButtonIncrease,
																						this.toolBarButtonDecrease});
			this.toolBar1.ButtonSize = new System.Drawing.Size(66, 39);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(576, 45);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButtonHit
			// 
			this.toolBarButtonHit.Text = "Hit";
			// 
			// toolBarButtonDouble
			// 
			this.toolBarButtonDouble.Text = "Double";
			// 
			// toolBarButtonSplit
			// 
			this.toolBarButtonSplit.Text = "Split";
			// 
			// toolBarButtonSurrender
			// 
			this.toolBarButtonSurrender.Text = "Surrender";
			// 
			// toolBarButtonStand
			// 
			this.toolBarButtonStand.Text = "Stand";
			// 
			// toolBarButton
			// 
			this.toolBarButton.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonIncrease
			// 
			this.toolBarButtonIncrease.Text = "+";
			// 
			// toolBarButtonDecrease
			// 
			this.toolBarButtonDecrease.Text = "-";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Green;
			this.ClientSize = new System.Drawing.Size(576, 516);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.statusBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "BlackJack for Windows";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelPlayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelBet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelBalance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDealer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelHint)).EndInit();
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
		  StartNewGame();
		}
		
		private void StartNewGame()
		{
		  game = new BlackJack(1, 6);
		  game.OnNewGame += new EventHandler(OnNewGame);
		  game.OnEndGame += new EventHandler(OnEndGame);
		  game.OnHitCurrentHand += new EventHandler(OnHitCurrentHand);
		  game.OnNextHand += new EventHandler(OnNextHand);
		  game.OnStandCurrentHand += new EventHandler(OnStandCurrentHand);
		  game.BeforePlayDealerHand += new EventHandler(BeforePlayDealerHand);
		  game.OnDealerHandChanged += new EventHandler(OnDealerHandChanged);
		  game.OnDoubleCurrentHand += new EventHandler(OnDoubleCurrentHand);
		  game.OnSurrenderCurrentHand += new EventHandler(OnSurrenderCurrentHand);
		  game.OnSplitCurrentHand += new EventHandler(OnSplitCurrentHand);
		  game.OnDecidePlay += new EventHandler(OnDecidePlay);
		  DisableChoiceSubMenus();
		  ClearStatus();
		  Invalidate();
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			PaintHands(e.Graphics);
		}
		
		private void PaintHands(Graphics g)
		{
			if( game == null ) return;
			PaintDealerHand(g);
			PaintPlayerHand(g);
		}
		
		private void PaintDealerHand(Graphics g)
		{
			game.Dealer.GraphicPrintHand(g, (int)this.ClientRectangle.Width / 3, 
				(int)this.ClientRectangle.Height/6, 75, 100, IsGameOver);
		}
	    
		private void PaintPlayerHand(Graphics g)
		{
			game.GetPlayer(0).GraphicPrintHand(g, ClientRectangle.Width / 3, 
				(int)3* this.ClientRectangle.Height/6, 75, 100, game.CurrentHand);     
		}
			
		private Card card = null;
		private void PaintCard(Graphics g)
		{
			if( card == null ) return;
			((GraphicCard)card).PaintFace(g, 75, 50, 50, 100);
		}

			
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			game.StopRecording();
			Card.cdtTerm();
		}
			
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			StartNewGame();
		}
	    
		public void EnableChoiceSubMenus()
		{
			menuItemHit.Enabled = true;
			menuItemDouble.Enabled = true;
			menuItemSurrender.Enabled = true && !game.Options.ProhibitSurrender;
			menuItemStand.Enabled = true;
			menuItemSplit.Enabled = true;
      toolBarButtonHit.Enabled = true;
      toolBarButtonDouble.Enabled = true;
      toolBarButtonSplit.Enabled = true;
      toolBarButtonSurrender.Enabled = true && !game.Options.ProhibitSurrender;
      toolBarButtonStand.Enabled = true;
      toolBarButton.Enabled = true;
		}



		public void DisableChoiceSubMenus()
		{
			menuItemHit.Enabled = false;
			menuItemDouble.Enabled = false;
			menuItemSurrender.Enabled = false;
			menuItemStand.Enabled = false;
			menuItemSplit.Enabled = false;
      toolBarButtonHit.Enabled = false;
      toolBarButtonDouble.Enabled = false;
      toolBarButtonSplit.Enabled = false;
      toolBarButtonSurrender.Enabled = false;
      toolBarButtonStand.Enabled = false;
      toolBarButton.Enabled = false;
		}
		
		private void DisableBettingMenus()
		{
			menuItemDecreaseBet.Enabled = false;
			menuItemIncreaseBet.Enabled = false;
      toolBarButtonIncrease.Enabled = false;
      toolBarButtonDecrease.Enabled = false;
		}
		
		private void EnableBettingMenus()
		{
			menuItemDecreaseBet.Enabled = true;
			menuItemIncreaseBet.Enabled = true;
      toolBarButtonIncrease.Enabled = true;
      toolBarButtonDecrease.Enabled = true;
		}

		private void UpdateStatus(PlayerHand hand)
		{
			SetPlayerStatus(hand.GetBestValue());
			SetPlayerBet(game.GetPlayer(0).CurrentBet);
			SetPlayerBalance(hand.Money);
			SetDealerStatus(game.Dealer);
			SetHintStatus(game);
		}
	     
		private void UpdateStatus()
		{
		SetPlayerBet(game.GetPlayer(0).CurrentBet);
		SetPlayerBalance(game.Players[0].Money);
		SetDealerStatus(game.Dealer);
		SetHintStatus(game);
		}

		private void ClearStatus()
		{
		  foreach(StatusBarPanel p in statusBar1.Panels)
			  p.Text = string.Empty;
		}
	           
		private void menuItem21_Click(object sender, System.EventArgs e)
		{
		  Close();
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
		  string About = "BlackJack for Windows v1.1" + Environment.NewLine + 
			  "Copyright \xA9 2003, 2005. All Rights Reserved." + Environment.NewLine +
			  "By Software Conceptions, Inc" + Environment.NewLine + 
			  "Written by Paul Kimmel. pkimmel@softconcepts.com";
  	        
		  MessageBox.Show(About, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void menuItem26_Click(object sender, System.EventArgs e)
		{
		  Hit();
		}
	    
		private void Hit()
		{
		  if( !game.Hit())
			  Sounds.Beep();
		}
	    
		private void SetPlayerStatus(int bestValue)
		{
			statusBarPanelPlayer.Text = string.Format("Player: {0}", bestValue); 
		}
	    
		private void SetPlayerBet(double currentBet)
		{
			statusBarPanelBet.Text = string.Format("Bet: {0:C}", currentBet);
		}
	    
		private void SetPlayerBalance(double money)
		{
			statusBarPanelBalance.Text = string.Format("Balance: {0:C}",
			money);
		}
	    
		private bool IsGameOver
		{
			get{ return game != null ? game.IsGameOver : true; }
		}
	    
		private bool IsNewGame
		{
			get{ return game != null ? game.IsNewGame : false; }
		}
	    
		private void SetDealerStatus(Hand dealer)
		{
			if( IsGameOver ) 
				statusBarPanelDealer.Text = string.Format("Dealer: {0}", 
				dealer.GetBestValue());
			else
				statusBarPanelDealer.Text = string.Format("Dealer: {0}",
				dealer[1].GetCardValue());
		}
	    
		private void ClearHintStatus()
		{
			statusBarPanelHint.Text = string.Empty;
		}
	    
		private void SetHintStatus(BlackJack game)
		{
			if( !IsGameOver )
			{
				statusBarPanelHint.Text = game.GetHint();
				statusBarPanelHint.ToolTipText = game.GetHint();
			}
			else
				ClearHintStatus();
		}
	    
		private void menuItem27_Click(object sender, System.EventArgs e)
		{
			Stand();
		}
	    
		private void Stand()
		{
			game.Stand();
		}
	    
		private void OnStandCurrentHand(object sender, System.EventArgs e)
		{
			Invalidate();
		}
	    
		private void BeforePlayDealerHand(object sender, System.EventArgs e)
		{
			DisableChoiceSubMenus();    
			Invalidate();
		}
	    
		private void OnDealerHandChanged(object sender, System.EventArgs e)
		{
			SetDealerStatus((DealerHand)sender);
			Invalidate();
		}

		private void menuItem32_Click(object sender, System.EventArgs e)
		{
			DecreaseBet();
		}
	    
		private void DecreaseBet()
		{
			if( game.DecreaseBet())
				UpdateStatus();
			else
				Sounds.Beep();
		}

		private void menuItem31_Click(object sender, System.EventArgs e)
		{
			IncreaseBet();
		}
	    
		private void IncreaseBet()
		{
			if( game.IncreaseBet())
				UpdateStatus();
			else
				Sounds.Beep();
		}
	    
		private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if( IsGameOver )
			{
				NewGame();
				return;
			}
	      
		if( IsNewGame ) return;
			switch(e.KeyChar)
			{
				case (char)32:
				Hit();
				break;
				case (char)13:
				Stand();
				break;
			}
		}

		private void menuItem25_Click(object sender, System.EventArgs e)
		{
			Double();
		}

		private void Double()
		{
			if( !game.Double())
			Sounds.Beep();
		}

		private void OnDoubleCurrentHand(object sender, System.EventArgs e)
		{
			UpdateStatus((PlayerHand)sender);
			Invalidate();
		}

		private void menuItem29_Click(object sender, System.EventArgs e)
		{
			Surrender();
		}

		private void Surrender()
		{
			game.Surrender();
		}

		private void OnSurrenderCurrentHand(object sender, System.EventArgs e)
		{
			UpdateStatus((PlayerHand)sender);		
			Invalidate();
		}

		private void menuItemSplit_Click(object sender, System.EventArgs e)
		{
		  Split();
		}

		private void Split()
		{
		  if( !game.Split())
		  Sounds.Beep();
		}

		private void OnSplitCurrentHand(object sender, System.EventArgs e)
		{
		  UpdateStatus((PlayerHand)sender);
		  Invalidate();
		}

		private void OnNewGame(object sender, System.EventArgs e)
		{
		  UpdateStatus(game.CurrentHand);
		  EnableChoiceSubMenus();
		  DisableBettingMenus();
		  Invalidate();
		  game.CheckEndGame();
		}

		private void OnEndGame(object sender, System.EventArgs e)
		{
		  DisableChoiceSubMenus();
		  EnableBettingMenus();
		  UpdateStatus();
		  Invalidate();
		}

		private void OnDecidePlay(object sender, System.EventArgs e)
		{
		  UpdateStatus((PlayerHand)sender);
		  Invalidate();
		}

		private void OnHitCurrentHand(object sender, System.EventArgs e)
		{
		  UpdateStatus((PlayerHand)sender);   
		  Invalidate();
		}

		private void OnNextHand(object sender, System.EventArgs e)
		{
		  UpdateStatus((PlayerHand)sender);
		  Invalidate();
		}

		private void Deal_Click(object sender, System.EventArgs e)
		{
		  NewGame();
		}

		private void NewGame()
		{
		  if( !game.NewGame())
		  Sounds.Beep();
		}

		private void menuItem24_Click(object sender, System.EventArgs e)
		{
			SetOptions();
		}

		private void SetOptions()
		{
			if( game != null )
			if( FormOptions.Execute(game.Options))
				OptionsChanged();
		}

		private void OptionsChanged()
		{
      if( IsNewGame ) return;
			toolBarButtonSurrender.Enabled = !game.Options.ProhibitSurrender;
			menuItemSurrender.Enabled = !game.Options.ProhibitSurrender;
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			Invalidate();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			if( game != null )
			FormStatistics.Execute(game.Players[0].Statistics);
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if( e.Button == toolBarButtonHit )
				Hit();
			else if( e.Button == toolBarButtonDouble )
				Double();
			else if( e.Button == toolBarButtonSplit )
				Split();
			else if( e.Button == toolBarButtonSurrender )
				Surrender();
			else if( e.Button == toolBarButtonStand )
				Stand();
			else if( e.Button == toolBarButtonIncrease )
				IncreaseBet();
			else if( e.Button == toolBarButtonDecrease )
				DecreaseBet();
		}
	}
}
