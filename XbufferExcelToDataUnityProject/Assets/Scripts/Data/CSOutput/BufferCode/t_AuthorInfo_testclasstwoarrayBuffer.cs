namespace xbuffer
{
    public static class t_AuthorInfo_testclasstwoarrayBuffer
    {
        public static t_AuthorInfo_testclasstwoarray Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// param11
			int param11 = intBuffer.Deserialize(buffer, ref offset);

			// param22
			bool param22 = boolBuffer.Deserialize(buffer, ref offset);

			// param33
			string param33 = stringBuffer.Deserialize(buffer, ref offset);

			return new t_AuthorInfo_testclasstwoarray(
                param11,
                param22,
                param33
            );
        }

        public static void Serialize(t_AuthorInfo_testclasstwoarray value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// param11
			intBuffer.Serialize(value.param11, steam);

			// param22
			boolBuffer.Serialize(value.param22, steam);

			// param33
			stringBuffer.Serialize(value.param33, steam);
        }
    }
}
