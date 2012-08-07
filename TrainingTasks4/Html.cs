using System;
using System.Collections.Generic;

namespace TrainingTasks4
{




    public class Html
    {
        public Html()
        {
            Attrs = new Dictionary<string, string>();
            Classes = new List<string>();
        }
        public string MyTag { get; set; }
        public Dictionary<string, string> Attrs { get; set; }
        public List<string> Classes { get; set; }

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

        public Html AddClass(string inClass)
        {
            Classes.Add(inClass);
            return this;
        }

        public Html Modify(Func<object, object> func)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("<{0} {1}{2}></{0}>",MyTag, GetAllAttrs(Attrs),GetAllClasses(Classes));
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
   
        public string GetAllClasses (List<string> classes )
        {
            var classStr = "";

            if (classes.Count == 0) return "";
            foreach (var thisClass in classes)
            {
                if (classStr != "") classStr += " ";
                classStr += thisClass;
            }
            
            return string.Format(" class=\"{0}\"",classStr);
        }     
    }
}