namespace Webservice.Utils
{
    public sealed class HashUtil
    {
        public static string GetUniqueId()
        {
            string strRet = "";
            string[] parts = System.Guid.NewGuid().ToString().Split('-');

            foreach (string part in parts)
                strRet += part;

            return strRet;
        }
    }
}
