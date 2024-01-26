//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace Softconcepts.BlackJackLib
{
	public class Options
	{
    private const string rootKey = "Software\\softconcepts\\BlackJack";
    private const string nameKey = "name";
    private const string deckCountKey  = "deckCount";
    private const string changeBetAmountKey = "changeBetAmountKey";
    private const string startupCashAmountKey = "startupCashAmount";
    private const string prohibitAntiHintPlayKey = "prohibitAntiHintPlay";
    private const string recordPlayKey = "recordPlay";
    private const string hintEnabledKey = "hintsEnabled";
    private const string prohibitSurrenderKey = "prohibitSurrender";
	  
    private string name = "Player 1";
    private int deckCount = 6;
	  private double changeBetAmount = 5;
	  private double startupCashAmount = 500;
	  private bool prohibitAntiHintPlay = false;
	  private bool recordPlay = false;
	  private bool hintsEnabled = true;
	  private bool prohibitSurrender = false;
	  private BlackJack game = null;
	  
		public Options(BlackJack game)
		{
		  this.game = game;
      ReadOptions();
		}
		
    private object GetValue(string key, object value)
    {
      RegistryKey myKey = Registry.CurrentUser.OpenSubKey(rootKey);
      if( myKey == null )
        myKey = Registry.CurrentUser.CreateSubKey(rootKey);
      try
      {
        return myKey.GetValue(key, value);
      }
      finally
      {
        myKey.Close();
      }
    }

    private void SetValue(string key, object value)
    {
      RegistryKey myKey = Registry.CurrentUser.OpenSubKey(rootKey, true);
      if( myKey == null )
        myKey = Registry.CurrentUser.CreateSubKey(rootKey);
      try
      {
        myKey.SetValue(key, value);
      }
      finally
      {
        myKey.Close();
      }
    }

    private void ReadOptions()
    {
      name = (string)GetValue(nameKey, name);
      deckCount = (int)GetValue(deckCountKey, deckCount);
      changeBetAmount = Convert.ToDouble(GetValue(changeBetAmountKey, changeBetAmount));

      startupCashAmount = Convert.ToDouble(GetValue(startupCashAmountKey, startupCashAmount));
      prohibitAntiHintPlay = Convert.ToBoolean(GetValue(prohibitAntiHintPlayKey , prohibitAntiHintPlay));
      recordPlay = Convert.ToBoolean(GetValue(recordPlayKey, recordPlay));
      hintsEnabled = Convert.ToBoolean(GetValue(hintEnabledKey, hintsEnabled));
      prohibitSurrender = Convert.ToBoolean(GetValue(prohibitSurrenderKey, prohibitSurrender));
    }

    private void WriteOptions()
    {
      SetValue(nameKey, name);
      SetValue(deckCountKey, deckCount);
      SetValue(changeBetAmountKey, changeBetAmount);
      SetValue(startupCashAmountKey, startupCashAmount);
      SetValue(prohibitAntiHintPlayKey , prohibitAntiHintPlay);
      SetValue(recordPlayKey, recordPlay);
      SetValue(hintEnabledKey, hintsEnabled);
      SetValue(prohibitSurrenderKey, prohibitSurrender);
    }

    public string Name
    {
      get{ return name; }
      set{ 
        name = value;
        WriteOptions();
      }
    }
    
    public int DeckCount
    {
      get{ return deckCount; }
      set{ 
        deckCount = value; 
        WriteOptions();
      }
    }
    
    public double ChangeBetAmount
    {
      get{ return changeBetAmount; }
      set{ 
        changeBetAmount = value; 
        WriteOptions();
      }
    }

    public double StartupCashAmount
    {
      get{ return startupCashAmount; }
      set{ 
        startupCashAmount = value; 
        WriteOptions();
      }
    }

    public bool RecordPlay
    {
      get{ return recordPlay; }
      set
      { 
        recordPlay = value; 
        WriteOptions();
        RecordPlayChanged();
      }
    }
    
    private void RecordPlayChanged()
    {
      if( game != null )
        if( recordPlay )
          game.StartRecording();
        else
          game.StopRecording();
    }
    
    public bool HintsEnabled
    {
      get{ return hintsEnabled; }
      set{ 
        hintsEnabled = value; 
        WriteOptions();
      }
    }
    
    public bool ProhibitAntiHintPlay
    {
      get{ return prohibitAntiHintPlay; }
      set{ 
        prohibitAntiHintPlay = value; 
        WriteOptions();
      }
    }
    
    public bool ProhibitSurrender
    {
      get{ return prohibitSurrender; }
      set{ 
        prohibitSurrender = value; 
        WriteOptions();
      }
    }
	}
}
