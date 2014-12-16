using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// Zuoanqh's Utility for Windows Forms.
  /// </summary>
  public static class zuwf
  {
    /// <summary>
    /// Remove all selected items in given ListView.
    /// </summary>
    /// <param name="v">ListView to remove item.</param>
    public static void ListView_RemoveSelected(ListView v)
    {
      foreach (ListViewItem i in v.SelectedItems)
        v.Items.RemoveAt(i.Index);
    }

    /// <summary>
    /// Search the content of given ListView for the given text.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="text"></param>
    /// <returns>Whether an item with given text is found.</returns>
    public static bool ListView_ContainsItemWithText(ListView v, string text)
    {
      foreach (ListViewItem i in v.Items)
        if (i.Text.Equals(text)) return true;
      return false;
    }
    /// <summary>
    /// Remove all items with text appeared in given set in given ListView.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="s"></param>
    public static void ListView_RemoveItemsWithSetofText(ListView v, HashSet<string> s)
    {
      List<ListViewItem> removeList = new List<ListViewItem>();

      foreach (ListViewItem i in v.Items)
        if (s.Contains(i.Text)) removeList.Add(i);

      removeList.ForEach((i) => v.Items.Remove(i));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    /// <param name="text"></param>
    public static void ListView_AddTextIfNotContained(ListView v, string text)
    {
      if (!ListView_ContainsItemWithText(v, text)) v.Items.Add(text);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    public static void ListView_AdjustTileSizetoFirstItem(ListView v)
    {
      v.TileSize = new System.Drawing.Size((int)Math.Round(v.CreateGraphics().MeasureString(v.Items[0].Text, v.Font).Width) + v.Items[0].Text.Length * 1 + 4, 28);
      string t = v.Items[v.Items.Count - 1].Text;
      v.Items.RemoveAt(v.Items.Count - 1);
      v.Items.Add(t);
    }
    /// <summary>
    /// Create a string by concatonating item's texts in given list view, sepearated by a space.
    /// </summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static string ListView_GenerateStringofItems(ListView l)
    {
      string s = "";
      foreach (ListViewItem i in l.Items)
        s += i.Text + " ";
      return s.Trim();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="l"></param>
    public static void ListBox_SelectLast(ListBox l)
    {
      l.SelectedIndex = l.Items.Count - 1;
    }
    /// <summary>
    /// Replace the old item at given index by the given item.
    /// </summary>
    /// <param name="l"></param>
    /// <param name="index"></param>
    /// <param name="item"></param>
    public static void ListBox_UpdateItem(ListBox l, int index, object item)
    {
      l.Items.RemoveAt(index);
      l.Items.Insert(index, item);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="l"></param>
    /// <param name="item"></param>
    public static void ListBox_UpdateSelectedItem(ListBox l, object item)
    {
      ListBox_UpdateItem(l, l.SelectedIndex, item);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static string ListBox_GetSelectedItemText(ListBox l)
    {
      if (l.SelectedItem != null)
        return l.SelectedItem.ToString();
      return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="l"></param>
    public static void ListBox_RemoveAllSelectedItems(ListBox l)
    {
      ListBox_RemoveAllSelectedItems(l, null);
    }
    /// <summary>
    /// Remove all selected items, but invoke given action with item removing as parameter before removing.
    /// </summary>
    /// <param name="l"></param>
    /// <param name="onRemove"></param>
    public static void ListBox_RemoveAllSelectedItems(ListBox l, Action<object> onRemove)
    {
      if (l.SelectedIndices.Count == 0) return;
      SortedSet<int> set = new SortedSet<int>();
      foreach (object i in l.SelectedItems)
      {
        set.Add(l.Items.IndexOf(i));
      }
      while (set.Count > 0)
      {
        if (onRemove != null) onRemove.Invoke(l.Items[set.Max]);
        l.Items.RemoveAt(set.Max);
        set.Remove(set.Max);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="l"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool ListBox_ContainsItemWithText(ListBox l, string s)
    {
      foreach (object i in l.Items)
        if (i.ToString() == s) return true;
      return false;
    }
    /// <summary>
    /// Adds given string as an item if given ListBox does not contain one already.
    /// </summary>
    /// <param name="l"></param>
    /// <param name="s"></param>
    public static void ListBox_AddTextIfNotContained(ListBox l, string s)
    {
      if (!ListBox_ContainsItemWithText(l, s)) l.Items.Add(s);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static bool ListBox_HaveItemSelected(ListBox l)
    {
      return l.SelectedItems.Count > 0;
    }

    public static string ListBox_MkString(ListBox l, char delim)
    {
      if (l.Items.Count == 0) return "";
      string ans = "";
      foreach(var v in l.Items)
      {
        ans += v.ToString()+delim+' ';
      }
      return zusp.ChopRight(ans, 2).First;
    }
    /// <summary>
    /// Avoids setting text to clipboard if given string does not have actual charecters.
    /// </summary>
    /// <param name="s"></param>
    public static void Clipboard_SetTextIfNotEmpty(string s)
    {
      if (s.Trim().Length > 0) Clipboard.SetText(s, TextDataFormat.UnicodeText);
    }

  }
}