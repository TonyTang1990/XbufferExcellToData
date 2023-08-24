namespace xbuffer
{
    public static class t_AuthorInfo_testclassBuffer
    {
        public static t_AuthorInfo_testclass Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// id
			int _id = intBuffer.deserialize(buffer, ref offset);

			// num
			int _num = intBuffer.deserialize(buffer, ref offset);

			// des
			string _des = stringBuffer.deserialize(buffer, ref offset);

			return new t_AuthorInfo_testclass(
                _id,
                _num,
                _des
            );
        }

        public static void Serialize(t_AuthorInfo_testclass value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// id
			intBuffer.serialize(value.id, steam);

			// num
			intBuffer.serialize(value.num, steam);

			// des
			stringBuffer.serialize(value.des, steam);
        }
    }
}
