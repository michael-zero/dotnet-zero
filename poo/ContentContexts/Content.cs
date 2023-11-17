namespace Zero.ContentContext {
    public abstract class Content : SharedContext.Base
    {
        public Content(string title, string url)
        {
            Title = title; 
            Url = url;
        }
        public string Title { get; set; }
        public string Url { get; set; }
        
    }
}