using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyEmbeddedRecourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Copy();
            instance.CopyInstance();
        }
}

    public class Copy
    {
        public void CopyInstance()
        {
            CopyResource("CopyEmbeddedRecourse.hamdi", @"C:\hamdi.ttf");
        }

        public void CopyResource(string resourceName, string file)
        {
            using (Stream resource = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                if (resource == null)
                {
                    throw new ArgumentException("No such resource", "resourceName");
                }
                using (Stream output = File.OpenWrite(file))
                {
                    resource.CopyTo(output);
                }
            }
        }

    }
}
