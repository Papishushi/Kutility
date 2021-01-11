using System.Globalization;

namespace Kutility.GoogleSheetsToUnity.Public
{
    public class SheetCellController
    {
        
        public enum XAxysSheetConverter
        {
            a = 1, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
        };


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
