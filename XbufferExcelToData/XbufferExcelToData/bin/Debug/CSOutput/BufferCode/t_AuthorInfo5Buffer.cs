namespace xbuffer
{
    public static class t_AuthorInfo5Buffer
    {
        public static t_AuthorInfo5 Deserialize(byte[] buffer, ref uint offset)
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

			return new t_AuthorInfo5(
                Id,
                author,
                age,
                money,
                hashouse,
                pbutctime,
                luckynumber
            );
        }

        public static void Serialize(t_AuthorInfo5 value, XSteam steam)
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
        }
    }
}
