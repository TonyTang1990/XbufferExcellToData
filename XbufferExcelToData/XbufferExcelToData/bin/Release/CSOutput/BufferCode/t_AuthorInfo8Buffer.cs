namespace xbuffer
{
    public static class t_AuthorInfo8Buffer
    {
        public static t_AuthorInfo8 Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.deserialize(buffer, ref offset);

			// author
			string _author = stringBuffer.deserialize(buffer, ref offset);

			// age
			int _age = intBuffer.deserialize(buffer, ref offset);

			// money
			float _money = floatBuffer.deserialize(buffer, ref offset);

			// hashouse
			bool _hashouse = boolBuffer.deserialize(buffer, ref offset);

			// pbutctime
			long _pbutctime = longBuffer.deserialize(buffer, ref offset);

			// luckynumber
			int _luckynumber_length = intBuffer.deserialize(buffer, ref offset);
            int[] _luckynumber = new int[_luckynumber_length];
            for (int i = 0; i < _luckynumber_length; i++)
            {
                _luckynumber[i] = intBuffer.deserialize(buffer, ref offset);
            }

			// value
			return new t_AuthorInfo8(
                _Id,
                _author,
                _age,
                _money,
                _hashouse,
                _pbutctime,
                _luckynumber
            );
        }

        public static void Serialize(t_AuthorInfo8 value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.serialize(value.Id, steam);

			// author
			stringBuffer.serialize(value.author, steam);

			// age
			intBuffer.serialize(value.age, steam);

			// money
			floatBuffer.serialize(value.money, steam);

			// hashouse
			boolBuffer.serialize(value.hashouse, steam);

			// pbutctime
			longBuffer.serialize(value.pbutctime, steam);

			// luckynumber
            intBuffer.serialize(value.luckynumber.Length, steam);
            for (int i = 0; i < value.luckynumber.Length; i++)
            {
                intBuffer.serialize(value.luckynumber[i], steam);
            }
        }
    }
}
