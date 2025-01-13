using UnityEngine;

namespace App.Managers
{
    public static class PlayerPrefsManager
    {
        public static void SavePlayerData(Data.PlayerData data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString("PlayerData", json);
            PlayerPrefs.Save();
        }

        public static Data.PlayerData LoadPlayerData()
        {
            var json = PlayerPrefs.GetString("PlayerData", "{}");
            return JsonUtility.FromJson<Data.PlayerData>(json);
        }
    }
}