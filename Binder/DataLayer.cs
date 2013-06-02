using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Binder
{
    public class DataLayer
    {

        private static SqlConnection m_oCn;
        private static bool m_bInitialized = false;
        private static long m_lErrorNo = 0;
        private static string m_sErrorMsg = "";

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
        }

        public static void DataLayer()
        {
            m_oCn = new SqlConnection(Util.getConn());

            try
            {
                m_oCn.Open();
            }
            catch (SqlException ex)
            {
                m_lErrorNo = ex.ErrorCode;
                m_sErrorMsg = ex.Message;
                m_bInitialized = false;
                return;
            }

            m_bInitialized = true;
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
                return null;
            }

            return oDt;
        }

    }
}