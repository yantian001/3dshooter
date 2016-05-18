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
    public class GDETaskInfoData : IGDEData
    {
        private static string PlayerHPKey = "PlayerHP";
		private int _PlayerHP;
        public int PlayerHP
        {
            get { return _PlayerHP; }
            set {
                if (_PlayerHP != value)
                {
                    _PlayerHP = value;
                    GDEDataManager.SetInt(_key+"_"+PlayerHPKey, _PlayerHP);
                }
            }
        }

        private static string TotalTimeKey = "TotalTime";
		private int _TotalTime;
        public int TotalTime
        {
            get { return _TotalTime; }
            set {
                if (_TotalTime != value)
                {
                    _TotalTime = value;
                    GDEDataManager.SetInt(_key+"_"+TotalTimeKey, _TotalTime);
                }
            }
        }

        private static string WaveIntervalKey = "WaveInterval";
		private float _WaveInterval;
        public float WaveInterval
        {
            get { return _WaveInterval; }
            set {
                if (_WaveInterval != value)
                {
                    _WaveInterval = value;
                    GDEDataManager.SetFloat(_key+"_"+WaveIntervalKey, _WaveInterval);
                }
            }
        }

        private static string WavesKey = "Waves";
		public List<GDEWaveData>      Waves;
		public void Set_Waves()
        {
	        GDEDataManager.SetCustomList(_key+"_"+WavesKey, Waves);
		}
		

        public GDETaskInfoData()
		{
			_key = string.Empty;
		}

		public GDETaskInfoData(string key)
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
                dict.TryGetInt(PlayerHPKey, out _PlayerHP);
                dict.TryGetInt(TotalTimeKey, out _TotalTime);
                dict.TryGetFloat(WaveIntervalKey, out _WaveInterval);

                dict.TryGetCustomList(WavesKey, out Waves);
                LoadFromSavedData(dataKey);
			}
		}

        public override void LoadFromSavedData(string dataKey)
		{
			_key = dataKey;
			
            _PlayerHP = GDEDataManager.GetInt(_key+"_"+PlayerHPKey, _PlayerHP);
            _TotalTime = GDEDataManager.GetInt(_key+"_"+TotalTimeKey, _TotalTime);
            _WaveInterval = GDEDataManager.GetFloat(_key+"_"+WaveIntervalKey, _WaveInterval);

            Waves = GDEDataManager.GetCustomList(_key+"_"+WavesKey, Waves);
         }

        public void Reset_PlayerHP()
        {
            GDEDataManager.ResetToDefault(_key, PlayerHPKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(PlayerHPKey, out _PlayerHP);
        }

        public void Reset_TotalTime()
        {
            GDEDataManager.ResetToDefault(_key, TotalTimeKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(TotalTimeKey, out _TotalTime);
        }

        public void Reset_WaveInterval()
        {
            GDEDataManager.ResetToDefault(_key, WaveIntervalKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(WaveIntervalKey, out _WaveInterval);
        }

        public void Reset_Waves()
		{
			GDEDataManager.ResetToDefault(_key, WavesKey);

			Dictionary<string, object> dict;
			GDEDataManager.Get(_key, out dict);

			dict.TryGetCustomList(WavesKey, out Waves);
			Waves = GDEDataManager.GetCustomList(_key+"_"+WavesKey, Waves);

			Waves.ForEach(x => x.ResetAll());
		}

        public void ResetAll()
        {
            GDEDataManager.ResetToDefault(_key, WavesKey);
            GDEDataManager.ResetToDefault(_key, PlayerHPKey);
            GDEDataManager.ResetToDefault(_key, TotalTimeKey);
            GDEDataManager.ResetToDefault(_key, WaveIntervalKey);

            Reset_Waves();

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}
