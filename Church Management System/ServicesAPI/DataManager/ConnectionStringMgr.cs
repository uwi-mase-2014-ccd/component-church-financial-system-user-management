using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ServicesAPI.DataManager
{
    public class ConnectionStringMgr
    {
        public  String getConnectionInfo(String path, String connectionStringType)
        {
            String connectionStringSkeleton;
            XDocument xmlDoc = XDocument.Load(path);
            var connectionInfo = from t in xmlDoc.Descendants("connectionstring")
                                 where t.Attribute("type").Value.ToLower() == connectionStringType
                                 select t; 
            connectionStringSkeleton = connectionInfo.SingleOrDefault().Value;
            return connectionStringSkeleton;
        }
    }
}