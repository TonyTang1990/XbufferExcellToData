namespace xbuffer
{
    public static class t_globalBuffer
    {
        public static t_global deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.deserialize(buffer, ref offset);

			// string_value
			string _string_value = stringBuffer.deserialize(buffer, ref offset);

			// int_value
			int _int_value = intBuffer.deserialize(buffer, ref offset);

			// bool_value
			bool _bool_value = boolBuffer.deserialize(buffer, ref offset);

			// value
			return new t_global() {
				Id = _Id,
				string_value = _string_value,
				int_value = _int_value,
				bool_value = _bool_value,
            };
        }

        public static void serialize(t_global value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.serialize(value.Id, steam);

			// string_value
			stringBuffer.serialize(value.string_value, steam);

			// int_value
			intBuffer.serialize(value.int_value, steam);

			// bool_value
			boolBuffer.serialize(value.bool_value, steam);
        }
    }
}
