namespace xbuffer
{
    public static class t_AuthorInfo9Buffer
    {
        public static t_AuthorInfo9 Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Id(唯一id)
			int _Id = intBuffer.Deserialize(buffer, ref offset);

			// author(作者)
			string _author = stringBuffer.Deserialize(buffer, ref offset);

			// age(年龄)
			int _age = intBuffer.Deserialize(buffer, ref offset);

			// money(拥有金钱)
			float _money = floatBuffer.Deserialize(buffer, ref offset);

			// hashouse(拥有房子)
			bool _hashouse = boolBuffer.Deserialize(buffer, ref offset);

			// pbutctime(出版utc时间)
			long _pbutctime = longBuffer.Deserialize(buffer, ref offset);

			// luckynumber(幸运数字)
			int _luckynumber_length = intBuffer.Deserialize(buffer, ref offset);
            int[] _luckynumber = new int[_luckynumber_length];
            for (int i = 0; i < _luckynumber_length; i++)
            {
                _luckynumber[i] = intBuffer.Deserialize(buffer, ref offset);
            }

			// value
			return new t_AuthorInfo9(
                _Id,
                _author,
                _age,
                _money,
                _hashouse,
                _pbutctime,
                _luckynumber
            );
        }

        public static void Serialize(t_AuthorInfo9 value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Id(唯一id)
			intBuffer.Serialize(value.Id, steam);

			// author(作者)
			stringBuffer.Serialize(value.author, steam);

			// age(年龄)
			intBuffer.Serialize(value.age, steam);

			// money(拥有金钱)
			floatBuffer.Serialize(value.money, steam);

			// hashouse(拥有房子)
			boolBuffer.Serialize(value.hashouse, steam);

			// pbutctime(出版utc时间)
			longBuffer.Serialize(value.pbutctime, steam);

			// luckynumber(幸运数字)
            intBuffer.Serialize(value.luckynumber.Length, steam);
            for (int i = 0; i < value.luckynumber.Length; i++)
            {
                intBuffer.Serialize(value.luckynumber[i], steam);
            }
        }
    }
}
