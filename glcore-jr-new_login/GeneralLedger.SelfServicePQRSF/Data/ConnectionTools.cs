using System.Collections.Generic;

namespace GeneralLedger.SelfServiceCore.Data
{
    public static class ConnectionTools
    {
        public static string KeyConnectionString { get; set; }
        public static Dictionary<string, string> ConnectionUsers = new Dictionary<string, string>();

        public static void SetKeyConnectionString(string user)
        {
            KeyConnectionString = ConnectionUsers[user];
        }

        public static void SetDefaultConnectionString()
        {
            KeyConnectionString = null;
        }

        public static void SetKeyConnectionStringDirect(string keyConnection)
        {
            KeyConnectionString = keyConnection;
        }

        public static string GetKeyConnectionString()
        {
            return KeyConnectionString;
        }

        public static void AddConnectionUser(string key, string value)
        {
            ConnectionUsers.Add(key, value);
        }

        public static void RemoveConnectionUser(string key)
        {
            ConnectionUsers.Remove(key);
        }
    }
}