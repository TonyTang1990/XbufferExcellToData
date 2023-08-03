// t_AuthorInfo6的注释
public class t_AuthorInfo6
{
	public readonly int Id;				// 唯一id
	public readonly string author;				// 作者
	public readonly int age;				// 年龄
	public readonly float money;				// 拥有金钱
	public readonly bool hashouse;				// 拥有房子
	public readonly long pbutctime;				// 出版utc时间
	public readonly int[] luckynumber;				// 幸运数字

	public t_AuthorInfo6(
		int Id,
		string author,
		int age,
		float money,
		bool hashouse,
		long pbutctime,
		int[] luckynumber
	)
	{
		this.Id = Id;
		this.author = author;
		this.age = age;
		this.money = money;
		this.hashouse = hashouse;
		this.pbutctime = pbutctime;
		this.luckynumber = luckynumber;
	}
}