using AktiehandelRepositoryLib;

namespace TestAktieHandelRepositoryLib
{
	[TestClass]
	public class TestAktieHandel
	{
		[TestMethod]
		public void TestAktieHandelConstructor()
		{
			AktieHandel ah = new AktieHandel(1, "Novo", 10, 250.25);

			Assert.IsInstanceOfType<AktieHandel>(ah);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestNullNavn()
		{
			AktieHandel ah = new AktieHandel(1, null, 10, 100);

			Assert.Fail();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestNavnLessThanFour()
		{
			AktieHandel ah = new AktieHandel(1, "Ni", 10, 100);

			Assert.Fail();
		}
	}
}