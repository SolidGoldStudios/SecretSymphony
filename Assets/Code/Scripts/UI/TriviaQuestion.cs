using System;

[Serializable]
public struct TriviaQuestion
{
    public string question;
    public string image;
    public string audio;
    public string correctAnswer;
    public string wrongAnswer1;
    public string wrongAnswer2;
    public string hint;
    public string followupFact;
}
