using ScoreEditor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreEditor.Models
{
    /// <summary>
    /// ノーツグループ
    /// </summary>
    internal class NotesGroup
    {
        #region メンバ
        /// <summary>
        /// ノーツグループはNotesのリストで構成される
        /// </summary>
        public List<Notes> NotesList { get; set; }
        /// <summary>
        /// ノーツグループのタイプ
        /// </summary>
        public NotesGroupType NotesGroupType { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// NotesGroup クラスの新しいインスタンスを初期化します。
        /// </summary>
        public NotesGroup()
        {
            NotesList = new List<Notes>();
        }
        #endregion
    }
}
