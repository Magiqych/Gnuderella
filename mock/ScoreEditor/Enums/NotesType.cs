namespace ScoreEditor.Enums
{
    /// <summary>
    /// ノーツのタイプを表す列挙体
    /// </summary>
    public class NotesType : Enumeration
    {
        /// <summary>
        /// シングルノーツ
        /// </summary>
        public static NotesType Single = new(1, nameof(Single));
        /// <summary>
        /// ロングノーツ
        /// </summary>
        public static NotesType Long = new(2, nameof(Long));
        /// <summary>
        /// 右フリックノーツ
        /// </summary>
        public static NotesType Flick_Riught = new(3, nameof(Flick_Riught));
        /// <summary>
        /// 左フリックノーツ
        /// </summary>
        public static NotesType Flick_Left = new(4, nameof(Flick_Left));
        /// <summary>
        /// 上フリックノーツ
        /// </summary>
        public static NotesType Flick_Up = new(5, nameof(Flick_Up));
        /// <summary>
        /// 下フリックノーツ
        /// </summary>
        public static NotesType Flick_Down = new(6, nameof(Flick_Down));
        /// <summary>
        /// スライドノーツ
        /// </summary> 
        public static NotesType Slide = new(7, nameof(Slide));

        public NotesType(int id, string name) : base(id, name)
        {
        }
    }
}