using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using System.Collections.Generic;

using Kutility.GoogleSheetsToUnity.Public.CellJSON;

using Newtonsoft.Json;

/**
  * @file DataRquester.cs
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
namespace Kutility.GoogleSheetsToUnity.Public
{
    /// <summary>
    /// Google Sheets to Unity data requester.
    /// </summary>
    public class DataRequester
    {
        #region CONSTANTS
        /// <summary>
        ///  Standard URI format for converting the result to a JSON.
        /// </summary>
        private const string TO_JSON = "?alt=json";
        #endregion

        #region OUTPUTS
        //Cell Output
        /// <summary>
        /// The <see cref="Root"/> from the cell JSON.
        /// </summary>
        public Root root = null;
        //Cell output root contents
        /// <summary>
        /// The <see cref="Content"/> inside the <see cref="Entry"/> from the cell JSON.
        /// </summary>
        public Content content = null;
        /// <summary>
        /// The <see cref="Updated"/> inside the <see cref="Entry"/> from the cell JSON.
        /// </summary>
        public Updated updated = null;
        /// <summary>
        /// The <see cref="Id"/> inside the <see cref="Entry"/> from the cell JSON.
        /// </summary>
        public Id id = null;
        /// <summary>
        /// The <see cref="List{T}"/> of <see cref="Category"/> inside the <see cref="Entry"/> from the cell JSON.
        /// </summary>
        public List<Category> category = new List<Category>();
        /// <summary>
        /// The <see cref="Title"/> inside the <see cref="Root"/> from the cell JSON.
        /// </summary>
        public Title title = null;
        /// <summary>
        /// The <see cref="List{T}"/> of <see cref="Link"/> inside the <see cref="Entry"/> from the cell JSON.
        /// </summary>
        public List<Link> link = new List<Link>();
        /// <summary>
        /// The <see cref="Entry"/> inside the <see cref="Root"/> from the cell JSON.
        /// </summary>
        public Entry entry = null;
        #endregion

        #region PRIVATE DECLARATION
        /// <summary>
        /// Reusable <see cref="Root"/>.
        /// </summary>
        private protected Root myDeserializedClass = null;
        /// <summary>
        /// Reusable <see cref="UnityWebRequest"/>.
        /// </summary>
        private protected UnityWebRequest request = null;
        #endregion

        /// <summary>
        /// Request cell data from a given Google Sheet and cell ID.
        /// </summary>
        /// <param name="sheetID">The id of the sheet can be obtained using the link of the sheet ["https://docs.google.com/spreadsheets/d/[sheetID]/"].</param>
        /// <param name="cellID">The cell ID must be passed into this parameter in format "R"+"Y Axys"+"C"+"X Axys", also the X Axys must be a number not a letter.</param>
        /// <returns></returns>
        public IEnumerator RequestCellData(string sheetID, string cellID)
        {
            request = UnityWebRequest.Get("https://spreadsheets.google.com/feeds/cells/" + sheetID + "/od6/public/basic/" + cellID + TO_JSON);
            yield return request.SendWebRequest();

            //Check if there is some kind of network error.
            if (request.isNetworkError)
            {
                //Print on console the type of error for debbuggin purposes.
                Debug.Log(request.error);

                //Return null parameters.
                yield return content = null;
                yield return updated = null;
                yield return id = null;
                yield return category = null;
                yield return title = null;
                yield return link = null;
                yield return entry = null;
                yield return root = null;
            }
            //If there is no error continue.
            else
            {
                // Show results as text.
                string tempJSON = request.downloadHandler.text;

                //Erase the reference to request.
                request = null;

                //Check if the obtained string is valid.
                if (tempJSON != null && tempJSON != "")
                {
                    //Deserialize JSON
                    myDeserializedClass = JsonConvert.DeserializeObject<Root>(tempJSON);

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

                        //Erase the reference to myDeserializedClass.
                        myDeserializedClass = null;
                    }
                    //Return null parameters if the deserialized object is null.
                    else
                    {
                        yield return content = null;
                        yield return updated = null;
                        yield return id = null;
                        yield return category = null;
                        yield return title = null;
                        yield return link = null;
                        yield return entry = null;
                        yield return root = null;

                        //Erase the reference to myDeserializedClass.
                        myDeserializedClass = null;
                    }
                } 
            }
        }
    }
}



