namespace xbuffer
{
    public static class t_AuthorInfo_testclasstwoarrayBuffer
    {
        public static t_AuthorInfo_testclasstwoarray Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// param11
			int _param11 = intBuffer.deserialize(buffer, ref offset);

			// param22
			bool _param22 = boolBuffer.deserialize(buffer, ref offset);

			// param33
			string _param33 = stringBuffer.deserialize(buffer, ref offset);

			return new t_AuthorInfo_testclasstwoarray(
                _param11,
                _param22,
                _param33
            );
        }

        public static void Serialize(t_AuthorInfo_testclasstwoarray value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// param11
			intBuffer.serialize(value.param11, steam);

			// param22
			boolBuffer.serialize(value.param22, steam);

			// param33
			stringBuffer.serialize(value.param33, steam);
        }
    }
}
