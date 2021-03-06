// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Game Data Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;

using GameDataEditor;

namespace GameDataEditor
{
    public class GDEEnemyAttrData : IGDEData
    {
        private static string IDKey = "ID";
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    GDEDataManager.SetInt(_key + "_" + IDKey, _ID);
                }
            }
        }

        private static string LevelKey = "Level";
        private int _Level;
        public int Level
        {
            get { return _Level; }
            set
            {
                if (_Level != value)
                {
                    _Level = value;
                    GDEDataManager.SetInt(_key + "_" + LevelKey, _Level);
                }
            }
        }

        private static string HPKey = "HP";
        private int _HP;
        public int HP
        {
            get { return _HP; }
            set
            {
                if (_HP != value)
                {
                    _HP = value;
                    GDEDataManager.SetInt(_key + "_" + HPKey, _HP);
                }
            }
        }

        private static string PowerKey = "Power";
        private int _Power;
        public int Power
        {
            get { return _Power; }
            set
            {
                if (_Power != value)
                {
                    _Power = value;
                    GDEDataManager.SetInt(_key + "_" + PowerKey, _Power);
                }
            }
        }

        private static string ClipKey = "Clip";
        private int _Clip;
        public int Clip
        {
            get { return _Clip; }
            set
            {
                if (_Clip != value)
                {
                    _Clip = value;
                    GDEDataManager.SetInt(_key + "_" + ClipKey, _Clip);
                }
            }
        }

        private static string FireRateKey = "FireRate";
        private float _FireRate;
        public float FireRate
        {
            get { return 1f / _FireRate; }
            set
            {
                if (_FireRate != value)
                {
                    _FireRate = value;
                    GDEDataManager.SetFloat(_key + "_" + FireRateKey, _FireRate);
                }
            }
        }

        private static string AvoidRateKey = "AvoidRate";
        private float _AvoidRate;
        public float AvoidRate
        {
            get { return _AvoidRate; }
            set
            {
                if (_AvoidRate != value)
                {
                    _AvoidRate = value;
                    GDEDataManager.SetFloat(_key + "_" + AvoidRateKey, _AvoidRate);
                }
            }
        }

        private static string HitRateKey = "HitRate";
        private float _HitRate;
        public float HitRate
        {
            get { return _HitRate; }
            set
            {
                if (_HitRate != value)
                {
                    _HitRate = value;
                    GDEDataManager.SetFloat(_key + "_" + HitRateKey, _HitRate);
                }
            }
        }

        private static string NameKey = "Name";
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    GDEDataManager.SetString(_key + "_" + NameKey, _Name);
                }
            }
        }

        public GDEEnemyAttrData()
        {
            _key = string.Empty;
        }

        public GDEEnemyAttrData(string key)
        {
            _key = key;
        }

        public override void LoadFromDict(string dataKey, Dictionary<string, object> dict)
        {
            _key = dataKey;

            if (dict == null)
                LoadFromSavedData(dataKey);
            else
            {
                dict.TryGetInt(IDKey, out _ID);
                dict.TryGetInt(LevelKey, out _Level);
                dict.TryGetInt(HPKey, out _HP);
                dict.TryGetInt(PowerKey, out _Power);
                dict.TryGetInt(ClipKey, out _Clip);
                dict.TryGetFloat(FireRateKey, out _FireRate);
                dict.TryGetFloat(AvoidRateKey, out _AvoidRate);
                dict.TryGetFloat(HitRateKey, out _HitRate);
                dict.TryGetString(NameKey, out _Name);
                LoadFromSavedData(dataKey);
            }
        }

        public override void LoadFromSavedData(string dataKey)
        {
            _key = dataKey;

            _ID = GDEDataManager.GetInt(_key + "_" + IDKey, _ID);
            _Level = GDEDataManager.GetInt(_key + "_" + LevelKey, _Level);
            _HP = GDEDataManager.GetInt(_key + "_" + HPKey, _HP);
            _Power = GDEDataManager.GetInt(_key + "_" + PowerKey, _Power);
            _Clip = GDEDataManager.GetInt(_key + "_" + ClipKey, _Clip);
            _FireRate = GDEDataManager.GetFloat(_key + "_" + FireRateKey, _FireRate);
            _AvoidRate = GDEDataManager.GetFloat(_key + "_" + AvoidRateKey, _AvoidRate);
            _HitRate = GDEDataManager.GetFloat(_key + "_" + HitRateKey, _HitRate);
            _Name = GDEDataManager.GetString(_key + "_" + NameKey, _Name);
        }

        public void Reset_ID()
        {
            GDEDataManager.ResetToDefault(_key, IDKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(IDKey, out _ID);
        }

        public void Reset_Level()
        {
            GDEDataManager.ResetToDefault(_key, LevelKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(LevelKey, out _Level);
        }

        public void Reset_HP()
        {
            GDEDataManager.ResetToDefault(_key, HPKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(HPKey, out _HP);
        }

        public void Reset_Power()
        {
            GDEDataManager.ResetToDefault(_key, PowerKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(PowerKey, out _Power);
        }

        public void Reset_Clip()
        {
            GDEDataManager.ResetToDefault(_key, ClipKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(ClipKey, out _Clip);
        }

        public void Reset_FireRate()
        {
            GDEDataManager.ResetToDefault(_key, FireRateKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(FireRateKey, out _FireRate);
        }

        public void Reset_AvoidRate()
        {
            GDEDataManager.ResetToDefault(_key, AvoidRateKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(AvoidRateKey, out _AvoidRate);
        }

        public void Reset_HitRate()
        {
            GDEDataManager.ResetToDefault(_key, HitRateKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(HitRateKey, out _HitRate);
        }

        public void Reset_Name()
        {
            GDEDataManager.ResetToDefault(_key, NameKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetString(NameKey, out _Name);
        }

        public void ResetAll()
        {
            GDEDataManager.ResetToDefault(_key, IDKey);
            GDEDataManager.ResetToDefault(_key, LevelKey);
            GDEDataManager.ResetToDefault(_key, HPKey);
            GDEDataManager.ResetToDefault(_key, PowerKey);
            GDEDataManager.ResetToDefault(_key, ClipKey);
            GDEDataManager.ResetToDefault(_key, FireRateKey);
            GDEDataManager.ResetToDefault(_key, AvoidRateKey);
            GDEDataManager.ResetToDefault(_key, HitRateKey);
            GDEDataManager.ResetToDefault(_key, NameKey);


            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}
