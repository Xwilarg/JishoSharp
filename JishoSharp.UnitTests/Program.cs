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
        public async Task SearchWordTest(string searchQuery, string firstWord, string firstReading, string firstEnglishDefinition, string firstPartOfSpeech)
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

        [Fact]
        public async Task SearchWordFullAsync()
        {
            var search = await SearchClient.SearchWordAsync("rori");
            Assert.NotEmpty(search);
            Assert.Equal("ロリ", search[0].slug);
            Assert.False(search[0].isCommon);
            Assert.Empty(search[0].tags);
            Assert.Empty(search[0].jlpt);
            Assert.NotEmpty(search[0].senses);
            Assert.Single(search[0].senses[0].info);
            Assert.Equal("also written 炉裏", search[0].senses[0].info[0]);
            Assert.Empty(search[0].senses[0].links);
            Assert.Equal(2, search[0].senses[0].tags.Length);
            Assert.Equal("Colloquialism", search[0].senses[0].tags[0]);
            Assert.Equal("Abbreviation", search[0].senses[0].tags[1]);
            Assert.Empty(search[0].senses[0].restrictions);
            Assert.Single(search[0].senses[0].seeAlso);
            Assert.Equal("ロリータ", search[0].senses[0].seeAlso[0]);
            Assert.Empty(search[0].senses[0].antonyms);
            Assert.Empty(search[0].senses[0].source);
            Assert.True(search[0].attribution.jmdict);
            Assert.False(search[0].attribution.jmnedict);
            Assert.Null(search[0].attribution.dbpedia);
        }
    }
}
