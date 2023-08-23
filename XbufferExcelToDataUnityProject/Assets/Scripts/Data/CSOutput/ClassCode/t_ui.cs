// 
public class t_ui
{
	public readonly string WinName;				// 窗口名
	public readonly string ResPath;				// 资源路径
	public readonly string TestSpace1;				// 测试空格 描述支持1
	public readonly bool IsFullScreen;				// 是否全屏
	public readonly int Layer;				// UI层级Layer
	public readonly string TestSpace2;				// 测试空格 描述支持2
	public readonly byte TestByte;				// 测试Byte数据类型
	public readonly byte[] TestByteArray;				// 测试Byte数组
	public readonly int[][] TestIntTwoArray;			// 测试整形二维数组
	public readonly string[][] TestStringTwoArray;			// 测试字符串二维数组

	public t_ui(
		string WinName,
		string ResPath,
		string TestSpace1,
		bool IsFullScreen,
		int Layer,
		string TestSpace2,
		byte TestByte,
		byte[] TestByteArray,
		int[][] TestIntTwoArray,
		string[][] TestStringTwoArray
	)
	{
		this.WinName = WinName;
		this.ResPath = ResPath;
		this.TestSpace1 = TestSpace1;
		this.IsFullScreen = IsFullScreen;
		this.Layer = Layer;
		this.TestSpace2 = TestSpace2;
		this.TestByte = TestByte;
		this.TestByteArray = TestByteArray;
		this.TestIntTwoArray = TestIntTwoArray;
		this.TestStringTwoArray = TestStringTwoArray;
	}
}