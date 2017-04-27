using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniGenerator
{
    public abstract class Ini
    {
        protected readonly IniFile IniFile;

        protected Ini(string filename)
        {
            IniFile = new IniFile(filename);
            LoadIni(filename);
        }

        protected void LoadIni(string filename)
        {
            if (!IniFile.FileExists)
            {
                GenerateDefaultIni();
                IniFile.Save();
            }
            else
            {
                var allPropertiesSet = true;

                // Check if the property exists in the current ini data
                foreach (var property in GetType().GetProperties())
                {
                    var propertyExists = false;

                    // Check if the property exists in any section
                    foreach (var section in IniFile.Data.Sections)
                    {
                        if (IniFile.Data.Sections[section.SectionName].ContainsKey(property.Name))
                        {
                            propertyExists = true;
                            break;
                        }
                    }

                    allPropertiesSet = propertyExists;
                    if (!allPropertiesSet)
                        break;
                }

                // Create a new ini file and merge our current values in it
                if (!allPropertiesSet)
                {
                    GenerateDefaultIni();
                    var oldIni = new IniFile(filename);
                    IniFile.Merge(oldIni.Data);
                    IniFile.Save();
                }
            }
        }

        protected abstract void GenerateDefaultIni();
    }
}
