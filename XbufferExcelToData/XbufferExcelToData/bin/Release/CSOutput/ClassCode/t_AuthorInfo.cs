// 
public class t_AuthorInfo
{
	public readonly int Id;				// 唯一id
	public readonly string author;				// 作者
	public readonly int age;				// 年龄
	public readonly float money;				// 拥有金钱
	public readonly bool hashouse;				// 拥有房子
	public readonly long pbutctime;				// 出版utc时间
	public readonly int[] luckynumber;				// 幸运数字
	public readonly byte weekday;				// 星期几
	public readonly t_AuthorInfo_testclass testclass;				// 测试嵌套类型
	public readonly t_AuthorInfo_testclassarray[] testclassarray;				// 测试嵌套类型数组
	public readonly t_AuthorInfo_testclasstwoarray[][] testclasstwoarray;			// 测试嵌套类型二维数组

	public t_AuthorInfo(
		int Id,
		string author,
		int age,
		float money,
		bool hashouse,
		long pbutctime,
		int[] luckynumber,
		byte weekday,
		t_AuthorInfo_testclass testclass,
		t_AuthorInfo_testclassarray[] testclassarray,
		t_AuthorInfo_testclasstwoarray[][] testclasstwoarray
	)
	{
		this.Id = Id;
		this.author = author;
		this.age = age;
		this.money = money;
		this.hashouse = hashouse;
		this.pbutctime = pbutctime;
		this.luckynumber = luckynumber;
		this.weekday = weekday;
		this.testclass = testclass;
		this.testclassarray = testclassarray;
		this.testclasstwoarray = testclasstwoarray;
	}
}