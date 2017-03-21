using cn.zuoanqh.open.zut.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using System.IO;
using System.Diagnostics;

namespace cn.zuoanqh.open.zut.win
{
  public class WindowsFileOperationProvider : DirectFileOperationProvider
  {
    public static WindowsFileOperationProvider Instance;

    static WindowsFileOperationProvider()
    {
      Instance = new WindowsFileOperationProvider();
    }

    private WindowsFileOperationProvider() : base(true, true, true, true, true)
    { }

    public override void ShowFile(IFile File)
    {
      Process.Start("explorer.exe", "/select," + File.Path);
    }

    public override void ShowFolder(IFolder Folder)
    {
      Process.Start(Folder.Path);
    }

    public override void OpenFileInDefaultApplication(IFile File)
    {
      Process.Start(File.Path);
    }

    public override void ExecuteFile(IFile File)
    {
      Process.Start(File.Path);
    }

    public override void ExecuteFileWithParameters(IFile File, IEnumerable<string> Parameters)
    {
      StringBuilder sb = new StringBuilder();
      foreach (string s in Parameters)
        sb.Append("\"").Append(s.Replace("\"", "\\\"")).Append("\" ");
      Process.Start(File.Path, sb.ToString());
    }
  }
}
