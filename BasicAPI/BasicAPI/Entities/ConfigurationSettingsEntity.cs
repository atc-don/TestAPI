using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BasicAPI.Entities
{
    public class ConfigurationSettingsEntity
    {
        public ConfigurationSettingsEntity(NameValueCollection configurationSettings)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException("configurationSettings");
            }
        }
    }
}