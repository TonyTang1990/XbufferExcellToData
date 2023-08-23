namespace xbuffer
{
    public static class t_AuthorInfo_testclassBuffer
    {
        public static t_AuthorInfo_testclass Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// id()
			int _id = intBuffer.Deserialize(buffer, ref offset);

			// num()
			int _num = intBuffer.Deserialize(buffer, ref offset);

			// des()
			string _des = stringBuffer.Deserialize(buffer, ref offset);

			// value
			return new t_AuthorInfo_testclass(
                _id,
                _num,
                _des
            );
        }

        public static void Serialize(t_AuthorInfo_testclass value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// id()
			intBuffer.Serialize(value.id, steam);

			// num()
			intBuffer.Serialize(value.num, steam);

			// des()
			stringBuffer.Serialize(value.des, steam);
        }
    }
}
