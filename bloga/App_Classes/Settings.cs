using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace bloga.App_Classes
{
    public class Settings
    {
        public static Size smallImage
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return result;
            }

        }

        public static Size mediumImage
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return result;
            }

        }

        public static Size bigImage
        {
            get
            {
                Size result = new Size();
                result.Width = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
                result.Height = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);
                return result;
            }

        }
    }
}