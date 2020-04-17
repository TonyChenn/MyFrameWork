/**
#########################
#                       
# Author:               
# Date:4/3/2020 12:33:04 PM         
# 关于游戏框架中用到的1. 存放资源路径，读取资源路径，统一配置在该脚本中          
#
#########################
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FilePathMgr{

    /// <summary>
    /// StreammingAsset Path
    /// </summary>
    public static string StreammingAssetRoot = Application.dataPath + "/StreamingAssets";

    /// <summary>
    /// Asset
    /// </summary>
    public static string AssetRoot = "Assets/Asset";
    public static string PanelDataName = "/PanelData.asset";



    /// <summary>
    /// NextFramework Root Path
    /// </summary>
    public static string FrameWorkRoot = Application.dataPath + "/NextFramework";

    /// <summary>
    /// UIKit Path
    /// </summary>
    public static string UIKitRoot = FrameWorkRoot + "/UIKit";


    /// <summary>
    /// ResKit Path
    /// </summary>
    public static string ResKitRoot = FrameWorkRoot + "/ResKit";
}
