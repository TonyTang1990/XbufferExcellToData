namespace xbuffer
{
    public static class t_AuthorInfoBuffer
    {
        public static t_AuthorInfo Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			int _Id = intBuffer.Deserialize(buffer, ref offset);

			// author
			string _author = stringBuffer.Deserialize(buffer, ref offset);

			// age
			int _age = intBuffer.Deserialize(buffer, ref offset);

			// money
			float _money = floatBuffer.Deserialize(buffer, ref offset);

			// hashouse
			bool _hashouse = boolBuffer.Deserialize(buffer, ref offset);

			// pbutctime
			long _pbutctime = longBuffer.Deserialize(buffer, ref offset);

			// luckynumber
			int _luckynumber_length = intBuffer.Deserialize(buffer, ref offset);
            int[] _luckynumber = new int[_luckynumber_length];
            for (int i = 0; i < _luckynumber_length; i++)
            {
                _luckynumber[i] = intBuffer.Deserialize(buffer, ref offset);
            }

			// weekday
			byte _weekday = byteBuffer.Deserialize(buffer, ref offset);

			// testclass
			t_AuthorInfo_testclass _testclass = t_AuthorInfo_testclassBuffer.Deserialize(buffer, ref offset);

			// testclassarray
			int _testclassarray_length = intBuffer.Deserialize(buffer, ref offset);
            t_AuthorInfo_testclassarray[] _testclassarray = new t_AuthorInfo_testclassarray[_testclassarray_length];
            for (int i = 0; i < _testclassarray_length; i++)
            {
                _testclassarray[i] = t_AuthorInfo_testclassarrayBuffer.Deserialize(buffer, ref offset);
            }

			// testclasstwoarray
            int _testclasstwoarray_two_length = intBuffer.Deserialize(buffer, ref offset);
            t_AuthorInfo_testclasstwoarray[][] _testclasstwoarray = new t_AuthorInfo_testclasstwoarray[_testclasstwoarray_two_length][];
            for (int i = 0; i < _testclasstwoarray_two_length; i++)
            {
                int _testclasstwoarray_one_length = intBuffer.Deserialize(buffer, ref offset);
                _testclasstwoarray[i] = new t_AuthorInfo_testclasstwoarray[_testclasstwoarray_one_length];
                for(int j = 0; j < _testclasstwoarray_one_length; j++)
                {
                    _testclasstwoarray[i][j] = t_AuthorInfo_testclasstwoarrayBuffer.Deserialize(buffer, ref offset);
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
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.Serialize(value.Id, steam);

			// author
			stringBuffer.Serialize(value.author, steam);

			// age
			intBuffer.Serialize(value.age, steam);

			// money
			floatBuffer.Serialize(value.money, steam);

			// hashouse
			boolBuffer.Serialize(value.hashouse, steam);

			// pbutctime
			longBuffer.Serialize(value.pbutctime, steam);

			// luckynumber
            intBuffer.Serialize(value.luckynumber.Length, steam);
            for (int i = 0; i < value.luckynumber.Length; i++)
            {
                intBuffer.Serialize(value.luckynumber[i], steam);
            }

			// weekday
			byteBuffer.Serialize(value.weekday, steam);

			// testclass
			t_AuthorInfo_testclassBuffer.Serialize(value.testclass, steam);

			// testclassarray
            intBuffer.Serialize(value.testclassarray.Length, steam);
            for (int i = 0; i < value.testclassarray.Length; i++)
            {
                t_AuthorInfo_testclassarrayBuffer.Serialize(value.testclassarray[i], steam);
            }

			// testclasstwoarray
            int _testclasstwoarray_two_length = value.testclasstwoarray.Length;
            intBuffer.Serialize(_testclasstwoarray_two_length, steam);
            for (int i = 0; i < _testclasstwoarray_two_length; i++)
            {
                int _testclasstwoarray_one_length = value.testclasstwoarray[i].Length;
                intBuffer.Serialize(_testclasstwoarray_one_length, steam);
                for(int j = 0; j < _testclasstwoarray_one_length; j++)
                {
                    t_AuthorInfo_testclasstwoarrayBuffer.Serialize(value.testclasstwoarray[i][j], steam);
                }
            }
        }
    }
}
