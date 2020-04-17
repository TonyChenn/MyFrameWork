using NextFramework.ResKit;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace NextFramework
{
    public class UIFrameworkTools
    {
        /// <summary>
        /// 规范相对路径：末尾不带"\",开头带
        /// </summary>
        public static string UIFrameworkRoot = Application.dataPath + "/Scripts/UIFrameWork";
        public static string UIPanelsFolderPath = Application.dataPath + "/Resources/Panel";
        public static string UIPanelEnumPath = Application.dataPath + "/Scripts";

        static StringBuilder builder = new StringBuilder();

        [MenuItem("UIFramework/GeneratePanel")]
	    static void Generate()
        {
            string path = FilePathMgr.AssetRoot;
            if (!Directory.Exists(FilePathMgr.AssetRoot))
                Directory.CreateDirectory(FilePathMgr.AssetRoot);

            PanelsDataObject obj = AssetHelper.Singlton.CreateAsset<PanelsDataObject>(FilePathMgr.AssetRoot + FilePathMgr.PanelDataName);

            builder.Remove(0, builder.Length);

            var dict = GetPanelList(UIPanelsFolderPath);
            foreach (var item in dict)
            {
                obj.panelList.Add(new Panel(item.Key, item.Value));
                builder.Append("\n\t\t");
                builder.Append(item.Key);
                builder.Append(",");
            }
            AssetDatabase.Refresh();
            string str_enum = EnumTemplete.Replace("{ENUM}", builder.ToString());
            FileUtils.WriteFile(UIPanelEnumPath + "/UIType.cs", str_enum);
        }

        /// <summary>
        /// 获取所有UI面板信息
        /// </summary>
        static Dictionary<string, string> GetPanelList(string panelsPrefabPath)
        {
            Dictionary<string, string> panelDict = new Dictionary<string, string>();
            DirectoryInfo fileInfos = new DirectoryInfo(panelsPrefabPath);
            foreach (var file in fileInfos.GetFiles("*.prefab"))
            {
                string _Name = Path.GetFileNameWithoutExtension(panelsPrefabPath + "/" + file.Name);
                string _Path = "Panel/" + _Name;
                panelDict[_Name] = _Path;
            }
            return panelDict;
        }

        /// <summary>
        /// 枚举模板字符串
        /// </summary>
        static string EnumTemplete = @"namespace NextFramework.UI
{
	public enum UIType
	{
		None,{ENUM}
	}
}";
    }
}

