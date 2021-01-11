using Kutility.GoogleSheetsToUnity.Public;

public class ExampleDR : DataReciever<ExampleDR>
{
    public OutputType outputType;

    public string sheetID;

    public int y;
    public SheetCellController.XAxysSheetConverter x;

    public object output;

    // Start is called before the first frame update
    public override void Start()
    {
        _outputType = outputType;
        _sheetID = sheetID;

        _y = y;
        _x = x;

        _output = output;

        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if(outputType != _outputType)
        {
            _outputType = outputType;
        }
        else if (sheetID != _sheetID)
        {
            _sheetID = sheetID;
        }
        else if (y != _y)
        {
            _y = y;
        }
        else if (x != _x)
        {
            _x = x;
        }

        base.Update();

        if(_output != output)
        {
            output = _output;

            print(output);
        }
    }
}
   

