using System.Threading.Tasks;
using Xunit;

namespace JishoSharp.UnitTests
{
    public class Program
    {
        [Theory]
        [InlineData("pettanko", null, "ぺちゃんこ", "crushed flat", "Na-adjective")]
        [InlineData("原発性免疫不全症", "原発性免疫不全症", "げんぱつせいめんえきふぜんしょう", "primary immunodeficiency syndrome", "Noun")]
        [InlineData("にく", "肉", "にく", "flesh", "Noun")]
        public async Task EmptyTest(string searchQuery, string firstWord, string firstReading, string firstEnglishDefinition, string firstPartOfSpeech)
        {
            var search = await SearchClient.SearchWordAsync(searchQuery);
            Assert.NotEmpty(search);
            Assert.NotEmpty(search[0].japanese);
            Assert.NotEmpty(search[0].senses);
            Assert.NotEmpty(search[0].senses[0].englishDefinitions);
            Assert.NotEmpty(search[0].senses[0].partsOfSpeech);
            Assert.Equal(firstWord, search[0].japanese[0].word);
            Assert.Equal(firstReading, search[0].japanese[0].reading);
            Assert.Equal(firstEnglishDefinition, search[0].senses[0].englishDefinitions[0]);
            Assert.Equal(firstPartOfSpeech, search[0].senses[0].partsOfSpeech[0]);
        }
    }
}
