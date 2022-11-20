# Kogane Backup Project Settings Scope

ProjectSettings.asset のバックアップと復元を行うクラス

## 使用例

```cs
using System.Linq;
using Kogane;
using UnityEditor;
using UnityEngine;

public static class Example
{
    [MenuItem( "Tools/Hoge" )]
    public static void Hoge()
    {
        const BuildTargetGroup buildTargetGroup = BuildTargetGroup.Standalone;

        var options = new BuildPlayerOptions
        {
            scenes           = EditorBuildSettings.scenes.Select( x => x.path ).ToArray(),
            locationPathName = "Build/Game.exe",
            targetGroup      = buildTargetGroup,
            target           = BuildTarget.StandaloneWindows64,
            options          = BuildOptions.AutoRunPlayer,
        };

        // このスコープ内で変更された ProjectSettings.asset の内容を
        // スコープを抜ける時に元に戻します
        using ( new BackupProjectSettingsScope() )
        {
            PlayerSettings.SetScriptingBackend( buildTargetGroup, ScriptingImplementation.IL2CPP );

            BuildPipeline.BuildPlayer( options );
        }
    }
}
```