namespace HeyTom.Infra.Util
{
	public class FilterModel
	{
		public string Field { get; set; }
		public string DbField { get; set; }
		public string Value { get; set; }
		public string Operator { get; set; }
		public string Connector { get; set; }
	}
}
