using NAudio.Wave;

namespace ScoreEditor.Utilities
{
    internal class AudioHelper
    {
        /// <summary>
        /// 出力デバイス
        /// </summary>
        private WaveOutEvent? OutputDevice;
        /// <summary>
        /// 音声ファイル
        /// </summary>
        private AudioFileReader? AudioFile;
        /// <summary>
        /// 音声ファイルパス
        /// </summary>
        public string? FilePath { get; set; }
        /// <summary>
        /// 音声ファイルのバイト数/秒
        /// </summary>
        public int BytesPerSecond { get; set; }
        /// <summary>
        /// 音声ファイルの長さ（ミリ秒）
        /// </summary>
        public double MusicLength { get; set; }
        /// <summary>
        /// 再生箇所
        /// </summary>
        public double MusicPos { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath"></param>
        private AudioHelper(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// 非同期でAudioHelperを生成します。
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static async Task<(AudioHelper, WaveOutEvent)> CreateAsync(string filePath)
        {
            var audioHelper = new AudioHelper(filePath);
            var outputDevice = await audioHelper.LoadAudioAsync();
            return (audioHelper, outputDevice);
        }

        /// <summary>
        /// 音声ファイルを読み込みます。
        /// </summary>
        /// <returns></returns>
        private async Task<WaveOutEvent> LoadAudioAsync()
        {
            return await Task.Run(() =>
            {
                AudioFile = new AudioFileReader(FilePath);
                OutputDevice = new WaveOutEvent();
                OutputDevice.Init(AudioFile);
                BytesPerSecond = AudioFile.WaveFormat.AverageBytesPerSecond;
                MusicLength = AudioFile.TotalTime.TotalMilliseconds;
                MusicPos = 0.0;
                return OutputDevice;
            });
        }

        /// <summary>
        /// 再生ポジションを取得
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetCurrentPosition()
        {
            return AudioFile?.CurrentTime ?? TimeSpan.Zero;
        }

        /// <summary>
        /// 再生ポジションを設定
        /// </summary>
        /// <param name="position"></param>
        public void SetCurrentPosition(TimeSpan position)
        {
            if (AudioFile != null)
            {
                AudioFile.CurrentTime = position;
                MusicPos = position.TotalSeconds;
            }
        }
    }
}
