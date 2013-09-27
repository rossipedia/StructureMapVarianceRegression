using NUnit.Framework;
using StructureMap;
using Types;

namespace NotWorking
{
    public class Tests
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void Init()
        {
            ObjectFactory.Initialize(i => i.Scan(s =>
            {
                s.AssemblyContainingType<Base>();
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AddAllTypesOf(typeof (ISomeInterface<>));
            }));

            _container = ObjectFactory.Container;
        }

        [Test]
        public void TestOpenGenericVariance()
        {
            var instance = _container.GetInstance<ISomeInterface<Derived>>();
            Assert.NotNull(instance);
        }
    }
}