using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployUtility
{

    public class CFile
    {
        public bool Deploy { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FileNameWithExtension { get; set; }                
        public string Modified { get; set; }
        public string Path { get; set; }
        public DocType docType { get; set; }
        public string version { get; set; }
        //public string ver { get; set; }

        public override string ToString()
        {
            return Name + "." + Extension + ": " + version;
        }
    }

    
    public enum DocType
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("File")]
        File = 1,
        [Description("Directory")]
        Directory = 2,
        [Description("FileEdit")]
        FileEdit = 3,
        [Description("FileAdd")]
        FileAdd = 4
    }
     
    class BL
    {
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class KeyVal<K, V>
    {
        public K Key { get; set; }
        public V Val { get; set; }

        public KeyVal() { }

        public KeyVal(K key)
        {
            this.Key = key;
        }

        public KeyVal(K key, V val)
        {
            this.Key = key;
            this.Val = val;
        } 
    }
}
