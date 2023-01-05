namespace xbuffer
{
    public static class t_Global6Buffer
    {
        public static t_Global6 Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.deserialize(buffer, ref offset);

			// stringvalue
			string _stringvalue = stringBuffer.deserialize(buffer, ref offset);

			// intvalue
			int _intvalue = intBuffer.deserialize(buffer, ref offset);

			// floatvalue
			float _floatvalue = floatBuffer.deserialize(buffer, ref offset);

			// intarrayvalue
			int _intarrayvalue_length = intBuffer.deserialize(buffer, ref offset);
            int[] _intarrayvalue = new int[_intarrayvalue_length];
            for (int i = 0; i < _intarrayvalue_length; i++)
            {
                _intarrayvalue[i] = intBuffer.deserialize(buffer, ref offset);
            }

			// stringarrayvalue
			int _stringarrayvalue_length = intBuffer.deserialize(buffer, ref offset);
            string[] _stringarrayvalue = new string[_stringarrayvalue_length];
            for (int i = 0; i < _stringarrayvalue_length; i++)
            {
                _stringarrayvalue[i] = stringBuffer.deserialize(buffer, ref offset);
            }

			// value
			return new t_Global6() {
				Id = _Id,
				stringvalue = _stringvalue,
				intvalue = _intvalue,
				floatvalue = _floatvalue,
				intarrayvalue = _intarrayvalue,
				stringarrayvalue = _stringarrayvalue,
            };
        }

        public static void Serialize(t_Global6 value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.serialize(value.Id, steam);

			// stringvalue
			stringBuffer.serialize(value.stringvalue, steam);

			// intvalue
			intBuffer.serialize(value.intvalue, steam);

			// floatvalue
			floatBuffer.serialize(value.floatvalue, steam);

			// intarrayvalue
            intBuffer.serialize(value.intarrayvalue.Length, steam);
            for (int i = 0; i < value.intarrayvalue.Length; i++)
            {
                intBuffer.serialize(value.intarrayvalue[i], steam);
            }

			// stringarrayvalue
            intBuffer.serialize(value.stringarrayvalue.Length, steam);
            for (int i = 0; i < value.stringarrayvalue.Length; i++)
            {
                stringBuffer.serialize(value.stringarrayvalue[i], steam);
            }
        }
    }
}
