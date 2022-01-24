
using Serde;

namespace Ards
{
    [GenerateSerde]
    [SerdeTypeOptions(MemberFormat = MemberFormat.CamelCase)]
    public readonly partial record struct PipelineGetResult
    {
        public int Id { get; init; }
    }

    [GenerateSerde]
    [SerdeTypeOptions(MemberFormat = MemberFormat.CamelCase)]
    public readonly partial record struct BuildListResponse
    {
        public int Count { get; init; }
        public List<BuildResponse> Value { get; init; }
    }

    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.CamelCase)]
    public readonly partial record struct BuildResponse
    {
        public int Id { get; init; }
        public string BuildNumber { get; init; }
        public string Status { get; init; }
        [SerdeMemberOptions(NullIfMissing = true)]
        public string? Result { get; init; }
        public string SourceVersion { get; init; }

        public string GetBuildLink() =>
            $"https://dev.azure.com/dnceng/public/_build/results?buildId={Id}&view=results";
    }
}