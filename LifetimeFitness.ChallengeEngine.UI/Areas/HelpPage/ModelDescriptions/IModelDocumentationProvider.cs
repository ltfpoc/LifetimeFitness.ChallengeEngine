using System;
using System.Reflection;

namespace LifetimeFitness.ChallengeEngine.UI.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}