using Newtonsoft.Json;
using SDTool.APIClient.Serialization;

namespace SDTool.APIClient.Models
{
    public class ProgressResult
    {
        [JsonProperty("progress")]
        public float Progress { get; private set; }

        [JsonProperty("eta_relative")]
        public float EtaRelative { get; private set; }

        [JsonProperty("state")]
        public ProgressState State { get; private set; }

        [JsonProperty("current_image")]
        public string CurrentImage { get; private set; }

        [JsonProperty("textinfo")]
        public string Textinfo { get; private set; }

        public class ProgressState
        {
            [JsonProperty("skipped")]
            public bool Skipped { get; private set; }

            [JsonProperty("interrupted")]
            public bool Interrupted { get; private set; }

            [JsonProperty("job")]
            public string Job { get; private set; }

            [JsonProperty("job_count"), JsonConverter(typeof(IntConverter))]
            public int JobCount { get; private set; }

            [JsonProperty("job_timestamp")]
            public string JobTimestamp { get; private set; }

            [JsonProperty("job_no"), JsonConverter(typeof(IntConverter))]
            public int JobNo { get; private set; }

            [JsonProperty("sampling_step"), JsonConverter(typeof(IntConverter))]
            public int SamplingStep { get; private set; }

            [JsonProperty("sampling_steps"), JsonConverter(typeof(IntConverter))]
            public int SamplingSteps { get; private set; }
        }
    }
}