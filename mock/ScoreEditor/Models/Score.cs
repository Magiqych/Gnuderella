using ScoreEditor.Enums;
using ScoreEditor.Settings;

namespace ScoreEditor.Models
{
    /// <summary>
    /// 譜面を表すクラス
    /// </summary>
    internal partial class Score
    {
        #region メンバ
        /// <summary>
        /// 譜面はNotesGroupのリストで構成される
        /// </summary>
        public List<NotesGroup> NotesGroupList { get; set; }
        /// <summary>
        /// 正規化されたノーツ速度
        /// </summary>
        public double NormalizedNotesSpeed { get; set; }
        /// <summary>
        /// ノーツ速度
        /// </summary>
        public double NotesSpeed { get; set; }
        /// <summary>
        /// ノーツ速度比率
        /// </summary>
        public double NotesSpeedRatio { get; set; }
        /// <summary>
        /// レーン数
        /// </summary>
        public int NumberOfLanes { get; set; }
        /// <summary>
        /// BPM
        /// </summary>
        public double StaticTempo { get; set; }
        /// <summary>
        /// Static Beats List
        /// </summary>
        public List<double> BeatsStatic { get; set; }
        /// <summary>
        /// Dynamic Beats List
        /// </summary>
        public List<double> BeatsDynamic { get; set; }
        /// <summary>
        /// 曲の長さ
        /// </summary> 
        public double Duration { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// Score クラスの新しいインスタンスを初期化します。
        /// </summary>
        public Score(List<NotesGroup> NotesGroupList,
            double normalizedNotesSpeed,
            double notesSpeed)
        {
            NotesGroupList = new List<NotesGroup>();
            NotesGroupList.AddRange(NotesGroupList);
            NormalizedNotesSpeed = normalizedNotesSpeed;
            NotesSpeed = notesSpeed;
            NotesSpeedRatio = NotesSpeed / NormalizedNotesSpeed;
            BeatsStatic = new List<double>();
            BeatsDynamic = new List<double>();
        }
        /// <summary>
        /// Score クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="laneCount"></param>
        /// <param name="normalizedNotesSpeed"></param>
        /// <param name="notesSpeed"></param>
        public Score(int laneCount,
            double normalizedNotesSpeed,
            double notesSpeed)
        {
            NotesGroupList = new List<NotesGroup>();
            NumberOfLanes = laneCount;
            NormalizedNotesSpeed = normalizedNotesSpeed;
            NotesSpeed = notesSpeed;
            NotesSpeedRatio = NotesSpeed / NormalizedNotesSpeed;
            BeatsStatic = new List<double>();
            BeatsDynamic = new List<double>();
        }
        /// <summary>
        /// Score クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="normalizedNotesSpeed"></param>
        /// <param name="notesSpeed"></param>
        public Score(double normalizedNotesSpeed,
            double notesSpeed)
        {
            NotesGroupList = new List<NotesGroup>();
            NormalizedNotesSpeed = normalizedNotesSpeed;
            NotesSpeed = notesSpeed;
            NotesSpeedRatio = NotesSpeed / NormalizedNotesSpeed;
            BeatsStatic = new List<double>();
            BeatsDynamic = new List<double>();
        }
        /// <summary>
        /// Score クラスの新しいインスタンスを初期化します。
        /// </summary>
        public Score()
        {
            NotesGroupList = new List<NotesGroup>();
            NormalizedNotesSpeed = Constants.NormalizedNotesSpeed;
            NotesSpeed = Constants.NormalizedNotesSpeed;
            NotesSpeedRatio = Constants.NormalizedNotesSpeed / Constants.NormalizedNotesSpeed;
            BeatsStatic = new List<double>();
            BeatsDynamic = new List<double>();
        }
        #endregion
    }
}
