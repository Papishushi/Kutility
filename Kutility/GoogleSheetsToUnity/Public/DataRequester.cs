using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using System.Collections.Generic;

using Kutility.GoogleSheetsToUnity.Public.CellJSON;

using Newtonsoft.Json;

namespace Kutility.GoogleSheetsToUnity.Public
{
    public class DataRequester
    {
        //Standard URI format for converting the result to a JSON.
        private const string TO_JSON = "?alt=json";

        //Cell Output
        public Root root = null;
        //Cell output root contents
        public Content content = null;
        public Updated updated = null;
        public Id id = null;
        public List<Category> category = new List<Category>();
        public Title title = null;
        public List<Link> link = new List<Link>();
        public Entry entry = null;
       

        public IEnumerator RequestCellData(string sheetID, string cellID)
        {
            UnityWebRequest request = UnityWebRequest.Get("https://spreadsheets.google.com/feeds/cells/" + sheetID + "/od6/public/basic/" + cellID + TO_JSON);
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);

                yield return content = null;
            }
            else
            {
                // Show results as text
                string tempJSON = request.downloadHandler.text;

                //Deserialize JSON
                if (tempJSON != null && tempJSON != "")
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(tempJSON);
                    //Return content
                    if (myDeserializedClass != null)
                    {
                        yield return content = myDeserializedClass.Entry.Content;
                        yield return updated = myDeserializedClass.Entry.Updated;
                        yield return id = myDeserializedClass.Entry.Id;
                        yield return category = myDeserializedClass.Entry.Category;
                        yield return title = myDeserializedClass.Entry.Title;
                        yield return link = myDeserializedClass.Entry.Link;
                        yield return entry = myDeserializedClass.Entry;
                        yield return root = myDeserializedClass;
                    }
                } 
            }
        }
    }
}



