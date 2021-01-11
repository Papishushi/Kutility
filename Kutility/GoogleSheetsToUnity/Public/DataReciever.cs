using UnityEngine;

namespace Kutility.GoogleSheetsToUnity.Public
{
    public abstract class DataReciever<T> : MonoBehaviour
    {
        public enum OutputType
        {
            raw,
            double_float,
            floating_point,
            integeer,
            date_time
        };

        public const string Y_STRING = "R";
        public const string X_STRING = "C";

        public const float CHECK_FOR_UPDATES_TIME = 5f;

        private static DataRequester cellInfoReq = new DataRequester();

        private static SheetCellController cellInfoSCtrl = null;

        public static OutputType _outputType;

        public static string _sheetID;

        public static int _y;
        public static SheetCellController.XAxysSheetConverter _x;

        public static object _output;

        private static float refresher;

        public virtual void Start()
        {
            //Request Bitcoin data
            StartCoroutine(cellInfoReq.RequestCellData(_sheetID, Y_STRING + _y + X_STRING + (int)_x));

            //Initialize the sheet controllers with their associated requests.
            cellInfoSCtrl = new SheetCellController(cellInfoReq);
        }
        // Update is called once per frame
        public virtual void Update()
        {
            //Add delta time to the chronometer.
            refresher += Time.deltaTime;

            //Refresh this code every CHECK_FOR_UPDATES_TIME seconds.
            if (refresher >= CHECK_FOR_UPDATES_TIME)
            {
                StartCoroutine(cellInfoReq.RequestCellData(_sheetID, Y_STRING + _y + X_STRING + (int)_x));

                switch (_outputType)
                {
                    case OutputType.raw:
                        //Get the default cell data and assign it to info.
                        _output = cellInfoSCtrl.GetCellContentRaw();
                        break;
                    case OutputType.double_float:
                        //Get the default cell data and assign it to info.
                        _output = cellInfoSCtrl.GetCellContentDouble();
                        break;
                    case OutputType.floating_point:
                        //Get the default cell data and assign it to info.
                        _output = cellInfoSCtrl.GetCellContentFloat();
                        break;
                    case OutputType.integeer:
                        //Get the default cell data and assign it to info.
                        _output = cellInfoSCtrl.GetCellContentInt();
                        break;
                    case OutputType.date_time:
                        //Get the default cell data and assign it to info.
                        _output = cellInfoSCtrl.GetDataTime();
                        break;
                }

                //Reset refresher.
                refresher = 0;
            }
        }
    }
}


