namespace xbuffer
{
    public static class t_Global6Buffer
    {
        public static t_Global6 Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Id(唯一id)
			int _Id = intBuffer.Deserialize(buffer, ref offset);

			// stringvalue(字符串数据)
			string _stringvalue = stringBuffer.Deserialize(buffer, ref offset);

			// intvalue(整形数据)
			int _intvalue = intBuffer.Deserialize(buffer, ref offset);

			// floatvalue(浮点数数据)
			float _floatvalue = floatBuffer.Deserialize(buffer, ref offset);

			// intarrayvalue(整形数组数据)
			int _intarrayvalue_length = intBuffer.Deserialize(buffer, ref offset);
            int[] _intarrayvalue = new int[_intarrayvalue_length];
            for (int i = 0; i < _intarrayvalue_length; i++)
            {
                _intarrayvalue[i] = intBuffer.Deserialize(buffer, ref offset);
            }

			// stringarrayvalue(字符串数组数据)
			int _stringarrayvalue_length = intBuffer.Deserialize(buffer, ref offset);
            string[] _stringarrayvalue = new string[_stringarrayvalue_length];
            for (int i = 0; i < _stringarrayvalue_length; i++)
            {
                _stringarrayvalue[i] = stringBuffer.Deserialize(buffer, ref offset);
            }

			// value
			return new t_Global6(
                _Id,
                _stringvalue,
                _intvalue,
                _floatvalue,
                _intarrayvalue,
                _stringarrayvalue
            );
        }

        public static void Serialize(t_Global6 value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Id(唯一id)
			intBuffer.Serialize(value.Id, steam);

			// stringvalue(字符串数据)
			stringBuffer.Serialize(value.stringvalue, steam);

			// intvalue(整形数据)
			intBuffer.Serialize(value.intvalue, steam);

			// floatvalue(浮点数数据)
			floatBuffer.Serialize(value.floatvalue, steam);

			// intarrayvalue(整形数组数据)
            intBuffer.Serialize(value.intarrayvalue.Length, steam);
            for (int i = 0; i < value.intarrayvalue.Length; i++)
            {
                intBuffer.Serialize(value.intarrayvalue[i], steam);
            }

			// stringarrayvalue(字符串数组数据)
            intBuffer.Serialize(value.stringarrayvalue.Length, steam);
            for (int i = 0; i < value.stringarrayvalue.Length; i++)
            {
                stringBuffer.Serialize(value.stringarrayvalue[i], steam);
            }
        }
    }
}
