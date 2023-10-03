using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreHelper
{
    public class TypeParser
    {
        public TypeParser()
        {
        }

        public static string ParseString(object s)
        {
            try
            {
                if (s == null)
                {
                    return "";
                }
                return s + "";

            }
            catch
            {
                return "";
            }
        }

        public static bool ParseBoolean(object s)
        {
            if (s == null)
            {
                return false;
            }
            try
            {
                string tmpS = (s+"").ToUpperInvariant();
                return (tmpS == "TRUE" || tmpS == "YES" || tmpS == "1");
            }
            catch
            {
                return false;
            }
        }

        

        public static Color ParseColor(object s)
        {
            if (s == null)
            {
                return new Color();
            }

            try
            {
                if (s is Color color)
                {
                    return color; // If the input is already a Color object, return it.
                }

                string colorString = s.ToString();
                return Color.FromName(colorString);
            }
            catch
            {
                return new Color();
            }
        }
        

        public static char ParseChar(object s)
        {
            if (s == null)
            {
                return new char();
            }

            try
            {
                string tmpS = s.ToString().ToUpperInvariant();
                if (tmpS.Length > 0)
                {
                    return tmpS[0];
                }
                else
                {
                    return new char();
                }
            }
            catch
            {
                return new char();
            }
        }

        public static int ParseInt(object s)
        {
            if (s == null)
            {
                return 0;
            }

            int usi = 0;
            Int32.TryParse(s.ToString(), out usi);
            // use default locale setting
            return usi;
        }

        public static short ParseShort(object s)
        {
            if (s == null)
            {
                return 0;
            }
            short usi = 0;
            Int16.TryParse(s+"", out usi);
            // use default locale setting
            return usi;
        }

        public static long ParseLong(string s)
        {
            long usl = 0;
            Int64.TryParse(s, out usl);
            // use default locale setting
            return usl;
        }

        public static float ParseSingle(object s)
        {
            if (s == null)
            {
                return 0;
            }
            float uss = 0;
            Single.TryParse(s+"", out uss);
            return uss;
        }

        public static double ParseDouble(object s)
        {
            double usd = 0;


            if (s == null)
            {
                return 0;
            }

            Double.TryParse(s.ToString(), out usd);
            return usd;
        }

        public static decimal ParseDecimal(string s)
        {
            decimal usd = default(decimal);
            Decimal.TryParse(s, out usd);
            return usd;
        }

        public static DateTime ParseDateTime(object s)
        {
            if (s == null)
            {
                return System.DateTime.MinValue;
            }
            try
            {
                return System.DateTime.Parse(s+"");
            }
            catch
            {
                return System.DateTime.MinValue;
            }
        }

        public static Guid ParseGuid(string s)
        {
            Guid usguid = default(Guid);
            try
            {
                usguid = new Guid(s);
            }
            catch (Exception ex)
            {
                usguid = Guid.Empty;
            }

            return usguid;
        }
    }
}