namespace xbuffer
{
    public static class t_uiBuffer
    {
        public static t_ui Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// WinName
			string WinName = stringBuffer.Deserialize(buffer, ref offset);

			// ResPath
			string ResPath = stringBuffer.Deserialize(buffer, ref offset);

			// TestSpace1
			string TestSpace1 = stringBuffer.Deserialize(buffer, ref offset);

			// IsFullScreen
			bool IsFullScreen = boolBuffer.Deserialize(buffer, ref offset);

			// Layer
			int Layer = intBuffer.Deserialize(buffer, ref offset);

			// TestSpace2
			string TestSpace2 = stringBuffer.Deserialize(buffer, ref offset);

			// TestByte
			byte TestByte = byteBuffer.Deserialize(buffer, ref offset);

			// TestByteArray
			int TestByteArrayLength = intBuffer.Deserialize(buffer, ref offset);
            byte[] TestByteArray = null;
            if(TestByteArrayLength != 0)
            {
                TestByteArray = new byte[TestByteArrayLength];
                for (int i = 0; i < TestByteArrayLength; i++)
                {
                    TestByteArray[i] = byteBuffer.Deserialize(buffer, ref offset);
                }            
            }

			// TestIntTwoArray
            int TestIntTwoArrayTwoLength = intBuffer.Deserialize(buffer, ref offset);
            int[][] TestIntTwoArray = null;
            if(TestIntTwoArrayTwoLength != 0)
            {
                TestIntTwoArray = new int[TestIntTwoArrayTwoLength][];
                for (int i = 0; i < TestIntTwoArrayTwoLength; i++)
                {
                    int TestIntTwoArrayOneLength = intBuffer.Deserialize(buffer, ref offset);
                    if(TestIntTwoArrayOneLength != 0)
                    {
                        TestIntTwoArray[i] = new int[TestIntTwoArrayOneLength];
                        for(int j = 0; j < TestIntTwoArrayOneLength; j++)
                        {
                            TestIntTwoArray[i][j] = intBuffer.Deserialize(buffer, ref offset);
                        }
                    }
                }
            }

			// TestStringTwoArray
            int TestStringTwoArrayTwoLength = intBuffer.Deserialize(buffer, ref offset);
            string[][] TestStringTwoArray = null;
            if(TestStringTwoArrayTwoLength != 0)
            {
                TestStringTwoArray = new string[TestStringTwoArrayTwoLength][];
                for (int i = 0; i < TestStringTwoArrayTwoLength; i++)
                {
                    int TestStringTwoArrayOneLength = intBuffer.Deserialize(buffer, ref offset);
                    if(TestStringTwoArrayOneLength != 0)
                    {
                        TestStringTwoArray[i] = new string[TestStringTwoArrayOneLength];
                        for(int j = 0; j < TestStringTwoArrayOneLength; j++)
                        {
                            TestStringTwoArray[i][j] = stringBuffer.Deserialize(buffer, ref offset);
                        }
                    }
                }
            }

			return new t_ui(
                WinName,
                ResPath,
                TestSpace1,
                IsFullScreen,
                Layer,
                TestSpace2,
                TestByte,
                TestByteArray,
                TestIntTwoArray,
                TestStringTwoArray
            );
        }

        public static void Serialize(t_ui value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// WinName
			stringBuffer.Serialize(value.WinName, steam);

			// ResPath
			stringBuffer.Serialize(value.ResPath, steam);

			// TestSpace1
			stringBuffer.Serialize(value.TestSpace1, steam);

			// IsFullScreen
			boolBuffer.Serialize(value.IsFullScreen, steam);

			// Layer
			intBuffer.Serialize(value.Layer, steam);

			// TestSpace2
			stringBuffer.Serialize(value.TestSpace2, steam);

			// TestByte
			byteBuffer.Serialize(value.TestByte, steam);

			// TestByteArray
            int TestByteArrayLength = value.TestByteArray != null ? value.TestByteArray.Length : 0;
            intBuffer.Serialize(TestByteArrayLength, steam);
            if(TestByteArrayLength != 0)
            {
                for (int i = 0; i < TestByteArrayLength; i++)
                {
                    byteBuffer.Serialize(value.TestByteArray[i], steam);
                }
            }

			// TestIntTwoArray
            int TestIntTwoArrayTwoLength = value.TestIntTwoArray != null ? value.TestIntTwoArray.Length : 0;
            intBuffer.Serialize(TestIntTwoArrayTwoLength, steam);
            for (int i = 0; i < TestIntTwoArrayTwoLength; i++)
            {
                int TestIntTwoArrayOneLength = value.TestIntTwoArray[i] != null ? value.TestIntTwoArray[i].Length : 0;
                intBuffer.Serialize(TestIntTwoArrayOneLength, steam);
                for(int j = 0; j < TestIntTwoArrayOneLength; j++)
                {
                    intBuffer.Serialize(value.TestIntTwoArray[i][j], steam);
                }
            }

			// TestStringTwoArray
            int TestStringTwoArrayTwoLength = value.TestStringTwoArray != null ? value.TestStringTwoArray.Length : 0;
            intBuffer.Serialize(TestStringTwoArrayTwoLength, steam);
            for (int i = 0; i < TestStringTwoArrayTwoLength; i++)
            {
                int TestStringTwoArrayOneLength = value.TestStringTwoArray[i] != null ? value.TestStringTwoArray[i].Length : 0;
                intBuffer.Serialize(TestStringTwoArrayOneLength, steam);
                for(int j = 0; j < TestStringTwoArrayOneLength; j++)
                {
                    stringBuffer.Serialize(value.TestStringTwoArray[i][j], steam);
                }
            }
        }
    }
}
