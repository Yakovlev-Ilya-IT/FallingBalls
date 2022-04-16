using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreSaver
{
    public bool TrySaveMaxScore(int scoreToSave)
    {
        if (GetSavedScore() < scoreToSave)
        {
            SaveScore(scoreToSave);
            return true;
        }
        return false;
    }

    private void SaveScore(int scoreToSave)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/SavedData.dat");
        binaryFormatter.Serialize(file, scoreToSave);
        file.Close();
    }

    public int GetSavedScore()
    {
        if (File.Exists(Application.persistentDataPath
          + "/SavedData.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath
          + "/SavedData.dat", FileMode.Open);
            int savedScore = (int)binaryFormatter.Deserialize(file);
            file.Close();
            return savedScore;
        }

        else return 0;
    }
}