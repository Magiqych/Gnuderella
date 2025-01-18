namespace ScoreEditor.Enums
{
    /// <summary>
    /// ノーツグループのタイプ
    /// </summary>
    public class NotesGroupType : Enumeration
    {
        /// <summary>
        /// グループ化されていない
        /// </summary>
        public static NotesGroupType NotGrouped = new(1, nameof(NotGrouped));
        /// <summary>
        /// グループ化されている
        /// </summary>
        public static NotesGroupType Grouped = new(2, nameof(Grouped));

        public NotesGroupType(int id, string name): base(id, name)
        {
        }
    }
}
