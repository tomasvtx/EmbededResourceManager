using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EmbeddedResourceManager
{
    public class Embedded
    {
        public void GetEmbeddedResourceStream(string resourceName, out Stream resource, out bool isExist, out string exception)
        {
            isExist = false;
            resource = null;
            exception = string.Empty;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceNames = assembly?.GetManifestResourceNames();

                var name = resourceNames?.FirstOrDefault(rr => rr.Contains(resourceName)) ?? string.Empty;

                isExist = name?.Length > 0;
                resource = assembly?.GetManifestResourceStream(name);
                exception = String.Empty;
            }
            catch (Exception ss)
            {
                exception = ss.Message;
            }
        }
    }
    }
