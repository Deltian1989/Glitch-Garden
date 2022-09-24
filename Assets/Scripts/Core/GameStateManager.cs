using UnityEngine;
using UnityEngine.Audio;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        var masterVolume = PlayerPrefsController.GetMasterVolume();

        audioMixer.SetFloat(OptionsManager.VOLUME_PARAM_NAME, masterVolume);

    }
}
