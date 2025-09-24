using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _length; // Length in seconds
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void AddComment(string name, string text)
    {
        Comment newComment = new Comment(name, text);
        _comments.Add(newComment);
    }
}