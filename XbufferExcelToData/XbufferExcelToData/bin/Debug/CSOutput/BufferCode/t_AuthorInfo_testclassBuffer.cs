namespace xbuffer
{
    public static class t_AuthorInfo_testclassBuffer
    {
        public static t_AuthorInfo_testclass Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// id
			int id = intBuffer.Deserialize(buffer, ref offset);

			// num
			int num = intBuffer.Deserialize(buffer, ref offset);

			// des
			string des = stringBuffer.Deserialize(buffer, ref offset);

			return new t_AuthorInfo_testclass(
                id,
                num,
                des
            );
        }

        public static void Serialize(t_AuthorInfo_testclass value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// id
			intBuffer.Serialize(value.id, steam);

			// num
			intBuffer.Serialize(value.num, steam);

			// des
			stringBuffer.Serialize(value.des, steam);
        }
    }
}
