namespace Domain;

public class Word
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Meaning { get; private set; } = null!;

    private Word() { }

    public Word(string name, string meaning)
    {
        ValidateName(name);
        ValidateMeaning(meaning);

        Name = name;
        Meaning = meaning;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void UpdateMeaning(string meaning)
    {
        ValidateMeaning(meaning);
        Meaning = meaning;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la palabra no puede estar vacío.");

        if (name.Length > 100)
            throw new ArgumentException("El nombre de la palabra no puede exceder los 100 caracteres.");
    }

    private static void ValidateMeaning(string meaning)
    {
        if (string.IsNullOrWhiteSpace(meaning))
            throw new ArgumentException("El significado de la palabra no puede estar vacío.");

        if (meaning.Length > 500)
            throw new ArgumentException("El significado no puede exceder los 500 caracteres.");
    }
}
