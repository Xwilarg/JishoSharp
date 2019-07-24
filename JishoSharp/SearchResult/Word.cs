using Newtonsoft.Json;

namespace JishoSharp.SearchResult
{
    public struct Word
    {
        public string       slug;
        [JsonProperty("is_common")]
        public bool         isCommon;
        public string[]     tags;

        /// <summary>
        /// Japanese-Language Proficiency Test
        /// </summary>
        public string[]     jlpt;

        /// <summary>
        /// Japanese reading
        /// </summary>
        public Japanese[]   japanese;

        /// <summary>
        /// Meanings of the word
        /// </summary>
        public Sense[]     senses;

        public Attribution attribution;
    }
}
