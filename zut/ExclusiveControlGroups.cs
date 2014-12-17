using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// A class for managing exclusive groups of controls where only one group can be visible at a time, or no group visible at all.
  /// </summary>
  /// <typeparam name="K">Key type for identifying different control groups.</typeparam>
  public class ExclusiveControlGroups<K>
  {
    private Dictionary<K, ISet<Control>> groups;
    /// <summary>
    /// Key of the group that is currently visible. "default" if no group is visible.
    /// </summary>
    public K currentGroup { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public ExclusiveControlGroups()
    {
      groups = new Dictionary<K, ISet<Control>>();
      currentGroup = default(K);
    }

    /// <summary>
    /// Add a new control group using given key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="group"></param>
    public void addGroup(K key, ISet<Control> group)
    {
      if (groups.ContainsKey(key)) throw new ArgumentException("There already exists a control group with key: " + key);
      groups.Add(key, group);
    }

    //public void removeGroup(K key)//not allowed. why would you want to do that?
    //{
    //  groups.Remove(key);
    //}

    /// <summary>
    /// Set all controls in the given group visible, others invisible.
    /// </summary>
    /// <param name="key">The identifier for the group to set visible of.</param>
    public void switchTo(K key)
    {
      if (!groups.ContainsKey(key)) throw new ArgumentException("No control group have the given key: " + key);
      foreach (var s in groups)
      {
        bool t = key.Equals(s.Key);
        foreach (var c in s.Value)
          c.Visible = t;
      }
      currentGroup = key;
    }
    /// <summary>
    /// Set all control groups invisible.
    /// </summary>
    public void switchOffAll()
    {
      foreach (var s in groups)
        foreach (var c in s.Value)
          c.Visible = false;
      currentGroup = default(K);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ISet<Control> getCurrentGroup()
    {
      return (currentGroup.Equals(default(K))) ? null : groups[currentGroup];
    }

    
  }
}
