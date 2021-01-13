using System;
using System.Collections.Generic;

using Newtonsoft.Json;

/**
  * @file SheetJSON.cs
  * @author Daniel Molinero @papishushi
  * @version 1.0.0
  * @section Copyright © <2021+> <Daniel Molinero>
  * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
  * to deal in the Software without restriction, including without limitation the rights to use, copy,
  * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
  * and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
  *
  * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
  *
  * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
  * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
  **/

/// <summary> |READ THIS BEFORE USE|
/// To use this script first of all you must set your google sheet to public on the web.
/// While this sheet is in this mode it cannot be overwriten but can be read by http calls.
/// To public the sheet on the web use ["Document" > "Publish to the web"] and set the parameters to "complete document as a web page".
/// </summary>
namespace Kutility.GoogleSheetsToUnity.Public.SheetJSON
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
        public string scheme { get; set; }
        public string term { get; set; }
    }

    public class Title
    {
        public string type { get; set; }
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Name
    {
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Email
    {
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Author
    {
        public Name name { get; set; }
        public Email email { get; set; }
    }

    public class OpenSearchTotalResults
    {
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class OpenSearchStartIndex
    {
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        [JsonProperty("$t")]
        public string T { get; set; }
    }

    public class Entry
    {
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public Content content { get; set; }
        public List<Link> link { get; set; }
    }

    public class Feed
    {
        public string xmlns { get; set; }
        [JsonProperty("xmlns$openSearch")]
        public string XmlnsOpenSearch { get; set; }
        [JsonProperty("xmlns$batch")]
        public string XmlnsBatch { get; set; }
        [JsonProperty("xmlns$gs")]
        public string XmlnsGs { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        [JsonProperty("openSearch$totalResults")]
        public OpenSearchTotalResults OpenSearchTotalResults { get; set; }
        [JsonProperty("openSearch$startIndex")]
        public OpenSearchStartIndex OpenSearchStartIndex { get; set; }
        public List<Entry> entry { get; set; }
    }

    public class Root
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Feed feed { get; set; }
    }
}
