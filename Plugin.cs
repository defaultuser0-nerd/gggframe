﻿using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace AssetBundleTemplate
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
	public static Plugin instance;
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;
        public static string parentName = "ggg";
        void Start()
	{
            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
	}
	void OnGameInitialized()
	{
			instance = this;
            bundle = LoadAssetBundle("ggg.ggg");
            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>(parentName));
            assetBundleParent.transform.position = new Vector3(-67.2225f, 11.575f, -82.6090f);
        }
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
