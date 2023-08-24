namespace xbuffer
{
    public static class t_AuthorInfoBuffer
    {
        public static t_AuthorInfo Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.deserialize(buffer, ref offset);

			// author
			string _author = stringBuffer.deserialize(buffer, ref offset);

			// age
			int _age = intBuffer.deserialize(buffer, ref offset);

			// money
			float _money = floatBuffer.deserialize(buffer, ref offset);

			// hashouse
			bool _hashouse = boolBuffer.deserialize(buffer, ref offset);

			// pbutctime
			long _pbutctime = longBuffer.deserialize(buffer, ref offset);

			// luckynumber
			int _luckynumber_length = intBuffer.deserialize(buffer, ref offset);
            int[] _luckynumber = new int[_luckynumber_length];
            for (int i = 0; i < _luckynumber_length; i++)
            {
                _luckynumber[i] = intBuffer.deserialize(buffer, ref offset);
            }

			// weekday
			byte _weekday = byteBuffer.deserialize(buffer, ref offset);

			// testclass
			t_AuthorInfo_testclass _testclass = t_AuthorInfo_testclassBuffer.deserialize(buffer, ref offset);

			// testclassarray
			int _testclassarray_length = intBuffer.deserialize(buffer, ref offset);
            t_AuthorInfo_testclassarray[] _testclassarray = new t_AuthorInfo_testclassarray[_testclassarray_length];
            for (int i = 0; i < _testclassarray_length; i++)
            {
                _testclassarray[i] = t_AuthorInfo_testclassarrayBuffer.deserialize(buffer, ref offset);
            }

			// testclasstwoarray
            int _testclasstwoarray_two_length = intBuffer.deserialize(buffer, ref offset);
            t_AuthorInfo_testclasstwoarray[][] _testclasstwoarray = new t_AuthorInfo_testclasstwoarray[_testclasstwoarray_two_length][];
            for (int i = 0; i < _testclasstwoarray_two_length; i++)
            {
                int _testclasstwoarray_one_length = intBuffer.deserialize(buffer, ref offset);
                _testclasstwoarray[i] = new t_AuthorInfo_testclasstwoarray[_testclasstwoarray_one_length];
                for(int j = 0; j < _testclasstwoarray_one_length; j++)
                {
                    _testclasstwoarray[i][j] = t_AuthorInfo_testclasstwoarrayBuffer.deserialize(buffer, ref offset);
                }
            }

			return new t_AuthorInfo(
                _Id,
                _author,
                _age,
                _money,
                _hashouse,
                _pbutctime,
                _luckynumber,
                _weekday,
                _testclass,
                _testclassarray,
                _testclasstwoarray
            );
        }

        public static void Serialize(t_AuthorInfo value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.serialize(value.Id, steam);

			// author
			stringBuffer.serialize(value.author, steam);

			// age
			intBuffer.serialize(value.age, steam);

			// money
			floatBuffer.serialize(value.money, steam);

			// hashouse
			boolBuffer.serialize(value.hashouse, steam);

			// pbutctime
			longBuffer.serialize(value.pbutctime, steam);

			// luckynumber
            intBuffer.serialize(value.luckynumber.Length, steam);
            for (int i = 0; i < value.luckynumber.Length; i++)
            {
                intBuffer.serialize(value.luckynumber[i], steam);
            }

			// weekday
			byteBuffer.serialize(value.weekday, steam);

			// testclass
			t_AuthorInfo_testclassBuffer.serialize(value.testclass, steam);

			// testclassarray
            intBuffer.serialize(value.testclassarray.Length, steam);
            for (int i = 0; i < value.testclassarray.Length; i++)
            {
                t_AuthorInfo_testclassarrayBuffer.serialize(value.testclassarray[i], steam);
            }

			// testclasstwoarray
            int _testclasstwoarray_two_length = value.testclasstwoarray.Length;
            intBuffer.serialize(_testclasstwoarray_two_length, steam);
            for (int i = 0; i < _testclasstwoarray_two_length; i++)
            {
                int _testclasstwoarray_one_length = value.testclasstwoarray[i].Length;
                intBuffer.serialize(_testclasstwoarray_one_length, steam);
                for(int j = 0; j < _testclasstwoarray_one_length; j++)
                {
                    t_AuthorInfo_testclasstwoarrayBuffer.serialize(value.testclasstwoarray[i][j], steam);
                }
            }
        }
    }
}
