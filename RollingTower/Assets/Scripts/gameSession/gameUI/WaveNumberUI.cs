using TMPro;
using UnityEngine;

public class WaveNumberUI : MonoBehaviour {


    [SerializeField]
    private TextMeshProUGUI _waveNumberText;


    public void ChangeWaveNumber(int waveNumber) {
        _waveNumberText.text = $"Wave {waveNumber}";
    }
}