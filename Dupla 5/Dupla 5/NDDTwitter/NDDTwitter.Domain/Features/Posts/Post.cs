using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Infra;
using System;

public class Post
{
    public long Id { get; set; }
    public string Message { get; set; }
    public DateTime PostDate { get; set; }
    public string DisplayPostDate
    {
        get { return PostDate.DateTimeToString(); }
        private set { PostDate.DateTimeToString(); }
    }

    public Post()
	{
	}

    public void Validate()
    {
        if (String.IsNullOrEmpty(Message))
            throw new PostMessageIsNullOrEmptyException();

        if (Message.Length > 140)
            throw new PostMessageOverFlowException();

        if (PostDate > DateTime.Now)
            throw new PostDateBeAfterTodayException();
    }
}
