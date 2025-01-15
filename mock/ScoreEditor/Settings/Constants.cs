namespace ScoreEditor.Settings
{
    /// <summary>
    /// 定数を表すクラス
    /// </summary>
    public static class Constants
    {
        #region アプリケーション
        /// <summary>
        /// アプリ名
        /// </summary>
        public const string AppName = "GnuderellaScoreMaker";
        #endregion

        #region 譜面定数
        /// <summary>
        /// スコアプロジェクトファイル名
        /// </summary>
        public const string ScoreProjectFileName = "ScoreProject.json";
        /// <summary>
        /// 譜面ファイル名
        /// </summary>
        public const string ScoreFileName = "Score.json";
        /// <summary>
        /// 音楽ファイル名
        /// </summary>
        public const string MusicFileName = "music.mp3";
        /// <summary>
        /// 正規化されたノーツ速度の初期値
        /// </summary>
        public const double NormalizedNotesSpeed = 10.0;
        /// <summary>
        /// レーン数の最小値
        /// </summary>
        public const int MinNumberOfLanes = 1;
        /// <summary>
        /// レーン数の最大値
        /// </summary>
        public const int MaxNumberOfLanes = 10;
        /// <summary>
        /// レーン数のデフォルト値
        /// </summary>
        public const int DefaultNumberOfLanes = 5;
        /// <summary>
        /// 拍数のデフォルト値
        /// </summary>
        public const int DefaultBeatsPerBar = 16;
        #endregion
    }
}
