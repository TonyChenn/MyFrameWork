/**
#########################
#
# Author:uniu
# Date:4/17/2020 10:58:55 AM
#
#########################
*/
using UnityEngine;
using System.Collections;
using System;
using NextFramework.Messenger;

namespace NextFramework.UI
{
    public class UIDialogMgr
    {
        public static string Str_ShowUIDialog = "Str_ShowUIDialog";
        public static string Str_ShowWait = "Str_ShowWait";
        public static string Str_ShowToast = "Str_ShowToast";

        #region Message Tips
        public static void ShowDialog(string content,bool mask)
        {
            ShowDialog("提示", content, mask);
        }
        public static void ShowDialog(string title,string content,bool mask)
        {
            ShowDialog(title, content, null, mask);
        }
        public static void ShowDialog(string title,string content,Action ok,bool mask)
        {
            ShowDialog(title, content, ok, null, mask);
        }

        public static void ShowDialog(string title, string content, Action ok,Action cancel, bool mask)
        {
            ShowDialog(title, content, ok, cancel, null, mask);
        }
        public static void ShowDialog(string title,string content,Action ok,Action cancel,Action close, bool mask)
        {
            Messenger<string, string, Action, Action, Action, bool>.Broadcast(Str_ShowUIDialog, title, content, ok, cancel, close, mask);
        }
        #endregion


        #region MessageLocading
        public static void ShowWait(bool isShow)
        {
            if (isShow)
                ShowWait(isShow, "加载中...");
            else
                ShowWait(isShow, "");
        }
        public static void ShowWait(bool isShow,string msg)
        {
            Messenger<bool,string>.Broadcast(Str_ShowWait, isShow, msg);
        }

        public static void ShowToast(string msg)
        {
            ShowToast(msg, 2f);
        }
        public static void ShowToast(string msg,float duration)
        {
            Messenger<string, float>.Broadcast(Str_ShowToast, msg, duration);
        }
        #endregion
    }
}

