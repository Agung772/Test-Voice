using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class TestVoice : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    bool isRecognizing;

    void Start()
    {
        // Inisialisasi keyword recognizer
        keywordRecognizer = new KeywordRecognizer(new string[] { "start game" });
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
    }

    void Update()
    {
        // Memulai pengenalan suara ketika tombol ditekan
        if (Input.GetKeyDown(KeyCode.Space) && !isRecognizing)
        {
            keywordRecognizer.Start();
            isRecognizing = true;
        }

        // Menghentikan pengenalan suara ketika tombol dilepas
        if (Input.GetKeyUp(KeyCode.Space) && isRecognizing)
        {
            keywordRecognizer.Stop();
            isRecognizing = false;
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        // Aksi yang dilakukan setelah keyword terdeteksi
        Debug.Log("Keyword detected: " + args.text);
    }
}
