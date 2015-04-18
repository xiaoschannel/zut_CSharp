using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvi3 : zvi
  {
    public zvi3(int first, int second, int third)
      : base(first, second, third) { }
    public zvi3(zvi2 vec, int third) 
      : this(vec[0], vec[1], third) { }

    public static explicit operator zvi2(zvi3 v)
    { return new zvi2(v[0], v[1]); }

    public int x { get { return this[0]; } }
    public int y { get { return this[1]; } }
    public int z { get { return this[2]; } }

    public int r { get { return this[0]; } }
    public int g { get { return this[1]; } }
    public int b { get { return this[2]; } }

    public zvi2 xy { get { return new zvi2(x, y); } }
    public zvi2 xz { get { return new zvi2(x, z); } }
    public zvi2 yz { get { return new zvi2(y, z); } }
    public zvi2 yx { get { return new zvi2(y, x); } }
    public zvi2 zx { get { return new zvi2(z, x); } }
    public zvi2 zy { get { return new zvi2(z, y); } }
    public zvi2 xx { get { return new zvi2(x, x); } }
    public zvi2 yy { get { return new zvi2(y, y); } }
    public zvi2 zz { get { return new zvi2(z, z); } }

    public zvi2 rg { get { return new zvi2(x, y); } }
    public zvi2 rb { get { return new zvi2(x, z); } }
    public zvi2 gb { get { return new zvi2(y, z); } }
    public zvi2 gr { get { return new zvi2(y, x); } }
    public zvi2 br { get { return new zvi2(z, x); } }
    public zvi2 bg { get { return new zvi2(z, y); } }
    public zvi2 rr { get { return new zvi2(x, x); } }
    public zvi2 gg { get { return new zvi2(y, y); } }
    public zvi2 bb { get { return new zvi2(z, z); } }

    public zvi3 xxx { get { return new zvi3(x, x, x); } }
    public zvi3 xxy { get { return new zvi3(x, x, y); } }
    public zvi3 xxz { get { return new zvi3(x, x, z); } }
    public zvi3 xyx { get { return new zvi3(x, y, x); } }
    public zvi3 xyy { get { return new zvi3(x, y, y); } }
    public zvi3 xyz { get { return this; } }
    public zvi3 xzx { get { return new zvi3(x, z, x); } }
    public zvi3 xzy { get { return new zvi3(x, z, y); } }
    public zvi3 xzz { get { return new zvi3(x, z, z); } }
    public zvi3 yxx { get { return new zvi3(y, x, x); } }
    public zvi3 yxy { get { return new zvi3(y, x, y); } }
    public zvi3 yxz { get { return new zvi3(y, x, z); } }
    public zvi3 yyx { get { return new zvi3(y, y, x); } }
    public zvi3 yyy { get { return new zvi3(y, y, y); } }
    public zvi3 yyz { get { return new zvi3(y, y, z); } }
    public zvi3 yzx { get { return new zvi3(y, z, x); } }
    public zvi3 yzy { get { return new zvi3(y, z, y); } }
    public zvi3 yzz { get { return new zvi3(y, z, z); } }
    public zvi3 zxx { get { return new zvi3(z, x, x); } }
    public zvi3 zxy { get { return new zvi3(z, x, y); } }
    public zvi3 zxz { get { return new zvi3(z, x, z); } }
    public zvi3 zyx { get { return new zvi3(z, y, x); } }
    public zvi3 zyy { get { return new zvi3(z, y, y); } }
    public zvi3 zyz { get { return new zvi3(z, y, z); } }
    public zvi3 zzx { get { return new zvi3(z, z, x); } }
    public zvi3 zzy { get { return new zvi3(z, z, y); } }
    public zvi3 zzz { get { return new zvi3(z, z, z); } }

    public zvi3 rrr { get { return new zvi3(x, x, x); } }
    public zvi3 rrg { get { return new zvi3(x, x, y); } }
    public zvi3 rrb { get { return new zvi3(x, x, z); } }
    public zvi3 rgr { get { return new zvi3(x, y, x); } }
    public zvi3 rgg { get { return new zvi3(x, y, y); } }
    public zvi3 rgb { get { return this; } }
    public zvi3 rbr { get { return new zvi3(x, z, x); } }
    public zvi3 rbg { get { return new zvi3(x, z, y); } }
    public zvi3 rbb { get { return new zvi3(x, z, z); } }
    public zvi3 grr { get { return new zvi3(y, x, x); } }
    public zvi3 grg { get { return new zvi3(y, x, y); } }
    public zvi3 grb { get { return new zvi3(y, x, z); } }
    public zvi3 ggr { get { return new zvi3(y, y, x); } }
    public zvi3 ggg { get { return new zvi3(y, y, y); } }
    public zvi3 ggb { get { return new zvi3(y, y, z); } }
    public zvi3 gbr { get { return new zvi3(y, z, x); } }
    public zvi3 gbg { get { return new zvi3(y, z, y); } }
    public zvi3 gbb { get { return new zvi3(y, z, z); } }
    public zvi3 brr { get { return new zvi3(z, x, x); } }
    public zvi3 brg { get { return new zvi3(z, x, y); } }
    public zvi3 brb { get { return new zvi3(z, x, z); } }
    public zvi3 bgr { get { return new zvi3(z, y, x); } }
    public zvi3 bgg { get { return new zvi3(z, y, y); } }
    public zvi3 bgb { get { return new zvi3(z, y, z); } }
    public zvi3 bbr { get { return new zvi3(z, z, x); } }
    public zvi3 bbg { get { return new zvi3(z, z, y); } }
    public zvi3 bbb { get { return new zvi3(z, z, z); } }

  }
}
