
using Serde;

namespace Ards
{
    [GenerateSerde]
    [SerdeOptions(MemberFormat = MemberFormat.CamelCase)]
    public readonly partial record struct PipelineGetResult
    {
        public int Id { get; init; }
    }

    [GenerateSerde]
    [SerdeOptions(MemberFormat = MemberFormat.CamelCase)]
    public readonly partial record struct BuildListResponse
    {
        public int Count { get; init; }
        public List<BuildResponse> Value { get; init; }
    }

    [GenerateSerde]
    [SerdeOptions(MemberFormat = MemberFormat.CamelCase)]
    public readonly partial record struct BuildResponse
    {
        public int Id { get; init; }
        public string BuildNumber { get; init; }
        public string Status { get; init; }
        public string Result { get; init; }
        public string SourceVersion { get; init; }

        public string GetBuildLink() =>
            $"https://dev.azure.com/dnceng/public/_build/results?buildId={Id}&view=results";
    }
}