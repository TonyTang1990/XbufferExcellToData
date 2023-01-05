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

			// value
			return new t_ui() {
				WinName = _WinName,
				ResPath = _ResPath,
				TestSpace1 = _TestSpace1,
				IsFullScreen = _IsFullScreen,
				Layer = _Layer,
				TestSpace2 = _TestSpace2,
            };
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
        }
    }
}