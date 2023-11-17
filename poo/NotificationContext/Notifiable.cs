namespace Zero.NotificationContext {
  public abstract class Notifiable {
    public List<Notification> Notifications {get; set;}
    public void AddNotification (Notification notification){
      Notifications.Add(notification);
    }

    public Notifiable()
    {
      Notifications = new List<Notification>(); 
    }

    public void AddNotifications (IEnumerable<Notification> notifications){
     Notifications.AddRange(notifications);
    }
    public void Remove (Notification notification){
      Notifications.Remove(notification);
    }

    public bool IsInvalid => Notifications.Any();

  }
}