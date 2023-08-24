namespace xbuffer
{
    public static class t_AuthorInfo_testclassarrayBuffer
    {
        public static t_AuthorInfo_testclassarray Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// param1
			int _param1 = intBuffer.deserialize(buffer, ref offset);

			// param2
			bool _param2 = boolBuffer.deserialize(buffer, ref offset);

			// param3
			string _param3 = stringBuffer.deserialize(buffer, ref offset);

			return new t_AuthorInfo_testclassarray(
                _param1,
                _param2,
                _param3
            );
        }

        public static void Serialize(t_AuthorInfo_testclassarray value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// param1
			intBuffer.serialize(value.param1, steam);

			// param2
			boolBuffer.serialize(value.param2, steam);

			// param3
			stringBuffer.serialize(value.param3, steam);
        }
    }
}
