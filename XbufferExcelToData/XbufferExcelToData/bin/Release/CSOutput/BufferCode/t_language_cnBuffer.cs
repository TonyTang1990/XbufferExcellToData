namespace xbuffer
{
    public static class t_language_cnBuffer
    {
        public static t_language_cn Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// Key
			string _Key = stringBuffer.deserialize(buffer, ref offset);

			// Value
			string _Value = stringBuffer.deserialize(buffer, ref offset);

			return new t_language_cn(
                _Key,
                _Value
            );
        }

        public static void Serialize(t_language_cn value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// Key
			stringBuffer.serialize(value.Key, steam);

			// Value
			stringBuffer.serialize(value.Value, steam);
        }
    }
}
