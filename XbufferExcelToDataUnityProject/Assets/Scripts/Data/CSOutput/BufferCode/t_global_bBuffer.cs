namespace xbuffer
{
    public static class t_global_bBuffer
    {
        public static t_global_b Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Key(唯一Key)
			string _Key = stringBuffer.Deserialize(buffer, ref offset);

			// Value(bool值)
			bool _Value = boolBuffer.Deserialize(buffer, ref offset);

			// value
			return new t_global_b(
                _Key,
                _Value
            );
        }

        public static void Serialize(t_global_b value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Key(唯一Key)
			stringBuffer.Serialize(value.Key, steam);

			// Value(bool值)
			boolBuffer.Serialize(value.Value, steam);
        }
    }
}
