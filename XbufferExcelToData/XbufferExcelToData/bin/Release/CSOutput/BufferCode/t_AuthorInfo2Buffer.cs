namespace xbuffer
{
    public static class t_AuthorInfo2Buffer
    {
        public static t_AuthorInfo2 Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.Deserialize(buffer, ref offset);

			// author
			string _author = stringBuffer.Deserialize(buffer, ref offset);

			// age
			int _age = intBuffer.Deserialize(buffer, ref offset);

			// money
			float _money = floatBuffer.Deserialize(buffer, ref offset);

			// hashouse
			bool _hashouse = boolBuffer.Deserialize(buffer, ref offset);

			// pbutctime
			long _pbutctime = longBuffer.Deserialize(buffer, ref offset);

			// luckynumber
			int _luckynumber_length = intBuffer.Deserialize(buffer, ref offset);
            int[] _luckynumber = new int[_luckynumber_length];
            for (int i = 0; i < _luckynumber_length; i++)
            {
                _luckynumber[i] = intBuffer.Deserialize(buffer, ref offset);
            }

			return new t_AuthorInfo2(
                _Id,
                _author,
                _age,
                _money,
                _hashouse,
                _pbutctime,
                _luckynumber
            );
        }

        public static void Serialize(t_AuthorInfo2 value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.Serialize(value.Id, steam);

			// author
			stringBuffer.Serialize(value.author, steam);

			// age
			intBuffer.Serialize(value.age, steam);

			// money
			floatBuffer.Serialize(value.money, steam);

			// hashouse
			boolBuffer.Serialize(value.hashouse, steam);

			// pbutctime
			longBuffer.Serialize(value.pbutctime, steam);

			// luckynumber
            intBuffer.Serialize(value.luckynumber.Length, steam);
            for (int i = 0; i < value.luckynumber.Length; i++)
            {
                intBuffer.Serialize(value.luckynumber[i], steam);
            }
        }
    }
}
