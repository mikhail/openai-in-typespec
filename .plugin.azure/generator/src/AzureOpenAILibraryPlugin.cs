using System.ComponentModel.Composition;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;

namespace AzureOpenAILibraryPlugin
{
    [Export(typeof(CodeModelPlugin))]
    [ExportMetadata("PluginName", nameof(AzureOpenAILibraryPlugin))]
    public class AzureOpenAILibraryPlugin : ScmCodeModelPlugin
    {
        [ImportingConstructor]
        public AzureOpenAILibraryPlugin(GeneratorContext context) : base(context) { }

        public override void Configure()
        {
            base.Configure();

            AddVisitor(new DocEditVisitor());
            AddVisitor(new AdditionalPropertiesVisitor());
            AddVisitor(new ModelSerializationEmptySentinelVisitor());
            AddVisitor(new WriteableSardVisitor());
            AddVisitor(new TypeRemovalVisitor());
            AddVisitor(new InternalSettablePropertiesVisitor());
        }
    }
}