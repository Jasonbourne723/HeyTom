namespace HeyTom.Infra.Util
{
	public class TResultModel<T> : ResultModel
	{
	
		public TResultModel(int resultNo, string message) : base(resultNo, message)
		{
		}
		public TResultModel(int resultNo) : base(resultNo)
		{

		}

		public T TModel { get; set; }

	}
}
