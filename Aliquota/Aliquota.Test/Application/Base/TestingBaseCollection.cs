using Xunit;

namespace Aliquota.Test.Application.Base
{
    [CollectionDefinition("CollectionFixture")]
    public class TestingBaseCollection : ICollectionFixture<TestingBaseFixture>
    {

    }
}