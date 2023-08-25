namespace xbuffer
{
    public static class t_global_iBuffer
    {
        public static t_global_i Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// Key
			string Key = stringBuffer.Deserialize(buffer, ref offset);

			// Value
			int Value = intBuffer.Deserialize(buffer, ref offset);

			return new t_global_i(
                Key,
                Value
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
