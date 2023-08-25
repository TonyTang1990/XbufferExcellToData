namespace xbuffer
{
    public static class t_AuthorInfoBuffer
    {
        public static t_AuthorInfo Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// Id
			int Id = intBuffer.Deserialize(buffer, ref offset);

			// author
			string author = stringBuffer.Deserialize(buffer, ref offset);

			// age
			int age = intBuffer.Deserialize(buffer, ref offset);

			// money
			float money = floatBuffer.Deserialize(buffer, ref offset);

			// hashouse
			bool hashouse = boolBuffer.Deserialize(buffer, ref offset);

			// pbutctime
			long pbutctime = longBuffer.Deserialize(buffer, ref offset);

			// luckynumber
			int luckynumberLength = intBuffer.Deserialize(buffer, ref offset);
            int[] luckynumber = null;
            if(luckynumberLength != 0)
            {
                luckynumber = new int[luckynumberLength];
                for (int i = 0; i < luckynumberLength; i++)
                {
                    luckynumber[i] = intBuffer.Deserialize(buffer, ref offset);
                }            
            }

			// weekday
			byte weekday = byteBuffer.Deserialize(buffer, ref offset);

			// testclass
			t_AuthorInfo_testclass testclass = t_AuthorInfo_testclassBuffer.Deserialize(buffer, ref offset);

			// testclassarray
			int testclassarrayLength = intBuffer.Deserialize(buffer, ref offset);
            t_AuthorInfo_testclassarray[] testclassarray = null;
            if(testclassarrayLength != 0)
            {
                testclassarray = new t_AuthorInfo_testclassarray[testclassarrayLength];
                for (int i = 0; i < testclassarrayLength; i++)
                {
                    testclassarray[i] = t_AuthorInfo_testclassarrayBuffer.Deserialize(buffer, ref offset);
                }            
            }

			// testclasstwoarray
            int testclasstwoarrayTwoLength = intBuffer.Deserialize(buffer, ref offset);
            t_AuthorInfo_testclasstwoarray[][] testclasstwoarray = null;
            if(testclasstwoarrayTwoLength != 0)
            {
                testclasstwoarray = new t_AuthorInfo_testclasstwoarray[testclasstwoarrayTwoLength][];
                for (int i = 0; i < testclasstwoarrayTwoLength; i++)
                {
                    int testclasstwoarrayOneLength = intBuffer.Deserialize(buffer, ref offset);
                    if(testclasstwoarrayOneLength != 0)
                    {
                        testclasstwoarray[i] = new t_AuthorInfo_testclasstwoarray[testclasstwoarrayOneLength];
                        for(int j = 0; j < testclasstwoarrayOneLength; j++)
                        {
                            testclasstwoarray[i][j] = t_AuthorInfo_testclasstwoarrayBuffer.Deserialize(buffer, ref offset);
                        }
                    }
                }
            }

			return new t_AuthorInfo(
                Id,
                author,
                age,
                money,
                hashouse,
                pbutctime,
                luckynumber,
                weekday,
                testclass,
                testclassarray,
                testclasstwoarray
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
            int luckynumberLength = value.luckynumber != null ? value.luckynumber.Length : 0;
            intBuffer.Serialize(luckynumberLength, steam);
            if(luckynumberLength != 0)
            {
                for (int i = 0; i < luckynumberLength; i++)
                {
                    intBuffer.Serialize(value.luckynumber[i], steam);
                }
            }

			// weekday
			byteBuffer.Serialize(value.weekday, steam);

			// testclass
			t_AuthorInfo_testclassBuffer.Serialize(value.testclass, steam);

			// testclassarray
            int testclassarrayLength = value.testclassarray != null ? value.testclassarray.Length : 0;
            intBuffer.Serialize(testclassarrayLength, steam);
            if(testclassarrayLength != 0)
            {
                for (int i = 0; i < testclassarrayLength; i++)
                {
                    t_AuthorInfo_testclassarrayBuffer.Serialize(value.testclassarray[i], steam);
                }
            }

			// testclasstwoarray
            int testclasstwoarrayTwoLength = value.testclasstwoarray != null ? value.testclasstwoarray.Length : 0;
            intBuffer.Serialize(testclasstwoarrayTwoLength, steam);
            for (int i = 0; i < testclasstwoarrayTwoLength; i++)
            {
                int testclasstwoarrayOneLength = value.testclasstwoarray[i] != null ? value.testclasstwoarray[i].Length : 0;
                intBuffer.Serialize(testclasstwoarrayOneLength, steam);
                for(int j = 0; j < testclasstwoarrayOneLength; j++)
                {
                    t_AuthorInfo_testclasstwoarrayBuffer.Serialize(value.testclasstwoarray[i][j], steam);
                }
            }
        }
    }
}
