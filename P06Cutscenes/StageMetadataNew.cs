using System;
using System.IO;
using P06ML.Metadata;

namespace StageExtensions
{
    public class StageMetadataNew : StageMetadata
    {
        public RequireSE RequireStageExtensions { get; set; } = 0;
        public string DescriptionSE { get; set; } = "N/A";
        public string AssetBundleSE { get; set; } = "N/A";
        public string TitleSE { get; set; } = "N/A";

        public enum RequireSE
        {
            Not_Required,
            Recommended,
            Required
        }

        public static StageMetadataNew Load(string path)
        {
            StageMetadataNew stageMetadata = MetadataBase.Load<StageMetadataNew>(path, false);
            if (!string.IsNullOrEmpty(stageMetadata.Thumbnail))
            {
                stageMetadata.Thumbnail = Path.Combine(stageMetadata.Location, stageMetadata.Thumbnail);
            }
            if (!string.IsNullOrEmpty(stageMetadata.LoadingThumbnail))
            {
                stageMetadata.LoadingThumbnail = Path.Combine(stageMetadata.Location, stageMetadata.LoadingThumbnail);
            }
            return stageMetadata;
        }
    }
}
