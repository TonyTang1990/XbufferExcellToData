namespace xbuffer
{
    public static class t_Global8Buffer
    {
        public static t_Global8 Deserialize(byte[] buffer, ref uint offset)
        {

            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;

			// Id
			int Id = intBuffer.Deserialize(buffer, ref offset);

			// stringvalue
			string stringvalue = stringBuffer.Deserialize(buffer, ref offset);

			// intvalue
			int intvalue = intBuffer.Deserialize(buffer, ref offset);

			// floatvalue
			float floatvalue = floatBuffer.Deserialize(buffer, ref offset);

			// intarrayvalue
			int intarrayvalueLength = intBuffer.Deserialize(buffer, ref offset);
            int[] intarrayvalue = null;
            if(intarrayvalueLength != 0)
            {
                intarrayvalue = new int[intarrayvalueLength];
                for (int i = 0; i < intarrayvalueLength; i++)
                {
                    intarrayvalue[i] = intBuffer.Deserialize(buffer, ref offset);
                }            
            }

			// stringarrayvalue
			int stringarrayvalueLength = intBuffer.Deserialize(buffer, ref offset);
            string[] stringarrayvalue = null;
            if(stringarrayvalueLength != 0)
            {
                stringarrayvalue = new string[stringarrayvalueLength];
                for (int i = 0; i < stringarrayvalueLength; i++)
                {
                    stringarrayvalue[i] = stringBuffer.Deserialize(buffer, ref offset);
                }            
            }

			return new t_Global8(
                Id,
                stringvalue,
                intvalue,
                floatvalue,
                intarrayvalue,
                stringarrayvalue
            );
        }

        public static void Serialize(t_Global8 value, XSteam steam)
        {

            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;

			// Id
			intBuffer.Serialize(value.Id, steam);

			// stringvalue
			stringBuffer.Serialize(value.stringvalue, steam);

			// intvalue
			intBuffer.Serialize(value.intvalue, steam);

			// floatvalue
			floatBuffer.Serialize(value.floatvalue, steam);

			// intarrayvalue
            int intarrayvalueLength = value.intarrayvalue != null ? value.intarrayvalue.Length : 0;
            intBuffer.Serialize(intarrayvalueLength, steam);
            if(intarrayvalueLength != 0)
            {
                for (int i = 0; i < intarrayvalueLength; i++)
                {
                    intBuffer.Serialize(value.intarrayvalue[i], steam);
                }
            }

			// stringarrayvalue
            int stringarrayvalueLength = value.stringarrayvalue != null ? value.stringarrayvalue.Length : 0;
            intBuffer.Serialize(stringarrayvalueLength, steam);
            if(stringarrayvalueLength != 0)
            {
                for (int i = 0; i < stringarrayvalueLength; i++)
                {
                    stringBuffer.Serialize(value.stringarrayvalue[i], steam);
                }
            }
        }
    }
}
