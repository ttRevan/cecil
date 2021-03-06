using System;

using SquabPie.Mono.Cecil;

using NUnit.Framework;

namespace SquabPie.Mono.Cecil.Tests {

	[TestFixture]
	public class AssemblyTests : BaseTestFixture {

		[Test]
		public void Name ()
		{
			TestModule ("hello.exe", module => {
				var name = module.Assembly.Name;

				Assert.IsNotNull (name);

				Assert.AreEqual ("hello", name.Name);
				Assert.AreEqual ("", name.Culture);
				Assert.AreEqual (new Version (0, 0, 0, 0), name.Version);
				Assert.AreEqual (AssemblyHashAlgorithm.SHA1, name.HashAlgorithm);
			});
		}

		[Test]
		public void ParseLowerCaseNameParts ()
		{
			var name = AssemblyNameReference.Parse ("Foo, version=2.0.0.0, culture=fr-FR");
			Assert.AreEqual ("Foo", name.Name);
			Assert.AreEqual (2, name.Version.Major);
			Assert.AreEqual (0, name.Version.Minor);
			Assert.AreEqual ("fr-FR", name.Culture);
		}

		[Test]
		public void ZeroVersion ()
		{
			var name = new AssemblyNameReference ("Foo", null);
			Assert.AreEqual ("0.0.0.0", name.Version.ToString (fieldCount: 4));
			Assert.AreEqual ("Foo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", name.FullName);

			name = new AssemblyNameReference ("Foo", new Version (0, 0, 0, 0));
			Assert.AreEqual ("0.0.0.0", name.Version.ToString (fieldCount: 4));
			Assert.AreEqual ("Foo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", name.FullName);
		}

		[Test]
		public void NoBuildOrMajor ()
		{
			var name = new AssemblyNameReference ("Foo", new Version (0, 0));
			Assert.AreEqual ("Foo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", name.FullName);

			name = new AssemblyNameReference ("Foo", new Version (0, 0, 0));
			Assert.AreEqual ("Foo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", name.FullName);
		}
	}
}
