using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject playerPrefabA;
    public GameObject playerPrefabB;
    public GameObject playerPrefabC;

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;

    private void Start()
    {
        buttonA.onClick.AddListener(() => SelectPlayer(playerPrefabA));
        buttonB.onClick.AddListener(() => SelectPlayer(playerPrefabB));
        buttonC.onClick.AddListener(() => SelectPlayer(playerPrefabC));
    }

    private void SelectPlayer(GameObject playerPrefab)
    {
        Debug.Log(playerPrefab.name);
        PlayerPrefs.SetString("SelectedPlayer", playerPrefab.name);
        SceneManager.LoadScene("PlayScene"); // º”‘ÿ”Œœ∑≥°æ∞
    }
}
