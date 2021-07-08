using Kutility.GoogleSheetsToUnity;
using Kutility.GoogleSheetsToUnity.Public;

/**
  * @file ExampleDR.cs
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
public class ExampleDR : DataReciever<ExampleDR>
{
    // Change the mode for obtaining parse results of different types.
    public OutputType outputType;

    //The id of the sheet can be obtained using the link of the sheet ["https://docs.google.com/spreadsheets/d/[sheetID]/"].
    public string sheetID;

    //Y Axys on the Google Sheet
    public int y;
    //X Axys on the Google Sheet, for comodity int values have been asociated through a enum using the letter as it is done in google sheets.
    public XAxysSheetConverter x;

    //The obtained result
    public object output;

    // Override Start() 
    public override void Start()
    {
        #region Initialize base parameters.
        TypeOfOutput = outputType;
        SheetID = sheetID;

        Y = y;
        X = x;
        #endregion

        //Call base.Start()
        base.Start();
    }

    // Override Update() 
    public override void Update()
    {
        #region If there is a change in some parameter update it.
        if (outputType != TypeOfOutput)
        {
            TypeOfOutput = outputType;
        }
        else if (sheetID != SheetID)
        {
            SheetID = sheetID;
        }
        else if (y != Y)
        {
            Y = y;
        }
        else if (x != X)
        {
            X = x;
        }
        #endregion

        //Call base.Update()
        base.Update();

        //If the output effectively is different update it and then print its content.
        if(Output != output)
        {
            output = Output;

            print(output);
        }
    }
}
   

