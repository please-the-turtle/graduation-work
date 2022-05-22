namespace BuisnessLogicLayer.Projects
{
    public class NewProject
    {
        private string _name = null!;

        public NewProject(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }

        public string Name 
        { 
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
                }   
                
                _name = value;
            } 
        }

        public string? Description { get; private set; }
    }
}