using System;
using System.IO;

namespace Kogane
{
    /// <summary>
    /// ProjectSettings.asset のバックアップと復元を行うスコープ
    /// </summary>
    internal sealed class BackupProjectSettingsScope : IDisposable
    {
        //================================================================================
        // 定数
        //================================================================================
        private const string PATH        = "ProjectSettings/ProjectSettings.asset";
        private const string BACKUP_PATH = "Temp/ProjectSettings.asset.backup";

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BackupProjectSettingsScope()
        {
            File.Copy( PATH, BACKUP_PATH, true );
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            if ( !File.Exists( BACKUP_PATH ) ) return;

            if ( File.Exists( PATH ) )
            {
                File.Delete( PATH );
            }

            File.Move( BACKUP_PATH, PATH );
        }
    }
}