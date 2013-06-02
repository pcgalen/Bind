using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Binder
{
    public class DataLayer
    {


        private string m_sConnectionString = "";
        private SqlConnection m_oCn;
        private bool m_bInitialized = false;
        private long m_lErrorNo = 0;
        private string m_sErrorMsg = "";
        private bool m_bError = false;

        public string ConnectionString
        {
            get { return m_sConnectionString; }
            set { m_sConnectionString = value; }
        }

        public bool Error
        {
            get
            {
                return m_bError;
            }

        }

        public bool Initialized
        {
            get
            {
                return m_bInitialized;
            }
        }
        public long ErrorNo
        {
            get
            {
                return m_lErrorNo;
            }
        }

        public string Errormsg
        {
            get
            {
                return m_sErrorMsg;
            }
        }
        public SqlConnection Connection
        {
            get
            {
                return m_oCn;
            }
        }

        private void ResetError()
        {
            m_lErrorNo = 0;
            m_sErrorMsg = "";
            m_bError = false;
        }

        public void DataLayer()
        {
            m_oCn = new SqlConnection(m_sConnectionString);

            try
            {
                m_oCn.Open();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bInitialized = false;
                m_bError = true;
                return;
            }

            m_bInitialized = true;
        }

        public void DataLayer(string pConnectionString)
        {
            m_sConnectionString = pConnectionString;
            DataLayer();
        }

        public void ExecSQL(string pSql, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSql, m_oCn);

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            try
            {
                oCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
            }

        }

        public DataTable ExecSql(string pSql, List<SqlParameter> pParams)
        {
            ResetError();

            DataTable oDt = new DataTable();
            SqlCommand oCmd = new SqlCommand(pSql, m_oCn);
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            foreach (SqlParameter oParam in pParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            oAdapter.SelectCommand = oCmd;

            try
            {

                oAdapter.Fill(oDt);
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
                return null;
            }

            return oDt;
        }

        public string ExecString(string pSQL, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSQL, m_oCn);
            string sReturn;

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            try
            {
                sReturn = (string)oCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;

                return null;
            }

            return sReturn;

        }

        public int ExecInt(string pSQL, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSQL, m_oCn);

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            int iReturn = 0;

            try
            {
                iReturn = (int)oCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
                return -1;
            }

            return iReturn;
        }

        public bool ExecBool(string pSQL, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSQL, m_oCn);

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            bool bReturn = false;

            try
            {
                bReturn = (bool)oCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
                return false;
            }

            return bReturn;
        }

        public long ExecLong(string pSQL, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSQL, m_oCn);

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            long lReturn = -1;

            try
            {
                lReturn = (long)oCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
                return -1;
            }

            return lReturn;
        }

        public double ExecDouble(string pSQL, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSQL, m_oCn);

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            double dReturn = -1;

            try
            {
                dReturn = (double)oCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
                return -1;
            }

            return dReturn;
        }

        public float ExecFloat(string pSQL, List<SqlParameter> oParams)
        {
            ResetError();
            SqlCommand oCmd = new SqlCommand(pSQL, m_oCn);

            foreach (SqlParameter oParam in oParams)
            {
                oCmd.Parameters.Add(oParam);
            }

            float fReturn = -1;

            try
            {
                fReturn = (float)oCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bError = true;
                return -1;
            }

            return fReturn;
        }
    }

}