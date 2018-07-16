using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class PlayerMenuVoiceSystem : MonoBehaviour
{
    private SpeechRecognitionEngine speechEngine;
    public Text results;

    // Use this for initialization
    private void Start()
    {
        speechEngine = GetComponent<SpeechRecognitionEngine>();
        speechEngine.onPhraseRecognized += OnCommandReceived;
    }

    // Update is called once per frame
    private void Update()
    {
        speechEngine.Listen();
    }

    private void OnCommandReceived(PhraseRecognizedEventArgs args)
    {
        string word = args.text;
        results.text = string.Format("You said: <b>{0}</b>\nConfidence: {1}\nPhrase Duration: {2}",
            word,
            args.confidence,
            args.phraseDuration);
        print(results.text);
    }
}