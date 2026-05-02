namespace Domain;

public class Word
{
    public int Id { get; internal set; }
    public string Name { get; internal set; } = null!;

    private Word() { }

    public Word(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Word(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la palabra no puede estar vacío.");

        if (name.Length > 100)
            throw new ArgumentException("El nombre de la palabra no puede exceder los 100 caracteres.");
    }
}
