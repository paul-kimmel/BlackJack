//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Softconcepts.BlackJackLib;

namespace WinBlackJack
{
	/// <summary>
	/// Summary description for FormStatistics.
	/// </summary>
	public class FormStatistics : System.Windows.Forms.Form
	{
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGrid dataGrid1;
    private System.Windows.Forms.Label labelSurrenders;
    private System.Windows.Forms.Label labelWins;
    private System.Windows.Forms.Label labelLosses;
    private System.Windows.Forms.Label labelPushes;
    private System.Windows.Forms.Label labelAverageAmountWon;
    private System.Windows.Forms.Label labelTotalAmountWon;
    private System.Windows.Forms.Label labelTotalAmountLost;
    private System.Windows.Forms.Label labelAverageAmountLost;
    private System.Windows.Forms.Label labelPercentageOfWins;
    private System.Windows.Forms.Label labelPercentageOfLosses;
    private System.Windows.Forms.Label labelPercentageOfPushes;
    private System.Windows.Forms.Label labelNetWonLoss;
    private System.Windows.Forms.Label labelNetAverageWonLost;
    private System.Windows.Forms.Label labelBlackJackData;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormStatistics()
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
				if(components != null)
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormStatistics));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.labelBlackJackData = new System.Windows.Forms.Label();
      this.labelNetAverageWonLost = new System.Windows.Forms.Label();
      this.labelNetWonLoss = new System.Windows.Forms.Label();
      this.labelPercentageOfPushes = new System.Windows.Forms.Label();
      this.labelPercentageOfLosses = new System.Windows.Forms.Label();
      this.labelPercentageOfWins = new System.Windows.Forms.Label();
      this.labelAverageAmountLost = new System.Windows.Forms.Label();
      this.labelTotalAmountLost = new System.Windows.Forms.Label();
      this.labelTotalAmountWon = new System.Windows.Forms.Label();
      this.labelAverageAmountWon = new System.Windows.Forms.Label();
      this.labelPushes = new System.Windows.Forms.Label();
      this.labelLosses = new System.Windows.Forms.Label();
      this.labelWins = new System.Windows.Forms.Label();
      this.labelSurrenders = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.dataGrid1 = new System.Windows.Forms.DataGrid();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(536, 506);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.labelBlackJackData);
      this.tabPage1.Controls.Add(this.labelNetAverageWonLost);
      this.tabPage1.Controls.Add(this.labelNetWonLoss);
      this.tabPage1.Controls.Add(this.labelPercentageOfPushes);
      this.tabPage1.Controls.Add(this.labelPercentageOfLosses);
      this.tabPage1.Controls.Add(this.labelPercentageOfWins);
      this.tabPage1.Controls.Add(this.labelAverageAmountLost);
      this.tabPage1.Controls.Add(this.labelTotalAmountLost);
      this.tabPage1.Controls.Add(this.labelTotalAmountWon);
      this.tabPage1.Controls.Add(this.labelAverageAmountWon);
      this.tabPage1.Controls.Add(this.labelPushes);
      this.tabPage1.Controls.Add(this.labelLosses);
      this.tabPage1.Controls.Add(this.labelWins);
      this.tabPage1.Controls.Add(this.labelSurrenders);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(528, 477);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Statistics";
      // 
      // labelBlackJackData
      // 
      this.labelBlackJackData.AutoSize = true;
      this.labelBlackJackData.Location = new System.Drawing.Point(16, 432);
      this.labelBlackJackData.Name = "labelBlackJackData";
      this.labelBlackJackData.Size = new System.Drawing.Size(41, 18);
      this.labelBlackJackData.TabIndex = 13;
      this.labelBlackJackData.Text = "label1";
      // 
      // labelNetAverageWonLost
      // 
      this.labelNetAverageWonLost.AutoSize = true;
      this.labelNetAverageWonLost.Location = new System.Drawing.Point(16, 208);
      this.labelNetAverageWonLost.Name = "labelNetAverageWonLost";
      this.labelNetAverageWonLost.Size = new System.Drawing.Size(41, 18);
      this.labelNetAverageWonLost.TabIndex = 12;
      this.labelNetAverageWonLost.Text = "label5";
      // 
      // labelNetWonLoss
      // 
      this.labelNetWonLoss.AutoSize = true;
      this.labelNetWonLoss.Location = new System.Drawing.Point(16, 304);
      this.labelNetWonLoss.Name = "labelNetWonLoss";
      this.labelNetWonLoss.Size = new System.Drawing.Size(41, 18);
      this.labelNetWonLoss.TabIndex = 11;
      this.labelNetWonLoss.Text = "label7";
      // 
      // labelPercentageOfPushes
      // 
      this.labelPercentageOfPushes.AutoSize = true;
      this.labelPercentageOfPushes.Location = new System.Drawing.Point(16, 400);
      this.labelPercentageOfPushes.Name = "labelPercentageOfPushes";
      this.labelPercentageOfPushes.Size = new System.Drawing.Size(41, 18);
      this.labelPercentageOfPushes.TabIndex = 10;
      this.labelPercentageOfPushes.Text = "label7";
      // 
      // labelPercentageOfLosses
      // 
      this.labelPercentageOfLosses.AutoSize = true;
      this.labelPercentageOfLosses.Location = new System.Drawing.Point(16, 368);
      this.labelPercentageOfLosses.Name = "labelPercentageOfLosses";
      this.labelPercentageOfLosses.Size = new System.Drawing.Size(41, 18);
      this.labelPercentageOfLosses.TabIndex = 9;
      this.labelPercentageOfLosses.Text = "label7";
      // 
      // labelPercentageOfWins
      // 
      this.labelPercentageOfWins.AutoSize = true;
      this.labelPercentageOfWins.Location = new System.Drawing.Point(16, 336);
      this.labelPercentageOfWins.Name = "labelPercentageOfWins";
      this.labelPercentageOfWins.Size = new System.Drawing.Size(41, 18);
      this.labelPercentageOfWins.TabIndex = 8;
      this.labelPercentageOfWins.Text = "label7";
      // 
      // labelAverageAmountLost
      // 
      this.labelAverageAmountLost.AutoSize = true;
      this.labelAverageAmountLost.Location = new System.Drawing.Point(16, 176);
      this.labelAverageAmountLost.Name = "labelAverageAmountLost";
      this.labelAverageAmountLost.Size = new System.Drawing.Size(41, 18);
      this.labelAverageAmountLost.TabIndex = 7;
      this.labelAverageAmountLost.Text = "label7";
      // 
      // labelTotalAmountLost
      // 
      this.labelTotalAmountLost.AutoSize = true;
      this.labelTotalAmountLost.Location = new System.Drawing.Point(16, 272);
      this.labelTotalAmountLost.Name = "labelTotalAmountLost";
      this.labelTotalAmountLost.Size = new System.Drawing.Size(41, 18);
      this.labelTotalAmountLost.TabIndex = 6;
      this.labelTotalAmountLost.Text = "label7";
      // 
      // labelTotalAmountWon
      // 
      this.labelTotalAmountWon.AutoSize = true;
      this.labelTotalAmountWon.Location = new System.Drawing.Point(16, 240);
      this.labelTotalAmountWon.Name = "labelTotalAmountWon";
      this.labelTotalAmountWon.Size = new System.Drawing.Size(41, 18);
      this.labelTotalAmountWon.TabIndex = 5;
      this.labelTotalAmountWon.Text = "label6";
      // 
      // labelAverageAmountWon
      // 
      this.labelAverageAmountWon.AutoSize = true;
      this.labelAverageAmountWon.Location = new System.Drawing.Point(16, 144);
      this.labelAverageAmountWon.Name = "labelAverageAmountWon";
      this.labelAverageAmountWon.Size = new System.Drawing.Size(41, 18);
      this.labelAverageAmountWon.TabIndex = 4;
      this.labelAverageAmountWon.Text = "label5";
      // 
      // labelPushes
      // 
      this.labelPushes.AutoSize = true;
      this.labelPushes.Location = new System.Drawing.Point(16, 112);
      this.labelPushes.Name = "labelPushes";
      this.labelPushes.Size = new System.Drawing.Size(41, 18);
      this.labelPushes.TabIndex = 3;
      this.labelPushes.Text = "label4";
      // 
      // labelLosses
      // 
      this.labelLosses.AutoSize = true;
      this.labelLosses.Location = new System.Drawing.Point(16, 80);
      this.labelLosses.Name = "labelLosses";
      this.labelLosses.Size = new System.Drawing.Size(41, 18);
      this.labelLosses.TabIndex = 2;
      this.labelLosses.Text = "label3";
      // 
      // labelWins
      // 
      this.labelWins.AutoSize = true;
      this.labelWins.Location = new System.Drawing.Point(16, 48);
      this.labelWins.Name = "labelWins";
      this.labelWins.Size = new System.Drawing.Size(41, 18);
      this.labelWins.TabIndex = 1;
      this.labelWins.Text = "label2";
      // 
      // labelSurrenders
      // 
      this.labelSurrenders.AutoSize = true;
      this.labelSurrenders.Location = new System.Drawing.Point(16, 16);
      this.labelSurrenders.Name = "labelSurrenders";
      this.labelSurrenders.Size = new System.Drawing.Size(41, 18);
      this.labelSurrenders.TabIndex = 0;
      this.labelSurrenders.Text = "label1";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.dataGrid1);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(528, 477);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Hands";
      // 
      // dataGrid1
      // 
      this.dataGrid1.DataMember = "";
      this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid1.Location = new System.Drawing.Point(0, 0);
      this.dataGrid1.Name = "dataGrid1";
      this.dataGrid1.Size = new System.Drawing.Size(528, 477);
      this.dataGrid1.TabIndex = 0;
      // 
      // FormStatistics
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(536, 506);
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormStatistics";
      this.Text = "Player Statistics";
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormStatistics_KeyPress);
      this.Load += new System.EventHandler(this.FormStatistics_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion
		
		public static void Execute(Statistics statistics)
		{
		  FormStatistics form = new FormStatistics();
		  try
		  {
		    form.dataGrid1.DataSource = statistics;
		    form.SetValues(statistics);
		    form.ShowDialog();
		  }
		  finally
		  {
		    form.Dispose();
		  }
		}
		
		private void SetValues(Statistics statistics)
		{
      labelSurrenders.Text = string.Format("Surrendered: {0}", statistics.Surrenders);
      labelWins.Text = string.Format("Wins: {0}", statistics.Wins);
      labelLosses.Text = string.Format("Losses: {0}", statistics.Losses);
      labelPushes.Text = string.Format("Pushes: {0}", statistics.Pushes);
      labelAverageAmountWon.Text = string.Format("Average amount won per hand: {0,2:c}", statistics.AverageAmountWon);
      labelNetAverageWonLost.Text = string.Format("Net average won/lost per hand: {0,2:c}", statistics.NetAverageWinLoss);
      labelTotalAmountWon.Text = string.Format("Total amount won: {0,2:c}", statistics.TotalAmountWon);
      labelTotalAmountLost.Text = string.Format("Total amount loss: {0,2:c}", statistics.TotalAmountLost);
      labelAverageAmountLost.Text = string.Format("Average amount lost per hand: {0,2:c}", statistics.AverageAmountLost);
      labelPercentageOfWins.Text = string.Format("Percentage of wins: {0,2:f}%", statistics.PercentageOfWins);
      labelPercentageOfLosses.Text = string.Format("Percentage of losses: {0,2:f}%", statistics.PercentageOfLosses);
      labelPercentageOfPushes.Text = string.Format("Percentage of pushes: {0,2:f}%", statistics.PercentageOfPushes);
      labelNetWonLoss.Text = string.Format("Net Won/Lost: {0,2:c}", statistics.NetWinLoss);
      labelBlackJackData.Text = string.Format("BlackJacks: {0}/Percentage of BlackJacks: {1,2:f}%",
        statistics.BlackJacks, statistics.PercentageOfBlackJacks);
		}

    private void FormStatistics_Load(object sender, System.EventArgs e)
    {
    
    }

    private void FormStatistics_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      if( e.KeyChar == (char)Keys.Escape ) Close();
    }
	}
}
