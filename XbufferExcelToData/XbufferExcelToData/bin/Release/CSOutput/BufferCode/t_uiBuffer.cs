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

			// IsFullScreen
			bool _IsFullScreen = boolBuffer.Deserialize(buffer, ref offset);

			// Layer
			int _Layer = intBuffer.Deserialize(buffer, ref offset);

			return new t_ui(
                _WinName,
                _ResPath,
                _IsFullScreen,
                _Layer
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

			// IsFullScreen
			boolBuffer.Serialize(value.IsFullScreen, steam);

			// Layer
			intBuffer.Serialize(value.Layer, steam);
        }
    }
}
