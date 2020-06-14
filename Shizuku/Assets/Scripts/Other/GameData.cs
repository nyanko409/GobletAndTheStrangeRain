using UnityEngine;

public class GameData : MonoBehaviour
{
    public Stage[] stageData;

    public void ResetGameData()
    {
        for(int i = 1; i < stageData.Length; ++i)
        {
            stageData[i].isLocked = true;
        }
    }

    public bool HasGameData()
    {
        return stageData[1].isLocked ? false : true;
    }

    public void UnlockStage(int stage)
    {
        if (stage > stageData.Length)
            return;

        foreach(Stage st in stageData)
        {
            if(st.stage == stage)
            {
                st.isLocked = false;
                return;
            }
        }
    }
}
