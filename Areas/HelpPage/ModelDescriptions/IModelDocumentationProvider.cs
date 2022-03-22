using System;
using System.Reflection;

namespace HTTP5101_Assignment3_AustinCaron.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}