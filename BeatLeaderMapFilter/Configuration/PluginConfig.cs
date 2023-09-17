using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using BeatLeaderMapFilter.UI;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BeatLeaderMapFilter.Configuration
{
    [IPA.Config.Stores.Attributes.NotifyPropertyChanges]
    public class PluginConfig : INotifyPropertyChanged, IDisposable
    {
        public event Action<PluginConfig> OnReloaded;
        public event Action<PluginConfig> ChangedEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        public static PluginConfig Instance { get; set; }
        //public virtual int IntValue { get; set; } = 42; // BSIPAが値の変更を検出し、自動的に設定を保存したい場合は、'virtual'でなければなりません

        public PluginConfig()
        {
            OnReloaded += OnReloadMethod;
            PropertyChanged += PropertyChangedMethod;
        }

        private void PropertyChangedMethod(object sender, PropertyChangedEventArgs e)
        {
            // Logger.log.Info($"{e.PropertyName} property changed");
            FilterView.Instance.SyncWithPluginConfig(e.PropertyName);
        }

        private void OnReloadMethod(PluginConfig pluginConfig)
        {
            // Logger.log.Info("Reload Method");
        }

        // IPAによって自動的に呼び出される
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// これは、BSIPAが設定ファイルを読み込むたびに（ファイルの変更が検出されたときを含めて）呼び出されます
        /// </summary>
        public virtual void OnReload()
        {
            // 設定ファイルを読み込んだ後の処理を行う
            this.OnReloaded?.Invoke(this);
        }

        /// <summary>
        /// これを呼び出すと、BSIPAに設定ファイルの更新を強制します。 これは、ファイルが変更されたことをBSIPAが検出した場合にも呼び出されます。
        /// </summary>
        public virtual void Changed()
        {
            // 設定が変更されたときに何かをします
            this.ChangedEvent?.Invoke(this);
        }

        /// <summary>
        /// これを呼び出して、BSIPAに値を<paramref name ="other"/>からこの構成にコピーさせます。
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // このインスタンスのメンバーは他から移入されました
        }

        public void Dispose()
        {
            OnReloaded -= OnReloadMethod;
            PropertyChanged -= PropertyChangedMethod;
        }

        public string Search { get; set; } = string.Empty;
        public string Type { get; set; } = "Ranked";
        public bool TypeChange { get; set; } = false;
        public string Category { get; set; } = "None";
        public bool Stars { get; set; } = false;
        public float StarsFrom { get; set; } = 0.00f;
        public float StarsTo { get; set; } = 0.00f;
        public bool AccRating { get; set; } = false;
        public float AccRatingFrom { get; set; } = 0.00f;
        public float AccRatingTo { get; set; } = 0.00f;
        public bool PassRating { get; set; } = false;
        public float PassRatingFrom { get; set; } = 0.00f;
        public float PassRatingTo { get; set; } = 0.00f;
        public bool TechRating { get; set; } = false;
        public float TechRatingFrom { get; set; } = 0.00f;
        public float TechRatingTo { get; set; } = 0.00f;
        public int MapsCount { get; set; } = 100;
        public string FolderName { get; set; } = "BeatLeaderMapFilter";
    }
}