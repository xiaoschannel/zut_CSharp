using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuoanqh.libzut.Data
{
  /// <summary>
  /// This is supposed to go with DictionaryFileIO. 
  /// Simply speaking, it's a Dictionary that allows me to save a couple lines of code.
  /// </summary>
  public class DictionaryDataObject : Dictionary<string, string>
  {

    /// <summary>
    /// Create object with given data. does not make a copy of the data. we trust you.
    /// </summary>
    /// <param name="Data"></param>
    public DictionaryDataObject(IDictionary<string, string> Data) : base(Data)
    { }
    /// <summary>
    /// Creates an empty object.
    /// </summary>
    public DictionaryDataObject() : base() { }

    /// <summary>
    /// Return data just like Dictionary. Why are you using this instead of this[Key]?
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public string Get(string Key)
    { return this[Key]; }

    /// <summary>
    /// Fetch the data as an int.
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public int GetAsInt(string Key)
    { return Convert.ToInt32(this[Key]); }

    /// <summary>
    /// Fetch the data as a double.
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public double GetAsDouble(string Key)
    { return Convert.ToDouble(this[Key]); }

    /// <summary>
    /// Fetch the data as a boolean
    /// </summary>
    /// <param name="Key"></param>
    /// <returns></returns>
    public bool GetAsBoolean(string Key)
    { return Convert.ToBoolean(this[Key]); }

    /// <summary>
    /// If this note does not have that Entry yet, the entry will be created.
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    public void Set(string Key, string Value)
    {
      if (!ContainsKey(Key))
        this.Add(Key, Value);
      else
        this[Key] = Value;
    }

    /// <summary>
    /// If this note does not have that Entry yet, the entry will be created.
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    public void Set(string Key, int Value)
    { Set(Key, Value + ""); }

    /// <summary>
    /// If this note does not have that Entry yet, the entry will be created.
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    public void Set(string Key, double Value)
    { Set(Key, Value + ""); }

    /// <summary>
    /// If this note does not have that Entry yet, the entry will be created.
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    public void Set(string Key, bool Value)
    { Set(Key, Value + ""); }

    /// <summary>
    /// Remove if entry exists.
    /// </summary>
    /// <param name="Key"></param>
    public void ClearEntry(string Key)
    {
      if (ContainsKey(Key))
        Remove(Key);
    }

    /// <summary>
    /// Converts the object back to text with given separator.
    /// </summary>
    /// <param name="separator"></param>
    /// <returns></returns>
    public List<string> ToStringList(string separator)
    { return this.Select((s) => s.Key + separator + s.Value).ToList(); }

    /// <summary>
    /// Converts the object back to text with given separator.
    /// </summary>
    /// <param name="separator"></param>
    /// <returns></returns>
    public string ToString(string separator)
    {
      return zusp.List("\r\n", ToStringList(separator).ToArray()) + "\r\n";
    }
  }
}
