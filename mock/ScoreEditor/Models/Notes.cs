using ScoreEditor.Enums;
using System.Numerics;

namespace ScoreEditor.Models
{
    /// <summary>
    /// ノーツ
    /// </summary>
    internal class Notes
    {
        #region メンバ
        /// <summary>
        /// 描写フラグ
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// 正規化されたタイミング変数
        /// </summary>
        public double NormalizedTiming { get; set; }
        /// <summary>
        /// タイミング変数
        /// </summary>
        public double Timing { get; set; }
        /// <summary>
        /// ノーツ生成レーンインデックス
        /// </summary>
        public int SpawnLaneIndex { get; set; }
        /// <summary>
        /// ノーツ到達レーンインデックス
        /// </summary>
        public int DestLaneIndex { get; set; }
        /// <summary>
        /// ノーツ生成座標
        /// </summary>
        public Vector3 SpawnPos { get; set; }
        /// <summary>
        /// ノーツ到達座標
        /// </summary>
        public Vector3 DestPos { get; set; }
        /// <summary>
        /// ノーツのタイプ
        /// </summary>
        public NotesType NotesType { get; set; }
        #endregion
    }
}
