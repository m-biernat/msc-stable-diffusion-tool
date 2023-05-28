namespace SDTool.APIClient
{
    public static class Endpoints
    {
        public static class Internal
        {
            public const string Progress = "/internal/progress";
        }

        public const string Txt2Img = "/sdapi/v1/txt2img";
        public const string Img2Img = "/sdapi/v1/img2img";
        public const string ExtraSingleImage = "/sdapi/v1/extra-single-image";
        public const string ExtraBatchImages = "/sdapi/v1/extra-batch-images";
        public const string PngInfo = "/sdapi/v1/png-info";
        public const string Progress = "/sdapi/v1/progress";
        public const string Interrogate = "/sdapi/v1/interrogate";
        public const string Interrupt = "/sdapi/v1/interrupt";
        public const string Skip = "/sdapi/v1/skip";
        public const string Options = "/sdapi/v1/options";
        public const string CmdFlags = "/sdapi/v1/cmd-flags";
        public const string Samplers = "/sdapi/v1/samplers";
        public const string Upscalers = "/sdapi/v1/upscalers";
        public const string SdModels = "/sdapi/v1/sd-models";
        public const string Hypernetworks = "/sdapi/v1/hypernetworks";
        public const string FaceRestorers = "/sdapi/v1/face-restorers";
        public const string RealesrganModels = "/sdapi/v1/realesrgan-models";
        public const string PromptStyles = "/sdapi/v1/prompt-styles";
        public const string Embeddings = "/sdapi/v1/embeddings";
        public const string RefreshCheckpoints = "/sdapi/v1/refresh-checkpoints";
        public const string CreateEmbedding = "/sdapi/v1/create/embedding";
        public const string CreateHypernetwork = "/sdapi/v1/create/hypernetwork";
        public const string Preprocess = "/sdapi/v1/preprocess";
        public const string TrainEmbedding = "/sdapi/v1/train/embedding";
        public const string TrainHypernetwork = "/sdapi/v1/train/hypernetwork";
        public const string Memory = "/sdapi/v1/memory";
        public const string UnloadCheckpoint = "/sdapi/v1/unload-checkpoint";
        public const string ReloadCheckpoint = "/sdapi/v1/reload-checkpoint";
        public const string Scripts = "/sdapi/v1/scripts";

        public static class SdExtraNetworks
        {
            public const string Thumb = "/sd_extra_networks/thumb";
            public const string Metadata = "/sd_extra_networks/metadata";
        }

        public static class ControlNet
        {
            public const string Version = "/controlnet/version";
            public const string ModelList = "/controlnet/model_list";
            public const string ModuleList = "/controlnet/module_list";
            public const string Preprocess = "/controlnet/detect";
        }
    }
}