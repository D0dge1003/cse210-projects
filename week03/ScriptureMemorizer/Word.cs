using System;

public class Word
{
    public string _text;
    public bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false; //method modified to show the user hints
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (IsHidden())
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}