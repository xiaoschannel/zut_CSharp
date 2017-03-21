using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.win
{
  public class zuw
  {
    

    /// <summary>
    /// Open the given directory if exists. If not, a debug error message will be printed.
    /// </summary>
    /// <param name="targetDirectory"></param>
    public static void openDirectory(string targetDirectory)
    {
      if (Directory.Exists(targetDirectory))
        Process.Start(targetDirectory);
      else
        zerr.e("zut.openDirectory", "Directory not exist: " + targetDirectory);
    }
    /// <summary>
    /// does what the name suggests.
    /// </summary>
    /// <param name="fpath"></param>
    public static void OpenContainingDirectoryAndSelect(string fpath)
    {
      Process.Start("explorer.exe", "/select," + fpath);
    }

  }
}
