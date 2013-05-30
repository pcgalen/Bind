using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using HSC.Crypto;

namespace Binder
{
    public static class Util
    {


        private static object m_oconfig;


        private static ListDictionary m_lListDictionary;

        public static string getJs()
        {
            return "<script language=\"javascript\" type=\"text/javascript\">";
        }

        public static string getJe()
        {
            return "</script>";
        }

        public static string getConn(string pServer = null, string pDatabase = null, string pUser = null, string pPassword = null)
        {
            if (pServer == null)
                pServer = Util.config["DatabaseServer"].ToString();

            if (pDatabase == null)
                pDatabase = Util.config["Database"].ToString();

            if (pUser == null)
                pUser = Util.config["DatabaseUser"].ToString();

            if (pPassword == null)
                pPassword = Util.config["DatabasePassword"].ToString();

            string sConnstr = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", pServer, pDatabase, pUser, pPassword);

            return sConnstr;
        }

        public static void Serialize()
        {
            string sPath = HttpContext.Current.Server.MapPath("~/config/config.txt");
            if (File.Exists(sPath))
                File.Delete(sPath);

            TextWriter oTs = File.CreateText(sPath);

            foreach (DictionaryEntry oDe in m_lListDictionary)
            {
                if (oDe.Key.ToString() != "Username" && oDe.Key.ToString() != "Password")
                    if (oDe.Key.ToString() == "DatabasePassword")
                    {
                        CCrypt oCrypt = new CCrypt();
                        string sCrypt = oCrypt.DESEncrypt(oDe.Value.ToString());
                        oTs.WriteLine(oDe.Key + "," + sCrypt);
                    }
                    else
                    {
                        oTs.WriteLine(oDe.Key + "," + oDe.Value);
                    }

            }
            oTs.Close();
        }

        public static void deSerialize()
        {
            string sPath = HttpContext.Current.Server.MapPath("~/config/config.txt");
            if (!File.Exists(sPath))
            {
                m_lListDictionary = new ListDictionary();
                return;
            }

            m_lListDictionary = new ListDictionary();
            TextReader oTr = File.OpenText(sPath);

            char cN1 = '\n';

            string sTemp = oTr.ReadToEnd();
            string[] asTemp = sTemp.Split(cN1);

            foreach (string sLine in asTemp)
            {
                if (sLine.Length == 0)
                    continue;

                string[] asTemp2 = sLine.Split(',');

                if (asTemp[0].ToString() == "DatabasePassword")
                {
                    CCrypt oCrypt = new CCrypt();
                    m_lListDictionary.Add(asTemp2[0], oCrypt.DESDecrypt(asTemp2[1]));
                    continue;
                }
                m_lListDictionary.Add(asTemp2[0], asTemp2[1]);
            }

            oTr.Close();
        }



        public static ListDictionary config
        {
            get { return m_lListDictionary; }
            set { m_lListDictionary = value; }
        }

    }
}