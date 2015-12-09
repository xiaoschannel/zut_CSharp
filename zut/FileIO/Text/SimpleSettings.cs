using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO.Text
{
  /// <summary>
  /// A lightweight class for saving the settings of your program into a file.
  /// </summary>
  public static class SimpleSettings
  {
    /// <summary>
    /// The name of setting file created by this class.
    /// </summary>
    public const string FILE_NAME = "Settings.zut.txt";

    /// <summary>
    /// Decides whether to save automatically after every single change.
    /// It's efficent to disable when doing a lot of changes at once.
    /// </summary>
    public static bool AutoSave = true;
    /// <summary>
    /// Where everything is. Play nice with it, ok?
    /// </summary>
    public static Dictionary<string, string> Content;

    static SimpleSettings()
    {
      Reload();
    }

    /// <summary>
    /// Set default value of things.
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="DefaultValue"></param>
    public static void UseDefaultValue(string Key, string DefaultValue)
    {
      if (!Content.ContainsKey(Key))
      {
        Content.Add(Key, DefaultValue);
        if (AutoSave) Save();
      }
    }

    /// <summary>
    /// Set value of a field.
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    public static void Set(string Key, string Value)
    {
      Content[Key] = Value;
      if (AutoSave) Save();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public static string GetString(string Key)
    { return Content[Key]; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public static int GetInt(string Key)
    { return Convert.ToInt32(Content[Key]); }

    /// <summary>
    /// Increases setting value by 1. Assumes it's an int.
    /// </summary>
    /// <param name="Key"></param>
    public static void Increase(string Key)
    { Set(Key, (GetInt(Key) + 1) + ""); }

    /// <summary>
    /// Decreases setting value by 1. Assumes it's an int.
    /// </summary>
    /// <param name="Key"></param>
    public static void Decrease(string Key)
    { Set(Key, (GetInt(Key) - 1) + ""); }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public static float GetFloat(string Key)
    { return Convert.ToSingle(Content[Key]); }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public static double GetDouble(string Key)
    { return Convert.ToDouble(Content[Key]); }
    /// <summary>
    /// Save current settings. If you don't do this, nothing will be saved.
    /// </summary>
    public static void Save()
    {
      DictionaryFileIO.writeFile(Content, ": ", FILE_NAME);
    }
    /// <summary>
    /// Abandon changes, revert to saved file.
    /// </summary>
    public static void Reload()
    {
      Content = new Dictionary<string, string>();
      if (File.Exists(Path.Combine(Directory.GetCurrentDirectory() , FILE_NAME)))
      {
        var t = DictionaryFileIO.readFile(": ", FILE_NAME);
        foreach (var i in t)
          Content.Add(i.Key, i.Value);
      }
      else
        File.Create(Directory.GetCurrentDirectory() + FILE_NAME);
    }

  }
}
