using ScoreEditor.Enums;
using System.Collections.Generic;

namespace ScoreEditor.Models
{
    internal partial class Score
    {
        #region ノーツグループ操作
        /// <summary>
        /// ノーツグループを追加します。
        /// </summary>
        /// <param name="notesGroup">追加するノーツグループ</param>
        public void AddNotesGroup(NotesGroup notesGroup)
        {
            NotesGroupList.Add(notesGroup);
        }

        /// <summary>
        /// ノーツグループを削除します。
        /// </summary>
        /// <param name="notesGroup">削除するノーツグループ</param>
        public void RemoveNotesGroup(NotesGroup notesGroup)
        {
            NotesGroupList.Remove(notesGroup);
        }

        /// <summary>
        /// ノーツグループを統合します
        /// </summary>
        /// <param name="notesGroupA">統合するノーツグループA</param>
        /// <param name="notesGroupB">統合するノーツグループB</param>
        public void MergeNotesGroup(NotesGroup notesGroupA, NotesGroup notesGroupB)
        {
            //マージするノーツグループの新規作成
            var mergedNotesGroup = new NotesGroup();
            mergedNotesGroup.NotesList.AddRange(notesGroupA.NotesList);
            mergedNotesGroup.NotesList.AddRange(notesGroupB.NotesList);
            mergedNotesGroup.NotesGroupType = NotesGroupType.Grouped;
            //ノーツグループリストの更新
            NotesGroupList.Add(mergedNotesGroup);
            //ノーツグループリストからノーツグループAとノーツグループBを削除
            NotesGroupList.Remove(notesGroupA);
            NotesGroupList.Remove(notesGroupB);
        }

        /// <summary>
        /// ノーツグループを分割します
        /// </summary>
        /// <param name="notesGroup">分割するノーツグループ</param>
        public void SeperateNotesGroup(NotesGroup notesGroup)
        {
            foreach (var notes in notesGroup.NotesList)
            {
                var newNotesGroup = new NotesGroup();
                newNotesGroup.NotesList.Add(notes);
                newNotesGroup.NotesGroupType = NotesGroupType.Single;
                NotesGroupList.Add(newNotesGroup);
            }
            //分割元のノーツグループを削除
            NotesGroupList.Remove(notesGroup);
        }

        /// <summary>
        /// ノーツグループ内のノーツのタイミングを設定します。
        /// </summary>
        public void SetNotesTiming()
        {
            // ノーツ速度比率が0以下の場合は何もしない
            if (NotesSpeedRatio <= 0)
            {
                return;
            }
            //ノーツグループリストがnullの場合は何もしない
            if (NotesGroupList == null)
            {
                return;
            }
            // ノーツのタイミングを設定
            var swapNotesGroupList = new List<NotesGroup>();
            foreach (var notesGroup in NotesGroupList)
            {
                var swapNotesList = new List<Notes>();
                foreach (var notes in notesGroup.NotesList)
                {
                    notes.Timing = notes.NormalizedTiming * NotesSpeedRatio;
                    swapNotesList.Add(notes);
                }
                swapNotesGroupList.Add(notesGroup);
            }
            NotesGroupList = swapNotesGroupList;
        }
        #endregion
    }
}
