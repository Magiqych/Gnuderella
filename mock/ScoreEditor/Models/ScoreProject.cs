namespace ScoreEditor.Models
{
    /// <summary>
    /// スコアプロジェクトを表すクラス
    /// </summary>
    internal class ScoreProject
    {
        #region メンバ
        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;
        /// <summary>
        /// プロジェクトパス
        /// </summary>
        public string ProjectPath { get; set; } = string.Empty;
        /// <summary>
        /// 楽曲ファイルパス
        /// </summary>
        public string MusicFilePath { get; set; } = string.Empty;
        /// <summary>
        /// 背景ファイルパス
        /// </summary>
        public string BackGroundFilePath { get; set; } = string.Empty;
        /// <summary>
        /// スコア作成者
        /// </summary>
        public string Author { get; set; } = string.Empty;
        /// <summary>
        /// クレジット
        /// </summary>
        public string Credit { get; set; } = string.Empty;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// ScoreProject クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="projectName">プロジェクト名</param>
        /// <param name="projectPath">プロジェクトパス</param>
        /// <param name="musicFilePath">楽曲ファイルパス</param>
        /// <param name="backGroundFilePath">背景ファイルパス</param>
        /// <param name="author">スコア作成者</param>
        /// <param name="credit">クレジット</param>
        public ScoreProject(string projectName,
            string projectPath,
            string musicFilePath,
            string backGroundFilePath,
            string author = "",
            string credit = "")
        {
            ProjectName = projectName;
            ProjectPath = projectPath;
            MusicFilePath = musicFilePath;
            BackGroundFilePath = backGroundFilePath;
            Author = author;
            Credit = credit;
        }
        /// <summary>
        /// ScoreProject クラスの新しいインスタンスを初期化します。
        /// </summary>
        public ScoreProject()
        {
        }
        #endregion
    }
}


