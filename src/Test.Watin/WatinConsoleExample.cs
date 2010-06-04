using System;
using WatiN.Core;

namespace WatiNGettingStarted
{
  class WatiNConsoleExample
  {
    [STAThread]
    static void Main(string[] args)
    {
      // Open a new Internet Explorer window and
      // goto the google website.
        IE ie = new IE("http://localhost:23089/");

      // Find the search text field and type Watin in it.
        ie.Link(Find.ByText("Log On")).Click(); // .TypeText("WatiN");

        ie.Link(Find.ByText("Register")).Click();
        ie.WaitForComplete();
        //ie.TextField(Find.ById("UserName")).TypeText("asfasf");
      // Uncomment the following line if you want to close
      // Internet Explorer and the console window immediately.
      //ie.Close();
    }
  }
}