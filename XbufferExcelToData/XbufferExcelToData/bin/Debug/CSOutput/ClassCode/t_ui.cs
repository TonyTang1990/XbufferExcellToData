// 
public class t_ui
{
	public readonly string WinName;				// 窗口名
	public readonly string ResPath;				// 资源路径
	public readonly bool IsFullScreen;				// 是否全屏
	public readonly int Layer;				// UI层级Layer

	public t_ui(
		string WinName,
		string ResPath,
		bool IsFullScreen,
		int Layer
	)
	{
		this.WinName = WinName;
		this.ResPath = ResPath;
		this.IsFullScreen = IsFullScreen;
		this.Layer = Layer;
	}
}