namespace BuisnessLogicLayer.Projects
{
    public class NewProject
    {
        public NewProject(string name, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Name = name;
            Description = description;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}