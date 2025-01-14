namespace ScoreEditor.Models
{
    /// <summary>
    /// スコアプロジェクトを表すクラス
    /// </summary>
    internal class ScoreProject
    {
        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// プロジェクトパス
        /// </summary>
        public string ProjectPath { get; set; }

        /// <summary>
        /// 楽曲ファイルパス
        /// </summary>
        public string MusicFilePath { get; set; }

        /// <summary>
        /// 背景ファイルパス
        /// </summary>
        public string BackGroundFilePath { get; set; }

        /// <summary>
        /// レーン数
        /// </summary>
        public int LaneCount { get; set; }

        /// <summary>
        /// 1分間の拍数
        /// </summary>
        public int BPM { get; set; }

        /// <summary>
        /// 1小節の拍数
        /// </summary>
        public int BeatsPerBar { get; set; }

        /// <summary>
        /// 正規化されたノーツ速度
        /// </summary>
        public double NormalizedNotesSpeed { get; set; }

        /// <summary>
        /// ノーツ速度
        /// </summary>
        public double NotesSpeed { get; set; }

        /// <summary>
        /// スコア作成者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// クレジット
        /// </summary>
        public string Credit { get; set; }

        /// <summary>
        /// ScoreProject クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="projectName">プロジェクト名</param>
        /// <param name="projectPath">プロジェクトパス</param>
        /// <param name="musicFilePath">楽曲ファイルパス</param>
        /// <param name="backGroundFilePath">背景ファイルパス</param>
        /// <param name="author">スコア作成者</param>
        /// <param name="credit">クレジット</param>
        /// <param name="laneCount">レーン数</param>
        /// <param name="normalizedNotesSpeed">正規化されたノーツ速度</param>
        /// <param name="notesSpeed">ノーツ速度</param>
        public ScoreProject(string projectName,
            string projectPath,
            string musicFilePath,
            string backGroundFilePath,
            string author = "",
            string credit = "",
            int laneCount = Constants.DefaultNumberOfLanes,
            double normalizedNotesSpeed = Constants.NormalizedNotesSpeed,
            double notesSpeed = Constants.NormalizedNotesSpeed)
        {
            ProjectName = projectName;
            ProjectPath = projectPath;
            MusicFilePath = musicFilePath;
            BackGroundFilePath = backGroundFilePath;
            LaneCount = laneCount;
            NormalizedNotesSpeed = normalizedNotesSpeed;
            NotesSpeed = notesSpeed;
            Author = author;
            Credit = credit;
        }
        /// <summary>
        /// ScoreProject クラスの新しいインスタンスを初期化します。
        /// </summary>
        public ScoreProject()
        {
            LaneCount = Constants.DefaultNumberOfLanes;
            NormalizedNotesSpeed = Constants.NormalizedNotesSpeed;
            NotesSpeed = Constants.NormalizedNotesSpeed;
        }
    }
}


