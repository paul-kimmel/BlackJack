//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Softconcepts.BlackJackLib
{
	public class Sounds
	{
	  [Flags]
	  public enum PlaySoundFlags
	  {
      SND_SYNC = 0x0,          // play synchronously
      SND_ASYNC = 0x1,         // play asynchronously
      SND_FILENAME = 0x20000,  // name is file name
      SND_RESOURCE = 0x40004,  // name is resource name or atom
    }

    [DllImport("winmm.dll")]
    private static extern int PlaySound(string fileName, IntPtr hmod, PlaySoundFlags flags);

    public static void Play( string fileName )
    {
      PlaySound(fileName, IntPtr.Zero, PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC);
    }
    
    public static void Beep()
    {
      try
      {
        const string soundFile = @"c:\windows\media\chord.wav";
        if( File.Exists(soundFile))
          Play(soundFile);
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex.Message);
        throw;
      }
    }
	}
}
