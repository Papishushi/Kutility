using UnityEngine;

/**
  * @file DataReciever.cs
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
    public abstract class DataReciever<T> : MonoBehaviour
    {

        // DONT MODIFY 
        //These two constants are the standard format in wich Google Sheet API manages cell IDs through HTTP.
        public const string Y_STRING = "R";
        public const string X_STRING = "C";

        //This constant is used as a reference time for request update. Modify this value to change the frequency of updates.
        public const float CHECK_FOR_UPDATES_TIME = 5f;

        #region PRIVATE DECLARATION
        private static readonly DataRequester CellInfoReq = new DataRequester();

        private static SheetCellController CellInfoSCtrl = null;

        private static float Refresher;
        #endregion


        #region PUBLIC PARAMETERS
        public static OutputType TypeOfOutput;

        public static string SheetID;

        public static int Y;
        public static XAxysSheetConverter X;

        public static object Output;
        #endregion


        /// <summary>
        /// Default <typeparamref name="T"/> implementation for Start().
        /// </summary>
        public virtual void Start()
        {
            //Request cell data
            StartCoroutine(CellInfoReq.RequestCellData(SheetID, Y_STRING + Y + X_STRING + (int)X));

            //Initialize the sheet controller with its associated request.
            CellInfoSCtrl = new SheetCellController(CellInfoReq);
        }

        /// <summary>
        /// Default <typeparamref name="T"/> implementation for Update() loop.
        /// </summary>
        public virtual void Update()
        {
            //Add delta time to the chronometer.
            Refresher += Time.deltaTime;

            //Refresh this code every CHECK_FOR_UPDATES_TIME seconds.
            if (Refresher >= CHECK_FOR_UPDATES_TIME)
            {

                //Request cell data
                StartCoroutine(CellInfoReq.RequestCellData(SheetID, Y_STRING + Y + X_STRING + (int)X));

                //Switch which type of output user want to retrieve.
                switch (TypeOfOutput)
                {
                    case OutputType.raw:
                        //Get the default cell data and assign it to output.
                        Output = CellInfoSCtrl.GetCellContentRaw();
                        break;
                    case OutputType.double_float:
                        //Get a double type cell data and assign it to output.
                        Output = CellInfoSCtrl.GetCellContentDouble();
                        break;
                    case OutputType.floating_point:
                        //Get a float type cell data and assign it to output.
                        Output = CellInfoSCtrl.GetCellContentFloat();
                        break;
                    case OutputType.integeer:
                        //Get a int type cell data and assign it to output.
                        Output = CellInfoSCtrl.GetCellContentInt();
                        break;
                    case OutputType.date_time:
                        //Get the System.DateTime in wich the response was sent and assign it to output.
                        Output = CellInfoSCtrl.GetDataTime();
                        break;
                }

                //Reset refresher.
                Refresher = 0;
            }
        }
    }
}


