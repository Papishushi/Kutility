using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kutility.GoogleSheetsToUnity.Public.CellJSON
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Id
    {
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Updated
    {
        [JsonProperty("$t")]
        public DateTime T { get; set; }
    }

    public class Category
    {
        [JsonProperty("scheme")]
        public string Scheme { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }
    }

    public class Title
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Entry
    {
        [JsonProperty("xmlns")]
        public string Xmlns { get; set; }

        [JsonProperty("xmlns$batch")]
        public string XmlnsBatch { get; set; }

        [JsonProperty("xmlns$gs")]
        public string XmlnsGs { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("updated")]
        public Updated Updated { get; set; }

        [JsonProperty("category")]
        public List<Category> Category { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("link")]
        public List<Link> Link { get; set; }
    }

    public class Root
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("entry")]
        public Entry Entry { get; set; }
    }
}