using FluentAssertions;
using NUnit.Framework;

namespace UnitTests
{
	public class Class1
	{
		[Test]
		public void Test()
		{
			true.Should().BeTrue();
		}
	}
}