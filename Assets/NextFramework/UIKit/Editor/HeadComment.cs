using System.IO;
using UnityEngine;

namespace Modules.UI
{
    public class NewBehaviourScript : UnityEditor.AssetModificationProcessor
    {
        /// <summary>
        /// 此函数在asset被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和import之前被调用
        /// </summary>
        /// <param name="newFileMeta">newfilemeta 是由创建文件的path加上.meta组成的</param>
        public static void OnWillCreateAsset(string newFileMeta)
        {
            string newFilePath = newFileMeta.Replace(".meta", "");
            string fileExt = Path.GetExtension(newFilePath);
            if (fileExt != ".cs")
            {
                return;
            }
            //注意，Application.datapath会根据使用平台不同而不同
            string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
            string scriptContent = File.ReadAllText(realPath);

            string str_head_commont = @"/**
#########################
#
# Author:{%NAME%}
# Date:{%TIME%}
#
#########################
*/
";
            str_head_commont = str_head_commont.Replace("{%TIME%}", System.DateTime.Now.ToString());
            str_head_commont = str_head_commont.Replace("{%NAME%}", System.Environment.UserName);
            File.WriteAllText(realPath, str_head_commont + scriptContent);
        }
    }
}

