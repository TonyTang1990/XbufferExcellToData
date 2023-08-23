// 
public #CLASS_TYPE# t_Global6
{
	public readonly int Id;				// 唯一id
	public readonly string stringvalue;				// 字符串数据
	public readonly int intvalue;				// 整形数据
	public readonly float floatvalue;				// 浮点数数据
	public readonly int[] intarrayvalue;				// 整形数组数据
	public readonly string[] stringarrayvalue;				// 字符串数组数据

	public t_Global6(
		int Id,
		string stringvalue,
		int intvalue,
		float floatvalue,
		int[] intarrayvalue,
		string[] stringarrayvalue
	)
	{
		this.Id = Id;
		this.stringvalue = stringvalue;
		this.intvalue = intvalue;
		this.floatvalue = floatvalue;
		this.intarrayvalue = intarrayvalue;
		this.stringarrayvalue = stringarrayvalue;
	}
}