using System.Globalization;

/**
  * @file SheetCellController.cs
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
    public class SheetCellController
    {
        private readonly protected DataRequester req = null;

        public SheetCellController(DataRequester req)
        {
            this.req = req;
        }

        public System.DateTime GetDataTime()
        {
            if(req != null && req.updated != null && req.updated.T != null)
            {
                return req.updated.T;
            }
            else
            {
                return System.DateTime.Now;
            }

        }
        public string GetCellContentRaw()
        {
            if (req != null && req.content != null)
            {
                return req.content.T;
            }
            else
            {
                return null;
            }
        }
        public double GetCellContentDouble()
        {
            double outContent = 0;
            string temp = GetCellContentRaw();

            if (double.TryParse(temp, out _) && temp != null)
            {
                outContent = double.Parse(temp, CultureInfo.InvariantCulture);
            }

            return outContent;
        }
        public float GetCellContentFloat()
        {
            float outContent = 0;
            string temp = GetCellContentRaw();

            if (float.TryParse(temp, out _) && temp != null)
            {
                outContent = float.Parse(temp, CultureInfo.InvariantCulture);
            }

            return outContent;
        }
        public int GetCellContentInt()
        {
            int outContent = 0;
            string temp = GetCellContentRaw();

            if (int.TryParse(temp, out _) && temp != null)
            {
                outContent = int.Parse(temp, CultureInfo.InvariantCulture);
            }

            return outContent;
        }
        public string GetCellContentType()
        {
            if (req != null && req.content != null)
            {
                return req.content.Type;
            }
            else
            {
                return null;
            }
        }
    }
}
