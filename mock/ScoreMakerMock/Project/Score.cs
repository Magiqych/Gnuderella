using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScoreMakerMock.Project
{
    /// <summary>
    /// 譜面を表すクラス
    /// </summary>
    internal class Score
    {
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
        public int LaneCount { get; set; }

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
        }

        public Score(int laneCount,
            double normalizedNotesSpeed,
            double notesSpeed)
        {
            NotesGroupList = new List<NotesGroup>();
            LaneCount = laneCount;
            NormalizedNotesSpeed = normalizedNotesSpeed;
            NotesSpeed = notesSpeed;
            NotesSpeedRatio = NotesSpeed / NormalizedNotesSpeed;
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
        }
    }

    internal class NotesGroup
    {
        /// <summary>
        /// ノーツグループはNotesのリストで構成される
        /// </summary>
        public List<Notes> NotesList { get; set; }

        public List<Notes>　CalcNotesTiming(double notesSpeedRatio)
        {
            List<Notes> notesList = new List<Notes>();
            foreach (var notes in NotesList)
            {
                Notes newNotes = new Notes();

                notesList.Add(newNotes);
            }
            return notesList;
        }

    }

    internal class Notes
    {
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
        /// ノーツ生成座標
        /// </summary>
        public Vector3 NormalizedSpawnPos { get; set; }
        /// <summary>
        /// ノーツ到達座標
        /// </summary>
        public Vector3 NormalizedDestPos { get; set; }

    }
}
