using System;
using Castle.DynamicProxy;

namespace HeyTom.Infra.AOP
{
	public class Class1 : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			throw new NotImplementedException();
		}
	}
}
