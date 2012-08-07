using System;
using System.Collections.Generic;

namespace TrainingTasks4
{




    public class Html
    {
        public Html()
        {
            Attrs = new Dictionary<string, string>();
        }
        public string MyTag { get; set; }
        public Dictionary<string, string> Attrs { get; set; }
        
        public static Html Tag(string div)
        {
            var html = new Html() {MyTag = div};

            return html;
        }

        public Html Attr(string key, string value)
        {
            Attrs.Add(key,value);

            return this;
        }

        public Html AddClass(string wow)
        {
            throw new NotImplementedException();
        }

        public Html Modify(Func<object, object> func)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("<{0} {1}></{0}>",MyTag, GetAllAttrs(Attrs));
        }

        public string GetAllAttrs (Dictionary<string,string> attrs )
        {
            var retStr = "";
            foreach (var attr in attrs)
            {
                if (retStr != "") retStr += " ";
                retStr += attr.Key + "=\"" + attr.Value + "\"";
            }
            return retStr;
        }
        
    }
}