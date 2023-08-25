namespace xbuffer
{
    public static class #CLASS_NAME#Buffer
    {
        public static #CLASS_NAME# Deserialize(byte[] buffer, ref uint offset)
        {
#IF_DESERIALIZE_CLASS#
            // 是否为空数据
            bool isNull = boolBuffer.Deserialize(buffer, ref offset);
            if (isNull) return null;
#END_DESERIALIZE_CLASS#
#DESERIALIZE_PROCESS#
			// #VAR_NAME#
#IF_SINGLE#
			#VAR_TYPE# #VAR_NAME# = #VAR_TYPE#Buffer.Deserialize(buffer, ref offset);
#END_SINGLE#
#IF_ARRAY#
			int #VAR_NAME#Length = intBuffer.Deserialize(buffer, ref offset);
            #VAR_TYPE#[] #VAR_NAME# = null;
            if(#VAR_NAME#Length != 0)
            {
                #VAR_NAME# = new #VAR_TYPE#[#VAR_NAME#Length];
                for (int i = 0; i < #VAR_NAME#Length; i++)
                {
                    #VAR_NAME#[i] = #VAR_TYPE#Buffer.Deserialize(buffer, ref offset);
                }            
            }
#END_ARRAY#
#IF_TWO_ARRAY#
            int #VAR_NAME#TwoLength = intBuffer.Deserialize(buffer, ref offset);
            #VAR_TYPE#[][] #VAR_NAME# = null;
            if(#VAR_NAME#TwoLength != 0)
            {
                #VAR_NAME# = new #VAR_TYPE#[#VAR_NAME#TwoLength][];
                for (int i = 0; i < #VAR_NAME#TwoLength; i++)
                {
                    int #VAR_NAME#OneLength = intBuffer.Deserialize(buffer, ref offset);
                    if(#VAR_NAME#OneLength != 0)
                    {
                        #VAR_NAME#[i] = new #VAR_TYPE#[#VAR_NAME#OneLength];
                        for(int j = 0; j < #VAR_NAME#OneLength; j++)
                        {
                            #VAR_NAME#[i][j] = #VAR_TYPE#Buffer.Deserialize(buffer, ref offset);
                        }
                    }
                }
            }
#END_TWO_ARRAY#
#DESERIALIZE_PROCESS#

			return new #CLASS_NAME#(
#DESERIALIZE_RETURN#
                #VAR_NAME##DESERIALIZE_RETURN#
            );
        }

        public static void Serialize(#CLASS_NAME# value, XSteam steam)
        {
#IF_SERIALIZE_CLASS#
            // null
            boolBuffer.Serialize(value == null, steam);
            if (value == null) return;
#END_SERIALIZE_CLASS#
#SERIALIZE_PROCESS#
			// #VAR_NAME#
#IF_SINGLE#
			#VAR_TYPE#Buffer.Serialize(value.#VAR_NAME#, steam);
#END_SINGLE#
#IF_ARRAY#
            int #VAR_NAME#Length = value.#VAR_NAME# != null ? value.#VAR_NAME#.Length : 0;
            intBuffer.Serialize(#VAR_NAME#Length, steam);
            if(#VAR_NAME#Length != 0)
            {
                for (int i = 0; i < #VAR_NAME#Length; i++)
                {
                    #VAR_TYPE#Buffer.Serialize(value.#VAR_NAME#[i], steam);
                }
            }
#END_ARRAY#
#IF_TWO_ARRAY#
            int #VAR_NAME#TwoLength = value.#VAR_NAME# != null ? value.#VAR_NAME#.Length : 0;
            intBuffer.Serialize(#VAR_NAME#TwoLength, steam);
            for (int i = 0; i < #VAR_NAME#TwoLength; i++)
            {
                int #VAR_NAME#OneLength = value.#VAR_NAME#[i] != null ? value.#VAR_NAME#[i].Length : 0;
                intBuffer.Serialize(#VAR_NAME#OneLength, steam);
                for(int j = 0; j < #VAR_NAME#OneLength; j++)
                {
                    #VAR_TYPE#Buffer.Serialize(value.#VAR_NAME#[i][j], steam);
                }
            }
#END_TWO_ARRAY#
#SERIALIZE_PROCESS#
        }
    }
}
