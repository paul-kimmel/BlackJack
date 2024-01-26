//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Data;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;

namespace Softconcepts.BlackJackLib
{
	public class Recorder
	{
	  private static bool recording = true;
	  private DataTable hands = null;
	  
	  public Recorder()
	  {
      InitializeRepository();
	  }
	  
	  public void WriteToFile(string fileName)
	  {
	    try
	    {
        DataSet temp = new DataSet("snapshot");
        temp.Tables.Add(hands);
        temp.WriteXml(fileName);
      }
      catch{}
	  }
	  
	  public void Record(object game)
	  {
	    try
	    {
	      if( game is BlackJack && Recording ) 
	        SaveSnapShot( game as BlackJack );
	    }catch{}
	  }
	  
	  public static bool Recording
	  {
	    get{ return recording; }
	    set{ recording = value; }
	  }
	  
	  private void SaveSnapShot(BlackJack game)
	  {
	    DataRow row = hands.NewRow();
	    int instanceId = (int)row["Id"];
	    row["When"] = DateTime.Now;
      row["InstanceId"] = instanceId;
      row["DealerHand"] = game.Dealer.GetTextHand();
      row["PlayerHand"] = game.Players[0][0].GetTextHand();
      row["HandNumber"] = 0;
      row["CurrentBet"] = game.Players[0].CurrentBet;
      row["Money"] = game.Players[0].Money;
      row["PlayState"] = game.Players[0][0].GetPlayState().ToString();
      row["Hints"] = Hints.GetHint(game.Dealer, game.Players[0][0]);
      hands.Rows.Add(row);
	    for(int i=1; i<game.Players[0].Hands.Count; i++)
	    {
	      row = hands.NewRow();
	      row["When"] = DateTime.Now;
        row["InstanceId"] = instanceId;
        row["DealerHand"] = game.Dealer.GetTextHand();
        row["PlayerHand"] = game.Players[0][i].GetTextHand();
        row["HandNumber"] = i;
        row["CurrentBet"] = game.Players[0].CurrentBet;
        row["Money"] = game.Players[0].Money;
        row["PlayState"] = game.Players[0][0].GetPlayState().ToString();
        row["Hints"] = Hints.GetHint(game.Dealer, game.Players[0][0]);
        hands.Rows.Add(row);
	    }
	  }
	  
	  private void InitializeRepository()
	  {
      hands = new DataTable("Recording");
      DataColumn column = hands.Columns.Add();
      column.DataType = typeof(int);
      column.AutoIncrement = true;
      column.ColumnName = "Id";
      column.ReadOnly = true;
      column.Unique = true;
      hands.PrimaryKey = new DataColumn[]{column};
      
      column = hands.Columns.Add();
      column.DataType = typeof(int);
      column.ColumnName = "Count";
      column.AutoIncrement = true;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(DateTime);
      column.ColumnName = "When";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(int);
      column.ColumnName = "InstanceId";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(string);
      column.ColumnName = "DealerHand";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(string);
      column.ColumnName = "PlayerHand";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(string);
      column.ColumnName = "HandNumber";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(double);
      column.ColumnName = "CurrentBet";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(double);
      column.ColumnName = "Money";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
      
      column = hands.Columns.Add();
      column.DataType = typeof(string);
      column.ColumnName = "PlayState";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;

      column = hands.Columns.Add();
      column.DataType = typeof(string);
      column.ColumnName = "Hints";
      column.AutoIncrement = false;
      column.ReadOnly = false;
      column.Unique = false;
	  }
	}
}
