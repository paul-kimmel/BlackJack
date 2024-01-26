using System;
using System.Collections.Generic;
using System.Text;

namespace Softconcepts.BlackJackLib
{
  public interface IActionable
  {
    void Double();
    void Split();
    void Stand();
    void Increase();
    void Decrease();
    void Surrender();
    void Hit();
    void NewGame();
    void Deal();

    void DealSplit();
    void DealSplitGame();
    void About();
  }
}
