using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/**
  * @file CellJSON.cs
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
/// To use this script, first of all, you must set your google sheet to public on the web.
/// While this sheet is in this mode it cannot be overwriten but can be read by HTTP calls.
/// To public the sheet on the web use ["Document" > "Publish to the web"] and set the parameters to "complete document as a web page".
/// </summary>
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