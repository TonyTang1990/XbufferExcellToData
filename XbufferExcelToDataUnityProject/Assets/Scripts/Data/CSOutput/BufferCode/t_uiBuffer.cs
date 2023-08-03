namespace xbuffer
{
    public static class t_uiBuffer
    {
        public static t_ui Deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// WinName
			string _WinName = stringBuffer.deserialize(buffer, ref offset);

			// ResPath
			string _ResPath = stringBuffer.deserialize(buffer, ref offset);

			// TestSpace1
			string _TestSpace1 = stringBuffer.deserialize(buffer, ref offset);

			// IsFullScreen
			bool _IsFullScreen = boolBuffer.deserialize(buffer, ref offset);

			// Layer
			int _Layer = intBuffer.deserialize(buffer, ref offset);

			// TestSpace2
			string _TestSpace2 = stringBuffer.deserialize(buffer, ref offset);

			// TestByte
			byte _TestByte = byteBuffer.deserialize(buffer, ref offset);

			// TestByteArray
			int _TestByteArray_length = intBuffer.deserialize(buffer, ref offset);
            byte[] _TestByteArray = new byte[_TestByteArray_length];
            for (int i = 0; i < _TestByteArray_length; i++)
            {
                _TestByteArray[i] = byteBuffer.deserialize(buffer, ref offset);
            }

			// TestIntTwoArray
            int _TestIntTwoArray_two_length = intBuffer.deserialize(buffer, ref offset);
            int[][] _TestIntTwoArray = new int[_TestIntTwoArray_two_length][];
            for (int i = 0; i < _TestIntTwoArray_two_length; i++)
            {
                int _TestIntTwoArray_one_length = intBuffer.deserialize(buffer, ref offset);
                _TestIntTwoArray[i] = new int[_TestIntTwoArray_one_length];
                for(int j = 0; j < _TestIntTwoArray_one_length; j++)
                {
                    _TestIntTwoArray[i][j] = intBuffer.deserialize(buffer, ref offset);
                }
            }

			// TestStringTwoArray
            int _TestStringTwoArray_two_length = intBuffer.deserialize(buffer, ref offset);
            string[][] _TestStringTwoArray = new string[_TestStringTwoArray_two_length][];
            for (int i = 0; i < _TestStringTwoArray_two_length; i++)
            {
                int _TestStringTwoArray_one_length = intBuffer.deserialize(buffer, ref offset);
                _TestStringTwoArray[i] = new string[_TestStringTwoArray_one_length];
                for(int j = 0; j < _TestStringTwoArray_one_length; j++)
                {
                    _TestStringTwoArray[i][j] = stringBuffer.deserialize(buffer, ref offset);
                }
            }

			// value
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
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// WinName
			stringBuffer.serialize(value.WinName, steam);

			// ResPath
			stringBuffer.serialize(value.ResPath, steam);

			// TestSpace1
			stringBuffer.serialize(value.TestSpace1, steam);

			// IsFullScreen
			boolBuffer.serialize(value.IsFullScreen, steam);

			// Layer
			intBuffer.serialize(value.Layer, steam);

			// TestSpace2
			stringBuffer.serialize(value.TestSpace2, steam);

			// TestByte
			byteBuffer.serialize(value.TestByte, steam);

			// TestByteArray
            intBuffer.serialize(value.TestByteArray.Length, steam);
            for (int i = 0; i < value.TestByteArray.Length; i++)
            {
                byteBuffer.serialize(value.TestByteArray[i], steam);
            }

			// TestIntTwoArray
            int _TestIntTwoArray_two_length = value.TestIntTwoArray.Length;
            intBuffer.serialize(_TestIntTwoArray_two_length, steam);
            for (int i = 0; i < _TestIntTwoArray_two_length; i++)
            {
                int _TestIntTwoArray_one_length = value.TestIntTwoArray[i].Length;
                intBuffer.serialize(_TestIntTwoArray_one_length, steam);
                for(int j = 0; j < _TestIntTwoArray_one_length; j++)
                {
                    intBuffer.serialize(value.TestIntTwoArray[i][j], steam);
                }
            }

			// TestStringTwoArray
            int _TestStringTwoArray_two_length = value.TestStringTwoArray.Length;
            intBuffer.serialize(_TestStringTwoArray_two_length, steam);
            for (int i = 0; i < _TestStringTwoArray_two_length; i++)
            {
                int _TestStringTwoArray_one_length = value.TestStringTwoArray[i].Length;
                intBuffer.serialize(_TestStringTwoArray_one_length, steam);
                for(int j = 0; j < _TestStringTwoArray_one_length; j++)
                {
                    stringBuffer.serialize(value.TestStringTwoArray[i][j], steam);
                }
            }
        }
    }
}
