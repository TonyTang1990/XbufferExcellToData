namespace xbuffer
{
    public static class t_global_bBuffer
    {
        public static t_global_b Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Key
			string _Key = stringBuffer.Deserialize(buffer, ref offset);

			// Value
			bool _Value = boolBuffer.Deserialize(buffer, ref offset);

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

			// Key
			stringBuffer.Serialize(value.Key, steam);

			// Value
			boolBuffer.Serialize(value.Value, steam);
        }
    }
}
