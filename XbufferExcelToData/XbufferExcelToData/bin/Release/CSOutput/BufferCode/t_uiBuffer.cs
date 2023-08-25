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

			// IsFullScreen
			bool IsFullScreen = boolBuffer.Deserialize(buffer, ref offset);

			// Layer
			int Layer = intBuffer.Deserialize(buffer, ref offset);

			return new t_ui(
                WinName,
                ResPath,
                IsFullScreen,
                Layer
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
