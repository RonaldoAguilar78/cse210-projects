using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the input text into an array of strings, then create Word objects
        string[] splitWords = text.Split(' ');
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHiddenThisRound = 0;

        // Loop until we hide the requested number of words OR the scripture is fully hidden
        while (wordsHiddenThisRound < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);

            // Stretch challenge: Only hide the word if it isn't already hidden
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHiddenThisRound++;
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
        
        return $"{_reference.GetDisplayText()} {scriptureText.TrimEnd()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false; // Found at least one visible word
            }
        }
        return true; // All words are hidden
    }
}