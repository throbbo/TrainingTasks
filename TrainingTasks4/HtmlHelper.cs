using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TrainingTasks4
{
    public class HtmlHelper<T>
    {
        public HtmlHelper(string tag)
        {
            _tag = tag ?? "";
        }

        private readonly string _tag;
        List<IHtmlElement> Elements = new List<IHtmlElement>();
        public Dictionary<string, string> Attrs = new Dictionary<string, string>();
        public List<string> Classes = new List<string>();
        public string GetOpeningTagString
        {
            get
            {
                return string.IsNullOrEmpty(_tag) ? "" : "<" + _tag;
            }
        }
        public string ClosingTagString
        {
            get
            {
                var isElClose = Elements.Count > 0 ? "":">";
                return string.IsNullOrEmpty(_tag) ? "" : isElClose + "</" + _tag + ">";
            }
        }
        public string ClosingTagStringFirst
        {
            get
            {
                return string.IsNullOrEmpty(_tag) ? "" : ">";
            }
        }
        public static implicit operator string(HtmlHelper<T> html)
        {
            return html.ToString();
        }


        public HtmlHelper<T> Attr(string key, string value)
        {
            Attrs.Add(key,value);

            return this;
        }

        public HtmlHelper<T> AddClass(string inClass)
        {
            Classes.Add(inClass);
            return this;
        }

        public HtmlHelper<T> Modify(Func<HtmlHelper<T>, Html> func)
        {
            func(this);
            return this;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}",GetOpeningTagString, GetAllAttrs(Attrs),GetAllClasses(Classes),ClosingTagStringFirst,GetAllElements(Elements),ClosingTagString);
        }

        private object GetAllElements(List<IHtmlElement> elements)
        {
            var retStr = "";
            foreach (var element in Elements)
            {
                if (retStr != "") retStr += " ";
                retStr += string.Format("<{0} name=\"{1}\" value=\"{2}\" />",element.Type,element.Name, element.Value);
            }
            return retStr;        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj);
        }

        public string GetAllAttrs (Dictionary<string,string> attrs )
        {
            var retStr = "";
            foreach (var attr in attrs)
            {
                if (retStr != "") retStr += " ";
                retStr += " " + attr.Key + "=\"" + attr.Value + "\"";
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

        private HtmlHelper<T> AddElement(IHtmlElement element)
        {
            if(element!=null)
                Elements.Add(element);
            return this;
        }

        
 
        public HtmlHelper<T> InputFor(Expression<Func<T, object>> func, T data)
        {
            var element = new HtmlInput();
            var expression = GetMemberInfo(func);
            string name = expression.Member.Name;
            element.Name = name;
            element.Value = func.Compile().Invoke(data).ToString();

            //element.ProperyAccessor = func;
            AddElement(element);
            return this;
        }

        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

    }
}