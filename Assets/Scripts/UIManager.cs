using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMPro.TextMeshProUGUI _scoreText, _livesText;
    private Player _player;
    [SerializeField]
    void Start()
    {
        _scoreText.text = "Score	 : 0";
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player Object Not Created in UIManager.cs");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoins(int coins)
    {
        _scoreText.text = "Score	 : " + coins.ToString();
    }
    public void UpdateLives(int lives)
    {
        _livesText.text = "Lives	 : " + lives.ToString();
    }
}
