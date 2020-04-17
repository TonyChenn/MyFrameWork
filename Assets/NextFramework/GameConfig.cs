/**
#########################
#                       
# Author:tonychenn
# Date:4/16/2020 12:46:23 PM         
#                       
#########################
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NextFramework
{
    public class GameConfig : MonoBehaviour
    {
        [SerializeField] public bool UseLocalAsset = true;
        [SerializeField] public PackageType CurPackageType = PackageType.Dev;


        static GameConfig _instance=null;
        private void Start()
        {
            _instance = this;
        }
        public static GameConfig Singlton { get { return _instance; } }
    }

    public enum PackageType
    {
        Dev,QA,Release,
    }
}

