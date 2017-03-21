using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO
{
  /// <summary>
  /// Extend this class for your file system to enable zuio's subclass to access certain functions, such as open file with default application, show file in explorer, etc.
  /// </summary>
  public abstract class DirectFileOperationProvider
  {
    public readonly bool CanShowFile;
    public readonly bool CanShowFolder;
    public readonly bool CanOpenFileInDefaultApplication;
    public readonly bool CanExecuteFile;
    public readonly bool CanExecuteWithParameters;

    /// <summary>
    /// Open a window that shows the file in the file system.
    /// </summary>
    /// <param name="File"></param>
    public abstract void ShowFile(IFile File);

    /// <summary>
    /// Open a window that displays the content of given folder.
    /// </summary>
    /// <param name="Folder"></param>
    public abstract void ShowFolder(IFolder Folder);

    /// <summary>
    /// Open target file in its default application, if it does not have one, this method should prompt the user to select an application.
    /// </summary>
    /// <param name="File"></param>
    public abstract void OpenFileInDefaultApplication(IFile File);

    /// <summary>
    /// Execute given file as if it's an application.
    /// </summary>
    /// <param name="File"></param>
    public abstract void ExecuteFile(IFile File);

    /// <summary>
    /// Execute given file as if it's an application with given parameters.
    /// </summary>
    /// <param name="File"></param>
    /// <param name="Parameters"></param>
    public abstract void ExecuteFileWithParameters(IFile File, IEnumerable<String> Parameters);

    protected DirectFileOperationProvider(bool CanShowFile, bool CanShowFolder, bool CanOpenFileInDefaultApplication, bool CanExecuteFile, bool CanExecuteWithParameters)
    {
      this.CanShowFile = CanShowFile;
      this.CanShowFolder = CanShowFolder;
      this.CanOpenFileInDefaultApplication = CanOpenFileInDefaultApplication;
      this.CanExecuteFile = CanExecuteFile;
      this.CanExecuteWithParameters = CanExecuteWithParameters;
    }
  }
}