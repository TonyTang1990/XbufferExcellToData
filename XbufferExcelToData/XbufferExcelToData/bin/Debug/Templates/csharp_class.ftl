// #CLASS_COMMENT#
public partial #CLASS_TYPE# #CLASS_NAME#
{
#VARIABLES#
#IF_SINGLE#
	public readonly #VAR_TYPE# #VAR_NAME#;				// #VAR_COMMENT#
#END_SINGLE#
#IF_ARRAY#
	public readonly #VAR_TYPE#[] #VAR_NAME#;				// #VAR_COMMENT#
#END_ARRAY#
#IF_TWO_ARRAY#
	public readonly #VAR_TYPE#[][] #VAR_NAME#;			// #VAR_COMMENT#
#END_TWO_ARRAY#
#VARIABLES#
}