﻿namespace CWebStore.Domain.Commands;

public class CommandResult : Notifiable<Notification>, ICommandResult
{
    public CommandResult() { }

    public CommandResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    
    public CommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public CommandResult(bool success, string message, object data, Notifiable<Notification> notifications)
    {
        Success = success;
        Message = message;
        Data = data;
        Errors = new Dictionary<string, string>();
        foreach (var notification in notifications.Notifications)
        {
            Errors.Keys.Append(notification.Key);
            Errors.Values.Append(notification.Message);
        }
        
    }

    public bool Success { get; set; }

    public string Message { get; set; }

    public object Data { get; set; }

    public Dictionary<string, string> Errors { get; set; }
}