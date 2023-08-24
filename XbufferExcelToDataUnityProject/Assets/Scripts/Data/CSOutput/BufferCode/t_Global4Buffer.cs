namespace xbuffer
{
    public static class t_Global4Buffer
    {
        public static t_Global4 Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.Deserialize(buffer, ref offset);

			// stringvalue
			string _stringvalue = stringBuffer.Deserialize(buffer, ref offset);

			// intvalue
			int _intvalue = intBuffer.Deserialize(buffer, ref offset);

			// floatvalue
			float _floatvalue = floatBuffer.Deserialize(buffer, ref offset);

			// intarrayvalue
			int _intarrayvalue_length = intBuffer.Deserialize(buffer, ref offset);
            int[] _intarrayvalue = new int[_intarrayvalue_length];
            for (int i = 0; i < _intarrayvalue_length; i++)
            {
                _intarrayvalue[i] = intBuffer.Deserialize(buffer, ref offset);
            }

			// stringarrayvalue
			int _stringarrayvalue_length = intBuffer.Deserialize(buffer, ref offset);
            string[] _stringarrayvalue = new string[_stringarrayvalue_length];
            for (int i = 0; i < _stringarrayvalue_length; i++)
            {
                _stringarrayvalue[i] = stringBuffer.Deserialize(buffer, ref offset);
            }

			return new t_Global4(
                _Id,
                _stringvalue,
                _intvalue,
                _floatvalue,
                _intarrayvalue,
                _stringarrayvalue
            );
        }

        public static void Serialize(t_Global4 value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.Serialize(value.Id, steam);

			// stringvalue
			stringBuffer.Serialize(value.stringvalue, steam);

			// intvalue
			intBuffer.Serialize(value.intvalue, steam);

			// floatvalue
			floatBuffer.Serialize(value.floatvalue, steam);

			// intarrayvalue
            intBuffer.Serialize(value.intarrayvalue.Length, steam);
            for (int i = 0; i < value.intarrayvalue.Length; i++)
            {
                intBuffer.Serialize(value.intarrayvalue[i], steam);
            }

			// stringarrayvalue
            intBuffer.Serialize(value.stringarrayvalue.Length, steam);
            for (int i = 0; i < value.stringarrayvalue.Length; i++)
            {
                stringBuffer.Serialize(value.stringarrayvalue[i], steam);
            }
        }
    }
}
