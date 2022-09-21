using System;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
	[UnitySerializable]
    public struct SerializedGuid
	{
		public static readonly SerializedGuid Empty = new SerializedGuid(Guid.Empty);

		public SerializedGuid(Guid guid)
        {
			var guidBytes = guid.ToByteArray();

            a = (guidBytes[3] << 24) | (guidBytes[2] << 16) | (guidBytes[1] << 8) | guidBytes[0];
            b = (short)((guidBytes[5] << 8) | guidBytes[4]);
            c = (short)((guidBytes[7] << 8) | guidBytes[6]);
            d = guidBytes[8];
			e = guidBytes[9];
			f = guidBytes[10];
			g = guidBytes[11];
			h = guidBytes[12];
			i = guidBytes[13];
			j = guidBytes[14];
			k = guidBytes[15];
		}

		public SerializedGuid(string guidString) : this(new Guid(guidString)) { }

		public Guid ToGuid()
        {
			return new Guid(a, b, c, d, e, f, g, h, i, j, k);
        }

        public override string ToString()
        {
			return ToGuid().ToString();
        }

        public override bool Equals(object obj)
        {
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				SerializedGuid o = (SerializedGuid)obj;
				return
					a == o.a &&
					b == o.b &&
					c == o.c &&
					d == o.d &&
					e == o.e &&
					f == o.f &&
					g == o.g &&
					h == o.h && 
					i == o.i &&
					j == o.j &&
					k == o.k;
			}
		}

        public override int GetHashCode()
        {
            return a ^ ((b << 16) | (int)c) ^ ((f << 24) | k);
        }

        public static bool operator ==(SerializedGuid left, SerializedGuid right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SerializedGuid left, SerializedGuid right)
        {
            return !(left == right);
        }

        public int a;
		public short b;
		public short c;
		public byte d;
		public byte e;
		public byte f;
		public byte g;
		public byte h;
		public byte i;
		public byte j;
		public byte k;
	}
}
