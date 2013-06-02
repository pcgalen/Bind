using System.Data.SqlClient;

namespace Binder
{
    public class DataLayer
    {

        private static SqlConnection m_oCn;
        private static bool m_bInitialized = false;

        public SqlConnection Connection
        {
            get
            {
                return m_oCn;
            }
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

            }
        }


    }
}