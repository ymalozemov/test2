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

        public static void InitPlayerData()
        {
            Data.PlayerData playerData = new Data.PlayerData
            {
                playerName = "Игрок1",
                playerLevel = 1,
                shieldLevel = 1,
                shieldThickness = 1
            };

            var json = JsonUtility.ToJson(playerData);
            PlayerPrefs.SetString("PlayerData", json);
            PlayerPrefs.Save();
        }
    }
}