namespace xbuffer
{
    public static class t_global_iBuffer
    {
        public static t_global_i Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Key
			string _Key = stringBuffer.Deserialize(buffer, ref offset);

			// Value
			int _Value = intBuffer.Deserialize(buffer, ref offset);

			return new t_global_i(
                _Key,
                _Value
            );
        }

        public static void Serialize(t_global_i value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Key
			stringBuffer.Serialize(value.Key, steam);

			// Value
			intBuffer.Serialize(value.Value, steam);
        }
    }
}
