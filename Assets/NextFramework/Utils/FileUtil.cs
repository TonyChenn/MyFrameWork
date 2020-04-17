using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace NextFramework
{ 
    public class FileUtils
    {
        //public static void GeneratePanelEnumFile(string prefabPath, string jsonPath)
        //{
        //    DirectoryInfo fileInfos = new DirectoryInfo(prefabPath);

        //    StringBuilder builder = new StringBuilder();
        //    builder.AppendLine("namespace Modules.UI");
        //    builder.AppendLine("{");
        //    builder.AppendLine("\tpublic enum UIType");
        //    builder.AppendLine("\t{");
        //    builder.AppendLine("\t\tNone,");
        //    foreach (var file in fileInfos.GetFiles("*.prefab"))
        //    {
        //        string fileName = file.Name.Replace(".prefab", "");
        //        builder.Append("\t\t" + fileName);
        //        builder.Append(",\n");
        //    }
        //    builder.AppendLine("\t}");
        //    builder.AppendLine("}");

        //    string str_path = jsonPath+ "/UIType.cs";
        //    WriteFile(str_path, builder.ToString());

        //    Debug.Log("Panel Enum 生成成功");
        //}

        public static string ReadFile(string path)
        {
            string json = "";
            if (File.Exists(path))
                json = File.ReadAllText(path);
            else
                Debug.LogError("文件路径不存在："+path);
            return json;
        }
        public static void WriteFile(string path,string content)
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();
            File.WriteAllText(path, content);
        }
    }
}

