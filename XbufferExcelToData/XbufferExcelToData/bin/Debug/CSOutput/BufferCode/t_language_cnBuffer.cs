namespace xbuffer
{
    public static class t_language_cnBuffer
    {
        public static t_language_cn Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Key
			string _Key = stringBuffer.Deserialize(buffer, ref offset);

			// Value
			string _Value = stringBuffer.Deserialize(buffer, ref offset);

			return new t_language_cn(
                _Key,
                _Value
            );
        }

        public static void Serialize(t_language_cn value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Key
			stringBuffer.Serialize(value.Key, steam);

			// Value
			stringBuffer.Serialize(value.Value, steam);
        }
    }
}
