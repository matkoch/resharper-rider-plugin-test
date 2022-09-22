using System.Linq;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace ReSharperPlugin.CodeInspections;

// Types mentioned in this attribute are used for performance optimizations
[ElementProblemAnalyzer(
    typeof (IClassMemberDeclaration),
    HighlightingTypes = new [] {typeof (SampleDeclarationHighlighting)})]
public class SampleDeclarationProblemAnalyzer : ElementProblemAnalyzer<IClassMemberDeclaration>
{
    protected override void Run(IClassMemberDeclaration element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
    {
        if (element.NameIdentifier?.Name.All(char.IsUpper) ?? true)
            return;

        consumer.AddHighlighting(new SampleDeclarationHighlighting(element));
    }
}
