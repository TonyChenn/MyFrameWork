/**
#########################
#
# Author:uniu
# Date:4/17/2020 1:18:38 PM
#
#########################
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NextFramework.ResKit
{
    public class AssetHelper : NormalSingleton<AssetHelper> {
        private AssetHelper() { }

        public T CreateAsset<T>(string path) where T : ScriptableObject
        {
            T asset = AssetDatabase.LoadAssetAtPath<T>(path);
            if(asset==null)
            {
                asset = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(asset, path);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            T obj = AssetDatabase.LoadAssetAtPath<T>(path);

            if (!obj) Debug.LogError("Generate PanelData,but still can't find it");

            return obj;
        }

        public T LoadAsset<T>(string path) where T : ScriptableObject
        {
            T asset = AssetDatabase.LoadAssetAtPath<T>(path);
            if (!asset) Debug.LogError("can't find:" + path);
            return asset;
        }
    }
}

