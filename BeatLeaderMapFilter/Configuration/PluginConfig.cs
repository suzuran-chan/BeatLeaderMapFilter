using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BeatLeaderMapFilter.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual int IntValue { get; set; } = 42; // BSIPAが値の変更を検出し、自動的に設定を保存したい場合は、'virtual'でなければなりません

        /// <summary>
        /// これは、BSIPAが設定ファイルを読み込むたびに（ファイルの変更が検出されたときを含めて）呼び出されます
        /// </summary>
        public virtual void OnReload()
        {
            // 設定ファイルを読み込んだ後の処理を行う
        }

        /// <summary>
        /// これを呼び出すと、BSIPAに設定ファイルの更新を強制します。 これは、ファイルが変更されたことをBSIPAが検出した場合にも呼び出されます。
        /// </summary>
        public virtual void Changed()
        {
            // 設定が変更されたときに何かをします
        }

        /// <summary>
        /// これを呼び出して、BSIPAに値を<paramref name ="other"/>からこの構成にコピーさせます。
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // このインスタンスのメンバーは他から移入されました
        }

        public string Search { get; set; } = string.Empty;
        public string Type { get; set; } = "Ranked";
        public string Category { get; set; } = "None";
        public bool Stars { get; set; } = false;
        public float StarsFrom { get; set; } = 0;
        public float StarsTo { get; set; } = 0;
        public bool AccRating { get; set; } = false;
        public float AccRatingFrom { get; set; } = 0;
        public float AccRatingTo { get; set; } = 0;
        public bool PassRating { get; set; } = false;
        public float PassRatingFrom { get; set; } = 0;
        public float PassRatingTo { get; set; } = 0;
        public bool TechRating { get; set; } = false;
        public float TechRatingFrom { get; set; } = 0;
        public float TechRatingTo { get; set; } = 0;
        public int MapsCount { get; set; } = 100;
        public string FolderName { get; set; } = "BeatLeaderMapFilter";
    }
}