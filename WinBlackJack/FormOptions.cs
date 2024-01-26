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
	/// Summary description for FormOptions.
	/// </summary>
	public class FormOptions : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxPlayerName;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.NumericUpDown numericUpDownChangeBetAmount;
    private System.Windows.Forms.NumericUpDown numericUpDownStartupCashAmount;
    private System.Windows.Forms.CheckBox checkBoxRecordPlay;
    private System.Windows.Forms.CheckBox checkBoxHintsEnabled;
    private System.Windows.Forms.CheckBox checkBoxProhibitPlay;
    private System.Windows.Forms.CheckBox checkBoxProhibitSurrender;
    private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormOptions()
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormOptions));
      this.label1 = new System.Windows.Forms.Label();
      this.numericUpDownChangeBetAmount = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.numericUpDownStartupCashAmount = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxPlayerName = new System.Windows.Forms.TextBox();
      this.checkBoxRecordPlay = new System.Windows.Forms.CheckBox();
      this.checkBoxHintsEnabled = new System.Windows.Forms.CheckBox();
      this.checkBoxProhibitPlay = new System.Windows.Forms.CheckBox();
      this.checkBoxProhibitSurrender = new System.Windows.Forms.CheckBox();
      this.button1 = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChangeBetAmount)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartupCashAmount)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(168, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Increase/Decrease Bet by:";
      // 
      // numericUpDownChangeBetAmount
      // 
      this.numericUpDownChangeBetAmount.Location = new System.Drawing.Point(192, 48);
      this.numericUpDownChangeBetAmount.Minimum = new System.Decimal(new int[] {
                                                                                 5,
                                                                                 0,
                                                                                 0,
                                                                                 0});
      this.numericUpDownChangeBetAmount.Name = "numericUpDownChangeBetAmount";
      this.numericUpDownChangeBetAmount.Size = new System.Drawing.Size(216, 22);
      this.numericUpDownChangeBetAmount.TabIndex = 2;
      this.numericUpDownChangeBetAmount.Value = new System.Decimal(new int[] {
                                                                               5,
                                                                               0,
                                                                               0,
                                                                               0});
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 88);
      this.label2.Name = "label2";
      this.label2.TabIndex = 2;
      this.label2.Text = "Player &Funds:";
      // 
      // numericUpDownStartupCashAmount
      // 
      this.numericUpDownStartupCashAmount.Location = new System.Drawing.Point(192, 88);
      this.numericUpDownStartupCashAmount.Maximum = new System.Decimal(new int[] {
                                                                                   5000,
                                                                                   0,
                                                                                   0,
                                                                                   0});
      this.numericUpDownStartupCashAmount.Minimum = new System.Decimal(new int[] {
                                                                                   50,
                                                                                   0,
                                                                                   0,
                                                                                   0});
      this.numericUpDownStartupCashAmount.Name = "numericUpDownStartupCashAmount";
      this.numericUpDownStartupCashAmount.Size = new System.Drawing.Size(216, 22);
      this.numericUpDownStartupCashAmount.TabIndex = 3;
      this.numericUpDownStartupCashAmount.Value = new System.Decimal(new int[] {
                                                                                 500,
                                                                                 0,
                                                                                 0,
                                                                                 0});
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(24, 16);
      this.label3.Name = "label3";
      this.label3.TabIndex = 4;
      this.label3.Text = "Player &name:";
      // 
      // textBoxPlayerName
      // 
      this.textBoxPlayerName.Location = new System.Drawing.Point(192, 16);
      this.textBoxPlayerName.Name = "textBoxPlayerName";
      this.textBoxPlayerName.Size = new System.Drawing.Size(216, 22);
      this.textBoxPlayerName.TabIndex = 1;
      this.textBoxPlayerName.Text = "Player 1";
      // 
      // checkBoxRecordPlay
      // 
      this.checkBoxRecordPlay.Location = new System.Drawing.Point(24, 128);
      this.checkBoxRecordPlay.Name = "checkBoxRecordPlay";
      this.checkBoxRecordPlay.Size = new System.Drawing.Size(192, 24);
      this.checkBoxRecordPlay.TabIndex = 4;
      this.checkBoxRecordPlay.Text = "Record play";
      this.checkBoxRecordPlay.CheckedChanged += new System.EventHandler(this.checkBoxRecordPlay_CheckedChanged);
      // 
      // checkBoxHintsEnabled
      // 
      this.checkBoxHintsEnabled.Checked = true;
      this.checkBoxHintsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxHintsEnabled.Location = new System.Drawing.Point(24, 160);
      this.checkBoxHintsEnabled.Name = "checkBoxHintsEnabled";
      this.checkBoxHintsEnabled.Size = new System.Drawing.Size(192, 24);
      this.checkBoxHintsEnabled.TabIndex = 6;
      this.checkBoxHintsEnabled.Text = "Hints enabled";
      // 
      // checkBoxProhibitPlay
      // 
      this.checkBoxProhibitPlay.Location = new System.Drawing.Point(224, 128);
      this.checkBoxProhibitPlay.Name = "checkBoxProhibitPlay";
      this.checkBoxProhibitPlay.Size = new System.Drawing.Size(192, 24);
      this.checkBoxProhibitPlay.TabIndex = 5;
      this.checkBoxProhibitPlay.Text = "Prohibit play against hints";
      // 
      // checkBoxProhibitSurrender
      // 
      this.checkBoxProhibitSurrender.Location = new System.Drawing.Point(224, 160);
      this.checkBoxProhibitSurrender.Name = "checkBoxProhibitSurrender";
      this.checkBoxProhibitSurrender.Size = new System.Drawing.Size(192, 24);
      this.checkBoxProhibitSurrender.TabIndex = 7;
      this.checkBoxProhibitSurrender.Text = "Prohibit surrender";
      // 
      // button1
      // 
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Location = new System.Drawing.Point(112, 216);
      this.button1.Name = "button1";
      this.button1.TabIndex = 8;
      this.button1.Text = "OK";
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(208, 216);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.TabIndex = 9;
      this.buttonCancel.Text = "Cancel";
      // 
      // FormOptions
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(434, 274);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.checkBoxProhibitSurrender);
      this.Controls.Add(this.checkBoxProhibitPlay);
      this.Controls.Add(this.checkBoxHintsEnabled);
      this.Controls.Add(this.textBoxPlayerName);
      this.Controls.Add(this.checkBoxRecordPlay);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.numericUpDownStartupCashAmount);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.numericUpDownChangeBetAmount);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormOptions";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Options";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChangeBetAmount)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartupCashAmount)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

    public static bool Execute(Options options)
    {
      FormOptions form = new FormOptions();
      try
      {
        form.InitializeOptions(options);
        if( form.ShowDialog() == DialogResult.OK )
        {
          form.StoreOptions(options);
          return true;
        }
        return false;
      }
      finally
      {
        form.Dispose();
      }
    }
    
    private void InitializeOptions(Options options)
    {
      PlayerName = options.Name;
      ChangeBetAmount = options.ChangeBetAmount;
      StartupCashAmount = options.StartupCashAmount;
      RecordPlay = options.RecordPlay;
      HintsEnabled = options.HintsEnabled;
      ProhibitAntiHintPlay = options.ProhibitAntiHintPlay;  
      ProhibitSurrender = options.ProhibitSurrender;
    }
    
    private void StoreOptions(Options options)
    {
      options.Name = PlayerName;
      options.ChangeBetAmount = ChangeBetAmount;
      options.StartupCashAmount = StartupCashAmount;
      options.RecordPlay = RecordPlay;
      options.HintsEnabled = HintsEnabled;
      options.ProhibitAntiHintPlay = ProhibitAntiHintPlay;  
      options.ProhibitSurrender = ProhibitSurrender;
    }

    private void checkBoxRecordPlay_CheckedChanged(object sender, System.EventArgs e)
    {
    
    }

    private void checkBoxRunningStatistics_CheckedChanged(object sender, System.EventArgs e)
    {
    
    }
    
    public string PlayerName
    {
      get{ return textBoxPlayerName.Text; }
      set{ textBoxPlayerName.Text = value; }
    }
    
    public double ChangeBetAmount
    {
      get{ return Convert.ToDouble(numericUpDownChangeBetAmount.Value); }
      set{ numericUpDownChangeBetAmount.Value = Convert.ToDecimal(value); }
    }

    public double StartupCashAmount
    {
      get{ return Convert.ToDouble(numericUpDownStartupCashAmount.Value); }
      set{ numericUpDownStartupCashAmount.Value = Convert.ToDecimal(value); }
    }

    public bool RecordPlay
    {
      get{ return checkBoxRecordPlay.Checked; }
      set{ checkBoxRecordPlay.Checked = value; }
    }
    
    public bool HintsEnabled
    {
      get{ return checkBoxHintsEnabled.Checked; }
      set{ checkBoxHintsEnabled.Checked = value; }
    }
    
    public bool ProhibitAntiHintPlay
    {
      get{ return checkBoxProhibitPlay.Checked; }
      set{ checkBoxProhibitPlay.Checked = value; }
    }
    
    public bool ProhibitSurrender
    {
      get{ return checkBoxProhibitSurrender.Checked; }
      set{ checkBoxProhibitSurrender.Checked = value; }
    }
	}
}
