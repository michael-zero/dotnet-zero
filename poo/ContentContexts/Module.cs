namespace Zero.ContentContext {
      public class Module : SharedContext.Base
    {

        public Module()
        {
         Lectures = new List<Lecture>();   
        }
        public int Order { get; set; }
        public string Title  { get; set; }
        public IList<Lecture> Lectures { get; set; }
    }

}