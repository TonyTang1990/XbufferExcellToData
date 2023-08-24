namespace xbuffer
{
    public static class t_uiBuffer
    {
        public static t_ui Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool _null = boolBuffer.Deserialize(buffer, ref offset);
            if (_null) return null;

			// WinName
			string _WinName = stringBuffer.Deserialize(buffer, ref offset);

			// ResPath
			string _ResPath = stringBuffer.Deserialize(buffer, ref offset);

			// TestSpace1
			string _TestSpace1 = stringBuffer.Deserialize(buffer, ref offset);

			// IsFullScreen
			bool _IsFullScreen = boolBuffer.Deserialize(buffer, ref offset);

			// Layer
			int _Layer = intBuffer.Deserialize(buffer, ref offset);

			// TestSpace2
			string _TestSpace2 = stringBuffer.Deserialize(buffer, ref offset);

			// TestByte
			byte _TestByte = byteBuffer.Deserialize(buffer, ref offset);

			// TestByteArray
			int _TestByteArray_length = intBuffer.Deserialize(buffer, ref offset);
            byte[] _TestByteArray = new byte[_TestByteArray_length];
            for (int i = 0; i < _TestByteArray_length; i++)
            {
                _TestByteArray[i] = byteBuffer.Deserialize(buffer, ref offset);
            }

			// TestIntTwoArray
            int _TestIntTwoArray_two_length = intBuffer.Deserialize(buffer, ref offset);
            int[][] _TestIntTwoArray = new int[_TestIntTwoArray_two_length][];
            for (int i = 0; i < _TestIntTwoArray_two_length; i++)
            {
                int _TestIntTwoArray_one_length = intBuffer.Deserialize(buffer, ref offset);
                _TestIntTwoArray[i] = new int[_TestIntTwoArray_one_length];
                for(int j = 0; j < _TestIntTwoArray_one_length; j++)
                {
                    _TestIntTwoArray[i][j] = intBuffer.Deserialize(buffer, ref offset);
                }
            }

			// TestStringTwoArray
            int _TestStringTwoArray_two_length = intBuffer.Deserialize(buffer, ref offset);
            string[][] _TestStringTwoArray = new string[_TestStringTwoArray_two_length][];
            for (int i = 0; i < _TestStringTwoArray_two_length; i++)
            {
                int _TestStringTwoArray_one_length = intBuffer.Deserialize(buffer, ref offset);
                _TestStringTwoArray[i] = new string[_TestStringTwoArray_one_length];
                for(int j = 0; j < _TestStringTwoArray_one_length; j++)
                {
                    _TestStringTwoArray[i][j] = stringBuffer.Deserialize(buffer, ref offset);
                }
            }

			return new t_ui(
                _WinName,
                _ResPath,
                _TestSpace1,
                _IsFullScreen,
                _Layer,
                _TestSpace2,
                _TestByte,
                _TestByteArray,
                _TestIntTwoArray,
                _TestStringTwoArray
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
            intBuffer.Serialize(value.TestByteArray.Length, steam);
            for (int i = 0; i < value.TestByteArray.Length; i++)
            {
                byteBuffer.Serialize(value.TestByteArray[i], steam);
            }

			// TestIntTwoArray
            int _TestIntTwoArray_two_length = value.TestIntTwoArray.Length;
            intBuffer.Serialize(_TestIntTwoArray_two_length, steam);
            for (int i = 0; i < _TestIntTwoArray_two_length; i++)
            {
                int _TestIntTwoArray_one_length = value.TestIntTwoArray[i].Length;
                intBuffer.Serialize(_TestIntTwoArray_one_length, steam);
                for(int j = 0; j < _TestIntTwoArray_one_length; j++)
                {
                    intBuffer.Serialize(value.TestIntTwoArray[i][j], steam);
                }
            }

			// TestStringTwoArray
            int _TestStringTwoArray_two_length = value.TestStringTwoArray.Length;
            intBuffer.Serialize(_TestStringTwoArray_two_length, steam);
            for (int i = 0; i < _TestStringTwoArray_two_length; i++)
            {
                int _TestStringTwoArray_one_length = value.TestStringTwoArray[i].Length;
                intBuffer.Serialize(_TestStringTwoArray_one_length, steam);
                for(int j = 0; j < _TestStringTwoArray_one_length; j++)
                {
                    stringBuffer.Serialize(value.TestStringTwoArray[i][j], steam);
                }
            }
        }
    }
}
