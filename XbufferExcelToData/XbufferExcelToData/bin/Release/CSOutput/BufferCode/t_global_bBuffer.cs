namespace xbuffer
{
    public static class t_global_bBuffer
    {
        public static t_global_b Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// Key
			string Key = stringBuffer.Deserialize(buffer, ref offset);

			// Value
			bool Value = boolBuffer.Deserialize(buffer, ref offset);

			return new t_global_b(
                Key,
                Value
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
