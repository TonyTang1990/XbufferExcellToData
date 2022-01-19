namespace xbuffer
{
    public static class t_uiBuffer
    {
        public static t_ui deserialize(byte[] buffer, ref uint offset)
        {

            // null
            bool _null = boolBuffer.deserialize(buffer, ref offset);
            if (_null) return null;

			// Id
			string _Id = stringBuffer.deserialize(buffer, ref offset);

			// resPath
			string _resPath = stringBuffer.deserialize(buffer, ref offset);

			// isFullScreen
			bool _isFullScreen = boolBuffer.deserialize(buffer, ref offset);

			// Layer
			int _Layer = intBuffer.deserialize(buffer, ref offset);

			// value
			return new t_ui() {
				Id = _Id,
				resPath = _resPath,
				isFullScreen = _isFullScreen,
				Layer = _Layer,
            };
        }

        public static void serialize(t_ui value, XSteam steam)
        {

            // null
            boolBuffer.serialize(value == null, steam);
            if (value == null) return;

			// Id
			stringBuffer.serialize(value.Id, steam);

			// resPath
			stringBuffer.serialize(value.resPath, steam);

			// isFullScreen
			boolBuffer.serialize(value.isFullScreen, steam);

			// Layer
			intBuffer.serialize(value.Layer, steam);
        }
    }
}
