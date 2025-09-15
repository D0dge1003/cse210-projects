using System;

public class Scripture
{
    public Reference _reference;
    public List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] wordsArray = text.Split(' ');

        foreach (string wordText in wordsArray)
        {
            _words.Add(new Word(wordText));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        if (IsCompletelyHidden())
        {
            return;
        }

        Random random = new Random();

        while (numberToHide > 0)
        {
            int index = random.Next(0, _words.Count);
            Word wordToHide = _words[index];

            if (!wordToHide.IsHidden())
            {
                wordToHide.Hide();
                numberToHide--;
            }
        }

    }
    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        scriptureText = scriptureText.Trim();

        return $"{_reference.GetDisplayText()} {scriptureText}";
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public void ShowRandomWord()
    {
        List<Word> hiddenWords = _words.FindAll(word => word.IsHidden());

        if (hiddenWords.Count > 0)
        {
            Random random = new Random();
            int index = random.Next(0, hiddenWords.Count);
            hiddenWords[index].Show();
        }
    }
}