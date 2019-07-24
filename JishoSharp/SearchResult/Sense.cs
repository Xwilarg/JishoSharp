using Newtonsoft.Json;

namespace JishoSharp.SearchResult
{
    public struct Sense
    {
        /// <summary>
        /// English definition of the word
        /// </summary>
        [JsonProperty("english_definitions")]
        public string[] englishDefinitions;

        /// <summary>
        /// Part of speech the word belong to (noun, verb, etc...)
        /// </summary>
        [JsonProperty("parts_of_speech")]
        public string[] partsOfSpeech;

        /// <summary>
        /// More information about the word
        /// </summary>
        public Link[] links;

        /// <summary>
        /// Tags giving additional information about the word
        /// </summary>
        public string[] tags;
        public string[] restrictions;

        /// <summary>
        /// Other way to write the word
        /// </summary>
        [JsonProperty("see_also")]
        public string[] seeAlso;

        /// <summary>
        /// Antonym (word meaning the contrary)
        /// </summary>
        public string[] antonyms;

        /// <summary>
        /// Origin of the word
        /// </summary>
        public Source[] source;

        /// <summary>
        /// Additional information
        /// </summary>
        public string[] info;
    }
}
